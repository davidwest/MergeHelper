using System.Diagnostics;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeWithConditionals
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo Merge With Conditionals *****\n");
            
            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities();

            source.Display("Source DTOs");
            destination.Display("Destination entities");
            
            var result =
                source.Merge(destination, 
                    getKeyFromSource: src => src.GetEntityId(), 
                    getKeyFromDest: dest => dest.Id, 
                    mapAdd: src => new Person(src.GetEntityId(), src.Name), 
                    mapUpdate: (src,dest) => new Person(dest.Id, src.Name), 
                    onAdding: src => !src.Name.StartsWith('A'),
                    onUpdating: (src,dest) => dest.Name != "Jim",
                    onDeleting: dest => !dest.Name.StartsWith('S'));

            result.Display("Result entities");
        }
    }
}
