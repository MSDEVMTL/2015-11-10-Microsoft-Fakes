using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSDEVMTL.Demo.Main.Service;
using MSDEVMTL.DEMO.DataProvider.Fakes;
using MSDEVMTL.DEMO.DataProvider.Interfaces;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.Demo.Test.Service
{
    [TestClass]
    public class UserServiceTest
    {
        private UserService _service;

        [TestMethod]
        public void GetBillingInfoByUser_ValidUser_BillingInfoReturned()
        {
            //Arrange
            _service = new UserService();

            IBillingProvider provider = new StubBillingProvider();
            _service.Container.RegisterInstance(provider);
            //Act
            var resultat = _service.GetBillingInfoByUser(new User());
            //Assert
            Assert.IsNotNull(resultat);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetBillingInfoByUser_ValidUser_WithException()
        {
            //Arrange
            _service = new UserService();
            
            //_service.Container.RegisterInstance<IBillingProvider>(null);
            //Act
            _service.GetBillingInfoByUser(new User());
        }
    }
}
