using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Zalcman_Gitman.Models;

namespace TP09_Zalcman_Gitman.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int idDest)
    {
        return View();
    }

     public IActionResult Destinos()
    {
        return View();
    }

    public IActionResult IniciarSesion()
    {
        return View();
    }

    public IActionResult Registrarse()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SesionIniciada()
    {
        return View("Index");
    }

    public IActionResult AgregarPost(int idUser)
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
