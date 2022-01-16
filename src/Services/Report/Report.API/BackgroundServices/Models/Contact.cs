namespace Report.API.BackgroundServices.Models
{
    public class Contact
    {
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Company { get; set; } = null!;
        public List<ContactInfo> ContactInfos { get; set; } = null!;
    }
}
