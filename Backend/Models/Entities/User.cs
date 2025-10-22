using ApiFactory.Models.Entities;

namespace Backend.Models.Entity;
public class User
{
    // ��
    public readonly ulong Id;
    public string Name { get; private set; } = "";
    public string Surname { get; private set; } = "";
    public string Patronymic { get; private set; } = "";

    // ����
    public Role Role { get; set; }

    // ������
    public Status Status { get; set; }

    // �����
    public Account Account { get; set; }
    // ������ ��������
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
} // User
