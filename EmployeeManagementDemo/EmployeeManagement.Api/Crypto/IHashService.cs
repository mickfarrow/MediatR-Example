namespace EmployeeManagement.Api.Crypto
{
    public interface IHashService
    {
        UserAuth GenerateSaltedPasswordHash(string password);
        UserAuth SaltAndHashPassword(string password, string salt);
    }
}