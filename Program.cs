using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static GenAlg GA = new GenAlg();

        static void Main(string[] args)
        {
            GA.Func = (x) => { return x * x + 4; };
            GA.Init();
            var result = GA.Process();
            Console.WriteLine("iter: {0}", GA.wag);
            Console.WriteLine("Rezyltat: x = {0}; y = {1}.", result.X, result.Y);
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
