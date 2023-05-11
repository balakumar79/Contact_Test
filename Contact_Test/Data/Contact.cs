namespace Contact_Test.Data
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Country { get; set; }
        public string PostalCode { get; set; }
        public string ProfileImage { get; set; }
    }
}
