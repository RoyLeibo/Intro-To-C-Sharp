using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate;
        private List<Func<double, double>> funcList;
        private String name;
        public String Name
        {
            get
            {
                return name;
            }
        }
        private String type;
        public String Type
        {
            get
            {
                return type;
            }
        }

        public ComposedMission(String name)
        {
            this.name = name;
            this.type = "Composed";
            this.funcList = new List<Func<double, double>>();
        }

        public ComposedMission Add(Func<double,double> newFunc)
        {
            this.funcList.Add(newFunc);
            return this;
        }

        public double Calculate(double value)
        {
            OnCalculate?.Invoke(this, value);
            double result = value;
            int counter = 0;
            foreach (var func in this.funcList)
            {
                counter++;
                Console.Write($"This is function {this.name} with the parameter {result}");
                result = func(result);
                Console.WriteLine($" and the result is {result}");
            }
            return result;
        }
    }
}
