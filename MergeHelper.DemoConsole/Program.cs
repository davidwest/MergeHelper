using System;

namespace MergeHelper.DemoConsole
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Starting");

            DemoMerge.Start();
            DemoMergeWithEvents.Start();
            DemoMergeWithConditionals.Start();
            DemoMergeWithoutUpdates.Start();
            DemoMergeAddOrUpdate.Start();
            DemoMergeAdd.Start();

            DemoMergeInto.Start();
            DemoMergeIntoWithEvents.Start();
            DemoMergeIntoWithConditionals.Start();
            DemoMergeIntoWithoutUpdates.Start();
            DemoMergeAddOrUpdateInto.Start();
            DemoMergeAddInto.Start();

            DemoControlMerge.Start();
            DemoControlMergeParallel.Start();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
