using FluentValidation;

namespace Nao_Sei_Bar_Backend.src.validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("CPF deve ter 11 dígitos.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");
        }
    }

}
