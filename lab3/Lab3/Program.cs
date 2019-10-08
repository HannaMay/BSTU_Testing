using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = new Triangle(-20, 10, 40);
            Console.WriteLine("Sides: " + i.a + " "+ i.b+ " "  + i.c);

        }
    }
}
