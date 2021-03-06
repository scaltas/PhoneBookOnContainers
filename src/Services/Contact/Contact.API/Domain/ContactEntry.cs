namespace Contact.API.Domain
{
    public class ContactEntry
    {
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Company { get; set; } = null!;
        public List<ContactInfo> ContactInfos { get; set; } = null!;

    }
}
