using System;
using Microsoft.Practices.Unity;
using MSDEVMTL.DEMO.DataProvider;
using MSDEVMTL.DEMO.DataProvider.Interfaces;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.Demo.Main.Service
{
    public class AuthenticationService
    { 
    //    private AccountProvider _provider;

    //    public IAccountProvider AccountProvider
    //    {
    //        get
    //        {
    //            if (_provider != null)
    //                return _provider;

    //            _provider = new AccountProvider();
    //            return _provider;
    //        }
    //    }

#region Alternate injection
        //[Dependency]
        public IAccountProvider AccountProvider { get; set; }
#endregion

        /// <summary>
        /// Valider un utilisateur
        /// </summary>
        public bool ValidateUser(string nomUtilisateur, string motDePasse)
        {
            var authenticated = AccountProvider.AuthenticateUserAccount(nomUtilisateur, motDePasse);

            if (!authenticated) 
                return false;

            var user = AccountProvider.GetUserAccountByUsername(nomUtilisateur);

            if (!IsUserValid(user)) 
                throw new InvalidUserException();

            return true;
        }

        public bool IsUserValid(UserAccount accountToValidate)
        {
            bool isExpired = accountToValidate.AccountExpiration > DateTime.Now;

            return isExpired && accountToValidate.IsActive;
        }

        public Membership GetAccountMembershipByAccount(IMembershipProvider provider, UserAccount account)
        {
            return provider.GetMembershipByAccount(account);
        }
    }
}
