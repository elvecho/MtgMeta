using Microsoft.AspNetCore.Mvc;
using MtgMeta.Data;
using MtgMeta.Models;

namespace MtgMeta.Controllers
{
    public class MazzoController : Controller
    {
        [HttpGet]
        public IActionResult Index(string SearchString)
        {
            List<Mazzo> mazzi = new List<Mazzo>();

            using (Context db = new Context())
            {
                if(SearchString != null)
                {
                    mazzi = db.Mazzi.Where(mazzi => mazzi.Name.Contains(SearchString)).ToList<Mazzo>();
                }
                else
                {
                    mazzi = db.Mazzi.ToList<Mazzo>();
                }
            }
            return View("Homepage", mazzi);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Mazzo mazzotrovato = null;

            using (Context db = new Context()) 
            { 
             mazzotrovato = db.Mazzi.Where(mazzo => mazzo.MazzoId == Id).FirstOrDefault();   //restituirà il primo elemento trovato
            }
            if (mazzotrovato != null)
            {
                
                return View("Details", mazzotrovato);
            }
            else
            {
                return NotFound("il mazzo non è stato trovato");
            }          
        }
        //private Mazzo GetMazzoById(int Id)
        //{
        //    Mazzo Mazzo1 = null;
        //    foreach (Mazzo mazzo in MazzoContext.GetMazzo())
        //    {
        //        if(mazzo.Id == Id)
        //        {
        //            Mazzo1 = mazzo;
        //            break;
        //        }
        //    }
        //    return Mazzo1;
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View("Mazzo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mazzo NuovoMazzo)
        {
            if (!ModelState.IsValid)
            {
                return View("Mazzo", NuovoMazzo);
            }
            using (Context db = new Context())
            {
                Mazzo mazzoDaCreare = new Mazzo(NuovoMazzo.Image, NuovoMazzo.Name, NuovoMazzo.PercentualeMeta);
                db.Add(mazzoDaCreare);
                db.SaveChanges();
            }
             return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Mazzo MazzoDaModificare = null;
            using (Context db = new Context())
            {
                MazzoDaModificare = db.Mazzi.Where(mazzo => mazzo.MazzoId == id).FirstOrDefault();
            }
            if (MazzoDaModificare == null)
            {
                return NotFound();
                 
            }
            else
            {
                return View("Update", MazzoDaModificare);
            }
        }
        [HttpPost]
        public IActionResult Update(int id, Mazzo Modello)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", Modello);
            }
            else
            {
                Mazzo MazzoDaModificare = null;
                using (Context db = new Context())
                {
                    MazzoDaModificare = db.Mazzi.Where(mazzo => mazzo.MazzoId == id).FirstOrDefault();

                    if(MazzoDaModificare != null)
                    {
                        MazzoDaModificare.Name = Modello.Name;
                        MazzoDaModificare.Image = Modello.Image;
                        MazzoDaModificare.PercentualeMeta = Modello.PercentualeMeta;

                        db.SaveChanges();
                        return RedirectToAction("Index");
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
                Mazzo MazzoDaRimuovere = db.Mazzi.Where(mazzo => mazzo.MazzoId == id).FirstOrDefault();

                if(MazzoDaRimuovere != null)
                {
                    db.Mazzi.Remove(MazzoDaRimuovere);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }      
        }
    }
}
