using FluentValidation;
using Application.DTO.Policy;

namespace Application.DTO.Validators
{
    public class ListPolicyValidator : AbstractValidator<ListPoliciesRequestDto>
    {
        private readonly string _inconsistentDataCode = "40";

        public ListPolicyValidator()
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
