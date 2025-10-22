using ApiFactory.Models.Configuration;
using ApiFactory.Models.Entities;
using Backend.Models.SoftDeletes;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Entity;
[EntityTypeConfiguration(typeof(ReviewConfiguration))]
public class Review : ISoftDelete
{
    // ид
    public int Id { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; private set; }
    public string Text { get; private set; }
    public string ImagePath { get; private set; }

    // м€гкое удаление
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}