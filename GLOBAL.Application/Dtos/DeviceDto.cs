using GLOBAL.Domain.Interfaces.Dtos;
using FluentValidation;

namespace GLOBAL.Application.Dtos
{
    public class DeviceDto : IDeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeviceInfoId { get; set; }
        public void Validate()
        {

            var validateResult = new DeviceDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new ArgumentException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));

        }
    }

    internal class DeviceDtoValidation : AbstractValidator<DeviceDto>
    {
        public DeviceDtoValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Name)}, deve ter no minimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Name)}, não pode ser vazio");
        }
    }

}
