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
            return RedirectToAction("GetCarte");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Carta cartaTrovato = null;

            using (Context db = new Context())
            {
                  
                cartaTrovato = db.Carte.Where(carta => carta.Id == id).FirstOrDefault();  //restituirà il primo elemento trovato
            }
            if (cartaTrovato != null)
            {

                return View("Details", cartaTrovato);
            }
            else
            {
                return NotFound("la carta non è stata trovata");
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Carta CartaDaModificare = null;
            using (Context db = new Context())
            {
                
                CartaDaModificare = db.Carte.Where(carta => carta.Id == id).FirstOrDefault();
            }
            if (CartaDaModificare == null)
            {
                return NotFound();

            }
            else
            {
                return View("Update", CartaDaModificare);
            }
        }


        [HttpPost]
        public IActionResult Update(int id, Carta Modello)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", Modello);
            }
            else
            {
               Carta CartaDaModificare = null;
                using (Context db = new Context())
                {
                    CartaDaModificare = db.Carte.Where(carta => carta.Id == id).FirstOrDefault();

                    if (CartaDaModificare != null)
                    {
                        CartaDaModificare.Nome = Modello.Nome;
                        CartaDaModificare.Prezzo = Modello.Prezzo;
                        CartaDaModificare.Numero = Modello.Numero;

                        db.SaveChanges();
                        return RedirectToAction("GetCarte");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (Context db = new Context())
            {
               
                Carta CartaDaRimuovere = db.Carte.Where(carta => carta.Id == id).FirstOrDefault();
                if (CartaDaRimuovere != null)
                {
                    db.Carte.Remove(CartaDaRimuovere);
                    db.SaveChanges();
                    return RedirectToAction("GetCarte");
                }
                else
                {
                    return NotFound();
                }
            }
        }

    }
}
