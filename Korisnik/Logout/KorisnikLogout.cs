using hakaton.aaa;
using hakaton.Data;
using Microsoft.AspNetCore.Mvc;

namespace PlaninarskeAvantureBackend.Controllers.Korisnik.Logout
{
    public class KorisnikLogout : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly AuthService _authService;
        public KorisnikLogout(ApplicationDbContext applicationDbContext, AuthService authService)
        {
            _applicationDbContext= applicationDbContext;
            _authService= authService;
        }
        [HttpPost("logout")]
        public JsonResult Logout()
        {
            AutentifikacijaToken? autentifikacijaToken = _authService.GetInfo().autentifikacijaToken;
            if (autentifikacijaToken == null)
            {
                return new JsonResult(new { poruka = "Niste ulogovani" });
            }
            _applicationDbContext.AutentifikacijaToken.Remove(autentifikacijaToken);
            _applicationDbContext.SaveChanges();
            return new JsonResult(new { poruka = "Uspjesno ste se odjavili!" });
        }
    }

}