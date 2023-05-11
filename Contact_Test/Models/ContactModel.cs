using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact_Test.Models
{
    public class ContactModel : BaseModel
    {
        public ContactModel()
        {
            CountryList = new List<SelectListItem>();
            GenderList = new List<SelectListItem>();
        }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress), Remote(controller: "Home", action: "IsEmailExists", AdditionalFields = nameof(Id))]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber), Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ProfileImage { get; set; }
        [Required]
        public int Gender { get; set; }
        public IList<SelectListItem> CountryList { get; set; }
        public IList<SelectListItem> GenderList { get; set; }
    }
}
