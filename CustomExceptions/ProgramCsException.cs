using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.CustomExceptions
{
    public class ProgramCsException : ApplicationException
    {
        public static void ProgramCsExceptionMethod(Exception ex, string header = "")
        { 
            Console.Clear();
            Console.WriteLine(header);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
        }
    }
}
