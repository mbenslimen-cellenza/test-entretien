using System;
using TestEntretien.Refactoring;
namespace TestEntretien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting..");

            // TestAlgo.GroupAnagram();
            TestLinq.IndexAddition();
            //TestRefacto_3.Run();

            Console.WriteLine("complete");
            Console.ReadLine();
        }
    }
}
