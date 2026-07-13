using HospitalProject.CustomExceptions;
using HospitalProject.EMAIL;
using HospitalProject.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.RegistrationLogin.UserPages
{
    public class UserLogin
    {
        string fileRegister = "user.json";
        string userEmailPassw = "UserEmailPassw.txt"; // $"{email} {password}"
        string? password = null;
         
        public bool isUserLoginSection()
        {
            try
            {
                if (!File.Exists(fileRegister) || !File.Exists(userEmailPassw)) 
                    throw new EmptyException("No users yet!");

            }
            catch(EmptyException exp)
            { 
                ProgramCsException.ProgramCsExceptionMethod(exp, "=========== USERS ===========");
                return false;
            }

            bool isUserLoginSection = false;  

            string[] ReadUserEmailPassw = File.ReadAllLines(userEmailPassw);
            if (ReadUserEmailPassw.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("=========== USERS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No users yet!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
                return false;
            }

            string[] emailsOnly = ReadUserEmailPassw
            .Select(x => x.Split(' ')[0].Replace("\"", ""))
            .ToArray(); 

            short ruep = MenuHelper.ShowMenu(emailsOnly, "=============== User Accounts ===============");

            if (ruep < 0 || ruep >= ReadUserEmailPassw.Length)
            {
                Console.Clear();
                Console.WriteLine("=========== USERS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation!");
                Console.ResetColor();
                return false;
            }

            string selected = ReadUserEmailPassw[ruep]; 

            if (selected.Length == 0 || selected == null)
            {
                Console.Clear();
                Console.WriteLine("=========== USERS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No users yet!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor(); 
            }

            string[] spliteSelected = selected.Split(' '); 
            string userEmail = spliteSelected[0].Replace("\"", "");
            string userPassword = spliteSelected[1].Replace("\"", ""); 

            try
            {
                if (File.Exists(fileRegister))
                {
                    Console.Clear();
                    Console.WriteLine("============== USERS =============="); 

                    Console.Write("Password: ");
                    try
                    {
                        password = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(password))
                        {
                            SoundPlayer soundPLayer = new(@$"D:\Downloads\System Operation Error Sound-yoyosound.com.wav");
                            soundPLayer.Play();
                            throw new EmptyException("This field can't be empty!");
                        }

                        if (password == userPassword)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("=================================");
                            Console.WriteLine("      Login Successful!");
                            Console.WriteLine("=================================");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Welcome, {userEmail}!");
                            Console.ResetColor();

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("Press any key to continue...");
                            Console.ResetColor();
                            isUserLoginSection = true;
                            return isUserLoginSection; 
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("=================================");
                            Console.WriteLine("      Access Denied!");
                            Console.WriteLine("=================================");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Incorrect password. Please try again.");
                            Console.ResetColor();

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("Press any key to continue...");
                            Console.ResetColor();
                            return isUserLoginSection;
                        }

                    }
                    catch (Exception exp)
                    { 
                        ProgramCsException.ProgramCsExceptionMethod(exp, "=========== USERS ===========");
                        return false;
                    } 
                }
                else
                    throw new EmptyException("No users yet!");
            }
            catch (Exception ex)
            {
                ProgramCsException.ProgramCsExceptionMethod(ex, "=========== USERS ===========");
                return false;
            }
        }
    }
}
