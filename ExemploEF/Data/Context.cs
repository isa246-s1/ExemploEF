using EFexemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFexemplo.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Cliente>().ToTable("tbClientes");
        modelBuilder.Entity<Categoria>().ToTable("tbCategorias");
        modelBuilder.Entity<Produto>().ToTable("tbProdutos");
        modelBuilder.Entity<Produto>().HasOne(p => p.Categoria).WithMany(c => c.Produtos).HasForeignKey(p => p.CategoriaId).OnDelete(DeleteBehavior.Restrict);
    }
}