using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDIct
{

    class Program
    {
        static void Main(string[] args)
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD[10] = 11;
            BTD[-1] = 0;
            var keys = BTD.Keys;
            var dic = new Dictionary<int, int>();
            dic[0] = 1;
            dic[10] = 11;
            dic[-1] = 0;
            Console.WriteLine(dic.Count);
            //foreach (var k in keys)
            //    Console.WriteLine(k);
            Console.ReadKey();
        }
    }
}
