using FluentValidation;
using Domain.Core.Models;

namespace Domain.Core.Validators.Policy
{
    public class GetPolicyValidator : AbstractValidator<PolicyModel>
    {
        private readonly string _inconsistentDataCode = "40";

        public GetPolicyValidator()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(x => x.PolicyId)
               .Cascade(CascadeMode.Stop)
               .NotNull()
               .WithErrorCode(_inconsistentDataCode)
               .WithMessage("Obrigatorio informar o id da apolice");              
        }
    }
}
