using System.Diagnostics;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeAdd
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo MergeAdd *****\n");
            
            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities();

            source.Display("Source DTOs");
            destination.Display("Destination entities");

            var result =
                source.MergeAdd(destination, 
                    getKeyFromSource:src => src.Id, 
                    getKeyFromDest:dest => dest.Id, 
                    mapAdd:src => new Person(src.Id, src.Name));

            result.Display("Result entities");
        }
    }
}
