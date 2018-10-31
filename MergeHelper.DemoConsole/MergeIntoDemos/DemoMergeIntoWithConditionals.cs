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
            
            source.MergeInto(destination, 
                getKeyFromSource: src => src.Id, 
                getKeyFromDest: dest => dest.Id, 
                mapAdd: src => new Person(src.Id, src.Name), 
                update: (src,dest) => dest.Name = src.Name,
                onAdding: src => !src.Name.StartsWith('A'),
                onDeleting: dest => !dest.Name.StartsWith('S'));

            destination.Display("Destination entity collection (after merge)");
        }
    }
}
