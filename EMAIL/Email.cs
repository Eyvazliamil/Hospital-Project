using HospitalProject.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.EMAIL
{
    public class Email
    { 
        public static void EmailMessages(string msg)
        { 
            Console.Clear();
            Console.WriteLine("========== E-Mail ==========");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
