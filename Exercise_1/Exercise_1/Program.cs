using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        public delegate double funcDelegate(double x);
        static void Main(string[] args)
        {
            
            FunctionContainer fc = new FunctionContainer();
            fc.setNewFunc("Double", Double);
            SingleMission sm = new SingleMission(fc.getFunc("Double"), "Double");
            fc.setNewFunc("Triple", x => x * 3);
            ComposedMission cm = new ComposedMission("mission 1");
            cm.Add(fc.getFunc("Double")).Add(fc.getFunc("Triple")).Add(Double).Add(x => x*x).Add(Divide);
            ComposedMission cm2 = new ComposedMission("mission 2");
            cm2.Add(x => x * x).Add(x => x * x).Add(x => x * x).Add(x => x * x).Add(x => x * x);
            List<IMission> missionList = new List<IMission>();
            missionList.Add(sm);
            missionList.Add(cm);
            missionList.Add(cm2);

            foreach (var m in missionList)
            {
                m.OnCalculate += SqrtHandler;
            }

            RunMissions(missionList, 2);

        }

        public static EventHandler<double> SqrtHandler = (sender, val) =>
        {
            IMission mission = sender as IMission;
            Console.WriteLine($"Hello I am {mission.Name} in SqrtHandler!");
        };

        static void RunMissions(List<IMission> missionList, double value)
        {
            foreach (var mission in missionList)
            {
                mission.Calculate(value);
            }
        }

        static double Double(double a)
        {
            return a * 2;
        }

        static double Divide(double a)
        {
            return a / a;
        }
    }
}
