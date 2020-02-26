using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurotico.UI.Helpers
{
    public static class FunctionHelper
    {
        private static readonly Dictionary<string, Func<double[], double[]>> Functions = new Dictionary<string, Func<double[], double[]>>
        {
            { "FTan", input => input.Select(x => Math.Tan(x)).ToArray() },
            { "FSin", input => input.Select(x => Math.Sin(x)).ToArray() },
            { "FSinh", input => input.Select(x => Math.Sinh(x)).ToArray() },
            { "FCos", input => input.Select(x => Math.Cos(x)).ToArray() },
            { "FTanh", input => input.Select(x => Math.Tanh(x)).ToArray() },
            { "FRelu", input => input.Select(x => x > 0 ? x * 0.001 : 0).ToArray() }
        };

        public static Func<double[], double[]> GetFunctionByName(string name)
        {
            if (Functions[name] != null)
            {
                return Functions[name];
            }
            else
            {
                throw new Exception("there is no such function");
            }
        }   

        public static double[] MakeInterval(double m, double M, int n)
        {            
            return Enumerable.Range(0, n).Select(i => m + ((Math.Abs(m) + Math.Abs(M)) / n) * i).ToArray();            
        }              
                
    }
}
