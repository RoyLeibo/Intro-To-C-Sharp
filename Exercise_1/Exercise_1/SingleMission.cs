using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    // This class handles a single mission.
    // In it's constructor it gets the mission name and the function defines it.
    // The class inherits the "IMission" interface and it's "Calculate"
    // function activates the function stored from the constructor.

    class SingleMission : IMission
    {
        public event EventHandler<double> OnCalculate; // event handler
        private Func<double, double> thisFunc; // pointer to the mission function
        private String name; // the mission name
        public String Name // the name property
        {
            get
            {
                return this.name;
            }
        }
        private String type; // the mission type
        public String Type // the type property
        { 
            get
            {
                return this.type;
            }
        }

        // the class's constructor. It's parameter is the mission name and the
        // function the mission should contain.
        public SingleMission(Func<double, double> thisFunc, String name)
        {
            this.name = name;
            this.type = "Single";
            this.thisFunc = thisFunc;
        }

        // When this function is activate it activates the function from
        // it's member.
        public double Calculate(double value)
        {
            double result = this.thisFunc(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}