using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Triangle
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            return (a + b > c && b + c > a && a + c > b);
        }   
    }
}
