using DesafioNubank.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using DesafioNubank.Models;
using DesafioNubank.Services.Cliente;


namespace DesafioNubank.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }


        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
        {
            var clientes = await _clienteInterface.ListarClientes();
            return Ok(clientes);
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> CriarCliente([FromBody] ClientesDTO clienteDto)
        {
            var resultado = await _clienteInterface.CriarCliente(clienteDto);

            if (!resultado.Status)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}