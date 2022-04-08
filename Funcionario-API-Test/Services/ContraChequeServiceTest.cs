using System.Collections.Generic;
using Funcionario_API.Middlewares.Services;
using FuncionarioApi.Models.Entity;
using FuncionarioApi.Models.Enum;
using Moq;
using Xunit;

namespace Funcionario_API_Test.Controllers
{
    public class ContraChequeTest
    {
        readonly Mock<ILancamentoContraChequeService> service;
        public ContraChequeTest()
        {
            service = new Mock<ILancamentoContraChequeService>();
        }

        [Fact]
        public void Totais_Contracheque_Devem_ser_calculados_corretamente()
        {
            const decimal VALOR = 100;
            Funcionario funcionario = new Funcionario() { SalarioBruto = VALOR };
            IEnumerable<Lancamento> lancamentos = new List<Lancamento>();

            service.Setup((r) => r.MontarLancamentos(funcionario)).Returns(lancamentos);
            ContraCheque contracheque = new ContraCheque(funcionario, service.Object);
            
            Assert.Empty(contracheque.Lancamentos);
            Assert.Equal(contracheque.SalarioBruto, VALOR);
            Assert.Equal(contracheque.TotalDescontos, 0);
            Assert.Equal(contracheque.SalarioLiquido, VALOR);
        }
    }
}