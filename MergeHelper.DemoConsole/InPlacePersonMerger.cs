using MergeHelper.DemoConsole.Models;

namespace MergeHelper.DemoConsole
{
    public class InPlacePersonMerger : InPlaceMerger<PersonDto, Person, int>
    {
        public InPlacePersonMerger()
        {
            WithSourceKey(src => src.GetEntityId())
            .WithDestKey(dest => dest.Id)
            .MapAdd(src => new Person(src.GetEntityId(), src.Name))
            .Update((src, dest) => dest.Name = src.Name);
        }
    }
}
