using Microsoft.AspNetCore.Mvc;

namespace sad2.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{

    private Cadeteria _cadeteria;

    public CadeteriaController()
    {
        // Acá podrías cargar desde JSON/CSV usando IAccesoADatos
        _cadeteria = new Cadeteria
        {
            Cadetes1 = new List<Cadetes>(),
            Pedidos = new List<Pedidos>()
        };
    }

    // GET api/cadeteria/pedidos
    [HttpGet("pedidos")]
    public ActionResult<List<Pedidos>> GetPedidos()
    {
        return Ok(_cadeteria.Pedidos);
    }

    // GET api/cadeteria/cadetes
    [HttpGet("cadetes")]
    public ActionResult<List<Cadetes>> GetCadetes()
    {
        return Ok(_cadeteria.Cadetes1);
    }

    // GET api/cadeteria/informe
    [HttpGet("informe")]
    public ActionResult<object> GetInforme()
    {
        var informe = new
        {
            TotalPedidos = _cadeteria.Pedidos.Count,
            Cadetes = _cadeteria.Cadetes1.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.PedidosRealizados,
                Jornal = _cadeteria.jornalAcobrar(c.Id)
            })
        };

        return Ok(informe);
    }

    // POST api/cadeteria/pedido
    [HttpPost("pedido")]
    public ActionResult<Pedidos> AgregarPedido([FromBody] Pedidos pedido)
    {
        _cadeteria.AsignarPedidos(pedido);
        return CreatedAtAction(nameof(GetPedidos), new { id = pedido.Nro }, pedido);
    }

    // PUT api/cadeteria/asignar/5/2
    [HttpPut("asignar/{idPedido}/{idCadete}")]
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        _cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
        return NoContent();
    }

    // PUT api/cadeteria/estado/5/true
    [HttpPut("estado/{idPedido}/{nuevoEstado}")]
    public IActionResult CambiarEstadoPedido(int idPedido, bool nuevoEstado)
    {
        var pedido = _cadeteria.Pedidos.FirstOrDefault(p => p.Nro == idPedido);
        if (pedido == null) return NotFound();

        pedido.Estado = nuevoEstado;
        return NoContent();
    }

    // PUT api/cadeteria/cambiarcadete/5/3
    [HttpPut("cambiarcadete/{idPedido}/{idNuevoCadete}")]
    public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        _cadeteria.AsignarCadeteAPedido(idNuevoCadete, idPedido);
        return NoContent();
    }
}