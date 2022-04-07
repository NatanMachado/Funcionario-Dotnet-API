namespace FuncionarioApi.Models.Entity
{
    public class Imposto
    {
        public Imposto(String descricao, decimal aliquota, decimal? teto, FaixaSalarial faixaSalarial)
        {
            this.Descricao = descricao;
            this.Aliquota = aliquota;
            this.Teto = teto;
            this.FaixaSalarial = faixaSalarial;
        }
        public String Descricao { get; }
        public decimal Aliquota { get; }

        public decimal? Teto { get; }

        public FaixaSalarial FaixaSalarial { get; }

        public bool dedutivel(decimal salario){
            return FaixaSalarial.contem(salario);
        }
    }
}