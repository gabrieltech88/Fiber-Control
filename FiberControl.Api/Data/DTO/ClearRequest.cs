namespace FiberControlApi.Data.Dtos.responses;

public record ClearRequest
{
    public string Nome { get; set; }
    public string Porta { get; set; }
}