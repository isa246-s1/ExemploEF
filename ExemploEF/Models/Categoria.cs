using System.ComponentModel.DataAnnotations;

namespace EFexemplo.Models;

public class Categoria
{
    public Guid CategoriaId { get; set; } = Guid.NewGuid();
    [Required, StringLength(100)] public string Nome { get; set; } = string.Empty;
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}