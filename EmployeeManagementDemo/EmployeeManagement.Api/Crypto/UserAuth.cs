namespace EmployeeManagement.Api.Crypto
{
    public class UserAuth
    {
        public string Password { get; set; }
        public string Salt { get; set; }
        public UserAuth() { }
    }
}
