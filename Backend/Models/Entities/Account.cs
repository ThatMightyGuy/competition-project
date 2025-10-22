using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Backend.Models.Entity;
using Backend.Models.SoftDeletes;

namespace Backend.Models.Entities;

// User account table
[EntityTypeConfiguration(typeof(UserConfiguration))]
public class Account : ISoftDelete
{
    public int Id { get; set; }
    // Login validity check
    [Required(ErrorMessage = "Логин обязателен")]
    public string Login { get; set; } = string.Empty;
    // Password compliance check
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]+$",
        ErrorMessage = "Пароль должен содержать только латинские буквы и цифры.")]

    public string Password { get; set; } = string.Empty;


    // User data
    public int UserId { get; set; }
    public User User { get; set; } = null!;


    public List<Review> Reviews = [];

    // Soft delete flags
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

}
