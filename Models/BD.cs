using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace TP09_Zalcman_Gitman.Models;

public static class BD
{
    private static Usuario _UserLog = new Usuario();

    private static string _connectionString = @"Server=.;DataBase=WeFly;Trusted_Connection=True;";

    public static void InicializarUser()
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE ID = 0";
            _UserLog = db.QueryFirstOrDefault<Usuario>(sql);
        }
    }

    public static Usuario ObtenerUser()
    {
        return _UserLog;
    }

    public static void CrearUser(Usuario User)
    {
        int RegistrosAñadidos = 0;
        string sql = "INSERT INTO Usuario (NombreUsuario, Contraseña, Pais, FotoPerfil) VALUES (@pNombre, @pContra, @pPais, @pFoto)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            RegistrosAñadidos = db.Execute(sql, new {pNombre = User.NombreUsuario, pContra = User.Contraseña, pPais = User.Pais, pFoto = User.FotoPerfil});
        }
        _UserLog = User;
    }

    public static bool UsuarioValido(string nomUser, string contra)
    {
        Usuario UserBuscado = new Usuario();
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE NombreUsuario = @pNombre and Contraseña = @pContra";
            UserBuscado = db.QueryFirstOrDefault<Usuario>(sql, new {pNombre = nomUser, pContra = contra});
        }
        if(UserBuscado == null)
        {
            return false;
        }
        else
        {
            _UserLog = UserBuscado;
            return true;
        }
    }

    private static List<Publicacion> _ListadoPosts = new List<Publicacion>();

    public static List<Publicacion> ListarPosts(int idUser, int idDest)
    {
        string where = "";
        if(idUser != 0 || idDest != 0)
        {
            where += "WHERE ";
            if(idUser != 0)
            {
                where += "us.ID = " + idUser + " ";
            }
            else
            {
                where += "des.ID = " + idDest + " ";
            }
        }
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT pub.ID, pub.IDUsuario, us.FotoPerfil as FotoUsuario, us.NombreUsuario, us.Pais as PaisOrigen, pub.IDDestino, des.Nombre as Destino, pub.Estrellas, pub.Opinion, pub.Foto1, pub.Foto2, pub.Foto3, pub.FechaPublicacion FROM Publicacion pub inner join Usuario us on pub.IDUsuario = us.ID inner join Destino des on pub.IDDestino = des.ID " + where + "ORDER BY pub.FechaPublicacion desc";
            _ListadoPosts = db.Query<Publicacion>(sql).ToList();
        }
        return _ListadoPosts;
    }

    public static void CrearPost(Publicacion post)
    {
        int RegistrosAñadidos = 0;
        string sql = "INSERT INTO Publicacion (IDUsuario, IDDestino, Estrellas, Opinion, Foto1, Foto2, Foto3, FechaPublicacion) VALUES (@pIDUser, @pIDDest, @pEstrellas, @pOpinion, @pFoto1, @pFoto2, @pFoto3, @pFecha)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            RegistrosAñadidos = db.Execute(sql, new {pIDUser = post.IDUsuario, pIDDest = post.IDDestino, pEstrellas = post.Estrellas, pOpinion = post.Opinion, pFoto1 = post.Foto1, pFoto2 = post.Foto2, pFoto3 = post.Foto3, pFecha = post.FechaPublicacion});
        }
    }

    private static List<Comentario> _ListadoComentarios = new List<Comentario>();

    public static List<Comentario> ListarComentarios(int idPost)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT com.ID, com.IDUsuario, us.NombreUsuario, us.Pais as PaisOrigen, com.IDPublicacion, com.Contenido, com.FechaComentario FROM Comentario com inner join Usuario us on com.IDUsuario = us.ID WHERE com.IDPublicacion = @pIDPost ORDER BY com.FechaComentario desc";
            _ListadoComentarios = db.Query<Comentario>(sql, new{pIDPost = idPost}).ToList();
        }
        return _ListadoComentarios;
    }

    private static List<Destino> _ListadoDestinos = new List<Destino>();

    public static List<Destino> ListarDestinos()
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT des.ID, des.Nombre, des.FotoPais, avg(pub.Estrellas) as PromedioEstrellas FROM Destino des left join Publicacion pub on des.ID = pub.IDDestino GROUP BY des.ID, des.Nombre, des.FotoPais ORDER BY PromedioEstrellas desc, des.Nombre";
            _ListadoDestinos = db.Query<Destino>(sql).ToList();
        }
        return _ListadoDestinos;
    }
}
