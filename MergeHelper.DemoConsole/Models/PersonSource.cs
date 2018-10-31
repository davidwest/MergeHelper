namespace MergeHelper.DemoConsole.Models
{
    public static class PersonEntitySource
    {
        public static Person[] GetPersonEntities()
        {
            return new[]
            {
                new Person(1, "Ralph"),
                new Person(2, "Claire"),
                new Person(3, "Jill"),
                new Person(4, "Mark"),
                new Person(5, "Mary"),
                new Person(6, "Clark"),
                new Person(7, "Chris"),
                new Person(8, "Jim"),
                new Person(9, "Sheila"),
                new Person(10, "Shannon") 
            };
        }
    }
}
