using ApiFactory.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{

    public void Configure(EntityTypeBuilder<Location> builder)
    {

        // для отображение после мягкого удаления
        builder.HasQueryFilter(s => !s.IsDeleted);

        // заполняем
        builder.HasData(Enumerable.Range(1, 5).Select(s => new Location()
        {
            Id = s,
            Name = $"Место {s}",

        })); // HasData);
    } // Configure

} // LocationConfiguration

