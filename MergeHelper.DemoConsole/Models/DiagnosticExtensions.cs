using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MergeHelper.DemoConsole.Models
{
    public static class DiagnosticExtensions
    {
        public static void Display(this IEnumerable<PersonDto> people, string title)
        {
            var builder = new StringBuilder();

            foreach (var person in people)
            {
                builder.AppendLine($"   {person.Id, -6} {person.Name}");
            }

            Debug.WriteLine($"--- {title} ---");
            Debug.WriteLine(builder);
        }

        public static void Display(this IEnumerable<Person> people, string title)
        {
            var builder = new StringBuilder();

            foreach (var person in people)
            {
                builder.AppendLine($"   {person.Id,-6} {person.Name}");
            }

            Debug.WriteLine($"--- {title} ---");
            Debug.WriteLine(builder);
        }
    }
}
