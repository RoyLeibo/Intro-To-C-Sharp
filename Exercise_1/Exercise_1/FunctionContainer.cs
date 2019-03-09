using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    // This class is the functions container. It maintains a dictionary
    // with a key of String which represents the function's name and the
    // function itself as value.

    class FunctionsContainer
    {
        private Dictionary<String, Func<double,double>> functionsDict; // the functions dictionary
        public Dictionary<String, Func<double, double>> FunctionsDict // the dictionary property
        {
            get
            {
                return this.functionsDict;
            }
        }

        // This class is an indexer class, which it means that the user can access
        // the class as a data structure, in this case as a dictionary.
        // in this way the user can add data into the dictionary in a single line without
        // a special function for it.

        public Func<double, double> this[String key]
        {
            get
            {
                if (!functionsDict.ContainsKey(key)) // if the dictionary is not contain some key
                {
                    this.functionsDict[key] = val => val; // add this key with a function that does nothing
                }
                return functionsDict[key]; // return the function with the key of "key"
            }
            set
            {
                if (!functionsDict.ContainsKey(key)) // if the dictionary is not contain some key
                {
                    functionsDict.Add(key, value); // add this key with a function that does nothing
                }
                else
                {
                    functionsDict[key] = value; // change the existing function with "key" to a new function 
                }
            }
        }

        // The class's constructor
        public FunctionsContainer()
        {
            this.functionsDict = new Dictionary<String, Func<double, double>>() ;
        }
        
        // this function returns a list of all the keys in the dictionary
        public List<String> getAllMissions()
        {
            List<String> FunctionsList = new List<string>();
            for (int i = 0; i < this.functionsDict.Count; i++)
            {
                FunctionsList.Add(functionsDict.ElementAt(i).Key);
            }
            return FunctionsList;
        }
    }
}
