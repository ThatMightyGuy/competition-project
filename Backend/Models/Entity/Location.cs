using Backend.Models.Configurations;
using Backend.Models.SoftDeletes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entity;
// таблица местоположения 
[EntityTypeConfiguration(typeof(LocationConfiguration))]
public class Location : ISoftDelete
{
    // ИД
    public int Id { get; set; }

    // само местопаложения курицы
    [Required(ErrorMessage = "Наименования локации не может быть пустым")]
    [RegularExpression(@"^[a-zA-Zа-яА-Я0-9\s]+$", ErrorMessage = "Название местоположения может содержать только буквы и цифры.")]
    public string Name { get; set; }

    // настройка связей
    // 1 : M 
    // 1 место может иметь множество кур 
    public virtual List<Chicken> Chickens { get; set; } = new();

    // для мягкого удаления
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

} // Location

