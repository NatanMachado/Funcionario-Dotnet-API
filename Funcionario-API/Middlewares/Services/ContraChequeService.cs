using FuncionarioApi.Data.Repositories;
using FuncionarioApi.Middlewares.Exceptions;
using FuncionarioApi.Models.Entity;

namespace FuncionarioApi.Middlewares.Services
{
    public class ContraChequeService
    {
        private readonly IFuncionarioRepository Repository;
        public ContraChequeService(IFuncionarioRepository repository)
        {
            this.Repository = repository;
        }

        public ContraCheque gerarContracheque(long FuncionarioId)
        {
            Funcionario funcionario = Repository.GetById(FuncionarioId);
            if (funcionario == null)
            {
                 throw new HttpResponseException(204, "Funcionário já cadastrado!");
            }
            return new ContraCheque(funcionario);
        }
    }
}