using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    // This is the interface which define how a mission
    // should behave.
    public interface IMission
    {
        event EventHandler<double> OnCalculate; // the event handler 

        String Name { get; } // the mission name
        String Type { get; } // the mission type

        double Calculate(double value); // the function which activate the mission
    }
}
