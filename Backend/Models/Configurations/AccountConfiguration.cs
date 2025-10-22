using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backend.Models.Entities;

namespace Backend.Models.Configurations;

// Password table
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        // Make sure logins are unique
        builder.HasIndex(s => s.Login)
               .IsUnique();

        // Make the User foreign key connection
        builder.HasOne(s => s.User)
               .WithOne(s => s.Account)
               .HasForeignKey<Account>(p => p.UserId);

        // Unicode support
        builder.Property(p => p.Password)
               .HasMaxLength(255)
               .IsUnicode()
               .IsRequired();

        // Show only active
        builder.HasQueryFilter(s => s.!IsDeleted);
    }
}
