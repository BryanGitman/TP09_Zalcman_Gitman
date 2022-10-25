namespace TP09_Zalcman_Gitman.Models;

public class Usuario
{
    private int _ID;
    private string _NombreUsuario;
    private string _Contraseña;
    private string _Pais;
    private string _FotoPerfil;

     public Usuario(int id, string nombreusuario, string contraseña, string pais, string fotoperfil)
    {
        _ID = id;
        _NombreUsuario = nombreusuario;
        _Contraseña = contraseña;
        _Pais = pais;
        _FotoPerfil = fotoperfil;
    }
    public Usuario()
    {
        
    }

     public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public string NombreUsuario
    {
        get { return _NombreUsuario; }
        set { _NombreUsuario = value; }
    }

    public string Contraseña
    {
        get { return _Contraseña; }
        set { _Contraseña = value; }
    }

    public string Pais
    {
        get { return _Pais; }
        set { _Pais = value; }
    }

    public string FotoPerfil
    {
        get { return _FotoPerfil; }
        set { _NombreUsuario = value; }
    }
}