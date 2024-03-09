using System.ComponentModel.DataAnnotations.Schema;

namespace hakaton.Data
{
    public class Auditivni
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Lekcija))]
        public int LekcijaId { get; set; }
        public Lekcija Lekcija { get; set; }
        public string LinkVidea { get; set; }
    }
}
