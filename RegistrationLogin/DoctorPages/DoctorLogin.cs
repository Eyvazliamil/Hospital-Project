using HospitalProject.CustomExceptions;
using HospitalProject.HelperClasses;
using HospitalProject.Logs;
using System;
using System.IO;
using System.Linq;
using System.Media;

namespace HospitalProject.RegistrationLogin.DoctorPages
{
    public class DoctorLogin
    {
        string fileRegister = "doctor.json";
        string doctorEmailPassw = "DoctorEmailPassw.txt"; // $"{email} {password}"
        string? password = null;

        public bool DoctorLoginSection()
        {
            LogHistory.saveLogInfos("Doctor Entered Login Section");

            bool isDoctorLoginSection = false;

            if (!File.Exists(doctorEmailPassw))
            {
                Console.Clear();
                Console.WriteLine("=========== DOCTORS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No doctors yet!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
                return false;
            }

            string[] readDoctorEmailPassw = File.ReadAllLines(doctorEmailPassw);
            if (readDoctorEmailPassw.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("=========== DOCTORS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No doctors yet!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor();
                return false;
            }

            string[] emailsOnly = readDoctorEmailPassw.Select(x => x.Split(' ')[0].Replace("\"", "")) 
                .Append("Back")
                .ToArray();

            short rdep = MenuHelper.ShowMenu(emailsOnly, "=============== Doctor Accounts ===============");

            if (rdep == emailsOnly.Length - 1)
                return false;

            if (rdep < 0 || rdep >= readDoctorEmailPassw.Length)
            {
                Console.Clear();
                Console.WriteLine("=========== DOCTORS ===========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid operation!");
                Console.ResetColor();
                return false;
            }

            string selected = readDoctorEmailPassw[rdep];

            string[] spliteSelected = selected.Split(' ');
            string doctorEmail = spliteSelected[0].Replace("\"", "");
            string doctorPassword = spliteSelected[1].Replace("\"", "");

            try
            {
                if (File.Exists(fileRegister))
                {
                    Console.Clear();
                    Console.WriteLine("============== DOCTORS ==============");

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

                        if (password == doctorPassword)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("=================================");
                            Console.WriteLine("      Login Successful!");
                            Console.WriteLine("=================================");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Welcome, {doctorEmail}!");
                            Console.ResetColor();

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("Press any key to continue...");
                            Console.ResetColor();
                            isDoctorLoginSection = true;
                            return isDoctorLoginSection;
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
                            return isDoctorLoginSection;
                        }
                    }
                    catch (Exception exp)
                    {
                        LogHistory.saveLogErrors("ERROR: Doctor Entered Login Section");
                        ProgramCsException.ProgramCsExceptionMethod(exp, "=========== DOCTORS ===========");
                        return false;
                    }
                }
                else
                    throw new EmptyException("No doctors yet!");
            }
            catch (Exception ex)
            { 
                ProgramCsException.ProgramCsExceptionMethod(ex, "=========== DOCTORS ===========");
                return false;
            }
        }
    }
}
