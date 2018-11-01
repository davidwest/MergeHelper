namespace MergeHelper.DemoConsole.Models
{
    public static class MappingExtensions
    {
        public static int GetEntityId(this PersonDto person)
        {
            return string.IsNullOrWhiteSpace(person.Id) ? 0 : int.Parse(person.Id);
        }
    }
}
