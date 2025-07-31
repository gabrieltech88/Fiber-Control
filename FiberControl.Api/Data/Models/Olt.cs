using System.ComponentModel.DataAnnotations;

namespace FiberControlApi.Data.Models;

public class Olt
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Ip { get; set; }

}