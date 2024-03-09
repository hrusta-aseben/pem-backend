using System.ComponentModel.DataAnnotations.Schema;

namespace hakaton.Data
{
    public class Lekcija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        [ForeignKey(nameof(Predmet))]
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
    }
}
