using DesafioNubank.dto;
using DesafioNubank.Models;

namespace DesafioNubank.Services.Contato;

public interface IContatoInterface
{
    Task<ResponseModel<ContatosDTO>> CriarContato(ContatosDTO contatosDto);
    Task<ResponseModel<List<ContatosResponseDTO>>> BuscarContatosPorIdCliente(int idCliente);
}