using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Contact_Test.Models
{
    public class ContactModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress), Remote(controller: "Home", action: "IsEmailExists", AdditionalFields = nameof(Id))]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
