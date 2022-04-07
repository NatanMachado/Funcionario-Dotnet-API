using FluentValidation;
using FuncionarioApi.Models.Entity;

namespace FuncionarioApi.Middlewares.Validators
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        private const string MENSAGEM_PADRAO = "{PropertyName} não foi informado";
        public void Validar(Funcionario model)
        {
            base.Validate(model);
            RuleFor(x => x.Nome).MinimumLength(3).MaximumLength(100).WithMessage(MENSAGEM_PADRAO);
            RuleFor(x => x.Sobrenome).MinimumLength(3).MaximumLength(100).WithMessage(MENSAGEM_PADRAO);
            RuleFor(x => x.Setor).MinimumLength(3).MaximumLength(100).WithMessage(MENSAGEM_PADRAO);
            RuleFor(x => x.SalarioBruto).GreaterThan(0).WithMessage(MENSAGEM_PADRAO);
            RuleFor(x => x.PlanoSaude).NotNull().WithMessage(MENSAGEM_PADRAO);
            RuleFor(x => x.PlanoDental).NotNull().WithMessage(MENSAGEM_PADRAO);
            RuleFor(x => x.ValeTransporte).NotNull().WithMessage(MENSAGEM_PADRAO);
            new ValidadorCpf().Validar(model.Documento);
        }
    }
}