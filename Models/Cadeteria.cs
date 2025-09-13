using System.Text.Json;

public class Cadeteria
{
    //campos siempre privados
    private string nombre;
    private int telefono;

    private List<Cadetes> cadetes;

    private List<Pedidos> pedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadetes> Cadetes1 { get => cadetes; set => cadetes = value; }

    public List<Pedidos> Pedidos { get => pedidos; set => pedidos = value; }

    public void AsignarPedidos(Pedidos pedidos)
    {

        Pedidos.Add(pedidos);

    }

    private void cambiarEstadoPedido(Pedidos pedidos)
    {
        pedidos.Estado = false;
        pedidos.cadete.PedidosRealizados += 1;
    }



    public List<Pedidos> BorrarPedido(int numero)
    {
        List<Pedidos> pedidosHecho = new List<Pedidos>();

        var pedidosAEliminar = pedidos.FirstOrDefault(p => p.Nro == numero);
        if (pedidosAEliminar != null)
        {

            cambiarEstadoPedido(pedidosAEliminar);


            pedidosHecho.Add(pedidosAEliminar);


            pedidos.Remove(pedidosAEliminar);
        }


        return pedidosHecho;

    }


    

    public void CrearInforme(string NombreArchivo, List<Pedidos> pedidos)
    {
        string json = JsonSerializer.Serialize(pedidos);
        File.WriteAllText(NombreArchivo, json);

    }


    public double jornalAcobrar(int idcadete)
    {
        
        Cadetes cadetes1 = cadetes.FirstOrDefault(c => c.Id == idcadete);
        double pagaDeCadete = cadetes1.PedidosRealizados * 500;
        return pagaDeCadete;
    }


    public void AsignarCadeteAPedido(int idcadete, int idpedido)
    {
        var cadete = cadetes.FirstOrDefault(c => c.Id == idcadete);
        var pedido = pedidos.FirstOrDefault(p => p.Nro == idpedido);
        pedido.cadete = cadete;

    }
    

    

}