using Microsoft.AspNetCore.Mvc;
using ReservaRestaurante.Data;
using ReservaRestaurante.Models;

namespace ReservaRestaurante.Controllers;

public class ClienteController : Controller
{
    private readonly AppDbContext _db;
    public ClienteController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        var listaClientes = _db.Clientes.ToList();
        return View(listaClientes);
    }
    //abrir o formulário para cadastrar um  novo cliente
    public IActionResult Create() => View();

    //Este outro create que recebe os dados do formuláriopor meio 
    //do HttpPost, la na view existe um method=post
    [HttpPost]
    public IActionResult Create(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Edit(int id)
    {
        var cliente = _db.Clientes.Find(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }
    [HttpPost]
    public IActionResult Edit(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            _db.Clientes.Update(cliente);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(cliente);
    }

    // GET: Clientes/Delete/5
    public IActionResult Delete(int id)
    {
        var cliente = _db.Clientes.Find(id);
        if (cliente == null) return NotFound();
        return View(cliente);
    }

    // POST: Clientes/Delete/5
    [HttpPost]
    public IActionResult Delete(Cliente cliente)
    {
        var clienteBanco = _db.Clientes.Find(cliente.IdCliente);
        if (clienteBanco == null) return NotFound();

        _db.Clientes.Remove(clienteBanco);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

}
