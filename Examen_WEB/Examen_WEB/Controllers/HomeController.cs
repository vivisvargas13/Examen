using Examen_WEB.Models;
using Examen_WEB.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using static Examen_WEB.Models.EstudianteModel;

namespace Examen_WEB.Controllers
{
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public class HomeController(IEstudianteModel iEstudianteModel) : Controller
        {
            [HttpGet]
            public IActionResult RegistrarEstudiante()
            {
                return View();
            }

            [HttpPost]
            public IActionResult RegistrarEstudiante(Estudiante estudiante)
            {
                  var respuesta = iEstudianteModel.RegistrarMatricula(estudiante);

                if (respuesta.Codigo == 1)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ViewBag.msj = respuesta.Mensaje;
                    return View();
                }
            }



            [HttpGet]
            public IActionResult Principal()
            {
                return View();
            }



            [HttpGet]
            public IActionResult Consultarestudiante()
            {
                var respuesta = iEstudianteModel.ConsultarMatricula();

                if (respuesta.Codigo == 1)
                {
                    var datos = JsonSerializer.Deserialize<List<Estudiante>>((JsonElement)respuesta.Contenido!);
                    return View(datos);
                }

                return View(new List<Estudiante>());
            }


        }
    }