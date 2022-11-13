using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteLabs.Domain;
using TesteLabs.DTOs;
using TesteLabs.Repository;

namespace TesteLabs.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        public readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public EstadosController(IUnitOfWork uof, IMapper mapper1)
        {
            _uof = uof;
            _mapper = mapper1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estados>>> Get()
        {
            try
            {
                var estados = await _uof.EstadosRepository.GetAll().ToListAsync();
                var estadosDto = _mapper.Map<List<EstadosDto>>(estados);
                return Ok(estadosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("{id = int}", Name = "ObterEstados")]
        public async Task<ActionResult<EstadosDto>> GetById(int id)
        {
            try
            {
                var estado = await _uof.EstadosRepository.GetById(p => p.Id == id);

                if (estado == null)
                {
                    return NotFound($"Nenhum estado encontrado com o ID {id} informado");
                }
                var estadosDto = _mapper.Map<EstadosDto>(estado);
                return estadosDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Estados estado)
        {
            try
            {
                if(estado == null)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.EstadosRepository.Add(estado);
                await _uof.Commit();

                var estadosDto = _mapper.Map<EstadosDto>(estado);

                return new CreatedAtRouteResult("ObterEstados",
                    new { id = estadosDto.Id }, estadosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Estados estado)
        {
            try
            {
                if (id != estado.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.EstadosRepository.Update(estado);
                await _uof.Commit();

                var estadosDto = _mapper.Map<EstadosDto>(estado);

                return Ok(estadosDto);
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
                var estado = await _uof.EstadosRepository.GetById(p => p.Id == id);

                if(estado == null)
                {
                    return NotFound($"Nenhum estado encontraddo com o ID {id} informado");
                }

                if (_uof.CidadesRepository.GetAll()
                                          .Where(c => c.EstadoId == id)
                                          .Any()
                                          )
                {
                    return StatusCode(StatusCodes.Status405MethodNotAllowed,
                        "Há registros de cidades relacionados a esse estado. \n" +
                        "Caso queira mesmo excluir o estado, " +
                        "favor exclua primeiramente os estados relacionados");
                }

                _uof.EstadosRepository.Delete(estado);
                await _uof.Commit();

                var estadosDto = _mapper.Map<EstadosDto>(estado);

                return Ok(estadosDto);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }
    }
}
