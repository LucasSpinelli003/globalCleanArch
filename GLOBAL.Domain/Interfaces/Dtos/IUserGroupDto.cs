namespace GLOBAL.Domain.Interfaces.Dtos
{
    public interface IUserGroupDto
    {
        int Id { get; set; }
        
        string Name { get; set; }

        int IsActive { get; set; }
        void Validate();
    }
}
