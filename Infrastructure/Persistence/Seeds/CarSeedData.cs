using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seeds
{
    public class CarSeedData : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(new Car[]
            {
                new()
                {
                    Id = 1,
                    BigImageUrl = "asdasdasd",
                    Km = 44,
                    Seat = 42,
                    BrandId = 1,
                    CoverImageUrl = "asdasdasd",
                    Luggage = 25,
                    Fuel ="asdasdasd",
                    Model = "asdasdasd",
                    Transmission = "asdasdasdad",
                    
                    

                },
                 new()
                {
                    Id = 2,
                    BigImageUrl = "astra",
                    Km = 15,
                    Seat = 52,
                    BrandId = 1,
                    CoverImageUrl = "asdasdasd",
                    Luggage = 65,
                    Fuel ="asdasdasd",
                    Model = "asdasdasd",
                    Transmission = "asdasdasdad"


                }
            });
        }
    }
}
