using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Neurotico.Bridge.Model;
using Newtonsoft.Json;

namespace Neurotico.Bridge
{
    public sealed class PythonBridge
    {
        internal static PythonBridge instance = null;
        public static PythonBridge Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PythonBridge();
                }
                return instance;
            }
        }

        public string InterpreterPath { get; set; }
        private readonly ProcessStartInfo StartInfo;

        private PythonBridge()
        {
            StartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
        }

        public async Task<PyCommandResult> PingSklearn()
        {
            StartInfo.FileName = InterpreterPath;
            StartInfo.Arguments = @"E:\Andozianos\neurotico_modules\python\main.py -ping sklearn"; //TODO: configs
            PyCommandResult result = null;
            using (Process p = Process.Start(StartInfo))
            {
                using(StreamReader reader = p.StandardOutput)
                {
                    string resultText = await reader.ReadToEndAsync();
                    try
                    {
                        result = JsonConvert.DeserializeObject<PyCommandResult>(resultText);
                        Console.WriteLine(result.Success);
                    }
                    catch
                    {
                        result = new PyCommandResult { Success = false, Reason = "unknow" };
                        Console.WriteLine("caiu no catch");
                    }
                }
            }

            return result;
        }

        
    }
}
