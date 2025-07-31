using System.ComponentModel.DataAnnotations;

namespace FiberControlApi.Data.Dtos.requests;
public class DadosOltRequest
{
    [Required]
    public string Nome { get; set; }
}