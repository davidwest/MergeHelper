namespace MergeHelper.DemoConsole.Models
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; set; }

        public bool IsNew => Id == default(int);
    }
}
