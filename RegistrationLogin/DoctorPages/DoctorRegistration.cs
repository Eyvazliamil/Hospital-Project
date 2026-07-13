using HospitalProject.CustomExceptions;
using HospitalProject.CV;
using HospitalProject.HelperClasses;
using HospitalProject.Persons;
using HospitalProject.SoundPlayerMethod;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalProject.RegistrationLogin.DoctorPages
{
    public class DoctorRegistration
    { 
        string fileRegister = "doctor.json";
        string doctorEmailPassw = "DoctorEmailPassw.txt";

        public string CheckException(string? item, string title = "")
        {
            Console.Write(title);
            item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmptyException("This field can't be empty!"));

            return item;
        }
        public void Registration()
        {

            List<string> emailsAdmin = File.Exists("AdminEmail.txt") ? File.ReadAllLines("AdminEmail.txt").ToList() : new List<string>();
            string[] cvArray = File.Exists("Cv.txt") ? File.ReadAllLines("Cv.txt") : Array.Empty<string>();
            Console.Clear();
            Console.WriteLine("============ Doctor Registration ============");

            if (emailsAdmin.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You haven't sent a CV yet.");
                Console.ResetColor();
                return;
            }

            short ep = MenuHelper.ShowMenu(emailsAdmin.ToArray(), "Select your e-mail:");
            string selectedEmail = emailsAdmin[ep];

            for (int i = 0; i < cvArray.Length; i++)
            {
                if (cvArray[i] == $"Email: {selectedEmail}")
                {
                    cvArray[(ep * 10) + 8] = cvArray[(ep * 10) + 8].Replace("Status: ", "");
                    break;
                }
            }
             
            if (cvArray[(ep * 10) + 8] == null || cvArray[(ep * 10) + 8] == CvStatus.Pending.ToString())
            {
                Console.Clear();
                Console.WriteLine("============ Doctor Registration ============");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your CV is still pending. Wait for response.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
                return;
            }
            else if (cvArray[(ep * 10) + 8] == CvStatus.Rejected.ToString())
            {
                Console.Clear();
                Console.WriteLine("============ Doctor Registration ============");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your CV was rejected. You cannot register.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor(); 
                return;
            }
            else
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("============ Doctor Registration ============");
                    string? name = null;
                    string? surname = null;
                    string? age = null;
                    string? email = null;
                    string? password = null;
                    string? phone = null;

                    name = CheckException(name, "Name: ");
                    surname = CheckException(surname, "Surname: ");

                    Console.Write("Age: ");
                    age = Console.ReadLine();
                    if (!int.TryParse(age, out int Age)) 
                        SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new SymboleException("Age must be number!")); 


                    Regex EmailRegex = new Regex(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", RegexOptions.IgnoreCase);

                    Console.Write("E-mail: ");
                    email = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(email))
                        SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmptyException("This field can't be empty!"));

                    else if (!EmailRegex.IsMatch(email)) 
                        SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmailException("Incorrect e-mail form!")); 

                    Console.Write("Phone: ");
                    phone = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(phone))
                        SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmptyException("This field can't be empty!"));

                    else if (!phone.All(x => char.IsDigit(x) || x == '-'))
                        SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new SymboleException("Phone can contain only numbers and '-'!"));


                    password = CheckException(password, "Password: ");

                    Doctor doctor = new Doctor(name, surname, email, phone, Age, Guid.NewGuid()) { };

                    string jsonUserFile = JsonConvert.SerializeObject(doctor, Formatting.Indented);
                    File.AppendAllText(fileRegister, jsonUserFile + Environment.NewLine);
                    File.AppendAllText(doctorEmailPassw, $"{email} {password}" + Environment.NewLine);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nRegistration completed successfully!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press any key to continue...");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

            } 
        }
    }
}

