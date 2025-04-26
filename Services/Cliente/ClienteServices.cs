using DesafioNubank.Data;
using DesafioNubank.dto;
using DesafioNubank.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioNubank.Services.Cliente;

public class ClienteServices : IClienteInterface
{
    private readonly AppDbContext _context;

    public ClienteServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<ClienteModel>> CriarCliente(ClientesDTO clientesDto)
    {
        var response = new ResponseModel<ClienteModel>();

        try
        {
            var cliente = new ClienteModel
            {
                Nome = clientesDto.Nome
            };

            

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var clienteCriado = await _context.Clientes
                .Include(c => c.Contatos)
                .FirstOrDefaultAsync(c => c.Id == cliente.Id);

            response.Dados = clienteCriado;
            response.Mensagem = "Cliente criado com sucesso!";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Mensagem = $"Erro ao criar cliente: {ex.Message}";
        }

        return response;
    }



    public async Task<ResponseModel<List<ClientesResponseDTO>>> ListarClientes()
    {
        var response = new ResponseModel<List<ClientesResponseDTO>>();

        try
        {
            var clientes = await _context.Clientes
                .Include(c => c.Contatos)
                .ToListAsync();

            var clientesDto = clientes.Select(c => new ClientesResponseDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Contatos = c.Contatos?.Select(contato => new ContatosResponseDTO
                {
                    Id = contato.Id,
                    Telefone = contato.Telefone,
                    Email = contato.Email,
                    ClienteId = contato.ClienteId
                }).ToList()
            }).ToList();
            
            response.Dados = clientesDto;
            response.Mensagem = "Clientes listados com sucesso!";
            return response;
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
    }
}