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

namespace HospitalProject.AllMenu
{
    public class MenuSystem
    {

        public static void MenuSystemMethod()
        {
            File.WriteAllText(appointmentsFile, "09:00-11:00 Available\n");
            File.AppendAllText(appointmentsFile, "12:00-14:00 Available\n");
            File.AppendAllText(appointmentsFile, "15:00-17:00 Available\n");

            #region Menu System
            bool isRunning = true;
            while (isRunning)
            {
                short mp = MenuHelper.ShowMenu(mainPage, "======== Main Page ========");
                switch (mp)
                {
                    case 0:
                        {
                            short ap = MenuHelper.ShowMenu(adminPage, "======== Admin Section ========");
                            switch (ap)
                            {
                                case 0:
                                    { 
                                        admin.DeleteUser(); 
                                        Console.ReadKey(); 
                                        break;
                                    }
                                case 1:
                                    {
                                        admin.DeleteDoctor();
                                        Console.ReadKey();
                                        break;
                                    }
                                case 2:
                                    {
                                        if (emails.Count == 0) { Email.EmailMessages("No emails yet!"); break; }

                                        string[] emailArray = File.Exists("AdminEmail.txt") ? File.ReadAllLines("AdminEmail.txt") : Array.Empty<string>();
                                        short eap = MenuHelper.ShowMenu(emailArray, "========== E-Mail ==========");
                                        string[] cvArray = File.Exists("CV.txt") ? File.ReadAllLines("CV.txt") : Array.Empty<string>();
                                        Console.Clear();
                                        Console.WriteLine("========== E-Mail ==========");
                                        for (int i = eap * 10; i <= (eap * 10) + 8; i++)
                                            Console.WriteLine(cvArray[i]);

                                        Console.ReadKey();
                                        Console.Clear();

                                        bool alreadyProcessed = cvArray[(eap * 10) + 8] != $"Status: {CvStatus.Pending}";

                                        if (!alreadyProcessed)
                                        {
                                            string[] cvStatusStrings = CvStatusPage.Select(x => x.ToString()).ToArray();
                                            short csp = MenuHelper.ShowMenu(cvStatusStrings, "========== E-Mail ==========");

                                            string[] statusLines = File.ReadAllLines("CV.txt");
                                            statusLines[(eap * 10) + 8] = $"Status: {cvStatusStrings[csp]}";
                                            File.WriteAllLines("CV.txt", statusLines);
                                        }
                                        else
                                            Email.EmailMessages("You have already checked this CV!");
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
                                                                    short timeInd1 = MenuHelper.ShowMenu(times, "======== SCHEDULE ========");
                                                                    switch (timeInd1)
                                                                    {
                                                                        case 0: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd1); break;
                                                                        case 1: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd1); break;
                                                                        case 2: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd1); break;
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
                                                                    short timeInd2 = MenuHelper.ShowMenu(times, "======== SCHEDULE ========");
                                                                    switch (timeInd2)
                                                                    {
                                                                        case 0: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd2); break;
                                                                        case 1: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd2); break;
                                                                        case 2: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd2); break;
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
                                                                    short timeInd3 = MenuHelper.ShowMenu(times, "======== SCHEDULE ========");
                                                                    switch (timeInd3)
                                                                    {
                                                                        case 0: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd3); break;
                                                                        case 1: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd3); break;
                                                                        case 2: makeAppointmentrs.MakeAppointments(times, isAvailable, timeInd3); break;
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
                                case 1: doctorLog.DoctorLoginSection(); Console.ReadKey(); break;
                                case 2: cv.CvApplied(emails); Console.ReadKey(); break;
                                case 3: break;
                            }
                            break;
                        }
                    case 3: isRunning = false; break;
                }
            }
            #endregion
        }
    }
}
