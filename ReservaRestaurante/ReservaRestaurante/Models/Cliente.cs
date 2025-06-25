using System.ComponentModel.DataAnnotations;

namespace ReservaRestaurante.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }
    [Required(ErrorMessage = "Campo nome obrigatório!")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Campo contato é obrigatório!")]
    public string? Telefone { get; set; }

}
