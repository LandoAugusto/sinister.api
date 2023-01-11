using FluentValidation;

namespace Application.DTO.Occurence.Validators
{
    internal class UpdateSaveOccurenceRequestDtoValidator : AbstractValidator<UpdateSaveOccurenceRequestDto>
    {
        private readonly string _inconsistentDataCode = "40";

        public UpdateSaveOccurenceRequestDtoValidator()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(x => x.NotificationId)
              .Cascade(CascadeMode.Stop)
              .GreaterThan(0)
              .WithErrorCode(_inconsistentDataCode)
              .WithMessage("Obrigatório informar o número do aviso.");

            RuleFor(x => x.DateOccurence)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .WithErrorCode(_inconsistentDataCode)
              .WithMessage("Obrigatório informar a data de ocorrência.");

            RuleFor(x => x.TimeOccurrence)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .WithErrorCode(_inconsistentDataCode)
              .WithMessage("Obrigatório informar a hora da ocorrência.");

            RuleFor(x => x.DescriptonOccurence)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .WithErrorCode(_inconsistentDataCode)
              .WithMessage("Não foi informada a descrição da ocorrência.");
        }
    }
}
