using System.ComponentModel.DataAnnotations.Schema;

namespace hakaton.Data
{
    public class Odgovor
    {
        public int Id { get; set; }
        public string Odgovori { get; set; }
        public bool isTacan { get; set; }
        [ForeignKey(nameof(Pitanje))]
        public int PitanjeId { get; set; }
        public Pitanje Pitanje{ get; set; }
        public int Bodovi { get; set; }
        public bool isSelected { get; set; } = false;

    }
}
