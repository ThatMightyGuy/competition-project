 using ApiFactory.Models.Configuration;
using Backend.Models.;
using Backend.Models.;
using Backend.Models.Configurations;
using Backend.Models.Entity;
using Backend.Models.SoftDeletes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFactory.Models.Entities;

// таблица для хранения аккаунтов пользователей
[EntityTypeConfiguration(typeof(AccountConfiguration))]
public class Account : ISoftDelete
{
    // ИД
    public int Id { get; set; }

    // логин
    [Required(ErrorMessage = "Логин обязателен")]
    public string Login { get; set; } = string.Empty;

    // пароль 
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]+$",
        ErrorMessage = "Пароль должен содержать только латинские буквы и цифры.")]
    
    public string Password { get; set; } = string.Empty;


    // пользователь
    public int UserId { get; set; }
    public User User { get; set; } = null!;


    public List<Review> Reviews = [];
    

    // мягкое удаление
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

} // Account

