using Contact_Test.ModelFactory.Interface;
using Contact_Test.Models;
using Contact_Test.Repository;
using System;
using System.Linq;

namespace Contact_Test.ModelFactory
{
    public class ContactModelFactory : IContactModelFactory
    {
        private IContactRepository _contactRepository;
        public ContactModelFactory(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public ContactModel PrepareContactModel(ContactModel model)
        {
            model.CountryList = _contactRepository.GetCountries().Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = s.CountryName,
                Value = s.Id.ToString()

            }).ToList();
            model.CountryList.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "--Select County--", Value = "" });
            model.GenderList = Enum.GetValues(typeof(Enums.Gender)).Cast<Enums.Gender>().ToList().Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = s.ToString(),
                Value = ((int)s).ToString()
            }).ToList();
            return model;
        }
    }
}
