using System.Diagnostics;
using System.Linq;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeIntoWithConditionals
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo MergeInto With Conditionals *****\n");
            
            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities().ToList();

            source.Display("Source DTOs");
            destination.Display("Destination entity collection (before merge)");

            new InPlacePersonMerger()
                .FromSource(source)
                .OnAdding(src => !src.Name.StartsWith('A'))
                .OnDeleting(dest => !dest.Name.StartsWith('S'))
                .MergeInto(destination);

            destination.Display("Destination entity collection (after merge)");
        }
    }
}
