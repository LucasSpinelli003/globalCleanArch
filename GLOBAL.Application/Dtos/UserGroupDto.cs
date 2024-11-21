using GLOBAL.Domain.Interfaces.Dtos;
using FluentValidation;

namespace GLOBAL.Application.Dtos
{
    public class UserGroupDto : IUserGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public void Validate()
        {

            var validateResult = new UserGroupDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new ArgumentException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));

        }
    }

    internal class UserGroupDtoValidation : AbstractValidator<UserGroupDto>
    {
        public UserGroupDtoValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Name)}, deve ter no minimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Name)}, não pode ser vazio");
        }
    }

}
