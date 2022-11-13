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
        public async Task<ActionResult<IEnumerable<FuncionariosDto>>> Get()
        {
            try
            {
                var funcionarios = await _uof.FuncionariosRepository.GetFuncionariosEnderecos().ToListAsync();
                var funcionariosDto = _mapper.Map<List<FuncionariosDto>>(funcionarios);
                return Ok(funcionariosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("{id = int}", Name = "ObterFuncionarios")]
        public async Task<ActionResult<FuncionariosDto>> GetById(int id)
        {
            try
            {
                var funcionario = await _uof.FuncionariosRepository.GetById(p => p.Id == id);

                if (funcionario == null)
                {
                    return NotFound($"Nenhum funcionário encontrado com o ID {id} informado");
                }

                var funcionariosDto = _mapper.Map<FuncionariosDto>(funcionario);

                return funcionariosDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("Endereco/{id = int}")]
        public async Task<ActionResult<IEnumerable<FuncionariosDto>>> GetFuncionariosEnderecosById(int id)
        {
            try
            {
                var funcionarios = await _uof.FuncionariosRepository
                                        .GetFuncionarioEnderecosById(id)
                                        .ToListAsync();

                if(funcionarios.Count == 0)
                {
                    return NotFound($"Nenhum registro encontrado para o ID {id} fornecido");
                }

                var funcionariosDto = _mapper.Map<List<FuncionariosDto>>(funcionarios);

                return funcionariosDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPost]
        public ActionResult Post(Funcionarios funcionario)
        {
            try
            {
                if(funcionario == null)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.FuncionariosRepository.Add(funcionario);
                _uof.Commit();

                var funcionariosDto = _mapper.Map<FuncionariosDto>(funcionario);

                return new CreatedAtRouteResult("ObterFuncionarios",
                    new { id = funcionariosDto.Id }, funcionariosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Funcionarios funcionario)
        {
            try
            {
                if (id != funcionario.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                _uof.FuncionariosRepository.Update(funcionario);
                _uof.Commit();

                var funcionariosDto = _mapper.Map<FuncionariosDto>(funcionario);

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
                    return NotFound($"Nenhum país encontraddo com o ID {id} informado");
                }

                if (_uof.FuncionariosRepository.GetFuncionarioEnderecosById(id)
                                               .Select(c => c.Enderecos)
                                               .ToList()
                                               .Count == 0)
                {
                    return StatusCode(StatusCodes.Status405MethodNotAllowed,
                        "Há registros de endereços relacionados a esse funcionário. \n" +
                        "Caso queira mesmo excluir o funcionário, " +
                        "favor exclua primeiramente os endereços relacionados");
                }

                _uof.FuncionariosRepository.Delete(funcionario);
                await _uof.Commit();

                var funcionariosDto = _mapper.Map<FuncionariosDto>(funcionario);

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
