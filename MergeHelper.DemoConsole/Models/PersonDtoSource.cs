namespace MergeHelper.DemoConsole.Models
{
    public static class PersonDtoSource
    {
        public static PersonDto[] GetPersonDtos()
        {
            return new[]
            {
                new PersonDto{Name = "Alex Thomas"},
                new PersonDto{Name = "Marcia Adams"},
                new PersonDto{Name = "Larry Shuman"},
                new PersonDto{Id = 1, Name = "Ralph Weller"},
                new PersonDto{Id = 2, Name = "Claire Morgan"},
                new PersonDto{Id = 3, Name = "Jill Hughes"},
                new PersonDto{Id = 5, Name = "Mary Butler"},
                new PersonDto{Id = 6, Name = "Clarke Henderson"},
                new PersonDto{Id = 7, Name = "Christopher Patterson"},
                new PersonDto{Id = 8, Name = "James Carter"},
                new PersonDto{Id = 9, Name = "Sheila Sanchez"}
            };
        }
    }
}
