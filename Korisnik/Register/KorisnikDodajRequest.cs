using hakaton.Data;
namespace FIT_Api_Example.Controllers.Korisnik.Dodaj
{
    public class KorisnikDodajRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Lozinka { get; set; }
        public string PotvrdaLozinke { get; set; }
    }
}
