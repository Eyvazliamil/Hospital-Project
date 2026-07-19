using HospitalProject.CustomExceptions;
using HospitalProject.EMAIL;
using HospitalProject.HelperClasses;
using HospitalProject.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.RegistrationLogin.AdminPages
{
    public class AdminLogin
    {
        string fileRegister = "admin.json";
        string adminEmailPassw = "AdminEmailPassw.txt"; // $"{email} {password}"
        string? password = null;

        public bool isAdminLoginSection()
        {
            LogHistory.saveLogInfos("Admin Entered Login Section");
            try
            {
                if (!File.Exists(fileRegister) || !File.Exists(adminEmailPassw))
                    throw new EmptyException("No admins yet!");
            }
            catch (EmptyException exp)
            {
                ProgramCsException.ProgramCsExceptionMethod(exp, "=========== ADMINS ===========");
                return false;
            }

            bool isAdminLoginSection = false;

            string[] ReadAdminEmailPassw = File.ReadAllLines(adminEmailPassw);
            if (ReadAdminEmailPassw.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("=========== ADMINS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No admins yet!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
                return false;
            }

            string[] emailsOnly = ReadAdminEmailPassw
            .Select(x => x.Split(' ')[0].Replace("\"", ""))
            .Append("Back")
            .ToArray();

            short raep = MenuHelper.ShowMenu(emailsOnly, "=============== Admin Accounts ===============");

            if (raep == emailsOnly.Length - 1)
                return false;

            if (raep < 0 || raep >= ReadAdminEmailPassw.Length)
            {
                Console.Clear();
                Console.WriteLine("=========== ADMINS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation!");
                Console.ResetColor();
                return false;
            }

            string selected = ReadAdminEmailPassw[raep];

            if (selected.Length == 0 || selected == null)
            {
                Console.Clear();
                Console.WriteLine("=========== ADMINS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No admins yet!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
            }

            string[] spliteSelected = selected.Split(' ');
            string adminEmail = spliteSelected[0].Replace("\"", "");
            string adminPassword = spliteSelected[1].Replace("\"", "");

            try
            {
                if (File.Exists(fileRegister))
                {
                    Console.Clear();
                    Console.WriteLine("============== ADMINS ==============");

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

                        if (password == adminPassword)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("=================================");
                            Console.WriteLine("      Login Successful!");
                            Console.WriteLine("=================================");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Welcome, {adminEmail}!");
                            Console.ResetColor();

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("Press any key to continue...");
                            Console.ResetColor();
                            isAdminLoginSection = true;
                            return isAdminLoginSection;
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
                            return isAdminLoginSection;
                        }
                    }
                    catch (Exception exp)
                    {
                        LogHistory.saveLogErrors("ERROR: Admin Entered Login Section");
                        ProgramCsException.ProgramCsExceptionMethod(exp, "=========== ADMINS ===========");
                        return false;
                    }
                }
                else
                    throw new EmptyException("No admins yet!");
            }
            catch (Exception ex)
            {
                ProgramCsException.ProgramCsExceptionMethod(ex, "=========== ADMINS ===========");
                return false;
            }
        }
    }
}
