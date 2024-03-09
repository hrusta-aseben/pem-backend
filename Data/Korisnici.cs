using System.ComponentModel.DataAnnotations.Schema;

namespace hakaton.Data
{
    public class Korisnici
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string username { get; set; }
        public string Sifra { get; set; }
        [ForeignKey(nameof(Tip))]
        public int? TipId { get; set; }
        public Tip? Tip{ get; set; }
    }
}
