using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.DEMO.DataProvider.Interfaces
{
    public interface IBillingProvider
    {
        BillingInfo GetBillingInfo(User user);
    }
}
