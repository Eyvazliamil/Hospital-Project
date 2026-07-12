using HospitalProject.Appointments;
using HospitalProject.CustomExceptions;
using HospitalProject.CV;
using HospitalProject.EMAIL;
using HospitalProject.HelperClasses;
using HospitalProject.HospitalDepartments;
using HospitalProject.Persons;
using HospitalProject.RegistrationLogin.AdminPages;
using HospitalProject.RegistrationLogin.DoctorPages;
using HospitalProject.RegistrationLogin.UserPages;
using System;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.Arm;


namespace HospitalProject.AllMenu
{
    public class MenuCollections
    {  
        #region objects and files
        public static Cv cv = new Cv();
        public static AdminLogin admin = new AdminLogin();
        public static UserLogin userLogin = new UserLogin();
        public static UserRegistration userReg = new UserRegistration();
        public static List<string> emails = File.Exists("AdminEmail.txt") ? File.ReadAllLines("AdminEmail.txt").ToList() : new List<string>();
        public static DoctorRegistration doctorReg = new DoctorRegistration();
        public static DoctorLogin doctorLog = new DoctorLogin();

        public static string dentistryDoctor = "dentistryDoctors.json";
        public static string pediatricsDoctor = "pediatricsDoctors.json";
        public static string traumatologyDoctor = "traumatologyDoctors.json";

        public static string appointmentsFile = "appointments.txt"; 
        #endregion

        #region AllMenu
        public static string[] hospitalDepartment = { "Pediatrics", "Traumatology", "Dentistry", "Back" };
        public static string[] appTimeToArray = File.Exists(appointmentsFile) ? File.ReadAllLines(appointmentsFile).ToArray() : Array.Empty<string>();
        public static string[] times = appTimeToArray.Select(x => x.Split(' ')[0]).ToArray();
        public static string[] isAvailable = appTimeToArray.Select(x => x.Split(' ')[1]).ToArray();
        public static string[] userLoginPage = { "User Registration", "User Login", "Back" };
        public static string[] doctorLoginPage = { "Doctor Registration", "Doctor Login", "Send CV", "Back" };
        public static string[] mainPage = { "Admin Login", "User Section", "Doctor Section", "Exit" };
        public static string[] adminPage = { "Delete User","Delete Doctor", "E-mail", "Back" };
        public static string[] userDoctorPage = { "Make Appointment", "About Doctors", "Back" };
        public static CvStatus[] CvStatusPage = { CvStatus.Pending, CvStatus.Rejected, CvStatus.Approved };
        #endregion
    
    }
}
