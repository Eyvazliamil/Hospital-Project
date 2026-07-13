using HospitalProject.CustomExceptions;
using HospitalProject.EMAIL;
using HospitalProject.HelperClasses;
using HospitalProject.HospitalDepartments;
using HospitalProject.Logs;
using HospitalProject.Persons;
using HospitalProject.SoundPlayerMethod;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration; 
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalProject.CV
{
    public enum CvStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class Cv
    { 
        public Cv() { }

        string fileCV = "CV.txt";
        string adminEmail = "AdminEmail.txt";

        string dentistryDoctor = "dentistryDoctors.json";
        string pediatricsDoctor = "pediatricsDoctors.json";
        string traumatologyDoctor = "traumatologyDoctors.json";

        string[] hospitalDepartment = { "Pediatrics", "Traumatology", "Dentistry", "Back" };
        public string CheckException(string? item, string title = "")
        {
            Console.Write(title);
            item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmptyException("This field can't be empty!")); 

            return item!;
        }

        public short selectDepartment()
        {
            short selectdDepartment = MenuHelper.ShowMenu(hospitalDepartment, "=========== Send CV To ===========");
            return selectdDepartment;
        }
        public void CvApplied(List<string> emails)
        {
            Console.Clear();
            LogHistory.saveLogInfos("CV Applied");
            Console.WriteLine("=========== Fill The CV ==========="); 
            string? name = null;
            string? surname = null;  
            string? age = null; 
            string? email = null; 
            string? phone = null; 
            string? wrkexp = null;
            string? description = null;
            string? reason = null;

            try
            { 
                name = CheckException(name, "Enter your name: ");
                surname = CheckException(surname, "Enter your surname: "); 

                Console.Write("Enter your age: ");
                age = Console.ReadLine();
                if (!int.TryParse(age, out int Age))
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new SymboleException("Age must be number!")); 

                Regex EmailRegex = new Regex(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", RegexOptions.IgnoreCase);
                Regex PhoneRegex = new Regex(@"^[+]{1}(?:[0-9\-\(\)\/\.]\s?){6,15}[0-9]{1}$", RegexOptions.IgnoreCase);

                Console.Write("E-mail: ");
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email))
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmptyException("This field can't be empty!")); 

                else if (!EmailRegex.IsMatch(email))
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmailException("Incorrect e-mail form!")); 

                Console.Write("Enter your phone: "); 
                phone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phone)) 
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmptyException("This field can't be empty!"));

                else if (!PhoneRegex.IsMatch(phone))
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmailException("Incorrect phone form!")); 

                Console.Write("Work Experience (year): ");
                wrkexp = Console.ReadLine();
                if(System.Convert.ToInt32(wrkexp) > System.Convert.ToInt32(age))
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new SymboleException("Please enter a valid information!"));

                if (!int.TryParse(wrkexp, out int Wrkexp)) 
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new SymboleException("Work Experience must be a number!"));

                description = CheckException(description, "Enter description: ");
                reason = CheckException(reason, "Why us? ");
            }
            catch (Exception ex)
            {
                LogHistory.saveLogInfos("ERROR: CV Applied");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor(); return;
            }
            string cvData =
$@"Name: {name}
Surname: {surname}
Age: {age}
Email: {email}
Phone: {phone}
Work Experience: {wrkexp}   
Description: {description}
Reason: {reason}
Status: {CvStatus.Pending}
======================================";
            try
            {
                Console.Write("Are you sure you want to send it?(y\\n) ");
                char? isSure = char.ToLower(Console.ReadKey().KeyChar); Console.WriteLine();

                if (isSure != null && isSure == 'y')
                { 
                    short selectedDepartment = selectDepartment(); 
                    switch (selectedDepartment)
                    {
                        case 0:
                            {
                                string jsonDentistryDoctor = JsonConvert.SerializeObject($"{name} {surname}", Formatting.Indented); 
                                File.AppendAllText(dentistryDoctor, jsonDentistryDoctor + Environment.NewLine); 
                                break;
                            }
                        case 1:
                            {
                                string jsonPediatricsDoctor = JsonConvert.SerializeObject($"{name} {surname}", Formatting.Indented);
                                File.AppendAllText(pediatricsDoctor, jsonPediatricsDoctor + Environment.NewLine);
                                break;
                            }
                        case 2:
                            {
                                string jsonTraumatologyDoctor = JsonConvert.SerializeObject($"{name} {surname}", Formatting.Indented);
                                File.AppendAllText(traumatologyDoctor, jsonTraumatologyDoctor + Environment.NewLine);
                                break;
                            }
                        case 3: break;
                    }

                    File.AppendAllText(fileCV, cvData + Environment.NewLine);

                    SoundPlayer soundPLayer = new(@$"D:\Downloads\mixkit-software-interface-start-2574.wav");
                    soundPLayer.Play(); 

                    File.AppendAllText(adminEmail, email + Environment.NewLine);
                    emails.Add(email!);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCV saved successfully!"); 
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press any key to continue...");
                    Console.ResetColor(); Email.SendCvToEmail($"{name} {surname}");

                }
                else if (isSure != null && isSure == 'n')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWarning: You might lose your all information!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press any key to continue...");
                    Console.ResetColor(); 
                }
                else 
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new SymboleException("Please enter a valid key!")); 
            }
            catch (Exception ex)
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor(); return;
            } 
        } 
    }
}
