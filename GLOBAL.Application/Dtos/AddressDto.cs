using GLOBAL.Domain.Interfaces.Dtos;
using FluentValidation;

namespace GLOBAL.Application.Dtos
{
    public class AddressDto : IAddressDto
    {
        public int Id { get; set; }
        public String Street { get; set; }
        public String Number { get; set; }
        public String Neighborhood { get; set; }
        public String ZipCode { get; set; }
        public void Validate()
        {

            var validateResult = new AddressDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new ArgumentException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));

        }
    }

    internal class AddressDtoValidation : AbstractValidator<AddressDto>
    {
        public AddressDtoValidation()
        {
            RuleFor(x => x.Street)
                .MinimumLength(3).WithMessage(x => $"O campo {nameof(x.Street)}, deve ter no minimo 3 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Street)}, não pode ser vazio");
            
            RuleFor(x => x.Neighborhood)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Neighborhood)}, deve ter no minimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Neighborhood)}, não pode ser vazio");

            RuleFor(x => x.ZipCode)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.ZipCode)}, deve ter no minimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.ZipCode)}, não pode ser vazio");
        }
    }

}
