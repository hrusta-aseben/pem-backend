using System.ComponentModel.DataAnnotations.Schema;

namespace hakaton.Data
{
    public class Vizuelni
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        [ForeignKey(nameof(Lekcija))]
        public int LekcijaId { get; set; }
        public Lekcija Lekcija { get; set; }

        public string LinkSlike { get; set; }
    }
}
