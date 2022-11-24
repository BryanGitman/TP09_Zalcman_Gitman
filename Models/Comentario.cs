namespace TP09_Zalcman_Gitman.Models;

public class Comentario
{
    private int _ID;
    private int _IDUsuario;
    private string _NombreUsuario;
    private string _FotoPerfil;
    private string _PaisOrigen;
    private int _IDPublicacion;
    private string _Contenido;
    private DateTime _FechaComentario;


    public Comentario(int id, int idusuario, string nombreusuario, string fotoperfil, string paisorigen, int idpublicacion, string contenido, DateTime fechacomentario)
    {
        _ID = id;
        _IDUsuario = idusuario;
        _NombreUsuario= nombreusuario;
        _FotoPerfil= fotoperfil;
        _PaisOrigen = paisorigen;
        _IDPublicacion = idpublicacion;
        _Contenido = contenido;
        _FechaComentario = fechacomentario;
    }
 public Comentario()
    {
        
    }

     public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    public int IDUsuario    
    {
        get { return _IDUsuario; }
        set { _IDUsuario = value; }
    }
     public string NombreUsuario
    {
        get { return _NombreUsuario; }
        set { _NombreUsuario = value; }
    }

    public string FotoPerfil    
    {
        get { return _FotoPerfil; }
        set { _FotoPerfil = value; }
    }
     public string PaisOrigen
    {
        get { return _PaisOrigen; }
        set { _PaisOrigen = value; }
    }

    public int IDPublicacion    
    {
        get { return _IDPublicacion; }
        set { _IDPublicacion = value; }
    }
    public string Contenido    
    {
        get { return _Contenido; }
        set { _Contenido = value; }
    }
    public DateTime FechaComentario    
    {
        get { return _FechaComentario; }
        set { _FechaComentario = value; }
    }


}

