using AutoMapper;
using Data.Repository;
using Domain.DTOs;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TesteLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        public readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public CargoController(IUnitOfWork uof, IMapper mapper1)
        {
            _uof = uof;
            _mapper = mapper1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargosDto>>> Get()
        {
            try
            {
                var cargos = await _uof.CargoRepository.GetAll().ToListAsync();
                var cargosDto = _mapper.Map<List<CargosDto>>(cargos);
                return Ok(cargosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("{id = int}", Name = "ObterCargo")]
        public async Task<ActionResult<CargosDto>> GetById(int id)
        {
            try
            {
                var cargo = await _uof.CargoRepository.GetById(p => p.Id == id);

                if (cargo == null)
                {
                    return NotFound($"Nenhum funcionário encontrado com o ID {id} informado");
                }

                var cargosDto = _mapper.Map<CargosDto>(cargo);

                return cargosDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(CargosDto cargo)
        {
            try
            {
                if(cargo == null)
                {
                    return BadRequest("Dados inválidos");
                }

                var entity = _mapper.Map<Cargo>(cargo);

                _uof.CargoRepository.Add(entity);
                await _uof.Commit();

                var cargosDto = _mapper.Map<CargosDto>(entity);

                return new CreatedAtRouteResult("ObterCargo",
                    new { id = cargosDto.Id }, cargosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Cargo cargo)
        {
            try
            {
                if (id != cargo.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.CargoRepository.Update(cargo);
                await _uof.Commit();

                var cargosDto = _mapper.Map<CargosDto>(cargo);

                return Ok(cargosDto);
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
                var cargo = await _uof.CargoRepository.GetById(p => p.Id == id);

                if(cargo == null)
                {
                    return NotFound($"Nenhum país encontraddo com o ID {id} informado");
                }

                if (_uof.FuncionarioCargoRepository.GetAll()
                                                   .Any(e => e.CargoId == id))
                {
                    return StatusCode(StatusCodes.Status405MethodNotAllowed,
                        "Há registros de funcionários relacionados a esse cargo. \n" +
                        "Caso queira mesmo excluir o funcionário, " +
                        "favor exclua primeiramente os endereços relacionados");
                }

                _uof.CargoRepository.Delete(cargo);
                await _uof.Commit();

                var cargosDto = _mapper.Map<CargosDto>(cargo);

                return Ok(cargosDto);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }
    }
}
