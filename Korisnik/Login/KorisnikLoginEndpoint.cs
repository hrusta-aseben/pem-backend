using hakaton.aaa;
using hakaton.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace FIT_Api_Example.Controllers.Korisnik.Login
{
    [ApiController]
    [Route("Korisnik/Login")]
    public class KorisnikLoginEndpoint 
    {
        private readonly ApplicationDbContext _applicationDbContext;
       public KorisnikLoginEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public  JsonResult Obradi([FromBody] KorisnikLoginRequest request)
        {
          var user=_applicationDbContext.Korisnici.Where(x=>x.username== request.username).FirstOrDefault();
            if (user == null)
            {
                return new JsonResult(new { poruka = "Unijeli ste pogresne podatke!" });
            }
            var sifra = user.Sifra;
            byte[] hashBytes = Convert.FromBase64String(sifra);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(request.Lozinka, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();
            var randomS = GenerisiJwtToken.GenerisiToken();
            var noviToken = new AutentifikacijaToken
            {
                vrijednost = randomS,
                Korisnik = user,
                vrijemeEvidentiranja = DateTime.Now
            };

            _applicationDbContext.AutentifikacijaToken.Add(noviToken);
            _applicationDbContext.SaveChanges();
            return new JsonResult(new { user, noviToken.vrijednost });
        }
    }
}
