using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.SharedKernel.Entities;
using CleanArchitecture.Template.SharedKernel.Entities.Events;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //Seed default data for users
            UserDefaultDataSeeder.Seed(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Update created and updated date
            var modifiedEntities = ChangeTracker.Entries<Entity>()
               .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);


            var now = DateTime.UtcNow;
            foreach (var entity in modifiedEntities)
            {
                if (entity.State == EntityState.Modified)
                    entity.Entity.UpdatedDate = now;

                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDate = now;
                    entity.Entity.UpdatedDate = now;
                }

            }

            var result = await base.SaveChangesAsync(cancellationToken);

            //TODO: Implement Outbox pattern to raise events

            //var domainEvents = ChangeTracker.Entries<Entity>()
            // .Select(entity => entity.Entity)
            // .Where(entity => entity.DomainEvents.Any())
            // .SelectMany(entity => entity.DomainEvents);

            //if (_publisher is null)
            //    return result;

            //foreach (var domainEvent in domainEvents)
            //{
            //    await _publisher.Publish(domainEvent, cancellationToken);
            //}

            return result;
        }
    }
}
