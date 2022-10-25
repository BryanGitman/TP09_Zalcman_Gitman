namespace TP09_Zalcman_Gitman.Models;

public class Destino
{
    private int _ID;
    private string _Nombre;
    private string _FotoPais;
    
    public Destino(int id, string nombre, string fotopais)
    {
        _ID = id;
        _Nombre = nombre;
        _FotoPais = fotopais;
    }

     public Destino()
    {
        
    }

     public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public string Nombre
    {
        get { return _Nombre; }
        set { _Nombre = value; }
    }

    public string FotoPais
    {
        get { return _FotoPais; }
        set { _FotoPais = value; }
    }

}