using LAB5.Models;
using Microsoft.AspNetCore.Mvc;
using static LAB5.ArbolesMulticaminos.Arbol23;

namespace LAB5.Controllers
{

    [Route("api/[controller]")]
    public class ImprimirTablas : Controller
    {
        [Route("Vehiculos")]
        public ActionResult Vehiculos()
        {
            List<Carros> paci = new List<Carros>();

            paci = ;

            return View(paci);
        }
    }
}
