using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class FunctionContainer
    {
        private Dictionary<String, Func<double,double>> functionsContainer;
        public Dictionary<String, Func<double, double>> FunctionsContainer
        {
            get
            {
                return this.functionsContainer;
            }
        }

        public Func<double, double> this[String key]
        {
            get
            {
                if (functionsContainer.ContainsKey(key))
                {
                    return functionsContainer[key];
                }
                else
                {
                    return this.DoNothing;
                }
            }
            set
            {
                functionsContainer.Add(key, value);
            }
        }

        double DoNothing(double x)
        {
            return x;
        }

        public FunctionContainer()
        {
            functionsContainer = new Dictionary<String, Func<double, double>>() ;
        }

        public void setNewFunc(String key, Func<double, double> value)
        {
            this.functionsContainer[key] = value;
        }

        public List<String> getAllMissions()
        {
            List<String> FunctionsList = new List<string>();
            for (int i = 0; i < this.functionsContainer.Count; i++)
            {
                FunctionsList.Add(functionsContainer.ElementAt(i).Key);
            }
            return FunctionsList;
        }

        public Func<double, double> getFunc(String key)
        {
            return this.functionsContainer[key];
        }
    }
}
