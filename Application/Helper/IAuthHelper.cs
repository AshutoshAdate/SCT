namespace SCT.Application.Helper
{
    public interface IAuthHelper
    {
        string HashPassword(string plainPassword);
        bool VerifyPassword(string plainPassword, string hashedPassword);
        string GenerateToken(string username, string password);
    }
}
