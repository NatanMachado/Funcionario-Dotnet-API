using FuncionarioApi.Middlewares.Validators;
using Xunit;

namespace Funcionario_API_Test.Middlewares.Validators
{
    public class ValidadorCpfTest

    {
        readonly ValidadorCpf validador;
        public ValidadorCpfTest()
        {
            validador = new ValidadorCpf();
        }

        [Theory]
        //https://www.4devs.com.br/gerador_de_cpf
        [InlineData("05010300001", true)]
        [InlineData("41902854047", true)]
        [InlineData("735.028.750-06", true)]
        [InlineData("982.731.280-40", true)]
        //---------------------------------------
        [InlineData("23456523463", false)]
        [InlineData("00000000000", false)]
        [InlineData("d4151f654tt", false)]
        [InlineData("2315431", false)]
        [InlineData("2233f152231g3215gb", false)]
        public void Digitos_Verificadores_Devem_Ser_Calculados_Corretamente(string cpf, bool valido)
        {
            var exception = Record.Exception(() => validador.Validar(cpf));
            Assert.Equal(exception == null, valido);
        }
    }
}