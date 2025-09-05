public class Cliente
{
    private string _nombre;

    private string _direccion;

    private int _telefono;
    private string datosReferenciaDireccion;

    public Cliente(string nombre, string direccion, int telefono, string datosReferenciaDireccion)
    {
        _nombre = nombre;
        _direccion = direccion;
        _telefono = telefono;
        this.datosReferenciaDireccion = datosReferenciaDireccion;
    }

    public string Nombre { get => _nombre; }
    public string Direccion { get => _direccion;  }
    public int Telefono { get => _telefono; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion;  }

 

  
}