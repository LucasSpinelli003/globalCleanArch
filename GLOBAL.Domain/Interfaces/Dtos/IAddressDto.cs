namespace GLOBAL.Domain.Interfaces.Dtos
{
    public interface IAddressDto
    {
        int Id { get; set; }
        
        String Street { get; set; }

        String Number { get; set; }

        String Neighborhood { get; set; }

        String ZipCode { get; set; }
        void Validate();
    }
}
