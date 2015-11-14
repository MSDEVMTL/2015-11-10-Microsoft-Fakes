using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.QualityTools.Testing.Fakes.Shims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDEVMTL.DEMO.DataProvider.Fakes;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.Demo.Test.DataProvider
{
    [TestClass]
    public class AccountProviderTest
    {
        private UserAccount _account;
        private const string Username = "Utilisateur1";
        private const string Password = "12345";

        [TestInitialize]
        private void Init()
        {
            _account = new UserAccount(Username, Password, new User())
            {
                AccountExpiration = DateTime.Now.AddMonths(3),
                IsActive = true
            };
        }

        [TestMethod]
        public void IsUserValid_ValidAccount_AccountValidated()
        {
            //ARRANGE
            //ACT
            //ASSERT
        }

        [TestMethod]
        public void Execute_ShimDemo_MethodIntercepted()
        {
            //ARRANGE
            using (ShimsContext.Create())
            {
                ShimAccountProvider provider = new ShimAccountProvider
                {
                    TestForExtremeCircumstances = () => true,
                    InstanceBehavior = ShimBehaviors.Fallthrough
                };
                //ACT
                var result = provider.Instance.Execute();
                //ASSERT
                Assert.IsTrue(result);
            }
        }
    }
}
