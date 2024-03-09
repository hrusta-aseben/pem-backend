using hakaton.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hakaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VizuelniController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public VizuelniController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public JsonResult DodajLekciju(VizuelniAddVm test)
        {
            var novi = new Vizuelni
            {
                Naziv = test.Naziv,
                LekcijaId = test.LekcijaId,
                LinkSlike = test.LinkSlike
            };
            _dbContext.Vizuelni.Add(novi);
            _dbContext.SaveChanges();
            return new JsonResult(new { poruka = "SKRRR" });
        }
        [HttpGet]
        public List<Vizuelni> GetVizualni(int lekcijaId)
        {
            var lista=_dbContext.Vizuelni.Where(x=>x.LekcijaId== lekcijaId).ToList();
            return lista;
        }
    }
}
