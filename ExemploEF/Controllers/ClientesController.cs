using EFexemplo.Data;
using EFexemplo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFexemplo.Controllers;

public class ClientesController : Controller
{
    private readonly Context _context;
    public ClientesController(Context context) => _context = context;
    public async Task<IActionResult> Index() => View(await _context.Clientes.OrderBy(c => c.Nome).ToListAsync());
    public async Task<IActionResult> Details(Guid? id) { if (id == null) return NotFound(); var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id); return cliente == null ? NotFound() : View(cliente); }
    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(Cliente cliente) { if (!ModelState.IsValid) return View(cliente); cliente.ClienteId = Guid.NewGuid(); _context.Add(cliente); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(Guid? id) { if (id == null) return NotFound(); var cliente = await _context.Clientes.FindAsync(id); return cliente == null ? NotFound() : View(cliente); }
    [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(Guid id, Cliente cliente) { if (id != cliente.ClienteId) return NotFound(); if (!ModelState.IsValid) return View(cliente); _context.Update(cliente); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(Guid? id) { if (id == null) return NotFound(); var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id); return cliente == null ? NotFound() : View(cliente); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(Guid id) { var cliente = await _context.Clientes.FindAsync(id); if (cliente != null) { _context.Clientes.Remove(cliente); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
}