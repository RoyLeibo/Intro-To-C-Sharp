using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    public interface IMission
    {
        

        String Name { get; }
        String Type { get; }

        double Calculate(double value);
    }
}
