using System;

namespace MSDEVMTL.DEMO.DTO
{
    public class Membership
    {
        public DateTime CreationDate { get; private set; }
        public DateTime Update { get; private set; }
        private string _type ;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                Update = DateTime.Now;
            }
        }

        public Membership(UserAccount account)
        {
            CreationDate = DateTime.Now;
            Update = DateTime.Now;
            RelatedUserAccount = account;
        }

        public UserAccount RelatedUserAccount { get; private set; }
    }
}
