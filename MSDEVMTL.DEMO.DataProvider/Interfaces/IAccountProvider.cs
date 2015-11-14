using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.DEMO.DataProvider.Interfaces
{
    public interface IAccountProvider
    {
        bool AuthenticateUserAccount(string username, string password);
        UserAccount GetUserAccountByUsername(string username);
    }
}
