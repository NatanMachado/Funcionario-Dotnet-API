using FuncionarioApi.Data.Repositories;
using FuncionarioApi.Middlewares.Services;
using FuncionarioApi.Models.Entity;
using Moq;
using Xunit;

namespace Funcionario_API_Test.Middlewares.Services
{
    public class ContraChequeServiceTest

    {
        readonly Mock<IFuncionarioRepository> repository;
        readonly ContraChequeService service;
        public ContraChequeServiceTest()
        {
            repository = new Mock<IFuncionarioRepository>();
            service = new ContraChequeService(repository.Object);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(1, false)]
        public void Servico_Deve_Lancar_Excecao_Se_Funcionario_Nao_Cadastrado(long id, bool cadastrado)
        {
            var funcionario = new Funcionario() { Id = id };
            this.repository.Setup(r => r.GetById(id)).Returns(cadastrado ? funcionario : null);
            var exception = Record.Exception(() => service.gerarContracheque(id));
            Assert.Equal(exception == null, cadastrado);
        }
    }
}