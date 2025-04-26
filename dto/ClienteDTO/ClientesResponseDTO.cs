namespace DesafioNubank.dto;

public class ClientesResponseDTO
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public ICollection<ContatosResponseDTO>? Contatos { get; set; }
}