using EFexemplo.Data;
using EFexemplo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFexemplo.Controllers;

public class CategoriasController : Controller
{
    private readonly Context _context;
    public CategoriasController(Context context) => _context = context;
    public async Task<IActionResult> Index() => View(await _context.Categorias.OrderBy(c => c.Nome).ToListAsync());
    public async Task<IActionResult> Details(Guid? id) { if (id == null) return NotFound(); var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == id); return categoria == null ? NotFound() : View(categoria); }
    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(Categoria categoria) { if (!ModelState.IsValid) return View(categoria); categoria.CategoriaId = Guid.NewGuid(); _context.Add(categoria); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(Guid? id) { if (id == null) return NotFound(); var categoria = await _context.Categorias.FindAsync(id); return categoria == null ? NotFound() : View(categoria); }
    [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(Guid id, Categoria categoria) { if (id != categoria.CategoriaId) return NotFound(); if (!ModelState.IsValid) return View(categoria); _context.Update(categoria); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(Guid? id) { if (id == null) return NotFound(); var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == id); return categoria == null ? NotFound() : View(categoria); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(Guid id) { var categoria = await _context.Categorias.FindAsync(id); if (categoria != null) { if (await _context.Produtos.AnyAsync(p => p.CategoriaId == id)) { ModelState.AddModelError("", "Não é possível excluir uma categoria que possui produtos."); return View("Delete", categoria); } _context.Categorias.Remove(categoria); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
}