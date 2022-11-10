namespace TP09_Zalcman_Gitman.Models;

public class Publicacion
{
    private int _ID;
    private int _IDUsuario;
    private string _FotoUsuario;
    private string _NombreUsuario;
    private string _PaisOrigen;
    private int _IDDestino;
    private string _Destino;
    private int _Estrellas;
    private string _Opinion;
    private string _Foto1;
    private string _Foto2;
    private string _Foto3;
    private DateTime _FechaPublicacion;   

    public Publicacion(int id, int idusuario, string fotoUsuario, string nombreusuario, string paisorigen, int iddestino, string destino, int estrellas, string opinion, string foto1, string foto2, string foto3, DateTime fechapublicacion)
    {
        _ID = id;
        _IDUsuario = idusuario;
        _FotoUsuario = fotoUsuario;
        _NombreUsuario= nombreusuario;
        _PaisOrigen = paisorigen;
        _IDDestino = iddestino;
        _Destino = destino;
        _Estrellas = estrellas;
        _Opinion = opinion;
        _Foto1 = foto1;
        _Foto2 = foto2;
        _Foto3 = foto3;
        _FechaPublicacion = fechapublicacion;
    }

    public Publicacion()
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

    public string FotoUsuario
    {
        get { return _FotoUsuario; }
        set { _FotoUsuario = value; }
    }

     public string NombreUsuario
    {
        get { return _NombreUsuario; }
        set { _NombreUsuario = value; }
    }

     public string PaisOrigen
    {
        get { return _PaisOrigen; }
        set { _PaisOrigen = value; }
    }

   public int IDDestino
    {
        get { return _IDDestino; }
        set { _IDDestino = value; }
    } 
    public string Destino
    {
        get { return _Destino; }
        set { _Destino = value; }
    } 

     public int Estrellas
    {
        get { return _Estrellas; }
        set { _Estrellas = value; }
    } 

     public string Opinion
    {
        get { return _Opinion; }
        set { _Opinion = value; }
    } 

    public string Foto1
    {
        get { return _Foto1; }
        set { _Foto1 = value; }
    } 
    public string Foto2
    {
        get { return _Foto2; }
        set { _Foto2 = value; }
    } 
    public string Foto3
    {
        get { return _Foto3; }
        set { _Foto3 = value; }
    } 
    public DateTime FechaPublicacion
    {
        get { return _FechaPublicacion; }
        set { _FechaPublicacion = value; }
    } 

}