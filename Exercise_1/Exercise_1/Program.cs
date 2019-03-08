using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionContainer fc = new FunctionContainer();
            fc.setNewFunc("Double", Double);
            Func<double, double> thisFunc = fc.getFunc("Double");
            Console.WriteLine(thisFunc(2));
        }

        static double Double(double a)
        {
            return a * 2;
        }
    }
}
