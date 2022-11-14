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
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosEnderecosController : ControllerBase
    {
        public readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public FuncionariosEnderecosController(IUnitOfWork uof, IMapper mapper1)
        {
            _uof = uof;
            _mapper = mapper1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionariosEnderecosDto>>> Get()
        {
            try
            {
                var enderecos = await _uof.FuncionariosEnderecosRepository.GetEnderecosCompleto();

                var enderecosDto = _mapper.Map<List<FuncionariosEnderecosDto>>(enderecos);

                return Ok(enderecosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpGet("{id = int}", Name = "ObterFuncionariosEnderecos")]
        public async Task<ActionResult<IEnumerable<FuncionariosEnderecosDto>>> GetById(int id)
        {
            try
            {
                var funcionariosEnderecos = await _uof.FuncionariosEnderecosRepository
                                                      .GetEnderecoCompletoById(id);

                if (funcionariosEnderecos.Where(f => f.Id == id).Any())
                {
                    return NotFound($"Nenhum endereço encontraddo com o ID {id} informado");
                }

                var enderecosDto = _mapper.Map<List<FuncionariosEnderecosDto>>(funcionariosEnderecos);

                return Ok(enderecosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(FuncionariosEnderecos funcionariosEnderecos)
        {
            try
            {
                if(funcionariosEnderecos == null)
                {
                    return BadRequest("Dados inválidos");
                }

                var isEnderecoPrincipal = _uof.FuncionariosEnderecosRepository.GetAll()
                                              .Where(f => f.FuncionarioId == funcionariosEnderecos.FuncionarioId &&
                                                          f.EnderecoPrincipal == true)
                                              .Any();

                if(isEnderecoPrincipal)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                                        "Já existe um endereço principal cadastrado para esse funcionário"
                        );
                }

                _uof.FuncionariosEnderecosRepository.Add(funcionariosEnderecos);
                await _uof.Commit();

                var enderecosDto = _mapper.Map<FuncionariosEnderecosDto>(funcionariosEnderecos);

                return new CreatedAtRouteResult("ObterFuncionariosEnderecos",
                    new { id = enderecosDto.Id }, enderecosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, FuncionariosEnderecos funcionariosEnderecos)
        {
            try
            {
                if (id != funcionariosEnderecos.Id)
                {
                    return BadRequest("Dados inválidos");
                }

                var isEnderecoPrincipal = _uof.FuncionariosEnderecosRepository.GetAll()
                                              .Where(f => f.FuncionarioId == funcionariosEnderecos.FuncionarioId &&
                                                          f.EnderecoPrincipal == true)
                                              .Any();
                if (isEnderecoPrincipal)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                                        "Já existe um endereço principal cadastrado para esse funcionário"
                        );
                }


                _uof.FuncionariosEnderecosRepository.Update(funcionariosEnderecos);
                await _uof.Commit();

                var enderecosDto = _mapper.Map<FuncionariosEnderecosDto>(funcionariosEnderecos);

                return Ok(enderecosDto);
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
                var funcionariosEnderecos = await _uof.FuncionariosEnderecosRepository.GetById(p => p.Id == id);

                if(funcionariosEnderecos == null)
                {
                    return NotFound($"Nenhum funcionário encontraddo com o ID {id} informado");
                }

                var funcionarios = await _uof.FuncionariosEnderecosRepository
                                             .GetAll().ToListAsync();

                if (funcionarios.Where(f => f.FuncionarioId == id).Any())
                {
                    return StatusCode(StatusCodes.Status405MethodNotAllowed,
                        "Há registros de funcionários relacionados a esse endereço. \n" +
                        "Caso queira mesmo excluir o endereço, " +
                        "favor exclua primeiramente os funcionários relacionados");
                }

                _uof.FuncionariosEnderecosRepository.Delete(funcionariosEnderecos);
                await _uof.Commit();

                var enderecosDto = _mapper.Map<FuncionariosEnderecosDto>(funcionariosEnderecos);

                return Ok(enderecosDto);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro desconhecido");
            }
        }
    }
}
