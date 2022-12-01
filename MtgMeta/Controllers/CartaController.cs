using Microsoft.AspNetCore.Mvc;
using MtgMeta.Data;
using MtgMeta.Models;
using System.Linq;

namespace MtgMeta.Controllers
{
    public class CartaController : Controller
    {
        [HttpGet]
        public IActionResult Index(string nomecarta)
        {
            List<Carta> carte = new List<Carta>();
            using (Context db = new Context())
            {

                carte = db.Carte.Where(carta => carta.Nome == nomecarta).ToList();

            }
            return View("Details", carte);
        }
    }
}
