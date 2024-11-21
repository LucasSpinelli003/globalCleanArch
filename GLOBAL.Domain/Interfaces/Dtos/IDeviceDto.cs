namespace GLOBAL.Domain.Interfaces.Dtos
{
    public interface IDeviceDto
    {
        int Id { get; set; }
        
        string Name { get; set; }

        int DeviceInfoId { get; set; }
        void Validate();
    }
}
