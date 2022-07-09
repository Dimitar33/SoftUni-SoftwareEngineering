namespace enumTest.Models
{
    public class Userr
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Roles> Roles { get; set; } = new List<Roles>();
    }
}
