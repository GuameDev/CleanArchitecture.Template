namespace CleanArchitecture.Template.Application.User.Services
{
    public interface IUserPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string passwordHash);
    }
}
