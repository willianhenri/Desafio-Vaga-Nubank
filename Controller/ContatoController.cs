using DesafioNubank.dto;
using DesafioNubank.Models;
using DesafioNubank.Services.Contato;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNubank.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoInterface _contatoInterface;
        
        public ContatoController(IContatoInterface contatoInterface)
        {
            _contatoInterface = contatoInterface;
        }
        
        [HttpGet("BuscarContatosPorIdCliente/{idCliente}")]
        public async Task<ActionResult<ResponseModel<List<ContatosResponseDTO>>>> BuscarContatosPorIdCliente(int idCliente)
        {
            var contatos = await _contatoInterface.BuscarContatosPorIdCliente(idCliente);
            return Ok(contatos);
        }

        [HttpPost("CriarContato")]
        public async Task<ActionResult<ResponseModel<ContatosDTO>>> CriarContato([FromBody] ContatosDTO contatosDto)
        {
            var resultado = await _contatoInterface.CriarContato(contatosDto);
            return Ok(resultado);
        }
    }
}