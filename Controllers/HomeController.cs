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

    public IActionResult Index()
    {
        ViewBag.destacado = "Home";
        BD.InicializarUser();
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoPosts = BD.ListarPosts(0,0);
        return View("Home");
    }

    public IActionResult Home(int idUser, int idDest)
    {
        ViewBag.destacado = "Home";
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoPosts = BD.ListarPosts(idUser,idDest);
        return View();
    }

     public IActionResult Destinos()
    {
        ViewBag.destacado = "Destinos";
        ViewBag.usuario = BD.ObtenerUser();
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
        return View("Home");
    }

    public IActionResult AgregarPost()
    {
        ViewBag.Usuario = BD.ObtenerUser();
        return View();
    }

    [HttpPost]
    public IActionResult GuardarPost(Publicacion post)
    {
        return View("Home");
    }

   /* public List<Comentario> VerComentariosAjax(int IdPost)
    {
        return BD.ListarComentarios(IdPost);
    }*/

    public Usuario ObtenerUsuarioAjax()
    {
        return BD.ObtenerUser();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
