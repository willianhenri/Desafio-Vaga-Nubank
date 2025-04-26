using DesafioNubank.Data;
using DesafioNubank.dto;
using DesafioNubank.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioNubank.Services.Contato;

public class ContatoServices : IContatoInterface
{
    private readonly AppDbContext _context;

    public ContatoServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<ContatosDTO>> CriarContato(ContatosDTO contatosDto)
    {
        var response = new ResponseModel<ContatosDTO>();

        try
        {
            var contato = new ContatoModel
            {
                Telefone = contatosDto.Telefone,
                Email = contatosDto.Email,
                ClienteId = contatosDto.ClienteId
            };

            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            response.Dados = contatosDto;
            response.Mensagem = "Contato criado com sucesso!";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = $"Erro ao criar contato: {ex.Message}";
        }

        return response;
    }

    public async Task<ResponseModel<List<ContatosResponseDTO>>> BuscarContatosPorIdCliente(int idCliente)
    {
        var response = new ResponseModel<List<ContatosResponseDTO>>();

        try
        {
            var contatos = await _context.Contatos
                .Where(c => c.ClienteId == idCliente)
                .ToListAsync();

            var contatosDto = contatos.Select(c => new ContatosResponseDTO
            {
                
                Id = c.Id,
                Email = c.Email,
                Telefone = c.Telefone
            }).ToList();

            response.Dados = contatosDto;
            response.Mensagem = "Contatos encontrados com sucesso!";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = $"Erro ao buscar contatos: {ex.Message}";
        }

        return response;
    }
}