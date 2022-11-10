using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Zalcman_Gitman.Models;
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
        ViewBag.error = "";
        return View();
    }

    public IActionResult Registrarse()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SesionIniciada(string NomUser, string Contra)
    {
        if(BD.UsuarioValido(NomUser,Contra))
        {
            ViewBag.destacado = "Home";
            ViewBag.usuario = BD.ObtenerUser();
            ViewBag.listadoPosts = BD.ListarPosts(0,0);
            return View("Home");
        }
        else
        {
            ViewBag.error = "Nombre de usuario o contraseña no valido. Intenta de nuevo.";
        }  
    }

     [HttpPost]
    public IActionResult SesionCreada(Usuario user, IFormFile Archivo)
    {
        if(u)
        user.FotoPerfil = "selfie" + user.ID + ".jpg";
        if(Archivo.Length>0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + user.FotoPerfil;
            using(var stream = System.IO.File.Create(wwwRootLocal))
            {
                Archivo.CopyToAsync(stream);
            }
        }
        BD.CrearUser(user);
        ViewBag.destacado = "Home";
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoPosts = BD.ListarPosts(0,0);
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
