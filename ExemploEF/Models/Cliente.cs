using System.ComponentModel.DataAnnotations;

namespace EFexemplo.Models;

public class Cliente
{
    public Guid ClienteId { get; set; } = Guid.NewGuid();
    [Required, StringLength(100)] public string Nome { get; set; } = string.Empty;
    [EmailAddress, StringLength(120)] public string? Email { get; set; }
}