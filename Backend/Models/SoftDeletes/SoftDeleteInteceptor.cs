using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace ApiFactory.Models.SoftDeletes;

// Здесь мы будем переопределять поведения удаления
// то есть если какая то сущность имеет поля и от наследовалась
// то к ней будем применено виртуальное удаление или мягкое удаление
public class SoftDeleteInterceptor : SaveChangesInterceptor
{    
    // переопределяем метод сохранения изменений
    // для синхронного метода
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        // здесь проверяем что если заданный контекст пустой
        if (eventData.Context is null) return result;

        // дальше проходимся по всем сущностям в контексте
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            // проверка на то что состояние сущности
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;
            // устанавливаем состояние сущности на измененное
            entry.State = EntityState.Modified;
            delete.IsDeleted = true;
            delete.DeletedAt = DateTimeOffset.UtcNow;
        } // foreach

        // возвращаем ссылку на результат
        return result;
    } // SavingChanges

    // асинхронный метод
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        // здесь проверяем что если заданный контекст пустой
        if (eventData.Context is null) return ValueTask.FromResult(result);

       
        // дальше проходимся по всем сущностям в контексте
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            // проверка на то что состояние сущности
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;
            // устанавливаем состояние сущности на измененное
            entry.State = EntityState.Modified;
            delete.IsDeleted = true;
            delete.DeletedAt = DateTimeOffset.UtcNow;
        } // foreach

        // возвращаем ссылку на результат
        return ValueTask.FromResult(result);

    } // SavingChangesAsync
} // SoftDeleteInterceptor

