using System;

namespace MSDEVMTL.DEMO.DTO
{
    public class UserAccount
    {
        public string Username { get; private set; }

        private readonly string _password;

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime AccountExpiration { get; set; }

        public User User { get; private set; }

        public UserAccount(string username, string password, User linkedUser)
        {
            Username = username;
            _password = password;
            User = linkedUser;
        }

        public bool ValidatePassword(string password)
        {
            return  _password == password;
        }
    }
}
