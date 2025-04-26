namespace DesafioNubank.dto;

public class ContatosResponseDTO
{
    public int Id { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public int? ClienteId { get; set; }
}