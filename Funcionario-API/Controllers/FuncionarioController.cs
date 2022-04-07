using FuncionarioApi.Context;
using FuncionarioApi.Data.Repositories;
using FuncionarioApi.Middlewares.Dto;
using FuncionarioApi.Middlewares.Exceptions;
using FuncionarioApi.Middlewares.Services;
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
        private readonly ContraChequeService FuncionarioService;
        public FuncionarioController(DBFuncionarioContext context)
        {
            this.Repository = new FuncionarioRepository(context);
            this.FuncionarioService = new ContraChequeService(this.Repository);
        }

        // GET: api/Funcionario
        [HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            return Repository.GetAll();
        }

        // GET: api/Funcionario/5
        [HttpGet]
        [Route("{id}")]
        public Funcionario Get(long id)
        {
            if (!Repository.Exists(e => e.Id == id))
            {
                throw new HttpResponseException(204, "Nenhum funcionário encontrado!");
            }
            return Repository.GetById(id);
        }

        // POST: api/Funcionario
        [HttpPost]
        public FuncionarioDto Post([FromBody] Funcionario value)
        {
            value.Id = null;
            if (Repository.Exists(e => e.Documento.Equals(value.Documento)))
            {
                throw new HttpResponseException(204, "Funcionário já cadastrado!");
            }
            new ValidadorFuncionario().Validar(value);

            Repository.Insert(value);
            return new FuncionarioDto(value.Id);
        }

        // GET: api/Funcionario/5/Contracheque
        [HttpGet]
        [Route("{FuncionarioId}/Contracheque")]
        public ContraCheque GetContracheque(long FuncionarioId)
        {
            return FuncionarioService.gerarContracheque(FuncionarioId);
        }
    }
}
