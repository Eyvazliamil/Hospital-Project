using HospitalProject.Appointments;
using HospitalProject.CV;
using HospitalProject.EMAIL;
using HospitalProject.HelperClasses;
using HospitalProject.HospitalDepartments;
using HospitalProject.RegistrationLogin.DoctorPages;
using HospitalProject.RegistrationLogin.UserPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static HospitalProject.AllMenu.MenuCollections;

namespace HospitalProject.AllMenu;

public class MenuSystem
{

    public static void MenuSystemMethod()
    {

        File.WriteAllText(appointmentsFile, "09:00-11:00 Available\n");
        File.AppendAllText(appointmentsFile, "12:00-14:00 Available\n");
        File.AppendAllText(appointmentsFile, "15:00-17:00 Available\n"); 

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        short sm = MenuHelper.ShowWelcomeScreen();
        Console.ReadKey();

        #region Menu System
        bool isRunning = true;

        if (sm == 0)
        {
            while (isRunning)
            {
                short mp = MenuHelper.ShowMenu(mainPage, "======== Main Page ========");
                switch (mp)
                {
                    case 0:
                        {
                            short alp = MenuHelper.ShowMenu(adminLoginPage, "======== Admin Section ========");
                            switch (alp)
                            {
                                case 0:
                                    {
                                        adminReg.Registration();
                                        Console.ReadKey();
                                        break;
                                    }
                                case 1:
                                    {
                                        bool isAdminTrue = adminLog.isAdminLoginSection();
                                        Console.ReadKey();
                                        if (isAdminTrue)
                                        {
                                            short aps = MenuHelper.ShowMenu(adminPage, "======== Admin Permission Section ========");
                                            switch (aps)
                                            {
                                                case 0:
                                                    {
                                                        adminPermission.DeleteUser();
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        adminPermission.DeleteDoctor();
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                    #region Additional Part
                                                    //case 2:
                                                    //    {
                                                    //        if (emails.Count == 0) { Email.EmailMessages("No emails yet!"); break; }

                                                    //        string[] emailArray = File.Exists("AdminEmail.txt") ? File.ReadAllLines("AdminEmail.txt") : Array.Empty<string>();
                                                    //        short eap = MenuHelper.ShowMenu(emailArray, "========== E-Mail ==========");
                                                    //        string[] cvArray = File.Exists("CV.txt") ? File.ReadAllLines("CV.txt") : Array.Empty<string>();
                                                    //        Console.Clear();
                                                    //        Console.WriteLine("========== E-Mail ==========");
                                                    //        for (int i = eap * 10; i <= (eap * 10) + 8; i++)
                                                    //            Console.WriteLine(cvArray[i]);

                                                    //        Console.ReadKey();
                                                    //        Console.Clear();

                                                    //        bool alreadyProcessed = cvArray[(eap * 10) + 8] != $"Status: {CvStatus.Pending}";

                                                    //        if (!alreadyProcessed)
                                                    //        {
                                                    //            string[] cvStatusStrings = CvStatusPage.Select(x => x.ToString()).ToArray();
                                                    //            short csp = MenuHelper.ShowMenu(cvStatusStrings, "========== E-Mail ==========");

                                                    //            string[] statusLines = File.ReadAllLines("CV.txt");
                                                    //            statusLines[(eap * 10) + 8] = $"Status: {cvStatusStrings[csp]}";
                                                    //            File.WriteAllLines("CV.txt", statusLines);
                                                    //        }
                                                    //        else
                                                    //            Email.EmailMessages("You have already checked this CV!");
                                                    //        break;
                                                    //    }
                                                    #endregion
                                            }
                                        }

                                        break;
                                    }
                                case 2:
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                    case 1:
                        {
                            short ulp = MenuHelper.ShowMenu(userLoginPage, "======== User Section ========");
                            switch (ulp)
                            {
                                case 0: userReg.Registration(); Console.ReadKey(); break;
                                case 1:
                                    {
                                        bool isTrue = userLogin.isUserLoginSection(); Console.ReadKey();
                                        if (isTrue)
                                        {
                                            short udp = MenuHelper.ShowMenu(userDoctorPage, "======== User Section ========");
                                            switch (udp)
                                            {
                                                case 0:
                                                    {
                                                        short hd = MenuHelper.ShowMenu(hospitalDepartment, "======== Hospital Department ========");
                                                        switch (hd)
                                                        {
                                                            case 0:
                                                                bool isTrue1 = DepartmentPediatrics.PediatricsMethod(pediatricsDoctor);

                                                                if (isTrue1)
                                                                {
                                                                    string[] scheduleMenu1 = appTimeToArray.Append("Back").ToArray();
                                                                    short timeInd1 = MenuHelper.ShowMenu(scheduleMenu1, "======== SCHEDULE ========");
                                                                    switch (timeInd1)
                                                                    {
                                                                        case 0: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd1); break;
                                                                        case 1: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd1); break;
                                                                        case 2: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd1); break;
                                                                    }
                                                                    Console.ReadKey();
                                                                }
                                                                else
                                                                    Console.ReadKey();

                                                                break;

                                                            case 1:
                                                                bool isTrue2 = DepartmentTraumatology.TraumatologyMethod(traumatologyDoctor);

                                                                if (isTrue2)
                                                                {
                                                                    string[] scheduleMenu2 = appTimeToArray.Append("Back").ToArray();
                                                                    short timeInd2 = MenuHelper.ShowMenu(scheduleMenu2, "======== SCHEDULE ========");
                                                                    switch (timeInd2)
                                                                    {
                                                                        case 0: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd2); break;
                                                                        case 1: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd2); break;
                                                                        case 2: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd2); break;
                                                                    }
                                                                    Console.ReadKey();
                                                                }
                                                                else
                                                                    Console.ReadKey();

                                                                break;

                                                            case 2:
                                                                bool isTrue3 = DepartmentDentistry.DentistryMethod(dentistryDoctor);
                                                                if (isTrue3)
                                                                {
                                                                    string[] scheduleMenu3 = appTimeToArray.Append("Back").ToArray();
                                                                    short timeInd3 = MenuHelper.ShowMenu(scheduleMenu3, "======== SCHEDULE ========");
                                                                    switch (timeInd3)
                                                                    {
                                                                        case 0: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd3); break;
                                                                        case 1: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd3); break;
                                                                        case 2: makeAppointmentrs.MakeAppointments(appTimeToArray, times, isAvailable, timeInd3); break;
                                                                    }
                                                                    Console.ReadKey();
                                                                }
                                                                else
                                                                    Console.ReadKey();

                                                                break;

                                                            case 3: break;
                                                        }
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        short hd = MenuHelper.ShowMenu(hospitalDepartment, "======== Hospital Department ========");
                                                        switch (hd)
                                                        {
                                                            case 0:
                                                                DepartmentPediatrics.getInfoPediatricsDoctor(pediatricsDoctor);
                                                                Console.ReadKey();
                                                                break;
                                                            case 1:
                                                                DepartmentTraumatology.getInfoTraumatologyDoctor(traumatologyDoctor);
                                                                Console.ReadKey();
                                                                break;
                                                            case 2:
                                                                DepartmentDentistry.getInfoDentistryDoctor(dentistryDoctor);
                                                                Console.ReadKey();
                                                                break;

                                                            case 3: break;
                                                        }
                                                        break;
                                                    }
                                                case 2: break;
                                            }
                                        }
                                        break;
                                    }
                                case 2: break;
                            }
                            break;
                        }
                    case 2:
                        {
                            short dlp = MenuHelper.ShowMenu(doctorLoginPage, "======== Doctor Section ========");
                            switch (dlp)
                            {
                                case 0: doctorReg.Registration(); Console.ReadKey(); break;
                                case 1:
                                    {
                                        bool isTrue = doctorLog.DoctorLoginSection();
                                        Console.ReadKey();

                                        if (isTrue)
                                        {
                                            short dop = MenuHelper.ShowMenu(DoctorOwnPage, "======== Doctor Menu ========");
                                            switch (dop)
                                            {
                                                case 0:
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("======== My Appointment ========");
                                                        foreach (string timeArray in appTimeToArray)
                                                        {
                                                            string[] parts = timeArray.Split(' ');
                                                            string time = parts[0];
                                                            string status = parts[1];

                                                            if (status == "Available")
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                            else
                                                                Console.ForegroundColor = ConsoleColor.Red;

                                                            Console.WriteLine($"{time} - {status}");
                                                            Console.ResetColor();
                                                        }
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.Write("Press any key to continue...");
                                                        Console.ResetColor();
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                case 1: break;
                                            }
                                        }
                                        break;
                                    }
                                case 2: cv.CvApplied(emails); Console.ReadKey(); break;
                                case 3: break;
                            }
                            break;
                        }
                    case 3: isRunning = false; break;
                }
            }
        }
        else
            isRunning = false;
        #endregion
    }
        }
     
