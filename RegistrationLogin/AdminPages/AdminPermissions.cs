using HospitalProject.CV;
using HospitalProject.HelperClasses;
using HospitalProject.Logs;
using HospitalProject.Persons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HospitalProject.RegistrationLogin.AdminPages;

public class AdminPermissions
{  
    public bool CheckUser()
    {
        return File.Exists("user.json");
    }

    public bool CheckDoctor()
    {
        return File.Exists("doctor.json");
    }
    public void DeleteUser()
    {
        LogHistory.saveLogInfos("Admin Entered User Deletion Section");
        string fileRegisterUser = "user.json";
        string userEmailPassw = "UserEmailPassw.txt";
         
        if (!CheckUser())
        {
            Console.Clear();
            Console.WriteLine("=========== User Deletion ===========");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No users yet!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
        }
        else
        {  
            Console.Clear();
            Console.WriteLine("=========== User Deletion ===========");

            if (!File.Exists(userEmailPassw))
            {
                Console.WriteLine("No registered users.");
                return;
            }

            string[] ReadUserEmailPassw = File.ReadAllLines(userEmailPassw); 

            string[] emailsOnly = ReadUserEmailPassw
            .Select(x => x.Split(' ')[0].Replace("\"", ""))
            .Append("Back")
            .ToArray();

            if (emailsOnly.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("=========== User Deletion ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No users yet!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
            }
            short ruep = MenuHelper.ShowMenu(emailsOnly, "=============== User Accounts ===============");

            if (ruep == emailsOnly.Length - 1)  
                return;

            if (ruep < 0 || ruep >= ReadUserEmailPassw.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid user selection.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            List<string> RegUserList = File.ReadAllLines(userEmailPassw).ToList(); 
            RegUserList.RemoveAt(ruep);
            File.WriteAllLines(userEmailPassw, RegUserList);
             
            List<string> EmailPasswUser = File.ReadAllLines(fileRegisterUser).ToList();

            int startIndex = ruep * 9;

            if (startIndex + 9 <= EmailPasswUser.Count) 
                EmailPasswUser.RemoveRange(startIndex, 9);

            File.WriteAllLines(fileRegisterUser, EmailPasswUser);
            Console.WriteLine("User deleted succesfully.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
        }
    }
    
    public void DeleteDoctor()
    {
        LogHistory.saveLogInfos("Admin Entered Doctor Deletion Section");
        string fileRegisterDoctor = "doctor.json";
        string doctorEmailPassw = "DoctorEmailPassw.txt";

        if (!CheckDoctor())
        {
            Console.Clear();
            Console.WriteLine("=========== Doctor Deletion ===========");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No doctors yet!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
        }
        else
        {  
            Console.Clear();
            Console.WriteLine("=========== Doctor Deletion ===========");

            if (!File.Exists(doctorEmailPassw))
            {
                Console.WriteLine("No registered users.");
                return;
            }

            string[] ReadDoctorEmailPassw = File.ReadAllLines(doctorEmailPassw);

            string[] emailsOnly = ReadDoctorEmailPassw
            .Select(x => x.Split(' ')[0].Replace("\"", ""))
            .Append("Back")
            .ToArray();

            short rdep = MenuHelper.ShowMenu(emailsOnly, "=============== Doctor Accounts ===============");

            if (rdep == emailsOnly.Length - 1)
                return;

            if (rdep < 0 || rdep >= ReadDoctorEmailPassw.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("Invalid doctor selection.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            List<string> RegDoctorList = File.ReadAllLines(doctorEmailPassw).ToList();
            RegDoctorList.RemoveAt(rdep);
            File.WriteAllLines(doctorEmailPassw, RegDoctorList);
             
            List<string> EmailPasswDoctor = File.ReadAllLines(fileRegisterDoctor).ToList();
             
            int startIndex = rdep * 9;

            if (startIndex + 9 <= EmailPasswDoctor.Count)
                EmailPasswDoctor.RemoveRange(startIndex, 9);

            File.WriteAllLines(fileRegisterDoctor, EmailPasswDoctor);
            Console.WriteLine("Doctor deleted succesfully.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
        }
    } 
}

