namespace FuncionarioApi.Models.Entity
{
    public class FaixaSalarial
    {
        public FaixaSalarial(decimal valorInicial, decimal valorFinal)
        {
            this.ValorInicial = valorInicial;
            this.ValorFinal = valorFinal;
        }

        public decimal ValorInicial { get; }

        public decimal ValorFinal { get; }

        public bool contem(decimal valor)
        {
            return valor >= ValorInicial && valor <= ValorFinal;
        }
    }
}