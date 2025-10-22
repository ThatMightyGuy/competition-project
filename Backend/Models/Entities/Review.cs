using Microsoft.EntityFrameworkCore;
using Backend.Models.SoftDeletes;

namespace Backend.Models.Entities;

[EntityTypeConfiguration(typeof(ReviewConfiguration))]
public class Review : ISoftDelete
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public string Text { get; set; } = string.Empty;
    public string? ImagePath { get; set; }

    // Soft delete flags
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}