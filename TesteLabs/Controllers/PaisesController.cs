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
    public class PaisesController : ControllerBase
    {
        public readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public PaisesController(IUnitOfWork uof, IMapper mapper1)
        {
            _uof = uof;
            _mapper = mapper1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisesDto>>> Get()
        {
            try
            {
                var paises = await _uof.PaisesRepository.GetAll().ToListAsync();
                var paisesDto = _mapper.Map<List<PaisesDto>>(paises);
                return Ok(paisesDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("{id = int}", Name = "ObterPais")]
        public async Task<ActionResult<PaisesDto>> GetById(int id)
        {
            try
            {
                var pais = await _uof.PaisesRepository.GetById(p => p.Id == id);

                if (pais == null)
                {
                    return NotFound($"Nenhum país encontraddo com o ID {id} informado");
                }

                var paisDto = _mapper.Map<PaisesDto>(pais);

                return paisDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("Estados")]
        public async Task<ActionResult<IEnumerable<Paises>>> GetPaisesEstados()
        {
            try
            {
                var paises = await _uof.PaisesRepository.GetPaisesEstados();

                var paisesDto = _mapper.Map<List<PaisesDto>>(paises);

                return Ok(paisesDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("Estados/{id = int}")]
        public async Task<ActionResult<IEnumerable<PaisesDto>>> GetPaisesEstadosById(int id)
        {
            try
            {
                var paises = await _uof.PaisesRepository.GetPaisEstadosById(id).ToListAsync();

                if(paises.Count == 0)
                {
                    return NotFound($"Nenhum registro encontrado para o ID {id} fornecido");
                }

                var paisesDto = _mapper.Map<List<PaisesDto>>(paises);

                return paisesDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Paises pais)
        {
            try
            {
                if(pais == null)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.PaisesRepository.Add(pais);
                await _uof.Commit();

                var paisDto = _mapper.Map<PaisesDto>(pais);

                return new CreatedAtRouteResult("ObterPais",
                    new { id = paisDto.Id }, paisDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Paises pais)
        {
            try
            {
                if (id != pais.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.PaisesRepository.Update(pais);
                await _uof.Commit();

                var paisDto = _mapper.Map<PaisesDto>(pais);

                return Ok(paisDto);
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
                var pais = await _uof.PaisesRepository.GetById(p => p.Id == id);

                if(pais == null)
                {
                    return NotFound($"Nenhum país encontraddo com o ID {id} informado");
                }

                if (_uof.EstadosRepository.GetAll()
                                          .Where(e => e.PaisId == id)
                                          .Any())
                {
                    return StatusCode(StatusCodes.Status405MethodNotAllowed,
                        "Há registros de estados relacionados a esse país. \n" +
                        "Caso queira mesmo excluir o país, " +
                        "favor exclua primeiramente os estados relacionados");
                }

                _uof.PaisesRepository.Delete(pais);
                await _uof.Commit();

                var paisDto = _mapper.Map<PaisesDto>(pais);

                return Ok(paisDto);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }
    }
}
