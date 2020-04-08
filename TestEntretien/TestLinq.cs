using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEntretien
{
    public class TestLinq
    {
        public static void Sum2List()
        {
            Dictionary<string, int> a = new Dictionary<string, int>()
            {
                {"a",1 },{"b",10},{"c",45}
            };

            Dictionary<string, int> b = new Dictionary<string, int>()
            {
                {"a",10 },{"c",22},{"b",7896}
            }; 
        }

        /// <summary>
        /// retourner la liste des sommes de chaque index des 3 listes
        /// </summary>
        public static void IndexAddition()
        {
            List<List<int>> datas = new List<List<int>>()
            {
                new List<int>() { 1, 10, 20, 30, 45, 75 },
                new List<int>() { 45, 2, 1, 4, 2, 2, 100 },
                new List<int>() { 45, 2, 1, 4, 2, 2 }
            };

            var result = datas.Select( (row,index) => new { index , row} );

            
        }

        /// <summary>
        /// Fusionner toutes les intervalles qui se chevauchent, en utilisant LINQ
        /// </summary>
        public static void MergeInterval()
        {
            List<int[]> intervals = new List<int[]>()
            {
                new int[]{ 1, 3 },
                new int[]{ 2, 6},
                new int[]{ 8, 10 },
                new int[]{ 15, 18 },
                new int[]{ 16, 19 },
                new int[]{ 17, 25 },
            };
            List<int[]> result = new List<int[]>();
        }
    }
}
