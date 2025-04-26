using System.Text.Json.Serialization;

namespace DesafioNubank.dto;

public class ClientesDTO
{
    public required string Nome { get; set; }
    [JsonIgnore]
    public ICollection<ContatosDTO>? Contatos { get; set; }
}