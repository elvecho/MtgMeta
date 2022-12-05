using Microsoft.AspNetCore.Mvc;
using MtgMeta.Data;
using MtgMeta.Models;
using System.Linq;

namespace MtgMeta.Controllers
{
    public class CartaController : Controller
    {

        [HttpGet]
        public IActionResult GetCarte(string SearchString)
        {
            List<Carta> carte = new List<Carta>();

            using (Context db = new Context())
            {
                if (SearchString != null)
                {
                    carte = db.Carte.Where(carte => carte.Nome.Contains(SearchString)).ToList<Carta>();
                }
                else
                {
                    carte = db.Carte.ToList<Carta>();
                }
            }
            return View("CardDatabase", carte);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Carta");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Carta NuovaCarta)
        {
            if (!ModelState.IsValid)
            {
                return View("Carta", NuovaCarta);
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
