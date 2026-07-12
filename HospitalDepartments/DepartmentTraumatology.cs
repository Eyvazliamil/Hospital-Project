using HospitalProject.CustomExceptions;
using HospitalProject.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.HospitalDepartments
{
    public class DepartmentTraumatology
    {
        static public bool TraumatologyMethod(string file)
        {
            try
            {
                if (!File.Exists(file))
                    throw new EmptyException("No doctors work at traumatology department yet!");

                string[] linesDentistryDoctor = File.ReadAllLines(file);
                short ldp = MenuHelper.ShowMenu(linesDentistryDoctor, "======== Traumatology Doctors ========");
                return true;
            }
            catch (EmptyException ex)
            {
                ProgramCsException.ProgramCsExceptionMethod(ex, "=========== DOCTORS ===========");
                return false;
            }
        }

        static public void getInfoTraumatologyDoctor(string file)
        {
            string fileCV = "CV.txt";
            try
            {
                if (!File.Exists(file))
                    throw new EmptyException("No doctors work at traumatology department yet!");

                string[] linesCv = File.ReadAllLines(fileCV);
                string[] onlyDoctorNames = linesCv.Where(x => x.StartsWith("Name:")).Select(x => x.Split(':')[1].Trim()).ToArray();

                short ldp = MenuHelper.ShowMenu(onlyDoctorNames, "======== Traumatology Doctors ========");
                Console.Clear();

                Console.WriteLine($"======== Information About DR.{onlyDoctorNames[ldp]}  ========");

                for (int i = 10 * ldp; i <= (10 * ldp) + 5; i++)
                {
                    Console.WriteLine(linesCv[i]);
                }
            }
            catch (EmptyException ex)
            {
                ProgramCsException.ProgramCsExceptionMethod(ex, "=========== DOCTORS ===========");
            }
        }
    }
}
