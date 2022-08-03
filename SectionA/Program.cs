using System;
using System.IO;

namespace SectionA
{
    public class Employee
    {
        public string Nric {get; set;}

        public string FullName {get; set;}

        public string Salutation {get; set;}

        public DateTime StartDate  {get; set;}

        public string Designation {get; set;}

        public string Department {get; set;}

        public string MobileNo {get; set;}

        public string HireType {get; set;}

        public double Salary {get; set;}

        public double MonthlyPayout = 0.0;
    }

    //1 -> declare a delegate
    public delegate void Delegate(List<Employee> listOfEmployees);
 
    public class Program
    {
        public static List<Employee> readHRMasterList()
        {
            List<Employee> listOfEmployees = new List<Employee>();

            using (StreamReader file = new StreamReader(@"C:\Users\User\Desktop\AVP Assignment 2\ASN2_Student_Resource\HRMasterlist.txt"))
            {
                    while (file.Peek() >= 0)
                    {
                    string str;
                    string[] strArray;
                    str = file.ReadLine();
                    strArray = str.Split( '|' );

                    var partsDate = strArray[3].Split('/');
                    DateTime dParts3 = new DateTime(Convert.ToInt32(partsDate[2]), Convert.ToInt32(partsDate[1]), Convert.ToInt32(partsDate[0]));

                    Employee newEmployee = new Employee();
                    newEmployee.Nric = strArray[0];
                    newEmployee.FullName = strArray[1];
                    newEmployee.Salutation = strArray[2];
                    newEmployee.StartDate = dParts3;
                    newEmployee.Designation = strArray[4];
                    newEmployee.Department = strArray[5];
                    newEmployee.MobileNo = strArray[6];
                    newEmployee.HireType = strArray[7];
                    newEmployee.Salary = Convert.ToDouble(strArray[8]);

                    listOfEmployees.Add(newEmployee);
                    }
                file.Close();
                }

            return listOfEmployees;
        }
        static void Main(string[] args)
        {
            // ReadFromFile("HRMasterlist.txt");
            List<Employee> listOfEmployees = readHRMasterList();

            // create delegate instances
            Delegate CorpAdmin = Method1.generateInfoForCorpAdmin;
            Delegate Procurement = Method2.generateInfoForITDepartment;
            Delegate ITDepart = Method3.generateInfoForProcurement;

            //Invoke a delegate
            Delegate genAll = CorpAdmin + Procurement + ITDepart;
            genAll(listOfEmployees);
        }
    }

    public class Method1
    {
        public static void generateInfoForCorpAdmin(List<Employee> listOfEmployees)
        {   
            string fileName = @"CorporateAdmin.txt";

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
                        sw.WriteLine(employ.FullName + "," + employ.Designation + "," + employ.Department);
                    }
                }
            }

            catch (Exception Ex)    
            {    
                Console.WriteLine(Ex.ToString());    
            }
        }
    }

    public class Method2
    {
        public static void generateInfoForITDepartment(List<Employee> listOfEmployees)
        {   
            string fileName = @"ITDepartment.txt";

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
                        sw.WriteLine(employ.Nric + "," + employ.FullName + "," + employ.StartDate.ToString("dd/MM/yyyy") + "," + employ.Department + "," + employ.MobileNo);
                    }
                }
            }

            catch (Exception Ex)    
            {    
                Console.WriteLine(Ex.ToString());    
            }
        }
    }

    public class Method3
    {
        public static void generateInfoForProcurement(List<Employee> listOfEmployees)
        {   
            string fileName = @"Procurement.txt";

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
                        sw.WriteLine(employ.Salutation + "," + employ.FullName + "," + employ.MobileNo + "," + employ.Designation + "," + employ.Department);
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
        
// Constructor that takes one argument:
// public Employee(string nric, string fullName, string salutation, DateTime startDate, string designation, string department, string mobileNo, string hireType, double monthlyPayout)
// {
//     nric = Nric;
//     fullName = FullName;
//     salutation = Salutation;
//     startDate = StartDate;
//     designation = Designation;
//     department = Department;
//     mobileNo = MobileNo;
//     hireType = HireType;
//     monthlyPayout = MonthlyPayout;

// }