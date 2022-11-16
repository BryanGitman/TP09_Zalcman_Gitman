using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Zalcman_Gitman.Models;
using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TP09_Zalcman_Gitman.Controllers;

public class HomeController : Controller
{
    private IWebHostEnvironment Environment;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public IActionResult Index()
    {
        ViewBag.destacado = "Home";
        ViewBag.listadoDestinos = BD.ListarDestinos();
        BD.InicializarUser();
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoPosts = BD.ListarPosts(0,0);
        return View("Home");
    }

    public IActionResult Home(int idUser, int idDest)
    {
        ViewBag.destacado = "Home";
        ViewBag.listadoDestinos = BD.ListarDestinos();
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoPosts = BD.ListarPosts(idUser,idDest);
        return View();
    }

     public IActionResult Destinos()
    {
        ViewBag.destacado = "Destinos";
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoDestinos = BD.ListarDestinos();
        return View();
    }

    public IActionResult IniciarSesion()
    {
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoDestinos = BD.ListarDestinos();
        ViewBag.error = "";
        return View();
    }

    public IActionResult Registrarse()
    {
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoDestinos = BD.ListarDestinos();
        return View();
    }

    [HttpPost]
    public IActionResult SesionIniciada(string NombreUsuario, string Contraseña)
    {
        if(BD.UsuarioValido(NombreUsuario,Contraseña))
        {
            ViewBag.destacado = "Home";
            ViewBag.listadoDestinos = BD.ListarDestinos();
            ViewBag.usuario = BD.ObtenerUser();
            ViewBag.listadoPosts = BD.ListarPosts(0,0);
            return View("Home");
        }
        else
        {
            ViewBag.usuario = BD.ObtenerUser();
            ViewBag.listadoDestinos = BD.ListarDestinos();
            ViewBag.error = "Nombre de usuario o contraseña no valido. Intenta de nuevo.";
            return View("IniciarSesion");
        }  
    }

     [HttpPost]
    public IActionResult SesionCreada(Usuario user, IFormFile Archivo)
    {
        if(Archivo.Length>0)
        {
            user.FotoPerfil = "selfie" + user.ID + ".jpg";
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + user.FotoPerfil;
            using(var stream = System.IO.File.Create(wwwRootLocal))
            {
                Archivo.CopyToAsync(stream);
            }
        }
        else
        {
            user.FotoPerfil = "selfie0.jpg";
        }
        BD.CrearUser(user);
        ViewBag.destacado = "Home";
        ViewBag.listadoDestinos = BD.ListarDestinos();
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoPosts = BD.ListarPosts(0,0);
        return View("Home");
    }

    public IActionResult AgregarPost()
    {
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoDestinos = BD.ListarDestinos();
        return View();
    }

    [HttpPost]
    public IActionResult GuardarPost(Publicacion post, IFormFile Archivo1, IFormFile Archivo2, IFormFile Archivo3)
    {
        BD.CrearPost(post);
        return View("Home");
    }

    public List<Comentario> VerComentariosAjax(int IdPost)
    {
        return BD.ListarComentarios(IdPost);
    }

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
