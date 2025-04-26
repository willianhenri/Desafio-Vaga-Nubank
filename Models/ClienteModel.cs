using System.Text.Json.Serialization;

namespace DesafioNubank.Models;

public class ClienteModel
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    [JsonIgnore]
    public ICollection<ContatoModel>? Contatos { get; set; }
}