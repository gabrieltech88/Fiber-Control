using System.ComponentModel.DataAnnotations;

namespace FiberControlApi.Data.Dtos.requests;
public class CreateOltRequest
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Ip { get; set; }
}