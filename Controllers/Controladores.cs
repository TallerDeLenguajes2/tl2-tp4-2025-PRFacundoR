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






    [HttpGet("informe")]
    public ActionResult GetInforme(List<Pedidos> pedidoR)
    {
        _cadeteria.CrearInforme("pedidosR.json", pedidoR);
        return Ok("Informe creado");
    }







    [HttpPost("pedido")]//asigna
    public ActionResult<Pedidos> AgregarPedido([FromQuery] int numeroDePedido,[FromQuery] string observacionPedido,[FromQuery] string nombreCliente,[FromQuery] string dirrrecion, [FromQuery] int telefono, [FromQuery] string datosDeReferenciaDireccion )
    {
        Pedidos p = new Pedidos(numeroDePedido,observacionPedido, new(nombreCliente,dirrrecion, telefono,datosDeReferenciaDireccion),true);
        
        _cadeteria.AsignarPedidos(p);
        return Ok(p); 
   }






    // PUT api/cadeteria/asignar/5/2
    [HttpPut("asignar/{idPedido}/{idCadete}")]//actuializa
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        _cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
        return NoContent();
    }






    [HttpPut("estado/{idPedido}")]
    public IActionResult BorrarPedido(int idPedido)
    {

        _cadeteria.BorrarPedido(idPedido);
       
        return NoContent();//para funciones void
    }






    [HttpPut("cambiarcadete/{idPedido}/{idNuevoCadete}")]
    public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        _cadeteria.AsignarCadeteAPedido(idNuevoCadete, idPedido);
        return NoContent();
    }
}