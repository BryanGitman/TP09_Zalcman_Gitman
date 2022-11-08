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
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT pub.ID, pub.IDUsuario, us.NombreUsuario, us.Pais as PaisOrigen, pub.IDDestino, des.Nombre as Destino, pub.Estrellas, pub.Opinion, pub.Foto1, pub.Foto2, pub.Foto3, pub.FechaPublicacion FROM Publicacion pub inner join Usuario us on pub.IDUsuario = us.ID inner join Destino des on pub.IDDestino = des.ID ORDER BY pub.FechaPublicacion desc";
            db.Execute(sql, new{});
        }
        _UserLog = User;
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
            string sql = "SELECT pub.ID, pub.IDUsuario, us.NombreUsuario, us.Pais as PaisOrigen, pub.IDDestino, des.Nombre as Destino, pub.Estrellas, pub.Opinion, pub.Foto1, pub.Foto2, pub.Foto3, pub.FechaPublicacion FROM Publicacion pub inner join Usuario us on pub.IDUsuario = us.ID inner join Destino des on pub.IDDestino = des.ID " + where + "ORDER BY pub.FechaPublicacion desc";
            _ListadoPosts = db.Query<Publicacion>(sql).ToList();
        }
        return _ListadoPosts;
    }
}