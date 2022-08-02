using System;

namespace SectionB
{
    using SectionA;
    class Program
    {
        public enum HireTypes {
            FullTime = employ.Salary,
            PartTime = employ.Salary * 0.5,
            Hourly = 0.25 * employ.Salary
        }

        public static void Main(string[] args)
        {
            // using system.enum -> "Enum.GetValues" method to print out each of the value 
            foreach (int i in System.Enum.GetValues(typeof(HireTypes)))
            {
                Console.WriteLine(i);
                //print out value of i.
            }
        }

        static void processPayroll()
        {
            using (StreamReader sr = new StreamReader(@"HRMasterlist.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void updateMonthlyPayoutToMasterlist(List<Employee> listOfEmployees)
        {   
            string fileName = @"HRMasterlistB.txt";

            try
            
            {
                if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        foreach(Employee employ in listOfEmployees)
                        {   
                            sw.WriteLine(employ.Nric + "|" + employ.FullName + "|" + employ.Salutation + "|" + employ.StartDate.ToString("dd/MM/yyyy") + "|" + employ.Designation + "|" + employ.Department + "|" + employ.mobileNo + "|" + employ.HireType + "|" + employ.Salary + "|" + employ.monthlyPayout);
                        }
                    }
            }

            catch (Exception Ex)    
            {    
                Console.WriteLine(Ex.ToString());    
            }
        }
    }
}