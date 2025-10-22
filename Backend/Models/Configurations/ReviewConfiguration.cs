using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backend.Models.Entity;

namespace Backend.Models.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        // Make the Account foreign key connection
        builder.HasOne(s => s.Account)
               .WithMany(s => s.Reviews)
               .HasForeignKey(p => p.AccountId);


        // Unicode support
        builder.Property(p => p.Text)
               .HasMaxLength(2048)
               .IsUnicode()
               .IsRequired();


        // Show only active
        builder.HasQueryFilter(s => !s.IsDeleted);
    }
}
