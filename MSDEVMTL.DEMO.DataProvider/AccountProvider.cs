using System;
using System.Collections.Generic;
using MSDEVMTL.DEMO.DataProvider.Interfaces;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.DEMO.DataProvider
{
    public class AccountProvider : IAccountProvider
    {
        private const string Username = "Utilisateur1";
        private const string Password = "12345";

        private readonly Dictionary<string, UserAccount> _userAccountRegistry;

        public AccountProvider()
        {
            _userAccountRegistry = new Dictionary<string, UserAccount>
            {
                {
                    Username, new UserAccount(Username, Password, new User())
                }
            };
            //We could be making a call here to verify that our repository is available
        }

        public UserAccount GetUserAccountByUsername(string username)
        {
            throw new Exception("Date Repository is unavailable!");
            //Normally, we'd be getting this from our repository
        }

        public bool AuthenticateUserAccount(string username, string password)
        {
            //Normalement, on accederais à la base de donnée
            if (!_userAccountRegistry.ContainsKey(username))
                return false;

            UserAccount account;

            if (!_userAccountRegistry.TryGetValue(username, out account))
                return false;

            return account.ValidatePassword(password);
        }

        public bool Execute()
        {
            if (!TestForExtremeCircumstances())
            {
                return false;
            }

            return true;
        }

        private bool TestForExtremeCircumstances()
        {
            throw new NotImplementedException();
        }
    }
}
