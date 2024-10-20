namespace CleanArchitecture.Template.Application.Users.Services.Authentication
{
    public interface IUserPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string passwordHash);
    }
}
