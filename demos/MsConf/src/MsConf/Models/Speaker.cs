namespace MsConf.Models
{
    public class Speaker
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        public string Bio { get; set; }
        public string Picture { get; set; }
        public string Website { get; set; }
    }
}
