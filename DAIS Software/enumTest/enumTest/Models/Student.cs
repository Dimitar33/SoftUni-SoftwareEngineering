namespace enumTest.Models
{
    public class Student : Userr
    {
        public int Id { get; set; }
        public string Nam2e { get; set; }

        public List<Scores> Scores { get; set; } = new List<Scores>();
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
