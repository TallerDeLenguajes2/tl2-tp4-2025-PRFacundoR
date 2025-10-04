using Microsoft.AspNetCore.Mvc;

namespace cadet.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{

    //asii se hace cuando no es estatico
    private Cadeteria _cadeteria = new Cadeteria
    {
        Cadetes1 = new AccesoADatosCadetes().Obtener(),
        Pedidos = new AccesoADatosPedidos().Obtener()
    };












    [HttpGet("pedidos")]//muestra
    public ActionResult<List<Pedidos>> GetPedidos()
    {
        return Ok(_cadeteria.Pedidos);
    }








    [HttpGet("cadetes")]
    public ActionResult<List<Cadetes>> GetCadetes()
    {
        return Ok(_cadeteria.Cadetes1);
    }






    /* [HttpGet("informe")] muestra sin modificar nada
     public ActionResult GetInforme(List<Pedidos> pedidoR)
     {
         _cadeteria.CrearInforme("pedidosR.json", pedidoR);
         return Ok("Informe creado");
     }*/







    [HttpPost("pedido")]//asigna
    public ActionResult<Pedidos> AgregarPedido([FromQuery] int numeroDePedido, [FromQuery] string observacionPedido, [FromQuery] string nombreCliente, [FromQuery] string dirrrecion, [FromQuery] int telefono, [FromQuery] string datosDeReferenciaDireccion)
    {
        Pedidos p = new Pedidos(numeroDePedido, observacionPedido, new(nombreCliente, dirrrecion, telefono, datosDeReferenciaDireccion), true);

        _cadeteria.AsignarPedidos(p);

        AccesoADatosPedidos acceso = new AccesoADatosPedidos();
        acceso.Guardar(_cadeteria.Pedidos);
        return Ok("Se guardo el pedido");
    }






    // PUT api/cadeteria/asignar/5/2
    [HttpPut("asignar/{idPedido}/{idCadete}")]//actuializa
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        bool existePedido = _cadeteria.Pedidos.Any(p => p.Nro == idPedido);
        if (!existePedido)
        {
            return NotFound("No existe el pedido con ese ID");
        }

        bool existeCadete = _cadeteria.Cadetes1.Any(c => c.Id == idCadete);
        if (!existeCadete)
        {
            return NotFound("No existe el cadete con ese ID");
        }

        Pedidos pedidoSinCadete = _cadeteria.Pedidos.FirstOrDefault(p => p.Nro==idPedido);

        if (pedidoSinCadete.cadete!=null)
        {
            return BadRequest("El pedido ya tiene un cadete asignado");

        }

        _cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
        AccesoADatosPedidos acceso = new AccesoADatosPedidos();
        acceso.Guardar(_cadeteria.Pedidos);
        return NoContent();
    }












    [HttpPut("cambiarcadete/{idPedido}/{idNuevoCadete}")]
    public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        bool existePedido = _cadeteria.Pedidos.Any(p => p.Nro == idPedido);
        if (!existePedido)
        {
            return NotFound("No existe el pedido con ese ID");
        }

        bool existeCadete = _cadeteria.Cadetes1.Any(c => c.Id == idNuevoCadete);
        if (!existeCadete)
        {
            return NotFound("No existe el cadete con ese ID");
        }

        _cadeteria.AsignarCadeteAPedido(idNuevoCadete, idPedido);
        AccesoADatosPedidos acceso = new AccesoADatosPedidos();
        acceso.Guardar(_cadeteria.Pedidos);

        return NoContent();
    }
    






    [HttpPut("estado/{idPedido}")]
    public IActionResult BorrarPedido(int idPedido)
    {   bool existePedido = _cadeteria.Pedidos.Any(p => p.Nro == idPedido);//any devuelve bool
        if (existePedido)
        {
            var pedidoR = _cadeteria.BorrarPedido(idPedido);
            _cadeteria.CrearInforme("pedidosR.json", pedidoR);

            return NoContent();//para funciones void
        }else
        {
            return NotFound("No existe ese id");
        }
    }

}