using System;
using MSDEVMTL.DEMO.DataProvider.Interfaces;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.DEMO.DataProvider
{
    public class BillingProvider : IBillingProvider
    {
        public BillingInfo GetBillingInfo(User user)
        {
            throw new Exception("Billing Repository is unavailable!");
            //Normally we'd call our repository to get this object
        }
    }
}
