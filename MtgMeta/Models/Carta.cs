using System.ComponentModel.DataAnnotations;

namespace MtgMeta.Models
{
    public class Carta
    {
        [Key]
        public string Nome { get; set; } = null!;
        public int Numero { get; set; }
        public int Prezzo { get; set; }

        public List<Mazzo> mazzi { get; set; }

        public Carta()
        {

        }
    }
}
