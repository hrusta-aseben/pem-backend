using hakaton.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hakaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestControllers : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public TestControllers(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        public JsonResult KreirajTest(int lekcijaID)
        {
            var novi = new Test
            {
                LekcijaId = lekcijaID
            };
            _dbcontext.Test.Add(novi);
            _dbcontext.SaveChanges();
            return new JsonResult(new { poruka="AAAAAAAAAa" });
        }
        [HttpGet]
        public JsonResult GetSve(int lekcijaID)
        {
         var lista=_dbcontext.Pitanje.Include(x=>x.Odgovori).Where(x => x.LekcijaId == lekcijaID).ToList();
            return new JsonResult(new { lista });
        }
        
        
    }
}
