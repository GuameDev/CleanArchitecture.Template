using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Users.Repository;
using CleanArchitecture.Template.Application.WeatherForecasts.Repository;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;

        public IWeatherForecastRepository WeatherForecastRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IWeatherForecastRepository weatherForecastRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _context = context;
            WeatherForecastRepository = weatherForecastRepository;
            UserRepository = userRepository;
            RoleRepository = roleRepository;
            RefreshTokenRepository = refreshTokenRepository;
        }



        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            // In EF Core, there's no direct rollback mechanism.
            // Just don't call CommitAsync, and the transaction will not be saved.
            return Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
