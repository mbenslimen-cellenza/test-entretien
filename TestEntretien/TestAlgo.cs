using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TestEntretien
{
    public class TestAlgo
    {

        /// <summary>
        /// grouper les anagrammes 
        /// 10 min
        /// </summary>
        public static void GroupAnagram()
        {
            Console.WriteLine("GroupAnagram start");
            string[] input = { "reza","eat", "tea", "tan", "ate", "nat", "bat", "bta", "azer" };


            var orderdByList = input.Select(s =>
            {
                var chars = s.ToCharArray().OrderBy(c=>c).ToArray();

                return new {original = s, formatted = string.Join("", chars)};
            });

            var groupedItems = orderdByList.GroupBy(str => str.formatted);

            foreach (var grouped in groupedItems)
            {
                Console.WriteLine(grouped.Key);

                foreach (var item in grouped)
                {
                    Console.WriteLine($"    -  {item.original}");
                }
            }

        }

        public static void SortInt()
        {
            int[] numbers = Enumerable.Range(0, 10).OrderBy(xp => Guid.NewGuid()).ToArray();
           
           
            



            Console.WriteLine(string.Join(",", numbers));
           
        }


        /// <summary>
        /// Reconstruire une liste en fusionnant les infos, de manière performante ( < 200ms pour 100_000 itérations)
        /// 10 min
        /// </summary>
        public static void PerfSeach()
        {
            int count = 100_000;
            IEnumerable<(string Id, string Name)> persons = Enumerable.Range(0, count)
                .Select(i =>  (i.ToString(), $"username_{i}"));

            IEnumerable<(string Id, string Email)> persons2 = Enumerable.Range(0, count)
                .Select(i => (i.ToString(),  $"mail_{i}@citeo.com" ));

            List<(string Id, string Email, string Name)> result = new List<(string Id, string Email, string Name)>();
            Stopwatch watch = Stopwatch.StartNew();

            // 
            Console.WriteLine(watch.Elapsed.TotalSeconds);


        }
    }
}
