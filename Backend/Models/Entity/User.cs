using ApiFactory.Models.Entities;

namespace Backend.Models.Entity;
public class User 
{
    // ИД
    public readonly ulong Id;
    public string Name { get; private set; } = "";
    public string Surname { get; private set; } = "";
    public string Patronymic { get; private set; } = "";

    // роль
    public Role Role { get; set; }

    // статус
    public Status Status { get; set; }

    // связь
    public Account Account { get; set; }
    // мягкое удаление
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
} // User

