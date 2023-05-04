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
        private IRepository<Contact> _repository;
        private readonly IMapper _mapper;
        public ContactRepository(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public bool AddContact(ContactModel model)
        {
            if (model == null) throw new System.Exception(nameof(model));
            var contact = _mapper.Map<Contact>(model);
            _repository.Insert(contact);
            return true;
        }
        public bool UpdateContact(ContactModel model)
        {
            if (model == null) throw new System.Exception(nameof(model));
            var contact = _mapper.Map<Contact>(model);
            _repository.Update(contact);
            return true;
        }
        public bool DeleteContact(int id)
        {
            if (id == 0) throw new System.Exception(nameof(id));

            var contact = _repository.Get(id);
            if (contact == null) throw new System.Exception(nameof(contact));
            _repository.Delete(contact);
            return true;
        }
        public ContactModel GetContact(int id)
        {
            var contact = _repository.Get(id);
            return _mapper.Map<ContactModel>(contact);
        }
        public IEnumerable<ContactModel> GetContacts()
        {
            return _mapper.Map<IEnumerable<ContactModel>>(_repository.GetAll());
        }
        public bool IsEmailExists(string email, int id)
        {
            return _repository.GetAll().Any(d => d.Email == email && d.Id != id);
        }
    }
}
