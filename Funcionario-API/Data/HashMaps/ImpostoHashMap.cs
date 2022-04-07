using System.Collections.Generic;
using FuncionarioApi.Models.Entity;

namespace FuncionarioApi.Data.HashMaps
{
    public class ImpostoHashMap
    {

        private static ImpostoHashMap Instancia;

        private IList<Imposto> Impostos;
        private const string FGTS = "FGTS";
        private const string INSS = "INSS";
        private const string IRPF = "Imposto de Renda Retido na Fonte (IRPF)";
        public static ImpostoHashMap get()
        {
            if (Instancia == null)
            {
                Instancia = new ImpostoHashMap();
            }
            return Instancia;
        }

        private ImpostoHashMap()
        {
            Impostos = new List<Imposto>();

            Impostos.Add(new Imposto(FGTS, 8, 0, new FaixaSalarial(0, decimal.MaxValue)));

            Impostos.Add(new Imposto(INSS, (decimal)7.5, null, new FaixaSalarial((decimal)0.00, (decimal)1045.00)));
            Impostos.Add(new Imposto(INSS, (decimal)9, null, new FaixaSalarial((decimal)1045.01, (decimal)2089.60)));
            Impostos.Add(new Imposto(INSS, (decimal)12, null, new FaixaSalarial((decimal)2089.61, (decimal)3134.40)));
            Impostos.Add(new Imposto(INSS, (decimal)14, null, new FaixaSalarial((decimal)3134.41, (decimal)6101.06)));

            Impostos.Add(new Imposto(IRPF, 0, 0, new FaixaSalarial(0, (decimal)1903.98)));
            Impostos.Add(new Imposto(IRPF, (decimal)7.5, (decimal)142.8, new FaixaSalarial((decimal)1903.99, (decimal)2826.65)));
            Impostos.Add(new Imposto(IRPF, (decimal)15, (decimal)354.8, new FaixaSalarial((decimal)2826.66, (decimal)3751.05)));
            Impostos.Add(new Imposto(IRPF, (decimal)22.5, (decimal)636.13, new FaixaSalarial((decimal)3751.06, (decimal)4661.68)));
            Impostos.Add(new Imposto(IRPF, (decimal)27.5, (decimal)869.36, new FaixaSalarial((decimal)4664.68, decimal.MaxValue)));
        }
        public Imposto GetFGTS(decimal salario)
        {
            return Impostos.Where(i => i.Descricao.Equals(FGTS) && i.dedutivel(salario)).FirstOrDefault(
                 new Imposto(FGTS, 0, 0, new FaixaSalarial(0, decimal.MaxValue))
            );
        }
        public Imposto GetINSS(decimal salario)
        {
            return Impostos.Where(i => i.Descricao.Equals(INSS) && i.dedutivel(salario)).FirstOrDefault(
                new Imposto(INSS, 0, 0, new FaixaSalarial(0, decimal.MaxValue))
            );
        }

        public Imposto GetIRPF(decimal salario)
        {
            return Impostos.Where(i => i.Descricao.Equals(IRPF) && i.dedutivel(salario)).FirstOrDefault(
                new Imposto(IRPF, 0, 0, new FaixaSalarial(0, decimal.MaxValue))
            );
        }
    }
}