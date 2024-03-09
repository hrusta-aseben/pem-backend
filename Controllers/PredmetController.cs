using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using hakaton.Data;
namespace hakaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PredmetController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public JsonResult PredmetDodaj(string naziv)
        {
            var novi = new Predmet
            {
                Naziv = naziv
            };
            _applicationDbContext.Predmet.Add(novi);
            _applicationDbContext.SaveChanges();
            return new JsonResult(new { poruka="Uspjesno dodan novi predmet!" });
        }
        [HttpGet]
        public JsonResult GetPredmeti()
        {
            var lista = _applicationDbContext.Predmet.ToList();
            return new JsonResult(new { lista });
        }
    }
}
