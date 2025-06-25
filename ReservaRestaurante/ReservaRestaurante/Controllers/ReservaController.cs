using Microsoft.AspNetCore.Mvc;//
using Microsoft.AspNetCore.Mvc.Rendering;//
using Microsoft.EntityFrameworkCore;//
using ReservaRestaurante.Data;//
using System;
using System.Runtime.ConstrainedExecution;

using ReservaRestaurante.Models;
using Microsoft.Identity.Client;



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
        var lista = _db.Reservas.Include(l => l.Cliente).ToList();
        return View(lista);
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




}


/*Criar um pequeno sistema de reservas de mesas.Deve ser informado  a
 quantidade de pessoas e horas da reserva 

no index deve ser listadas todas as reservas e horário de inicio e termino
*/