using System;

namespace MSDEVMTL.DEMO.DTO
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                return (int)DateTime.Now.Subtract(BirthDate).TotalDays/365;
            }
        }
    }
}
