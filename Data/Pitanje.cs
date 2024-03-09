using System.ComponentModel.DataAnnotations.Schema;

namespace hakaton.Data
{
    public class Pitanje
    {
        public int PitanjeId { get; set; }
        public string Pitanjee { get; set; }
        [ForeignKey(nameof(Lekcija))]
        public int LekcijaId { get; set; }
        public Lekcija Lekcija { get; set; }
        public List<Odgovor>? Odgovori { get; set; }
        public bool isTestno { get; set; } = false;
    }
}
