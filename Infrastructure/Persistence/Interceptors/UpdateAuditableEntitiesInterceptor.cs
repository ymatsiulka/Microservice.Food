using Microservice.Food.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Microservice.Food.Infrastructure.Persistence.Interceptors;

public class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;
        if (dbContext is not null)
        {
            var entries = dbContext.ChangeTracker.Entries<IAuditableEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Property(p => p.CreatedAt).CurrentValue = DateTime.UtcNow;
                else if (entry.State == EntityState.Modified)
                    entry.Property(p => p.UpdatedAt).CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
