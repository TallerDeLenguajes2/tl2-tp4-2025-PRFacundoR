

using System.Text.Json;

public class AccesoADatosCadeteria 
{
    public Cadeteria Obtener()
    {
        string json = File.ReadAllText("cadeteria.json");
        Cadeteria cadeteria1 = JsonSerializer.Deserialize<Cadeteria>(json);
        return cadeteria1;

    }

}

