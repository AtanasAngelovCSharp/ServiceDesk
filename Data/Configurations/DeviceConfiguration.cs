using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Models.Enums;

namespace ServiceDesk.Data.Configurations;

public class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.HasData(
            new Device
            {
                Id = 1,
                Type = DeviceType.MFC,
                Brand = "Kyocera",
                Model = "ECOSYS M2540dn",
                SerialNumber = "VCF8Z12345",
                CustomerId = 2
            },

              new Device
              {
                  Id = 2,
                  Type = DeviceType.MFC,
                  Brand = "Kyocera",
                  Model = "ECOSYS M2540dn",
                  SerialNumber = "ECO321123",
                  CustomerId = 1
              },

            new Device
            {
                Id = 3,
                Type = DeviceType.Printer,
                Brand = "HP",
                Model = "LaserJet Pro M404dn",
                SerialNumber = "LJ12345",
                CustomerId = 3
            },

            new Device
            {
                Id = 4,
                Type = DeviceType.Laptop,
                Brand = "Lenovo",
                Model = "ThinkPad T14",
                SerialNumber = "982798834",
                CustomerId = 1
            },

            new Device
            {
                Id = 5,
                Type = DeviceType.PC,
                Brand = "Dell",
                Model = "OptiPlex 7090",
                SerialNumber = "DELL67690096",
                CustomerId = 2
            },

            new Device
            {
                Id = 6,
                Type = DeviceType.Laptop,
                Brand = "Lenovo",
                Model = "ThinkPad T16",
                SerialNumber = "45677654",
                CustomerId = 3
            }
        );
    }
}