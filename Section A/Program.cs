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
            static void HRMasterlist()
            {
                var file = "HRMasterlist.txt";

                using var sr = new StreamReader(file);

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            public static List<Employee> ReadFromFile(string fileName)
            {
                var result = new List<Employee>();

                using (var sr = new StreamReader(fileName))
                {
                     while (!sr.EndOfStream)
                     {
                        string line = sr.ReadLine();
                        var parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                         if (parts.Count() == 9)
                         {
                            result.Add(new Employee
                            {
                                 Nric = parts[1],
                                 FullName = parts[2],
                                 Salutation = parts[3],
                                 StartDate = Convert.ToDateTime(parts[4]),
                                 Designation = parts[5],
                                 Department = parts[6],
                                 MobileNo = parts[7],
                                 HireType = parts[8],
                                 MonthlyPayout = Convert.ToDouble(parts[9])
                            });
                         }
                     }
                 }

                return result;
             }

             static void Main(string[] args)
            {
                string myFile = "HRMasterlist.txt";
                var theList = ReadFromFile(myFile);
                
                foreach(var c in theList)
                {
                    Console.WriteLine($"{c.Nric}, {c.FullName}, {c.Designation}");
                }

                Console.ReadLine();
            }
             static void generateInfoForCorpAdmin()
            {   
                string myFile = "HRMasterlist.txt";
                var theList = ReadFromFile(myFile);
                // using (StreamWriter sw = File.CreateText(myFile))

                foreach(var c in theList)
                {
                    Console.WriteLine($"{c.FullName}, {c.Designation}, {c.Department}");
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