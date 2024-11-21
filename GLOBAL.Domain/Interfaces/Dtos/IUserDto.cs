namespace GLOBAL.Domain.Interfaces.Dtos
{
    public interface IUserDto
    {
        int Id { get; set; }
        string Name { get; set; }
        int IsActive { get; set; }
        String Cpf { get; set; }
        String Email { get; set; }
        String Password { get; set; }
        int? UserGroupId { get; set; }
        int? DeviceId { get; set; }
        void Validate();
    }
}
