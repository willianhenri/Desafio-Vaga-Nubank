using System.Text.Json.Serialization;

namespace DesafioNubank.Models;

public class ContatoModel
{
    public int Id { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public int ClienteId { get; set; }
    [JsonIgnore]
    public ClienteModel? Cliente { get; set; }
}