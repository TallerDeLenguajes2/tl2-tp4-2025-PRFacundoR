using System.Text.Json;

public class AccesoADatosPedidos
{
    public List<Pedidos> Obtener()
    {
        if (!File.Exists("pedidos.json"))
        {
            File.WriteAllText("pedidos.json", "[]"); // crea un JSON válido vacío
        }
        string json = File.ReadAllText("pedidos.json");
        List<Pedidos> Pedidos1 = JsonSerializer.Deserialize<List<Pedidos>>(json);
        return Pedidos1;

    }

    public void Guardar(List<Pedidos> Pedidos)
    {

        string json = JsonSerializer.Serialize(Pedidos);
        File.WriteAllText("pedidos.json", json);
    }

}