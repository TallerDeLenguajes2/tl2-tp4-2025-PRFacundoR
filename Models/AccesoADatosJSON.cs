using System.Text.Json;

public interface IAccesoADatos
{   //caulquier metodo desde interface es publico por defecto
    public Cadeteria LeerCadeteria(string NombreArchivo);
    public List <Cadetes> LeerCadetedes(string NombreArchivo);
}

public class AccesoADatosJSON : IAccesoADatos
{
    public Cadeteria LeerCadeteria(string NombreArchivo)
    {
        string json = File.ReadAllText(NombreArchivo);
        Cadeteria cadeteria1 = JsonSerializer.Deserialize<Cadeteria>(json);
        return cadeteria1;

    }
    public List<Cadetes> LeerCadetedes(string NombreArchivo)
    {
        string json = File.ReadAllText(NombreArchivo);
        List<Cadetes> Cadetes1=JsonSerializer.Deserialize<List<Cadetes>>(json);
        return Cadetes1;
    }
}

public class AccesoADatosCSV: IAccesoADatos
{
    public Cadeteria LeerCadeteria(string NombreArchivo)
    {
        Cadeteria cadeteria1 = new Cadeteria();
        string[] lineas = File.ReadAllLines(NombreArchivo);

        int i = 0;
        foreach (var l in lineas)
        {

            string[] celdas = l.Split(',');


            cadeteria1.Nombre = celdas[0];
            cadeteria1.Telefono = int.Parse(celdas[1]);



            i++;
        }
        cadeteria1.Pedidos = new List<Pedidos>();

        return cadeteria1;
        
    }
    public List<Cadetes> LeerCadetedes(string NombreArchivo)
    {

        List<Cadetes> cadetes1 = new List<Cadetes>();

        string[] lineas = File.ReadAllLines(NombreArchivo);


        foreach (var l in lineas)
        {

            string[] celdas = l.Split(',');
            Cadetes cadetes = new Cadetes
            {


                Nombre = celdas[0],
                Telefono = int.Parse(celdas[1]),
                Id = int.Parse(celdas[2]),

            };


            cadetes1.Add(cadetes);



        }
        return cadetes1;
    }
}