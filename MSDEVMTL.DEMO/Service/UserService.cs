//using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity;
using MSDEVMTL.DEMO.DataProvider.Interfaces;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.Demo.Main.Service
{
    public class UserService
    {
        public UnityContainer Container { get; private set; }

        [Dependency]
        public IUserProvider Provider { get; set; }

        public UserService() 
        {
            Container = new UnityContainer();
        }

        public string EstablishUserGeneration(User user)
        {
            return Provider.GetUserGeneration(user);
        }

        public BillingInfo GetBillingInfoByUser(User userToQuery)
        {
            IBillingProvider provider = Container.Resolve<IBillingProvider>();

            return provider.GetBillingInfo(userToQuery);
        }
    }
}
