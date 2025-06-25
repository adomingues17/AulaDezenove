using Microsoft.AspNetCore.Mvc;//
using Microsoft.AspNetCore.Mvc.Rendering;//
using Microsoft.EntityFrameworkCore;//
using Microsoft.Identity.Client;
using ReservaRestaurante.Data;//
using ReservaRestaurante.Migrations;
using ReservaRestaurante.Models;
using System;
using System.Runtime.ConstrainedExecution;



namespace ReservaRestaurante.Controllers;

public class ReservaController : Controller
{
    public readonly AppDbContext _db;
    public ReservaController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        var reservaList = _db.Reservas.ToList();
        return View(reservaList);
        //var lista = _db.Reservas.Include(l => l.Cliente).ToList();
        //return View(lista);
    }
    public IActionResult Create()
    {
        ViewBag.Clientes = _db.Clientes
            .Select(c => new SelectListItem
            {
                Value = c.IdCliente.ToString(),
                Text = c.Nome
            })
            .ToList();
        
        ViewBag.Contato = _db.Clientes
            .Select(v => new SelectListItem
            {
                Value = v.IdCliente.ToString(),
                Text = v.Telefone
            }).ToList();
        
                ViewBag.Reserva = _db.Reservas
            .Select(r => new SelectListItem 
            { 
                Value = r.IdReserva.ToString(), 
                Text = r.QuantidadePessoas})
            .ToList();
        
        return View();
    }

    [HttpPost]
    public IActionResult Create(Reserva reserva)
    {
        if (ModelState.IsValid)
        {
            
            _db.Reservas.Add(reserva);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //ViewBag.Reservas = new SelectList(_db.Reservas, "Id", "Nome", reserva.IdReserva);
        
        return View(reserva);
    }


}

