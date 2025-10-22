using ApiFactory.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Configurations;


// таблица для паролей
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
       // конфигурируем
      public void Configure(EntityTypeBuilder<Account> builder)
    {

        // каждый логин должен быть уникальным
        builder.HasIndex(s => s.Login)
                .IsUnique();


        // связь
        builder.HasOne(s => s.User)
               .WithOne(s => s.Account)
               .HasForeignKey<Account>(p => p.UserId);
               

        // для unicode
        builder
             .Property(p => p.Password)
             .HasMaxLength(255)
             .IsUnicode()
             .IsRequired();



        // для отображение после мяшкого удаления
        builder.HasQueryFilter(s => !s.IsDeleted);
       
    } // Configure
    } // LoginConfiguration

