using Microsoft.AspNetCore.Mvc;
using FiberControlApi.Data.Models;
using FiberControlApi.Data.Dtos.requests;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace FiberControlApi.Data.Dal
{
    [ApiController]
    [Route("oltDal")]
    public class OltDAL : ControllerBase
    {
        private FiberControlContext _context;
        private IMapper _mapper;

        public OltDAL(FiberControlContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
            
        [HttpPost]
        public async Task<IActionResult> CriarOlt([FromBody] CreateOltRequest dto)
        {   
            try 
            {
                Olt olt = _mapper.Map<Olt>(dto);
                _context.Olts.Add(olt);
                _context.SaveChanges();

                return CreatedAtAction(nameof(CriarOlt), olt);
                
            } catch 
            {
                throw new Exception("Erro ao cadastrar Olt");
            }
        }

    

        [HttpGet]
        public async Task<IActionResult> PegarOlts()
        {
            try 
            {
                var olts = await _context.Olts.ToListAsync();
                return Ok(olts);
            } catch 
            {
                return NotFound("Nenhuma Olt foi achada");
            }
        }

        public async Task<Olt> PegarOlt(string nome)
        {
            try
            {
                var olt = await _context.Olts.Where(o => o.Nome == nome).FirstOrDefaultAsync();
                return olt;
            }
            catch
            {
                throw new Exception("Erro ao buscar OLT");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirOlt(int id)
        {
            try 
            {
                var olt = await _context.Olts.FindAsync(id);
                if (olt == null)
                {
                    return NotFound("Olt não existe no banco de dados");
                }
                _context.Olts.Remove(olt);
                _context.SaveChanges();

                return NoContent();
            }catch
            {
                throw new Exception("Algum erro ocorreu ao excluir");
            }
        }
    }
}
