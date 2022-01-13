namespace Contact.API.Model
{
    public class Contact
    {
        public Guid UUId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }

    }
}
