using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteLabs.Domain;
using TesteLabs.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TesteLabs.DTOs;

namespace TesteLabs.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        public readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public CidadesController (IUnitOfWork uof, IMapper mapper1)
        {
            _uof = uof;
            _mapper = mapper1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CidadesDto>>> Get()
        {
            try
            {
                var cidades = await _uof.CidadesRepository.GetAll().ToListAsync();
                var cidadesDto = _mapper.Map<List<CidadesDto>>(cidades);
                return Ok(cidadesDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("{id = int}", Name = "ObterCidades")]
        public async Task<ActionResult<CidadesDto>> GetById(int id)
        {
            try
            {
                var cidade = await _uof.CidadesRepository.GetById(p => p.Id == id);

                if (cidade == null)
                {
                    return NotFound($"Nenhuma cidade encontraddo com o ID {id} informado");
                }

                var cidadesDto = _mapper.Map<CidadesDto>(cidade);
                return Ok(cidadesDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("Enderecos/{id = int}")]
        public async Task<ActionResult<IEnumerable<CidadesDto>>> GetByIdEnderecos(int id)
        {
            try
            {
                var cidade = await _uof.CidadesRepository.GetEstadosCidadesById(id);

                if (cidade.ToList().Count == 0)
                {
                    return NotFound($"Endereços encontrados para a cidade informada");
                }

                var cidadesDto = _mapper.Map<CidadesDto>(cidade);
                return Ok(cidadesDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cidades cidade)
        {
            try
            {
                if(cidade == null)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.CidadesRepository.Add(cidade);
                await _uof.Commit();

                var cidadesDto = _mapper.Map<CidadesDto>(cidade);

                return new CreatedAtRouteResult("ObterCidades",
                    new { id = cidadesDto.Id }, cidadesDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Cidades cidade)
        {
            try
            {
                if (id != cidade.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.CidadesRepository.Update(cidade);
                await _uof.Commit();

                return Ok(cidade);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cidade = await _uof.CidadesRepository.GetById(p => p.Id == id);

                if(cidade == null)
                {
                    return NotFound($"Nenhuma cidade encontraddo com o ID {id} informado");
                }

                var enderecos = await _uof.FuncionariosEnderecosRepository.GetAll().ToListAsync();

                if (!enderecos.Where(e => e.CidadeId == id).Any())
                {
                    return StatusCode(StatusCodes.Status405MethodNotAllowed,
                        "Há registros de endereços relacionados a essa cidade. \n" +
                        "Caso queira mesmo excluir a cidade, " +
                        "favor exclua primeiramente os endereços relacionados");
                }

                var cidadesDto = _mapper.Map<CidadesDto>(cidade);

                _uof.CidadesRepository.Delete(cidade);
                await _uof.Commit();
                return Ok(cidadesDto);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }
    }
}
