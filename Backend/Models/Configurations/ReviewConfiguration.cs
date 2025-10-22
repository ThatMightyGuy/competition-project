using ApiFactory.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models.Entity;

namespace Backend.Models.Configurations;


// таблица для паролей
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
       // конфигурируем
      public void Configure(EntityTypeBuilder<Review> builder)
    {


        // связь
        builder.HasOne(s => s.Account)
               .WithMany(s => s.Reviews)
               .HasForeignKey(p => p.AccountId);
               

        // для unicode
        // описание
        builder
             .Property(p => p.Text)
             .HasMaxLength(2048)
             .IsUnicode()
             .IsRequired();



        // для отображение после мяшкого удаления
        builder.HasQueryFilter(s => !s.IsDeleted);
    } // Configure
    } // LoginConfiguration

