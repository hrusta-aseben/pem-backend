using hakaton.Data;
using hakaton.VM_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hakaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdgovorController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public OdgovorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public JsonResult DodajPitanje(OdgovorAddVM odgovor)
        {
            var novi = new Odgovor
            {
                Odgovori = odgovor.Odgovor,
                isTacan = odgovor.isTacan,
                PitanjeId = odgovor.PitanjeId
            };
            _dbContext.Odgovor.Add(novi);
            _dbContext.SaveChanges();
            return new JsonResult(new { poruka = "AAAAAAAa" });
        }
    }
}
