using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDEVMTL.Demo.Main.Service;
using MSDEVMTL.DEMO.DataProvider;
using MSDEVMTL.DEMO.DataProvider.Interfaces;
using MSDEVMTL.DEMO.DataProvider.Interfaces.Fakes;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.Demo.Test.Service
{
    [TestClass]
    public class AuthenticationServiceTest
    {
        private AuthenticationService _service;

        [TestMethod]
        public void GetAccountMembershipByAccount_InvalidUser_MembershipReturned()
        {
            //ARRANGE
            _service = new AuthenticationService();
            IMembershipProvider provider = new StubIMembershipProvider()
            {
                GetMembershipByAccountUserAccount = account => new Membership(new UserAccount("","",new User()))
            };
            //ACT
            var result = _service.GetAccountMembershipByAccount(provider, new UserAccount("VaultBoy", "Fallout", new User()));
            //ASSERT
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ValidateUser_NotASatisfyingTest_UserInvalidated()
        {
            //ARRANGE
            _service = new AuthenticationService();
            //ACT
            var result = _service.ValidateUser("VaultBoy", "Fallout");
            //ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateUser_ValidUser_UserValidated()
        {
            //ARRANGE
            _service = new AuthenticationService();
            _service.AccountProvider = new StubIAccountProvider()
            {
                AuthenticateUserAccountStringString = (s, s1) => true,
                GetUserAccountByUsernameString = s => new UserAccount("", "", new User())
                {
                    AccountExpiration = DateTime.Now.AddDays(10),
                    IsActive = true
                }
            };
            //ACT
            var result = _service.ValidateUser("VaultBoy", "Fallout");
            //ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserException))]
        public void ValidateUser_InvalidUser_WithException()
        {
            //ARRANGE
            _service = new AuthenticationService
            {
                AccountProvider = new StubIAccountProvider()
                {
                    AuthenticateUserAccountStringString = (s, s1) => true,
                    GetUserAccountByUsernameString = s => new UserAccount("", "", new User())
                    {
                        AccountExpiration = DateTime.Now.AddDays(-10)
                    }
                }
            };
            //ACT
            _service.ValidateUser("VaultBoy", "Fallout");
        }
    }
}
