using System.Diagnostics;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoMergeAddOrUpdate
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo MergeAddOrUpdate *****\n");

            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities();

            source.Display("Source DTOs");
            destination.Display("Destination entities");

            var result =
                source.MergeAddOrUpdate(destination, 
                    getKeyFromSource:src => src.Id, 
                    getKeyFromDest:dest => dest.Id, 
                    mapAdd:src => new Person(src.Id, src.Name), 
                    mapUpdate:(src,dest) => new Person(src.Id, src.Name));
            
            result.Display("Result entities");
        }
    }
}
