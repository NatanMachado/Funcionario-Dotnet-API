using System.Net;
using FuncionarioApi.Context;
using FuncionarioApi.Data.Repositories;
using FuncionarioApi.Middlewares.Dto;
using FuncionarioApi.Middlewares.Exceptions;
using FuncionarioApi.Middlewares.Validators;
using FuncionarioApi.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FuncionarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IFuncionarioRepository Repository;

        public FuncionarioController(DBFuncionarioContext context)
        {
            this.Repository = new FuncionarioRepository(context);
        }

        // GET: api/Funcionario
        [HttpGet]
        public ActionResult<IEnumerable<Funcionario>> Get()
        {
            var funcionarios = Repository.GetAll();
            if (!funcionarios.Any())
            {
                throw new FailValidationException(HttpStatusCode.NoContent, "Nenhum funcionário cadastrado!");

            }
            return Ok(funcionarios);
        }

        // GET: api/Funcionario/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Funcionario> Get(long id)
        {
            Funcionario funcionario = Repository.GetById(id);
            if (funcionario == null)
            {
                throw new FailValidationException(HttpStatusCode.NoContent, "Nenhum funcionário encontrado!");
            }
            return Ok(funcionario);
        }

        // POST: api/Funcionario
        [HttpPost]
        public ActionResult<FuncionarioDto> Post([FromBody] Funcionario value)
        {
            value.Id = null;
            if (Repository.Exists(e => e.Documento.Equals(value.Documento)))
            {
                throw new FailValidationException(HttpStatusCode.OK, "Funcionário já cadastrado!");
            }
            new ValidadorFuncionario().Validar(value);

            Repository.Insert(value);
            return Ok(new FuncionarioDto(value.Id));
        }

        // GET: api/Funcionario/5/Contracheque
        [HttpGet]
        [Route("{FuncionarioId}/Contracheque")]
        public ActionResult<ContraCheque> GetContracheque(long FuncionarioId)
        {
            Funcionario funcionario = Repository.GetById(FuncionarioId);
            if (funcionario == null){
                throw new FailValidationException(HttpStatusCode.NoContent, "Nenhum funcionário encontrado!");
            }
            return Ok(new ContraCheque(funcionario));
        }
    }
}
