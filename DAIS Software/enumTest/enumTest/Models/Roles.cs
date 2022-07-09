namespace enumTest.Models
{
    public class Roles
    {
        public int Id { get; set; }

        public TypeOfRoles Role { get; set; }
        public List<Userr> Users { get; set; } = new List<Userr>();
    }
}
