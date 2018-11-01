using System.Diagnostics;
using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public static class DemoControlMerge
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo ControlMerge *****\n");

            var source = PersonDtoSource.GetPersonDtos();
            var destination = PersonEntitySource.GetPersonEntities();

            source.Display("Source DTOs");
            destination.Display("Destination entities");

            source.ControlMerge(destination, 
                src => src.GetEntityId(), 
                dest => dest.Id, 
                add: src => Debug.WriteLine($"Adding :   {src.Name}"),
                update: (src, dest) => Debug.WriteLine($"Updating : {dest.Name} => {src.Name}"),
                delete: dest => Debug.WriteLine($"Deleting : {dest.Name}"));
        }
    }
}
