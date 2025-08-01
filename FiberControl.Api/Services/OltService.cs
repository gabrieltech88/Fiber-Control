using FiberControlApi.Data.Dtos.responses;
using FiberControlApi.Data.Dal;
using FiberControlApi.Data;
using System.Text.Json;

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
    public async Task<string> ExecutarComando(string comando, string nome)
    {
        var response = await _oltDal.PegarOlt(nome);
        Console.WriteLine(response.Ip);
        OltConnection conn = new OltConnection(response.Ip, _configuration["User"], _configuration["Password"]);

        var shell = conn.CreateConnection();
        shell.WriteLine("enable");
        shell.WriteLine($"display ont info {comando}");
        Thread.Sleep(1000);
        shell.WriteLine("");
        Thread.Sleep(3000);

        string output = shell.Read();

        conn.Disconnect();

        return output;
    }

    public async Task<string[]> FazerLimpeza(ClearRequest dto)
    {
        try
        {

            string output = await ExecutarComando($"summary {dto.Porta} | include -/-", dto.Nome);
            
            string[] linhas = output.Split('\n');
            var linhasRelevantes = linhas.Skip(24).ToArray();

            linhasRelevantes = linhasRelevantes.Take(linhasRelevantes.Length - 2).ToArray();


            return linhasRelevantes;

        }
        catch (HttpRequestException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<string> ChecarStatus(StatusRequest dto)
    {
        try
        {
            string output = await ExecutarComando($"by-desc {dto.Descricao}", dto.Nome);
            Console.WriteLine(output);

            string[] linhas = output.Split('\n');
            var linhasRelevantes = linhas.Skip(25).ToArray();
            
            linhasRelevantes = linhasRelevantes.Take(linhasRelevantes.Length - 12).ToArray();

            Console.WriteLine(linhas.Count());

            foreach (string linha in linhasRelevantes)
            {
                Console.WriteLine(linha);
            };


            return output;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception(ex.Message);
        }
    }
}