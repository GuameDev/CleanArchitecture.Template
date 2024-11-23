namespace CleanArchitecture.Template.Application.Users.Queries.GetById.DTOs
{
    public record GetUserByIdResponse(
        Guid Id,
        string Username,
        string Email,
        string FirstName,
        string LastName1,
        string? LastName2,
        bool IsActive)
    {
        public IEnumerable<string> Roles { get; set; } = [];
        public IEnumerable<string> Permissions { get; set; } = [];
    }
}
