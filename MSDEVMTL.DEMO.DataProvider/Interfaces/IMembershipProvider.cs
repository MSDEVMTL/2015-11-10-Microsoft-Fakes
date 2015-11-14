using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.DEMO.DataProvider.Interfaces
{
    public interface IMembershipProvider
    {
        Membership GetMembershipByAccount(UserAccount account);
    }
}
