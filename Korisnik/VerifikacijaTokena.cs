using hakaton.Data;
using Microsoft.AspNetCore.Mvc;
using hakaton.aaa;
using hakaton.Data;
namespace PlaninarskeAvantureBackend.Controllers.Korisnik
{
    [ApiController]
    public class VerifikacijaTokena : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly AuthService _authservice;
        public VerifikacijaTokena(ApplicationDbContext applicationDbContext, AuthService authservice)
        {
            _applicationDbContext = applicationDbContext;
            _authservice = authservice;
        }
        [HttpGet]
        [Route("Korisnik/Verifikacija")]
        public JsonResult Verifikacija()
        {
            var k = _authservice.GetInfo().autentifikacijaToken;
            if(k== null)
            {
                return new JsonResult(new { poruka = "Niste prijavljeni!" });
            }
            return new JsonResult(k.Korisnik);
        }
    }
}
