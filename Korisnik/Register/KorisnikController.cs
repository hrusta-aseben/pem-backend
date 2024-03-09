using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using hakaton.Data;
using hakaton.VM_s;
using hakaton.aaa;
namespace FIT_Api_Example.Controllers.Korisnik.Dodaj
{
    [ApiController]
    [Route("Korisnik/Register")]
    public class KorisnikRegisterEndpoint : ControllerBase
    {

      private readonly  ApplicationDbContext _applicationDbContext;
        public KorisnikRegisterEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public  async Task<KorisnikDodajResponse> Obradi([FromBody]KorisnikAddVM request)
        {
            if(request.Ime==string.Empty ||request.Prezime== string.Empty || request.username== string.Empty || request.sifra== string.Empty)
            {
                throw new Exception("Prazno polje");
            }
           
          
          bool postojiLiIsti=_applicationDbContext.Korisnici.Any(x=>x.username==request.username);
            if (postojiLiIsti)
            {
                throw new Exception("Ima isti mail rodjak");
            }
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(request.sifra, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string lozinka = Convert.ToBase64String(hashBytes);

            var korisnik = new Korisnici
            {
                Ime= request.Ime,
                Prezime= request.Prezime,
                username = request.username,
                Sifra= lozinka
            };
            var noviK = new AutentifikacijaToken
            {
                Korisnik = korisnik,
                vrijednost = GenerisiJwtToken.GenerisiToken(),
                vrijemeEvidentiranja = DateTime.Now,
                KorisnikID=korisnik.Id
            };
            _applicationDbContext.AutentifikacijaToken.Add(noviK);
            _applicationDbContext.Korisnici.Add(korisnik);
           await _applicationDbContext.SaveChangesAsync();
            return new KorisnikDodajResponse
            {
                Ime = request.Ime,
                Token = noviK.vrijednost.ToString()
            };
        }
    }
}
