using hakaton.Data;
using hakaton.VM_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hakaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PitanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public PitanjeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public JsonResult DodajPitanje(PitanjeAddVM pitanje)
        {
            var novo = new Pitanje
            {
                Pitanjee = pitanje.Pitanje,
                LekcijaId = pitanje.LekcijaId
            };
            _dbContext.Pitanje.Add(novo);
            _dbContext.SaveChanges();
            return new JsonResult(new { poruka = "AAAAAAaa" });
        }
      
    }
}
