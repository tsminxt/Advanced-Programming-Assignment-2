using System;
using System.IO;

namespace SectionA

{
    public class Employee
        {
            public string Nric {get; set;}

            public string FullName {get; set;}

            public string Salutation {get; set;}

            public DateTime StartDate {get; set;}

            public string Designation {get; set;}

            public string Department {get; set;}

            public string MobileNo {get; set;}

            public string HireType {get; set;}
    
            public double Salary {get; set;}

            public double MonthlyPayout = 0.0;
        
            // Constructor that takes one argument:
            public Employee(string nric, string fullName, string salutation, DateTime startDate, string designation, string department, string mobileNo, string hireType, double monthlyPayout)
            {
                nric = Nric;
                fullName = FullName;
                salutation = Salutation;
                startDate = StartDate;
                designation = Designation;
                department = Department;
                mobileNo = MobileNo;
                hireType = HireType;
                monthlyPayout = MonthlyPayout;
            }
        }

        class Program
        {
             public static List<Employee> ReadFromFile(string fileName)
            {
                var result = new List<Employee>(); // in a list

                using (var sr = new StreamReader(fileName))
                {
                     while (!sr.EndOfStream)
                     {
                        string line = sr.ReadLine();
                        var parts = line.Split( '|' );
                         if (parts.Count() == 9)
                         {
                            Employee x = new Employee
                            (
                                parts[0],
                                parts[1],
                                parts[2],
                                Convert.ToDateTime(parts[3]),
                                parts[4],
                                parts[5],
                                parts[6],
                                parts[7],
                                Convert.ToDouble(parts[8])
                            );
                         }
                     }
                 }

                return result;
             }
            static void Main(string[] args)
            {
                ReadFromFile("HRMasterlist.txt");
            }

             static void generateInfoForCorpAdmin()
            {   
                string myFile = "HRMasterlist.txt";
                var theList = ReadFromFile(myFile);
                // using (StreamWriter sw = File.CreateText(myFile))

                foreach(var c in theList) //shld be one function generate strng; write to file is another function
                {
                    Console.WriteLine($"{c.FullName}, {c.Designation}, {c.Department}"); // to variable then u reutrn whole variable
                }

                Console.ReadLine();
                // myFile.close();
            }

            static void generateInfoForITDepartment()
            {
                string itdepart = @"HRMasterlist.txt";
                var theList = ReadFromFile(itdepart);

                foreach(var c in theList)
                {
                    Console.WriteLine($"{c.Nric}, {c.FullName}, {c.StartDate}, {c.Department}, {c.MobileNo}");
                }

                Console.ReadLine();
            }
            static void generateInfoForProcurement()
            {
                string procurement = @"HRMasterlist.txt";
                var theList = ReadFromFile(procurement);

                foreach(var c in theList)
                {
                    Console.WriteLine($"{c.Salutation}.{c.FullName} {c.MobileNo}, {c.Designation}, {c.Department}");
                }

                Console.ReadLine();
            }

        }
}

// var file = "HRMasterlist.txt";

// string[] readText = File.ReadAllLines(file);
// foreach (string s in readText)
// {
//     Console.WriteLine(s);
// }