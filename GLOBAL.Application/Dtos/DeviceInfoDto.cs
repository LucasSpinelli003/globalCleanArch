using GLOBAL.Domain.Interfaces.Dtos;
using FluentValidation;

namespace GLOBAL.Application.Dtos
{
    public class DeviceInfoDto : IDeviceInfoDto
    {
        public int Id { get; set; }
        
        public Double voltage { get; set; }

        public int EnergyLevel { get; set; }
        public void Validate()
        {

            var validateResult = new DeviceInfoDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new ArgumentException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));

        }
    }

    internal class DeviceInfoDtoValidation : AbstractValidator<DeviceInfoDto>
    {
        public DeviceInfoDtoValidation()
        {
        }
    }

}
