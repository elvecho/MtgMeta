using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MtgMeta.Models
{

    [Index(nameof(Nome), IsUnique = true)]
    public class Carta
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Numero { get; set; }
        public int Prezzo { get; set; }
        

        public List<Mazzo>? mazzi { get; set; }

        public Carta(string Nome, int Numero, int Prezzo)
        {
            this.Nome = Nome;
            this.Numero = Numero;
            this.Prezzo = Prezzo;
        }

        public Carta()
        {

        }
    }
}
