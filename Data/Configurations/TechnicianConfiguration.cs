using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceDesk.Data.Models;

namespace ServiceDesk.Data.Configurations;

public class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
{
    public void Configure(EntityTypeBuilder<Technician> builder)
    {
        builder.HasData(
            new Technician
            {
                Id = 1,
                FullName = "Петър Иванов",
                PhoneNumber = "+359888100200",
                Specialization = "Лазерни принтери"
            },

              new Technician
              {
                  Id = 2,
                  FullName = "Наско Ангелов",
                  PhoneNumber = "+35988634598",
                  Specialization = "Мастилено-струйни принтери"
              },

            new Technician
            {
                Id = 3,
                FullName = "Георги Георгиев",
                PhoneNumber = "+359888907654",
                Specialization = "Лаптопи/Настолни Компютри"
            }
        );
    }
}