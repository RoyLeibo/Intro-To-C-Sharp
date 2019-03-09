using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    // This class handles a composed mission.
    // In it's constructor it gets the mission name and
    // every time the user wants to add some function into it
    // he should use the "Add" function and adds it to the function's list.
    // The class inherits the "IMission" interface and it's "Calculate"
    // function activates each function stored in the list.

    class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate; // event handler
        private List<Func<double, double>> funcList; // list of functions
        private String name; // the mission name
        public String Name // the name property
        {
            get
            {
                return name;
            }
        }
        private String type; // the mission type
        public String Type // the type property
        {
            get
            {
                return type;
            }
        }
        // the class's constructor. It's parameter is the mission name
        public ComposedMission(String name)
        {
            this.name = name;
            this.type = "Composed";
            this.funcList = new List<Func<double, double>>();
        }

        // This function gets a new function and adds it into the functions list
        // The function returns the class itself to allow chaining of functions to add.
        public ComposedMission Add(Func<double,double> newFunc)
        {
            this.funcList.Add(newFunc);
            return this;
        }

        // When this function is activate it activates all the functions from
        // the functions list.
        public double Calculate(double value)
        {
            double result = value;
            foreach (var func in this.funcList) // run throw all list
            {
                result = func(result); // calculate the function and keep the result for next iteration
            }
            // if the "OnCalculate" event is not empty, operate each function stored in it.
            OnCalculate?.Invoke(this, result); 
            return result;
        }
    }
}