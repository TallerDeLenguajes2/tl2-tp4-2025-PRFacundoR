

using System.Text.Json;

public class AccesoADatosCadeteria 
{
    public Cadeteria LeerCadeteria(string NombreArchivo)
    {
        string json = File.ReadAllText(NombreArchivo);
        Cadeteria cadeteria1 = JsonSerializer.Deserialize<Cadeteria>(json);
        return cadeteria1;

    }

}

