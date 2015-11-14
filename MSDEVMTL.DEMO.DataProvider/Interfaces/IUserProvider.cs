using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.DEMO.DataProvider.Interfaces
{
    public interface IUserProvider
    {
        User GetUserByUsername(string username);
        string GetUserGeneration(User userToPutInCategory);
    }
}
