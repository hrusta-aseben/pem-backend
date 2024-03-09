using hakaton.Data;
using hakaton.VM_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hakaton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LekcijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public LekcijaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public JsonResult DodajLekciju(LekcijaAddVM lekcija)
        {
            var predmet = _dbContext.Predmet.Where(x => x.Id == lekcija.PredmetId).FirstOrDefault();
            var nova = new Lekcija
            {
                Naziv = lekcija.Naziv,
                PredmetId = lekcija.PredmetId,
                Predmet=_dbContext.Predmet.Where(x=>x.Id==lekcija.PredmetId).FirstOrDefault()
            };
            _dbContext.Lekcija.Add(nova);
            _dbContext.SaveChanges();

            return new JsonResult(new { poruka = "AAAA" });
        }
        [HttpGet]
        public JsonResult GetLekcije(int predmetId)
        {
            var lista=_dbContext.Lekcija.Include(x=>x.Predmet).Where(x=>x.PredmetId== predmetId).ToList();
            return new JsonResult(new { lista });
        }
        [HttpPost]
        [Route("GetOdgovori")]
        public JsonResult Pitanjaaaa([FromBody] List<PitanjeOdgovor> pitanjeOdgovors)
        {
            int bodovi = 0;
            int tip1=0;
            int tip2=0;
            int tip3=0;
            foreach (var pO in pitanjeOdgovors)
            {
                bodovi += _dbContext.Odgovor.Where(x => x.Id == pO.OdgovorId).Select(x => x.Bodovi).FirstOrDefault();
                var odgovor = _dbContext.Odgovor.Where(x => x.Id == pO.OdgovorId).FirstOrDefault();
                var aaa = odgovor.Bodovi;
                if (aaa == 1)
                    tip1++;
                else if(aaa == 2) tip2++;
                else tip3++;
            }
            var korisnik = _dbContext.Korisnici.Where(x => x.Id == 2).FirstOrDefault();

            if (tip1 > tip2 && tip1 > tip3)
            {
                korisnik.TipId = 1;
            }
            else if (tip2 > tip1 && tip2 > tip3)
                korisnik.TipId = 2;
            else
                korisnik.TipId = 3;

            _dbContext.Update(korisnik);
            _dbContext.SaveChanges();

            return new JsonResult(new { bodovi});
        }
    }
}
