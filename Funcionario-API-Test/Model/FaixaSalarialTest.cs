using FuncionarioApi.Models.Entity;
using Xunit;

namespace Funcionario_API_Test.Models;

public class FaixaSalarialTest
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 10)]
    [InlineData(10, 10)]
    public void Gets_Devem_Retornar_Faixa_Salarial_Corretamente(decimal valorInicial, decimal valorFinal)
    {
        var faixa = new FaixaSalarial(valorInicial, valorFinal);
        Assert.Equal(valorInicial, faixa.ValorInicial);
        Assert.Equal(valorFinal, faixa.ValorFinal);
        Assert.True(faixa.contem(valorInicial));
        Assert.True(faixa.contem(valorFinal));
        Assert.False(faixa.contem(valorFinal + 1));
        Assert.False(faixa.contem(valorInicial -1));
    }
}
