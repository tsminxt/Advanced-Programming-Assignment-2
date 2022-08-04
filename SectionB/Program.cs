using System;
using SectionA;

namespace SectionB
{

    class Program
    {
        public enum HireTypes
        {
            FullTime,
            PartTime,
            Hourly
        }

        static async Task Main(string[] args)
        {
            List<SectionA.Employee> listOfEmployees = new List<SectionA.Employee>();
            listOfEmployees = SectionA.Program.readHRMasterList();

            await Task.Run(() => processPayroll(listOfEmployees));

            updateMonthlyPayoutToMasterlist(listOfEmployees);
            // using system.enum -> "Enum.GetValues" method to print out each of the value 
            // foreach (int i in System.Enum.GetValues(typeof(HireTypes)))
            // {
            //     Console.WriteLine(i);
            //     //print out value of i.
            // }
        }

        static void processPayroll(List<SectionA.Employee> listOfEmployees)
        {
            double totalSalary = 0.0;
            int totalEmploy = 0;

            foreach(SectionA.Employee employ in listOfEmployees)
            {
                Console.WriteLine(employ.FullName + " (" + employ.Nric + ")");
                Console.WriteLine(employ.Designation);

                if (employ.HireType == HireTypes.PartTime.ToString())
                {
                    employ.MonthlyPayout = employ.Salary * 0.5;
                    Console.WriteLine(HireTypes.PartTime.ToString() + " Payout: $" + employ.Salary);
                }
                else if (employ.HireType == HireTypes.Hourly.ToString())
                {
                    employ.MonthlyPayout = employ.Salary * 0.25;
                    Console.WriteLine(HireTypes.Hourly.ToString() + " Payout: $" + employ.Salary);
                }
                else
                {
                    Console.WriteLine(HireTypes.FullTime.ToString() + " Payout: $" + employ.Salary);
                }
                
                Console.WriteLine("----------------------------------------");

                totalSalary = totalSalary + employ.Salary;
                totalEmploy++;

            }

            // foreach(SectionA.Employee employ in listOfEmployees)
            // {
            //     Console.WriteLine(employ.FullName + " (" + employ.Nric + ")");
            //     Console.WriteLine(employ.Designation);

            //     if (employ.HireType == HireTypes.PartTime.ToString())
            //     {
            //         employ.Salary = employ.Salary * 0.5;
            //         Console.WriteLine(HireTypes.PartTime.ToString() + " Payout: $" + employ.Salary);
            //     }
            //     else if (employ.HireType == HireTypes.Hourly.ToString())
            //     {
            //         employ.Salary = employ.Salary * 0.25;
            //         Console.WriteLine(HireTypes.Hourly.ToString() + " Payout: $" + employ.Salary);
            //     }
            //     else
            //     {
            //         Console.WriteLine(HireTypes.FullTime.ToString() + " Payout: $" + employ.Salary);
            //     }
                
            //     Console.WriteLine("----------------------------------------");

            //     totalSalary = totalSalary + employ.Salary;
            //     totalEmploy++;
            // }

            Console.WriteLine("Total Payroll Amount: $" + totalSalary + " to be paid to " + totalEmploy + " employees.");
            Console.WriteLine(" ");
        }

        static void updateMonthlyPayoutToMasterlist(List<SectionA.Employee> listOfEmployees)
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
                            sw.WriteLine(employ.Nric + "|" + employ.FullName + "|" + employ.Salutation + "|" + employ.StartDate.ToString("dd/MM/yyyy") + "|" + employ.Designation + "|" + employ.Department + "|" + employ.MobileNo + "|" + employ.HireType + "|" + employ.Salary + "|" + employ.Salary);
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