using EFexemplo.Data;
using EFexemplo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFexemplo.Controllers;

public class ProdutosController : Controller
{
    private readonly Context _context;
    public ProdutosController(Context context) => _context = context;
    private void CarregarCategorias(Guid? selecionada = null) => ViewData["CategoriaId"] = new SelectList(_context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome", selecionada);
    public async Task<IActionResult> Index() => View(await _context.Produtos.Include(p => p.Categoria).OrderBy(p => p.Nome).ToListAsync());
    public async Task<IActionResult> Details(Guid? id) { if (id == null) return NotFound(); var produto = await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.ProdutoId == id); return produto == null ? NotFound() : View(produto); }
    public IActionResult Create() { CarregarCategorias(); return View(); }
    [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(Produto produto) { if (!ModelState.IsValid) { CarregarCategorias(produto.CategoriaId); return View(produto); } produto.ProdutoId = Guid.NewGuid(); _context.Add(produto); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(Guid? id) { if (id == null) return NotFound(); var produto = await _context.Produtos.FindAsync(id); if (produto == null) return NotFound(); CarregarCategorias(produto.CategoriaId); return View(produto); }
    [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(Guid id, Produto produto) { if (id != produto.ProdutoId) return NotFound(); if (!ModelState.IsValid) { CarregarCategorias(produto.CategoriaId); return View(produto); } try { _context.Update(produto); await _context.SaveChangesAsync(); } catch (DbUpdateConcurrencyException) { if (!_context.Produtos.Any(p => p.ProdutoId == id)) return NotFound(); throw; } return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(Guid? id) { if (id == null) return NotFound(); var produto = await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.ProdutoId == id); return produto == null ? NotFound() : View(produto); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(Guid id) { var produto = await _context.Produtos.FindAsync(id); if (produto != null) { _context.Produtos.Remove(produto); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
}