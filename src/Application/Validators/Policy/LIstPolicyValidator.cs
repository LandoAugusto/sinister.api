using FluentValidation;
using SinisterApi.DTO.Policy;

namespace Domain.Core.Validators.Policy
{
    public class LIstPolicyValidator : AbstractValidator<ListPoliciesRequestDto>
    {
        private readonly string _inconsistentDataCode = "40";

        public LIstPolicyValidator()
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
