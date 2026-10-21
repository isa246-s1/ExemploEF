using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFexemplo.Models;

public class Produto
{
    public Guid ProdutoId { get; set; } = Guid.NewGuid();
    [Required, StringLength(100)] public string Nome { get; set; } = string.Empty;
    [Required, StringLength(500)] public string Descricao { get; set; } = string.Empty;
    [Range(typeof(decimal), "0.01", "999999999")] [Column(TypeName = "decimal(10,2)")] public decimal Preco { get; set; }
    [Required] public Guid CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}