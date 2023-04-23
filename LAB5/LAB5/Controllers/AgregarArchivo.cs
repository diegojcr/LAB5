using LAB5.ArbolesMulticaminos;
using LAB5.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB5.Controllers
{
    [Route("[controller]")]
    public class AgregarArchivo : Controller
    {
        public List <Carros> carros = new List<Carros>();
        public Arbol23<Carros> arbol23 = new Arbol23<Carros>();
        public Arbol23 ad = new Arbol23();

        public void Agregar(Carros carros)
        {
          ad.Insertar(carros);
        }

        Carros carros1 = new Carros();
        public Carros RegistrarCarros(string Placa, string Color, string Propietario, string Latitud, string Longitud)
        {
            carros1.placa = Placa;
            carros1.color = Color;
            carros1.propiertario = Propietario;
            carros1.latitud = Latitud; 
            carros1.longitud = Longitud;
       
            return carros1;
        }

        [HttpPost("subirarchivo")]
        public IActionResult SubirArchivo(IFormFile archivo)
        {
            if (archivo != null)
            {
                try
                {
                    //Crear una copia del archivo recibido
                    string ruta = Path.Combine(Path.GetTempPath(), archivo.Name);
                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        archivo.CopyTo(stream); //Copiar el contenido del archivo
                    }

                    //Leer el arhivo
                    string informacionArchivo = System.IO.File.ReadAllText(ruta);
                    //Obtener lineas del archivo y llenar lista
                    foreach (string linea in informacionArchivo.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(linea))
                        {
                            //Extraer la informacion de cada persona
                            string[] FilaActual = linea.Split(',');

                            Agregar(RegistrarCarros(FilaActual[0], FilaActual[1], FilaActual[2], FilaActual[3], FilaActual[4]));

                        }
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Error al leer el archivo" + e.Message;
                }
            }
            else
            {
                ViewBag.Error = "No se ha ingresado la ruta de archivo";
            }

            return View();
        }
        [Route("SubirArchivo")]

        public IActionResult SubirArchivo()
        {
            return View();
        }
    }

    public class Arbol23<T>
    {
    }
}
