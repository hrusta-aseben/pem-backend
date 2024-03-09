using hakaton.Data;
using hakaton.VM_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hakaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditivniController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AuditivniController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public JsonResult DodajAuditivni(AuditivniAddVM dodaj)
        {
            var novi = new Auditivni
            {
                LekcijaId = dodaj.LekcijaId,
                LinkVidea = dodaj.VideoLink
            };
            _dbContext.Auditivni.Add(novi);
            _dbContext.SaveChanges();
            return new JsonResult(new { poruka = "SKRRR" });
        }
        [HttpGet]
        public JsonResult GetajAuditivne(int lekcijaID)
        {
            var lista=_dbContext.Auditivni.Where(x=>x.LekcijaId==lekcijaID).ToList();
            return new JsonResult(lista);   
        }
    }
}
