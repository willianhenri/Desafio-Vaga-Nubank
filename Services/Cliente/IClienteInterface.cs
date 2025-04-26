using DesafioNubank.dto;
using DesafioNubank.Models;

namespace DesafioNubank.Services.Cliente;

public interface IClienteInterface
{
    Task<ResponseModel<ClienteModel>> CriarCliente(ClientesDTO clientesDto);
    Task<ResponseModel<List<ClientesResponseDTO>>> ListarClientes();
   
}