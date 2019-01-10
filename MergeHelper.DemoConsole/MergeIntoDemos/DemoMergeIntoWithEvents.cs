using System.Diagnostics;
using System.Linq;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeIntoWithEvents
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo MergeInto With Events *****\n");

            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities().ToList();

            source.Display("Source DTOs");
            destination.Display("Destination entity collection (before merge)");
            
            new InPlacePersonMerger()
                .FromSource(source)
                .OnAdding(src => Debug.WriteLine($"Adding :   {src.Name}"))
                .OnDeleting(dest => Debug.WriteLine($"Deleting : {dest.Name}"))
                .MergeInto(destination);
            
            destination.Display("Destination entity collection (after merge)");
        }
    }
}
