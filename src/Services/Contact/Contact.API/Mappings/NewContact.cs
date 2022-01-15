using Contact.API.Domain;

namespace Contact.API
{
    public class NewContact
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Company { get; set; } = null!;
        public List<ContactInfo> ContactInfos { get; set; } = null!;
    }
}
