using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FuncionarioApi.Middlewares.Validators
{
    public class ValidadorCpf
    {
        private const string REGEX = "(?!(\\d)\\1{10})\\d{11}";
        private const string MSG_CPF_INVALIDO = "O CPF informado é inválido!";
        public void Validar(string documento)
        {
            if (documento == null)
            {
                throw new ValidationException(MSG_CPF_INVALIDO);
            }
            String cpf = documento.Replace(".", "").Replace("-", "");

            if (!Regex.IsMatch(cpf, REGEX))
            {
                throw new ValidationException(MSG_CPF_INVALIDO);
            }
            Int32 digitoVerificador1Esperado = CalcularDigitoVerificador1(cpf);
            Int32 digitoVerificador1Informado = Int32.Parse(cpf.Substring(9, 1));
            if (digitoVerificador1Esperado != digitoVerificador1Informado)
            {
                throw new ValidationException(MSG_CPF_INVALIDO);
            }
            Int32 digitoVerificador2Esperado = CalcularDigitoVerificador2(cpf);
            Int32 digitoVerificador2Informado = Int32.Parse(cpf.Substring(10, 1));
            if (digitoVerificador2Esperado != digitoVerificador2Informado)
            {
                throw new ValidationException(MSG_CPF_INVALIDO);
            }
        }

        private Int32 CalcularDigitoVerificador1(String cpf)
        {
            Int32[] multiplicadores = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var novePrimeirosDigitos = cpf.Substring(0, 9);
            return obterDigitoVerificador(novePrimeirosDigitos, multiplicadores);
        }

        private Int32 CalcularDigitoVerificador2(String cpf)
        {
            Int32[] multiplicadores = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string dezPrimeirosDigitos = cpf.Substring(0, 10);
            return obterDigitoVerificador(dezPrimeirosDigitos, multiplicadores);
        }
        private Int32 obterDigitoVerificador(String digitos, Int32[] multiplicadores)
        {
            const Int32 tamanhoCpf = 11;
            Int32 soma = obterSomaDosMultiplicadores(digitos, multiplicadores);
            Int32 restoDaDivisao = soma % tamanhoCpf;
            if (restoDaDivisao < 2)
            {
                return 0;
            }
            return tamanhoCpf - restoDaDivisao;
        }
        private static Int32 obterSomaDosMultiplicadores(String digitos, Int32[] multiplicadores)
        {
            Int32 soma = 0; 
            Int32 Length = multiplicadores.Length;
            for (Int32 i = 0; i < Length; i++)
            {
                Int32 multiplicador = multiplicadores[i];
                string substring = digitos.Substring(i, 1);
                Int32 digito = Int32.Parse(substring);
                soma = soma + (multiplicador * digito);
            }
            return soma;
        }
    }
}