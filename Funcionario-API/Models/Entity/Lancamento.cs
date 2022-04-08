using System.Text.Json.Serialization;
using FuncionarioApi.Models.Enum;

namespace FuncionarioApi.Models.Entity
{
    public class Lancamento
    {
        public Lancamento(string descricao, decimal valor, TipoLancamento tipo)
        {
            this.Tipo = tipo;
            this.Descricao = descricao;
            this.Valor = valor;
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoLancamento Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        
    }
}