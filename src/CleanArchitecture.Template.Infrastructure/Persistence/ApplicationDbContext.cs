using CleanArchitecture.Template.Domain.Base.Events;
using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.Permissions;
using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Infrastructure.Persistence.Configuration.WeatherForecasts;
using CleanArchitecture.Template.Infrastructure.Persistence.Interceptors;
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
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //Seed default data for users
            RolesDefaultDataSeeder.Seed(modelBuilder);
            WeatherForecastDefaultDataSeeder.Seed(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.AddInterceptors(new UpdateAuditableInterceptor());
    }
}
