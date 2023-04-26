using Microsoft.AspNetCore.Mvc;
using LAB5.Models;
using LAB5.ArbolesMulticaminos;

namespace LAB5.Controllers
{
    [Route("api/[controller]")]
    public class AgregarManual : Controller
    {
        [Route("Registro")]

        
        public ActionResult Registro(Carros carr)
        {
            if (!ModelState.IsValid)
            {
                return View(carr);
            }
            ViewBag.mensaje = "Datos validos";
            Arbol23.insertar(carr);

            return View(carr);
        }


        //[HttpPost("manual")]
        /*public ActionResult Registro(Carros carr)
        {
            if (!ModelState.IsValid)
            {
                return View(carr);
            }
            ViewBag.mensaje = "Datos validos";
            Arbol23.insertar(carr);

            return View(carr);
        }*/
    }
}
