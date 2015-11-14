using System;
using MSDEVMTL.DEMO.DataProvider.Interfaces;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.DEMO.DataProvider
{
    public class MembershipProvider : IMembershipProvider
    {
        public Membership GetMembershipByAccount(UserAccount account)
        {
            throw new Exception("Data Repository is unavailable!");
            //Normally we'd call our repository to get this object
        }
    }
}
