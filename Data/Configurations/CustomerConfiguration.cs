using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceDesk.Data.Models;

namespace ServiceDesk.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            new Customer
            {
                Id = 1,
                FullName = "Атанас Ангелов",
                PhoneNumber = "+359876658866",
                Email = "atanas.angelov.2006@gmail.com"
            },

              new Customer
              {
                  Id = 2,
                  FullName = "Адроит Електроникс ЕООД",
                  PhoneNumber = "+35988634598",
                  Address = "Ул. Граг Игнатиев №4"
              },

            new Customer
            {
                Id = 3,
                FullName = "Георги Георгиев",
                PhoneNumber = "+359888907654",
                Email = "g.georgiev.77@gmail.com",
                Address = "Бул. Дунав №190"
            }
        );
    }
}