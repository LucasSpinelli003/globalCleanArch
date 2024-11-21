using GLOBAL.Domain.Interfaces.Dtos;
using FluentValidation;

namespace GLOBAL.Application.Dtos
{
    public class UserDto : IUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public String Cpf { get; set; }
        public String Email{ get; set; }
        public String Password{ get; set; }
        public int? UserGroupId { get; set; }
        public int? DeviceId { get; set; }
        public void Validate()
        {

            var validateResult = new UserDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new ArgumentException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));

        }
    }

    internal class UserDtoValidation : AbstractValidator<UserDto>
    {
        public UserDtoValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Name)}, deve ter no minimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Name)}, não pode ser vazio");
            
            RuleFor(x => x.Email)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Email)}, deve ter no minimo 10 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)}, não pode ser vazio");

        }
    }

}
