using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Triangle
    {
        public int a;
        public int b;
        public int c;

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            if (this.a == 0)
                this.a = 1;

            this.b = b;
            if (this.b == 0)
                this.b = 1;
           
            this.c = c;
            if (this.c == 0)
                this.c = 1;
        }

        public bool IsTriangle()
        {
            return (a + b > c && b + c > a && a + c > b) ? true : false;
        }
    }
}
