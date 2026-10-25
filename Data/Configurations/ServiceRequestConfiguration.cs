using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceDesk.Data.Models;
using ServiceDesk.Data.Models.Enums;

namespace ServiceDesk.Data.Configurations;

public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
{
    public void Configure(EntityTypeBuilder<ServiceRequest> builder)
    {
        builder.HasData(
            new ServiceRequest
            {
                Id = 1,
                Title = "Засядане на хартия",
                ProblemDescription = "Хартията засяда при двустранен печат, на дисплея излиза грешка J0511.",
                Status = RequestStatus.Completed,
                CreatedOn = new DateTime(2026, 10, 20, 9, 30, 0),
                CompletedOn = new DateTime(2026, 10, 21, 14, 0, 0),
                EstimatedPrice = 85.50m,
                DeviceId = 1,
                TechnicianId = 1
            },

             new ServiceRequest
             {
                 Id = 2,
                 Title = "Не зарежда батерията",
                 ProblemDescription = "Лаптопът работи само на ток, батерията стои на 0% и не се зарежда.",
                 Status = RequestStatus.InProgress,
                 CreatedOn = new DateTime(2026, 10, 22, 10, 15, 0),
                 EstimatedPrice = 120m,
                 DeviceId = 4,
                 TechnicianId = 3
             },

            new ServiceRequest
            {
                Id = 3,
                Title = "Бледо копиране",
                ProblemDescription = "Копията излизат бледи и с ивици, принтът от компютър е нормален.",
                Status = RequestStatus.WaitingForParts,
                CreatedOn = new DateTime(2026, 10, 21, 11, 0, 0),
                EstimatedPrice = 210m,
                DeviceId = 2,
                TechnicianId = 1
            },

             new ServiceRequest
             {
                 Id = 4,
                 Title = "Не стартира",
                 ProblemDescription = "Компютърът не се включва, вентилаторите се завъртат за секунда и спират.",
                 Status = RequestStatus.New,
                 CreatedOn = new DateTime(2026, 10, 24, 16, 45, 0),
                 EstimatedPrice = 0m,
                 DeviceId = 5,
             },

            new ServiceRequest
            {
                Id = 5,
                Title = "Петна по листа",
                ProblemDescription = "При печат по листа остават черни петна на равни разстояния.",
                Status = RequestStatus.Completed,
                CreatedOn = new DateTime(2026, 10, 18, 9, 50, 0),
                CompletedOn = new DateTime(2026, 10, 19, 12, 35, 0),
                EstimatedPrice = 65m,
                DeviceId = 3,
                TechnicianId = 2
            },

            new ServiceRequest
            {
                Id = 6,
                Title = "Прегрява и се изключва",
                ProblemDescription = "Лаптопът се изключва сам след около 20 минути работа, долният капак е много горещ.",
                Status = RequestStatus.New,
                CreatedOn = new DateTime(2026, 10, 25, 9, 30, 0),
                EstimatedPrice = 0m,
                DeviceId = 6,
            }
        );
    }
}