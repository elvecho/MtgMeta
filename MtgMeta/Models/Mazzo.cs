using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MtgMeta.Models
{
    public class Mazzo
    {
        [Key]
        public int MazzoId { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PercentualeMeta { get; set; }
        public List<Carta>? carte { get; set; } 

        public Mazzo(string image, string name, int percentualeMeta)
        {           

            Image = image;
            Name = name;
            PercentualeMeta = percentualeMeta;

        }
        public Mazzo()
        {

        }
    }
}
