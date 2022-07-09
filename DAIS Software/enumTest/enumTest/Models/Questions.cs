namespace enumTest.Models
{
    public class Questions
    {
        public int Id { get; set; }

        public List<Answears> Answears { get; set; } = new List<Answears>();
    }
}
