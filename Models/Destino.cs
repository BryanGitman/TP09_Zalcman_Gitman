namespace TP09_Zalcman_Gitman.Models;

public class Destino
{
    private int _ID;
    private string _Nombre;
    private string _FotoPais;
    private int _PromedioEstrellas;
    
    public Destino(int id, string nombre, string fotopais, int promedioestrellas)
    {
        _ID = id;
        _Nombre = nombre;
        _FotoPais = fotopais;
        _PromedioEstrellas = promedioestrellas;
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

    public int PromedioEstrellas
    {
        get { return _PromedioEstrellas; }
        set { _PromedioEstrellas = value; }
    }

}