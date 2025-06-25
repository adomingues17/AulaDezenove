using System.ComponentModel.DataAnnotations;

namespace ReservaRestaurante.Models;

public class Reserva
{
    [Key]
    public int IdReserva { get; set; }    
    public int ClienteId { get; set; }
    [Required]
    public Cliente? Cliente { get; set; }
    [Required]
    public string QuantidadePessoas { get; set; }
    [Required]
    public DateTime DataReserva { get; set; }  
   
}
