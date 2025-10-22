using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Models.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{

    public void Configure(EntityTypeBuilder<Location> builder)
    {

        // Make sure the account is active
        builder.HasQueryFilter(s => s.!IsDeleted);

        // Fill out the data
        builder.HasData(Enumerable.Range(1, 5).Select(s => new Location()
        {
            Id = s,
            Name = $"Место {s}",

        }));
    }

}
