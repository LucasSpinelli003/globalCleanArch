namespace GLOBAL.Domain.Interfaces.Dtos
{
    public interface IDeviceInfoDto
    {
        int Id { get; set; }
        
        Double voltage { get; set; }

        int EnergyLevel { get; set; }
        void Validate();
    }
}
