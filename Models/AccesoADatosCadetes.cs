using System.Text.Json;

public class AccesoADatosCadetes 
{

    public List<Cadetes> LeerCadetedes(string NombreArchivo)
    {
        string json = File.ReadAllText(NombreArchivo);
        List<Cadetes> Cadetes1=JsonSerializer.Deserialize<List<Cadetes>>(json);
        return Cadetes1;
    }
}
