using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDEVMTL.DEMO.DataProvider;
using MSDEVMTL.DEMO.DTO;
using Microsoft.QualityTools.Testing.Fakes;
using System.Fakes;

namespace MSDEVMTL.Demo.Test.DataProvider
{
    [TestClass]
    public class UserProviderTest
    {
        private UserProvider _provider;
        private User _user;

        [TestInitialize]
        private void Init()
        {
            _provider = new UserProvider();
            _user = new User
            {
                FirstName = "Vault",
                LastName = "Boy",
                BirthDate = DateTime.Now.AddYears(-37)
            };
        }

        [TestMethod]
        public void GetUserGeneration_ValidUser_GenerationObtained()
        {
            //ARRANGE
            //ACT
            //ASSERT
        }

        [TestMethod]
        [TestCategory("Shim")]
        public void GetUserGeneration_GenerationalTimeExceeded_WithException()
        {
            using (ShimsContext.Create())
            {
                ShimDateTime.NowGet = () => new DateTime(2035, 1, 1);
                //ARRANGE
                User user = new User()
                {
                    BirthDate = DateTime.Now.AddYears(-5)
                };
                UserProvider provider = new UserProvider();
                //ACT
                var gen = provider.GetUserGeneration(user);
                //ASSERT
                Assert.AreEqual("Millenials", gen);
            }
        }

    }
}
