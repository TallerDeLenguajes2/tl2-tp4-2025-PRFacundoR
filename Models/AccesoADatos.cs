using System.Text.Json;

public interface IAccesoADatos
{   //caulquier metodo desde interface es publico por defecto
    public Cadeteria LeerCadeteria(string NombreArchivo);
    public List<Cadetes> LeerCadetedes(string NombreArchivo);

}

