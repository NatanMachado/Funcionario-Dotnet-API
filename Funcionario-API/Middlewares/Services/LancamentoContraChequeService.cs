using FuncionarioApi.Data.HashMaps;
using FuncionarioApi.Models.Entity;
using FuncionarioApi.Models.Enum;

namespace Funcionario_API.Middlewares.Services
{
    public interface ILancamentoContraChequeService
    {
        public IEnumerable<Lancamento> MontarLancamentos(Funcionario funcionario);
    }

    public class LancamentoContraChequeService
    {
        public IEnumerable<Lancamento> MontarLancamentos(Funcionario funcionario)
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            lancamentos.Add(new Lancamento("Salário", funcionario.SalarioBruto, TipoLancamento.Remuneracao));
            lancamentos.Add(new Lancamento("FGTS", calcularFGTS(funcionario.SalarioBruto), TipoLancamento.Desconto));
            lancamentos.Add(new Lancamento("INSS", calcularINSS(funcionario.SalarioBruto), TipoLancamento.Desconto));
            lancamentos.Add(new Lancamento("IRPF", calcularIRPF(funcionario.SalarioBruto), TipoLancamento.Desconto));
            if (funcionario.PlanoSaude)
            {
                lancamentos.Add(new Lancamento("Plano Saude", calcularPlanoSaude(), TipoLancamento.Desconto));
            }
            if (funcionario.PlanoDental)
            {
                lancamentos.Add(new Lancamento("Plano Dental", calcularPlanoDental(), TipoLancamento.Desconto));
            }
            if (funcionario.ValeTransporte)
            {
                lancamentos.Add(new Lancamento("Vale Transporte", calculaValeTransporte(funcionario.SalarioBruto), TipoLancamento.Desconto));
            }
            return lancamentos.AsReadOnly();
        }

        private decimal calcularINSS(decimal salario)
        {
            Imposto inss = ImpostoHashMap.get().GetINSS(salario);
            return converterPercentual(salario * inss.Aliquota);
        }

        private decimal calcularFGTS(decimal salario)
        {
            Imposto fgts = ImpostoHashMap.get().GetFGTS(salario);
            return converterPercentual(salario * fgts.Aliquota);
        }

        private decimal calcularIRPF(decimal salario)
        {
            Imposto irpf = ImpostoHashMap.get().GetIRPF(salario);
            decimal valor = converterPercentual(irpf.Aliquota * salario);
            if (valor > irpf.Teto)
            {
                return (decimal)irpf.Teto;
            }
            return valor;
        }

        private decimal calculaValeTransporte(decimal salario)
        {
            const decimal PERCENTUAL_VALE_TRASNSPORTE = (decimal)0.06;
            const decimal SALARIO_MINIMO_VALE_TRANSPORTE = (decimal)1500.00;
            if (salario > SALARIO_MINIMO_VALE_TRANSPORTE)
            {
                return converterPercentual(salario * PERCENTUAL_VALE_TRASNSPORTE);
            }
            return decimal.Zero;
        }

        private decimal calcularPlanoSaude()
        {
            return 10;
        }

        private decimal calcularPlanoDental()
        {
            return 5;
        }

        private decimal converterPercentual(decimal valor)
        {
            return valor / 100;
        }
    }
}