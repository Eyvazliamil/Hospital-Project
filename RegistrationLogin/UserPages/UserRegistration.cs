using HospitalProject.CustomExceptions;
using HospitalProject.Persons; 
using HospitalProject.SoundPlayerMethod;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks; 

namespace HospitalProject.RegistrationLogin.UserPages
{
    public class UserRegistration
    {
        string fileRegister = "user.json";
        string userEmailPassw = "UserEmailPassw.txt";

        public string CheckException(string ?item, string title = "")
        {
            Console.Write(title);
            item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmptyException("This field can't be empty!"));
            
            return item;
        }
        public void Registration()
        {
            Console.Clear();
            Console.WriteLine("============ User Registration ============");
            string ?name = null;
            string ?surname = null;
            string ?age = null;
            string ?email = null;
            string ?password = null;
            string ?phone = null;

            try
            {
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
                {
                    SoundPlayer soundPLayer = new(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav");
                    soundPLayer.Play();
                    throw new EmailException("Incorrect e-mail form!");
                } 

                Console.Write("Phone: ");
                phone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phone))  
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new EmptyException("This field can't be empty!")); 

                else if (!phone.All(x => char.IsDigit(x) || x == '-')) 
                    SoundPlayers.PlaySound(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav", new SymboleException("Phone can contain only numbers and '-'!"));

                password = CheckException(password, "Password: "); 
                User user = new (name, surname, email, phone, password, Age, Guid.NewGuid()) {};
                 
                string jsonUserFile = JsonConvert.SerializeObject(user, Formatting.Indented);

                File.AppendAllText(fileRegister, jsonUserFile + Environment.NewLine); 
                File.AppendAllText(userEmailPassw, $"{email} {password}" + Environment.NewLine); 


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRegistration successful."); 
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
