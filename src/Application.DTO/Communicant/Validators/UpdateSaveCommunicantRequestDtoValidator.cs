using FluentValidation;

namespace Application.DTO.Communicant.Validators
{
    public class UpdateSaveCommunicantRequestDtoValidator : AbstractValidator<UpdateSaveCommunicantRequestDto>
    {
        private readonly string _inconsistentDataCode = "40";

        public UpdateSaveCommunicantRequestDtoValidator()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(x => x.NotificationId)
               .Cascade(CascadeMode.Stop)
               .GreaterThan(0)
               .WithErrorCode(_inconsistentDataCode)
               .WithMessage("Obrigatorio informar o número do aviso");

            RuleFor(x => x.CommunicantTypeId)
               .Cascade(CascadeMode.Stop)
               .GreaterThan(0)
               .WithErrorCode(_inconsistentDataCode)
               .WithMessage("Obrigatorio informar o nome do comunicante");

            RuleFor(x => x.Name)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithErrorCode(_inconsistentDataCode)
               .WithMessage("Obrigatorio informar o nome do comunicante")
               .NotNull()
               .WithErrorCode(_inconsistentDataCode)
               .WithMessage("Obrigatorio informar o nome do comunicante");

        }
    }
}
