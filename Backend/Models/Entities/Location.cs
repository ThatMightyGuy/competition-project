using Backend.Models.Configurations;
using Backend.Models.SoftDeletes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities;

[EntityTypeConfiguration(typeof(LocationConfiguration))]
public class Location : ISoftDelete
{
    public int Id { get; set; }


    [Required(ErrorMessage = "Наименование локации не может быть пустым")]
    [RegularExpression(@"^[a-zA-Zа-яА-Я0-9\s]+$", ErrorMessage = "Название местоположения может содержать только буквы и цифры.")]
    public string Name { get; set; } = string.Empty;

    // FIXME: Chickens?
    public virtual List<Chicken> Chickens { get; set; } = new();

    // Soft delete flags
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

}
