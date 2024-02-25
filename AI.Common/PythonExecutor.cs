using AI.Infrastructure.Data;

using Newtonsoft.Json;

using System;

using System.Collections.Generic;

using System.Diagnostics;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace AI.Common

{

    public class PythonExecutor

    {

        //in ject all required strings



        public static CentroidData? ExecPythonScript()

        {

            // This logic can be further abstracted into common



            var psi = new ProcessStartInfo();

            //please put into config file, this is testing only

            psi.FileName = "C:\\...\\python.exe";// @"C:\Python311\python.exe";

            var script = "C:\\...\\AI.Python\\AI.Python.py";// @"D:\Projects\ISH\ISHPlus\ISH.Calculators.Python\Plots.py";

            psi.Arguments = $"\"{script}\"";

            psi.UseShellExecute = false;

            psi.CreateNoWindow = true;

            psi.RedirectStandardOutput = true;

            psi.RedirectStandardError = true;

            var errors = "";

            var results = "";

            using (var process = Process.Start(psi))

            {

                if (process != null)

                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

            }



            // 5) Display output

            Console.WriteLine("ERRORS:");

            Console.WriteLine(errors);

            Console.WriteLine();

            Console.WriteLine("Results:");

            Console.WriteLine(results);



            //var serialized = JsonSerializer.DeserializeJsonToObject<int>();

            var jsonString = results;

            var dserialized = JsonConvert.DeserializeObject<CentroidData>(jsonString);

            return dserialized;

        }

    }



}