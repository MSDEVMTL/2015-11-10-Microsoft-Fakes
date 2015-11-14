using System;
using MSDEVMTL.DEMO.DTO;

namespace MSDEVMTL.DEMO.DataProvider
{
    public class UserProvider
    {
        public User GetUserName(string firstname, string lastname)
        {
            throw new Exception("Data Repository is unavailable!");
            //Normally we'd call our repository to get this object
        }

        public string GetUserGeneration(User userToPutInCategory)
        {
            if ((DateTime.Now.Subtract(new DateTime(2005, 1, 1)).TotalDays / 365) > 20)
                throw new Exception("There should be a new generation!");

            if (userToPutInCategory.Age >= 70)
                return "Greatest Generation";
            if (userToPutInCategory.Age > 50 && userToPutInCategory.Age < 70)
                return "Baby Boomer";
            if (userToPutInCategory.Age > 30 && userToPutInCategory.Age <= 50)
                return "Gen X";
            if (userToPutInCategory.Age > 10 && userToPutInCategory.Age <= 30)
                return "Millenials";
            if (userToPutInCategory.Age <= 10)
                return "TBD";

            return string.Empty;
        }
    }
}
