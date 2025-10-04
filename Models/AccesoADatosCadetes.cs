using System.Text.Json;

public class AccesoADatosCadetes 
{

    public List<Cadetes> Obtener()
    {
        string json = File.ReadAllText("cadetes.json");
        List<Cadetes> Cadetes1=JsonSerializer.Deserialize<List<Cadetes>>(json);
        return Cadetes1;
    }
}
