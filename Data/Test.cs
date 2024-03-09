using System.ComponentModel.DataAnnotations.Schema;
using hakaton.Data;
namespace hakaton.Data
{
    public class Test
    {
        public int TestId { get; set; }
        [ForeignKey(nameof(Lekcija))]
        public int LekcijaId { get; set; }
        public Lekcija Lekcija { get; set; }
    }
}
