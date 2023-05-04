using System;

namespace Contact_Test.Models
{
    public class BaseModel
    {
        public int Id
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        } = DateTime.Now;
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
    }
}
