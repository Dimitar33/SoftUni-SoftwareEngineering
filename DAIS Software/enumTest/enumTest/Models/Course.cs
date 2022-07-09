namespace enumTest.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StudentsCount => Students.Count();
        public List<Modules> Modules { get; set; } = new List<Modules>();

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
