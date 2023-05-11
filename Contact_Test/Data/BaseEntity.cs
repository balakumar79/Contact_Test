using System;

namespace Contact_Test.Data
{
    public class BaseEntity
    {
        public int Id
        {
            get;
            set;
        }

        public int? CreatedBy
        {
            get;
            set;
        }

        public DateTime? CreatedDate
        {
            get;
            set;
        } = DateTime.Now;
        public DateTime? ModifiedDate
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
