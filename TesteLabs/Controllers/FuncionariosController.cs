using AutoMapper;
using Data.Repository;
using Domain.DTOs;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TesteLabs.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        public readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public FuncionariosController(IUnitOfWork uof, IMapper mapper1)
        {
            _uof = uof;
            _mapper = mapper1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDto>>> Get()
        {
            try
            {
                var funcionarios = await _uof.FuncionariosRepository.GetFuncionariosCargo().ToListAsync();
                var funcionariosDto = _mapper.Map<List<FuncionarioDto>>(funcionarios);
                return Ok(funcionariosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("{id = int}", Name = "ObterFuncionarios")]
        public async Task<ActionResult<FuncionarioDto>> GetById(int id)
        {
            try
            {
                var funcionario = await _uof.FuncionariosRepository.GetById(p => p.Id == id);

                if (funcionario == null)
                {
                    return NotFound($"Nenhum funcionário encontrado com o ID {id} informado");
                }

                var funcionariosDto = _mapper.Map<FuncionarioDto>(funcionario);

                return funcionariosDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(FuncionarioDto funcionario)
        {
            try
            {
                if(funcionario == null)
                {
                    return BadRequest("Dados inválidos");
                }

                var entity = _mapper.Map<Funcionario>(funcionario);

                _uof.FuncionariosRepository.Add(entity);

                await _uof.Commit();

                var funcionariosDto = _mapper.Map<FuncionarioDto>(entity);

                return new CreatedAtRouteResult("ObterFuncionarios",
                    new { id = funcionariosDto.Id }, funcionariosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPost("cargo")]
        public async Task<ActionResult> PostCargo(FuncionarioCargoDto cargo)
        {
            try
            {
                if(cargo == null)
                {
                    return BadRequest("Dados inválidos");
                }

                var entity = _mapper.Map<FuncionarioCargo>(cargo);

                _uof.FuncionarioCargoRepository.Add(entity);
                await _uof.Commit();

                var cargoDto = _mapper.Map<FuncionarioCargoDto>(entity);

                return new CreatedAtRouteResult("ObterFuncionarios",
                    new { id = cargoDto.Id }, cargoDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Funcionario funcionario)
        {
            try
            {
                if (id != funcionario.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.FuncionariosRepository.Update(funcionario);
                _uof.Commit();

                var funcionariosDto = _mapper.Map<FuncionarioDto>(funcionario);

                return Ok(funcionariosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPut("cargo/{id:int}")]
        public ActionResult Put(int id, FuncionarioCargo cargo)
        {
            try
            {
                if (id != cargo.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.FuncionarioCargoRepository.Update(cargo);
                _uof.Commit();

                var funcionariosDto = _mapper.Map<FuncionarioDto>(cargo);

                return Ok(funcionariosDto);
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
                var funcionario = await _uof.FuncionariosRepository.GetById(p => p.Id == id);

                if(funcionario == null)
                {
                    return NotFound($"Nenhum funcionario encontraddo com o ID {id} informado");
                }

                _uof.FuncionariosRepository.Delete(funcionario);
                await _uof.Commit();

                var funcionariosDto = _mapper.Map<FuncionarioDto>(funcionario);

                return Ok(funcionariosDto);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }
    }
}
