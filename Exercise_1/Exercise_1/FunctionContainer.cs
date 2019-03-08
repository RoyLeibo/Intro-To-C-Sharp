using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class FunctionContainer
    {
        Dictionary<String, Func<double, double>> funcList;

        public FunctionContainer()
        {
            funcList = new Dictionary<String, Func<double, double>>() ;
        }

        public void setNewFunc(String key, Func<double, double> value)
        {
            this.funcList[key] = value;
        }

        public Func<double, double> getFunc(String key)
        {
            return this.funcList[key];
        }
    }
}
