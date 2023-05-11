using AutoMapper;
using Contact_Test.Data;
using Contact_Test.Models;
using Contact_Test.Repository.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Contact_Test.Repository
{
    public class ContactRepository : IContactRepository
    {
        private IRepository<Contact> _contactRepository;
        private IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;
        public ContactRepository(IRepository<Contact> repository, IMapper mapper, IRepository<Country> countryrepo)
        {
            _contactRepository = repository;
            _mapper = mapper;
            _countryRepository = countryrepo;

        }
        public bool AddContact(ContactModel model)
        {
            if (model == null) throw new System.Exception(nameof(model));
            var contact = _mapper.Map<Contact>(model);
            _contactRepository.Insert(contact);
            return true;
        }
        public bool UpdateContact(ContactModel model)
        {
            if (model == null) throw new System.Exception(nameof(model));
            var contact = _mapper.Map<Contact>(model);
            _contactRepository.Update(contact);
            return true;
        }
        public bool DeleteContact(int id)
        {
            if (id == 0) throw new System.Exception(nameof(id));

            var contact = _contactRepository.Get(id);
            if (contact == null) throw new System.Exception(nameof(contact));
            _contactRepository.Delete(contact);
            return true;
        }
        public ContactModel GetContact(int id)
        {
            return _mapper.Map<ContactModel>(_contactRepository.Get(id));

        }
        public IEnumerable<ContactModel> GetContacts()
        {
            return _mapper.Map<IEnumerable<ContactModel>>(_contactRepository.GetAll());
        }
        public bool IsEmailExists(string email, int id)
        {
            return _contactRepository.GetAll().Any(d => d.Email == email && d.Id != id);
        }
        public IEnumerable<Country> GetCountries()
        {
            var contry = _countryRepository.GetAll();
            return contry;
        }
    }
}
