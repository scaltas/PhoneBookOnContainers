namespace Contact.API.Domain
{
    public class ContactInfo
    {
        public ContactType Type { get; set; }
        public string Value { get; set; } = null!;
    }
}