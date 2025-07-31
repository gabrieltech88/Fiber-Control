using Microsoft.AspNetCore.Mvc;
using FiberControlApi.Services;
using FiberControlApi.Data.Dtos.responses;

[ApiController]
[Route("olt")]
public class OltController : ControllerBase
{
    private readonly OltService _oltService;

    public OltController(OltService oltService)
    {
        _oltService = oltService;
    }
    

    [HttpPost("clear")]
    public async Task<IActionResult> LimpezaDeCto([FromBody] ClearRequest dto)
    {
        var result = await _oltService.FazerLimpeza(dto);
        return Ok(result);
    }
}