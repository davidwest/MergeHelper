using System.Diagnostics;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeWithoutUpdates
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo Merge Without Updates *****\n");
            
            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities();

            source.Display("Source DTOs");
            destination.Display("Destination entities");

            var result =
                source.Merge(destination, 
                    getKeyFromSource:src => src.GetEntityId(), 
                    getKeyFromDest:dest => dest.Id, 
                    mapAdd:src => new Person(src.GetEntityId(), src.Name));
            
            result.Display("Result entities");
        }
    }
}
