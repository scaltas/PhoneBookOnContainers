using AutoMapper;
using Contact.API.Domain;

namespace Contact.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewContact, ContactEntry>().ReverseMap();
        }
    }
}
