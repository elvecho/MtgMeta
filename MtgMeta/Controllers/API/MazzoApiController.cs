using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtgMeta.Data;
using MtgMeta.Models;

namespace MtgMeta.Controllers.API
{
    //[Route("api/[controller]/[action]")]
    //[ApiController]
    //public class MazzoApiController : ControllerBase
    //{
    //    [HttpGet]
    //    public IActionResult Get(string? search)
    //    {
    //        List<Mazzo> Mazzi = new List<Mazzo>();

    //        using (Context db = new Context())
    //        {
    //            if(search != null && search != "")
    //            {
    //                Mazzi = db.Mazzi.Where(Mazzi => Mazzi.Name.Contains(search) || Mazzi.Carte.ToString().Contains(search)).ToList<Mazzo>();
    //            }
    //            else
    //            {
    //                Mazzi = db.Mazzi.ToList<Mazzo>();
    //            }
    //        }
    //        return Ok(Mazzi);
    //    }

    //}
}
