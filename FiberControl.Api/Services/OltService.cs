using FiberControlApi.Data.Dtos.responses;
using FiberControlApi.Data.Dal;
using FiberControlApi.Data;

namespace FiberControlApi.Services;

public class OltService
{
    private IConfiguration _configuration;
    private readonly OltDAL _oltDal;

    public OltService(OltDAL oltDal, IConfiguration configuration)
    {
        _oltDal = oltDal;
        _configuration = configuration;
    }

    public async Task<string[]> FazerLimpeza(ClearRequest dto)
    {
        try
        {   
            var response = await _oltDal.PegarOlt(dto.Nome);
            OltConnection conn = new OltConnection(response.Ip, _configuration["User"], _configuration["Password"]);

            var shell = conn.CreateConnection();
            shell.WriteLine("enable");
            shell.WriteLine($"display ont info summary {dto.Porta} | include -/-");
            Thread.Sleep(1000);
            shell.WriteLine("");
            Thread.Sleep(1000);

            string output = shell.Read();

            string[] linhas = output.Split('\n');
            var linhasRelevantes = linhas.Skip(24).ToArray();

            return linhasRelevantes;

        } catch (HttpRequestException ex)
        {
            throw new Exception(ex.Message);
        }
    }
}