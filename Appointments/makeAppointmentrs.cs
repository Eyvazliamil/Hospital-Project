using HospitalProject.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Appointments
{
    public class makeAppointmentrs
    {
        public static void MakeAppointments(string[] appTimeToArray, string[] timeArray, string[] isAvaialbleArray, short ind)
        {
            LogHistory.saveLogInfos("User Entered Appointment Section");
            if (isAvaialbleArray[ind] == "Available") 
            {
                Console.Clear();
                Console.WriteLine("======== SCHEDULE ========");
                isAvaialbleArray[ind] = "Booked";
                appTimeToArray[ind] = $"{timeArray[ind]} {isAvaialbleArray[ind]}";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Appointment has been booked at {timeArray[ind]}.");
                Console.ResetColor();  
            }
            else
            {
                Console.Clear();
                Console.WriteLine("======== SCHEDULE ========");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Appointment is full!");
                Console.ResetColor(); 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to continue...");
                Console.ResetColor(); return;
            }
        }
    }
}
