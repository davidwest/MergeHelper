using System.Diagnostics;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeWithEvents
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo Merge With Events *****\n");

            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities();

            source.Display("Source DTOs");
            destination.Display("Destination entities");

            var result = 
                source.Merge(destination, 
                    getKeyFromSource: src => src.Id, 
                    getKeyFromDest: dest => dest.Id, 
                    mapAdd: src => new Person(src.Id, src.Name), 
                    mapUpdate: (src,dest) => new Person(src.Id, src.Name), 
                    onAdding: src => Debug.WriteLine($"Adding :   {src.Name}"),
                    onUpdating: (src, dest) => Debug.WriteLine($"Updating : {dest.Name} => {src.Name}"),
                    onDeleting: dest => Debug.WriteLine($"Deleting : {dest.Name}"));

            result.Display("Result entities");
        }
    }
}
