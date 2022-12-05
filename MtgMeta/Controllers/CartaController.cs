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
        [HttpGet]
        public IActionResult Create()
        {
            return View("CartaForm");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Carta NuovaCarta)
        {
            if (!ModelState.IsValid)
            {
                return View("CartaForm", NuovaCarta);
            }
            using(Context db = new Context())
            {
                Carta CartaDaCreare = new() {Nome = NuovaCarta.Nome, Numero = NuovaCarta.Numero, Prezzo = NuovaCarta.Prezzo};
                db.Add(CartaDaCreare);
                db.SaveChanges();
            }
            return RedirectToAction("CardDatabase");
        }
    }
}
