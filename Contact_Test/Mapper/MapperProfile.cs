using AutoMapper;
using Contact_Test.Data;
using Contact_Test.Models;

namespace Contact_Test.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, ContactModel>();
            CreateMap<ContactModel, Contact>();

        }
    }
}
