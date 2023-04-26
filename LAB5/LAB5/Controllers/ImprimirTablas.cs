using LAB5.ArbolesMulticaminos;
using LAB5.Models;
using Microsoft.AspNetCore.Mvc;
using static LAB5.ArbolesMulticaminos.Arbol23;

namespace LAB5.Controllers
{

    [Route("api/[controller]")]
    public class ImprimirTablas : Controller
    {
        
        [Route("Vehiculos")]


        public ActionResult Vehiculos(Carros carr)
        {
            List<Carros> paci = new List<Carros>();

            paci = Arbol23.Salida(); 

            return View(paci);
        }

        [HttpGet]
        public ActionResult Editar(Carros carr)
        {
            if (!ModelState.IsValid)
            {
                return View(carr);
            }
            ViewBag.mensaje = "Datos validos";
            Arbol23.edit(carr);

            return View(carr);
        }

        /*[HttpPost]

        public IActionResult delet(Carros carr)
        {
            Arbol23.delet(carr);
            return View(new Carros());
        }*/

    }
}
