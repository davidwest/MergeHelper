namespace MergeHelper.DemoConsole
{
    public class IntMerger : ControlMerger<int, int>
    {
        public IntMerger()
        {
            WithKey(x => x);
        }
    }
}
