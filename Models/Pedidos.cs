public class Pedidos
{
    private int nro;
    private string obs;

    private Cliente cliente;

    private bool estado = false;

    public Cadetes cadete { get; set; }

    public Pedidos(int nro, string obs, Cliente cliente, bool estado)
    {
        this.Nro = nro;
        this.Obs = obs;
        this.Cliente1 = cliente;
        this.estado = estado;
    }


    public bool Estado { get => estado; set => estado = value; }
    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente1 { get => cliente; set => cliente = value; }

    public string VerDireccionCliente()
    {
        return cliente.Direccion;
    }

    public string VerNombreCliente()
    {
        return cliente.Nombre;
    }


    public string VerdatosReferenciaDireccion()
    {
        return cliente.DatosReferenciaDireccion;
    }

    public int VerTelefonoCliente()
    {

        return cliente.Telefono;
    }
}