using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Database;

public class TimeTrackerContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Organisation> Organisations => Set<Organisation>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Record> Records => Set<Record>();
    public DbSet<WorkItem> WorkItems => Set<WorkItem>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=TimeTracker.db");
        optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Record>()
            .Navigation(record => record.WorkItem)
            .AutoInclude();
    }

    /// <summary>
    ///     <para>
    ///         Automatically populates createdAt and updatedAt on creation and updates updatedAt on udpated.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     This code was taken from <see href="https://dotnetcoretutorials.com/2022/03/16/auto-updating-created-updated-and-deleted-timestamps-in-entity-framework/">this link</see>.
    /// </remarks>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var insertedEntries = this.ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added)
            .Select(x => x.Entity);

        foreach (var insertedEntry in insertedEntries)
        {
            if (insertedEntry is not IMetadata timestampedEntity) continue;
            timestampedEntity.CreatedAt = DateTime.Now;
            timestampedEntity.UpdatedAt = DateTime.Now;
        }

        var modifiedEntries = this.ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified)
            .Select(x => x.Entity);

        foreach (var modifiedEntry in modifiedEntries)
        {
            if (modifiedEntry is IMetadata timestampedEntity)
            {
                timestampedEntity.UpdatedAt = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        var insertedEntries = this.ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added)
            .Select(x => x.Entity);

        foreach (var insertedEntry in insertedEntries)
        {
            if (insertedEntry is not IMetadata timestampedEntity) continue;
            timestampedEntity.CreatedAt = DateTime.Now;
            timestampedEntity.UpdatedAt = DateTime.Now;
        }

        var modifiedEntries = this.ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified)
            .Select(x => x.Entity);

        foreach (var modifiedEntry in modifiedEntries)
        {
            if (modifiedEntry is IMetadata timestampedEntity)
            {
                timestampedEntity.UpdatedAt = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }
}