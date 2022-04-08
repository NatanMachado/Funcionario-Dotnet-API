using Funcionario_API.Middlewares.Services;
using FuncionarioApi.Models.Enum;

namespace FuncionarioApi.Models.Entity
{
    public class ContraCheque
    {
         public ContraCheque(Funcionario funcionario, ILancamentoContraChequeService service)
        {
            this.MesReferencia = DateTime.Now.ToString("MMMM");
            this.SalarioBruto = funcionario.SalarioBruto;
            this.Lancamentos = service.MontarLancamentos(funcionario);
        }
        public ContraCheque(Funcionario funcionario)
        {
            this.MesReferencia = DateTime.Now.ToString("MMMM");
            this.SalarioBruto = funcionario.SalarioBruto;
            this.Lancamentos = new LancamentoContraChequeService().MontarLancamentos(funcionario);
        }
        public String MesReferencia { get; }
        public decimal SalarioBruto { get; }

        public IEnumerable<Lancamento> Lancamentos { get; }

        public decimal TotalDescontos { get => GetTotalDescontos(); }

        public decimal SalarioLiquido { get => GetSalarioLiquido(); }

        public decimal GetSalarioLiquido()
        {
            return this.SalarioBruto + this.GetTotalDescontos();
        }

        public decimal GetTotalDescontos()
        {
            return 0 - this.Lancamentos.Where(d => d.Tipo == TipoLancamento.Desconto).Sum(d => d.Valor);
        }
    }
}