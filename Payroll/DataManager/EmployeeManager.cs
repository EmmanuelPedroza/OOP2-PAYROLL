using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.Classes;
using Payroll.Helpers;

namespace Payroll.DataManager
{
    public class EmployeeManager
    {
        private List<Employee> _employees = new List<Employee>();
        public List<Employee> Employees => _employees;
        public EmployeeManager() 
        {
            _employees = LoadEmployeeData();
        }

        public List<Employee> LoadEmployeeData()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                string[] lines = FileHelper.ReadFromFile("employees.txt");
          
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');

                    string idFirstDigit = parts[0].Substring(0, 1);

                    if (int.TryParse(idFirstDigit, out int id)) 
                    {
                        if (Employee.EmployeeTypes[Employee.EmployeeType.Salaried].Contains(id))
                        {
                            Salaried? salaried = CreateSalaried(parts);
                            if (salaried != null)
                            {
                                employees.Add(salaried);
                            }
                        }
                        else if (Employee.EmployeeTypes[Employee.EmployeeType.PartTime].Contains(id))
                        {
                            PartTime? partTime = CreatePartTime(parts);
                            if (partTime != null)
                            {
                                employees.Add(partTime);
                            }
                        }
                        else if (Employee.EmployeeTypes[Employee.EmployeeType.Wage].Contains(id))
                        {
                            Wage? wage = CreateWage(parts);
                            if (wage != null)
                            {
                                employees.Add(wage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading employee data: {ex.Message}");
            }
            return employees;
        }


        internal Salaried? CreateSalaried(string[] parts) =>
            parts.Length >= 8 ?
            new Salaried(parts[0], parts[1], parts[2], parts[3], int.Parse(parts[4]), parts[5], parts[6], double.Parse(parts[7])) :
            null;

        internal PartTime? CreatePartTime(string[] parts) =>
            parts.Length >= 9 ?
            new PartTime(parts[0], parts[1], parts[2], parts[3], int.Parse(parts[4]), parts[5], parts[6], double.Parse(parts[7]), int.Parse(parts[8])) :
            null;

        internal Wage? CreateWage(string[] parts) =>
            parts.Length >= 9 ?
            new Wage(parts[0], parts[1], parts[2], parts[3], int.Parse(parts[4]), parts[5], parts[6], double.Parse(parts[7]), int.Parse(parts[8])) :
            null;

        public void ShowAllEmployees() 
        {
            if (Employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("List of Employes:");

            foreach (var employee in Employees)
            {
                Console.WriteLine(employee.ToString());
                Console.WriteLine();
            }
        }

        public void CalculateAveragePay()
        {
            if (Employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Calculated Salary of each Employee and the Average pay of all employees:");
            Console.WriteLine();

            double employeePay = 0;
            foreach (var employee in Employees)
            {
                 
                if (employee is Salaried salaried)
                {
                    Console.WriteLine(salaried.DisplayNameAndSalary());
                    Console.WriteLine();
                    employeePay += salaried.CalculatePay();
                }
                else if (employee is PartTime partTime)
                {
                    Console.WriteLine(partTime.DisplayNameAndSalary());
                    Console.WriteLine();
                    employeePay += partTime.CalculatePay();
                }
                else if (employee is Wage wage)
                {
                    Console.WriteLine(wage.DisplayNameAndSalary());
                    Console.WriteLine();
                    employeePay += wage.CalculatePay();
                }
            }

            if (employeePay > 0)
            {
                Console.WriteLine($"Total Pay: {employeePay:C}");
                Console.WriteLine($"Average Pay: {employeePay / Employees.Count:C}");
                Console.WriteLine();
            }
        }

        public void ShowHighestPaidEmployee()
        {
            if (Employees.Count == 0)
            { 
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("The highest paying Employee:");
            Console.WriteLine();

            // In case that there will be more than one employee with the same highest pay.
            List<Employee> highestPaidEmployees = new List<Employee>();
            double highestPay = 0;
            foreach (Employee employee in Employees) 
            {
                if (employee is Salaried salaried)
                {
                    double pay = salaried.CalculatePay();
                    if (pay > highestPay) 
                    {
                        highestPay = pay;
                        highestPaidEmployees.Clear();
                        highestPaidEmployees.Add(salaried);
                    }
                    else if (pay == highestPay)
                    {
                        highestPaidEmployees.Add(salaried);
                    }
                }
                else if (employee is PartTime partTime)
                {
                    double pay = partTime.CalculatePay();
                    if (pay > highestPay)
                    {
                        highestPay = pay;
                        highestPaidEmployees.Clear();
                        highestPaidEmployees.Add(partTime);
                    }
                    else if (pay == highestPay)
                    {
                        highestPaidEmployees.Add(partTime);
                    }
                }
                else if (employee is Wage wage)
                {
                    double pay = wage.CalculatePay();
                    if (pay > highestPay)
                    {
                        highestPay = pay;
                        highestPaidEmployees.Clear();
                        highestPaidEmployees.Add(wage);
                    }
                    else if (pay == highestPay)
                    {
                        highestPaidEmployees.Add(wage);
                    }
                }
            }

            if (highestPaidEmployees.Count > 0)
            {
                Console.WriteLine("Highest Paid Employee(s):");
                foreach (var emp in highestPaidEmployees)
                {
                    if (emp is PartTime partTime)
                    {
                        Console.WriteLine(partTime.DisplayNameAndSalary());
                        Console.WriteLine();
                    }
                    else if (emp is Wage wage)
                    {
                        Console.WriteLine(wage.DisplayNameAndSalary());
                        Console.WriteLine();
                    }
                    else if (emp is Salaried salaried)
                    {
                        Console.WriteLine(salaried.DisplayNameAndSalary());
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }

        public void ShowLowestPaidEmployee()
        {

            Console.WriteLine();
            Console.WriteLine("The highest paying Employee:");
            Console.WriteLine();

            if (Employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }
            // In case that there will be more than one employee with the same lowest pay.
            List<Employee> lowestPaidEmployees = new List<Employee>();
            double lowestPay = double.MaxValue;
            foreach (Employee employee in Employees)
            {
                if (employee is Salaried salaried)
                {
                    double pay = salaried.CalculatePay();
                    if (pay < lowestPay)
                    {
                        lowestPay = pay;
                        lowestPaidEmployees.Clear();
                        lowestPaidEmployees.Add(salaried);
                    }
                    else if (pay == lowestPay)
                    {
                        lowestPaidEmployees.Add(salaried);
                    }
                }
                else if (employee is PartTime partTime)
                {
                    double pay = partTime.CalculatePay();
                    if (pay < lowestPay)
                    {
                        lowestPay = pay;
                        lowestPaidEmployees.Clear();
                        lowestPaidEmployees.Add(partTime);
                    }
                    else if (pay == lowestPay)
                    {
                        lowestPaidEmployees.Add(partTime);
                    }
                }
                else if (employee is Wage wage)
                {
                    double pay = wage.CalculatePay();
                    if (pay < lowestPay)
                    {
                        lowestPay = pay;
                        lowestPaidEmployees.Clear();
                        lowestPaidEmployees.Add(wage);
                    }
                    else if (pay == lowestPay)
                    {
                        lowestPaidEmployees.Add(wage);
                    }
                }
            }
            if (lowestPaidEmployees.Count > 0)
            {
                Console.WriteLine("Lowest Paid Employee(s):");
                foreach (var emp in lowestPaidEmployees)
                {
                    if (emp is PartTime partTime)
                    {
                        Console.WriteLine(partTime.DisplayNameAndSalary());
                        Console.WriteLine();
                    }
                    else if (emp is Wage wage)
                    {
                        Console.WriteLine(wage.DisplayNameAndSalary());
                        Console.WriteLine();
                    }
                    else if (emp is Salaried salaried)
                    {
                        Console.WriteLine(salaried.DisplayNameAndSalary());
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }

        public void ShowEmployeePercentage()
        {
            var employeeTypesCount = new Dictionary<Employee.EmployeeType, int>
            {
                { Employee.EmployeeType.Salaried, 0 },
                { Employee.EmployeeType.PartTime, 0 },
                { Employee.EmployeeType.Wage, 0 }
            };

            foreach (var employee in Employees)
            {
                if (employee is Salaried)
                {
                    employeeTypesCount[Employee.EmployeeType.Salaried]++;
                }
                else if (employee is PartTime)
                {
                    employeeTypesCount[Employee.EmployeeType.PartTime]++;
                }
                else if (employee is Wage)
                {
                    employeeTypesCount[Employee.EmployeeType.Wage]++;
                }
            }

            if (Employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Employee Percentage by Type:");
            Console.WriteLine();
            foreach (var type in employeeTypesCount.Keys)
            {
                double percentage = (double)employeeTypesCount[type] / Employees.Count * 100;
                Console.WriteLine($"{type}: {percentage:F2}%");
            }
            Console.WriteLine("Total: 100%");
            Console.WriteLine();
        }


    }
}
