using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class SingleMission : IMission
    {
        private Func<double, double> thisFunc;
        private String name;
        public String Name
        {
            get
            {
                return name;
            }
        }
        private String type;
        public String Type {
            get
            {
                return type;
            }
        }
        
        public SingleMission(Func<double, double> thisFunc, String name)
        {
            this.name = name;
            this.type = "Single";
            this.thisFunc = thisFunc;
        }

        public double Calculate(double value)
        {
            Console.WriteLine($"This is {this.name} with the value {value} and the result of {this.thisFunc(value)}");
            return this.thisFunc(value);
        }
    }
}