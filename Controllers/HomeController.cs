using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP07.Models;

namespace TP07.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InicioJuego(string n)
        {
            Juego.IniciarJuego(n);
            return RedirectToAction("Pregunta","Home");
        }

        public IActionResult Pregunta(){
            ViewBag.J=Juego.LevantarJugador();
            ViewBag.Pregunta=Juego.LevantarPregunta();
            ViewBag.Respuestas=Juego.LevantarRespuestas();
            return View();
        }

        [HttpPost]
        public IActionResult ComprobarRespuesta(char r){
            bool estJuego=Juego.ComprobarEstJuego(r);
            if(estJuego==true){
                return RedirectToAction("Pregunta","Home");
            }else{
                return RedirectToAction("FinJuego","Home");
            }
        }

        public IActionResult FinJuego(){
            ViewBag.j=Juego.LevantarJugador();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
