using Newtonsoft.Json;
using System.Text.Json;
using System.Xml.Serialization;

namespace Task_7._Simple_Json__XML_serilization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            for (int i = 1; i <= 10; i++)
            {
                var person = new Person
                {
                    Name = "person" + i,
                    Age = 20 + i,
                    Address = new Address
                    {
                        Sity = "karlovo" + i,
                        Street = "karlovska" + i,
                        Country = "bulgaria" + i
                    }
                };

                people.Add(person);
            }

            // Json 

            var jsonSerializer = JsonConvert.SerializeObject(people, Formatting.Indented);

            //string jsonSerializer = JsonSerializer.Serialize(people); - also works, but no formatting

            File.WriteAllText("E:\\jsonSrilize.txt", jsonSerializer);

            var jsonDeserialize = JsonConvert.DeserializeObject(File.ReadAllText("E:\\jsonSrilize.txt"));

            Console.WriteLine(jsonDeserialize);

            // Xml 

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));

            using (TextWriter writer = new StreamWriter("E:\\xmlSrilize.txt"))
            {
                xmlSerializer.Serialize(writer, people);
            }



            using (TextReader reader = new StreamReader("E:\\xmlSrilize.txt"))
            {
                var asd = xmlSerializer.Deserialize(reader);

            }

            Console.WriteLine(File.ReadAllText("E:\\xmlSrilize.txt"));
        }
    }
}