
public class Cadetes
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;

    private int pedidosRealizados = 0;
    

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public int PedidosRealizados { get => pedidosRealizados; set => pedidosRealizados = value; }


}