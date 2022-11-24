using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Zalcman_Gitman.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
            ViewBag.usuario = BD.ObtenerUser();
            ViewBag.destacado = "Home";
            ViewBag.listadoDestinos = BD.ListarDestinos();
            ViewBag.listadoPosts = BD.ListarPosts(0,0);
            return View("Home");
        }
        else
        {
            ViewBag.usuario = BD.ObtenerUser();
            ViewBag.listadoDestinos = BD.ListarDestinos();
            ViewBag.error = "Nombre de usuario o contraseña no válido. Intentá de nuevo.";
            return View("IniciarSesion");
        }  
    }

    [HttpPost]
    public IActionResult SesionCreada(Usuario user, IFormFile Archivo)
    {
        user.FotoPerfil = "selfie0.jpg";
        BD.CrearUser(user);
        ViewBag.usuario = BD.ObtenerUser();
        if(Archivo != null)
        {
            user.FotoPerfil = "selfie" + ViewBag.usuario.ID + ".jpg";
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + user.FotoPerfil;
            using(var stream = System.IO.File.Create(wwwRootLocal))
            {
                Archivo.CopyToAsync(stream);
            }
            BD.ActualizarFoto(ViewBag.usuario,user.FotoPerfil);
            ViewBag.usuario = BD.ObtenerUser();
        }
        ViewBag.destacado = "Home";
        ViewBag.listadoDestinos = BD.ListarDestinos();
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
        ViewBag.listadoPosts = BD.ListarPosts(0,0);
        int id = ViewBag.listadoPosts[0].ID;
        if(Archivo1 != null)
        {
            post.Foto1 = "post" + id + "f1.jpg";
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + post.Foto1;
            using(var stream = System.IO.File.Create(wwwRootLocal))
            {
                Archivo1.CopyToAsync(stream);
            }
        }
        if(Archivo2 != null)
        {
            post.Foto2 = "post" + id + "f2.jpg";
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + post.Foto2;
            using(var stream = System.IO.File.Create(wwwRootLocal))
            {
                Archivo2.CopyToAsync(stream);
            }
        }
        if(Archivo3 != null)
        {
            post.Foto3 = "post" + id + "f3.jpg";
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + post.Foto3;
            using(var stream = System.IO.File.Create(wwwRootLocal))
            {
                Archivo3.CopyToAsync(stream);
            }
        }
        BD.ActualizarPost(id,post.Foto1,post.Foto2,post.Foto3);
        ViewBag.listadoPosts = BD.ListarPosts(0,0);
        ViewBag.destacado = "Home";
        ViewBag.listadoDestinos = BD.ListarDestinos();
        ViewBag.usuario = BD.ObtenerUser();
        return View("Home");
    }

    public IActionResult EliminarPost(int idPost)
    {
        BD.EliminarPost(idPost);
        ViewBag.destacado = "Home";
        ViewBag.listadoDestinos = BD.ListarDestinos();
        ViewBag.usuario = BD.ObtenerUser();
        ViewBag.listadoPosts = BD.ListarPosts(0,0);
        return View("Home");
    }

    public List<Comentario> VerComentariosAjax(int IdPost)
    {
        return BD.ListarComentarios(IdPost);
    }

    public List<int> VerLikesAjax(int IdPost)
    {
        return BD.ListarLikes(IdPost);
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
