using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.DataManager;

namespace Payroll.Helpers
{
    class MenuHelper
    {
        private readonly EmployeeManager _employeeManager;
        public EmployeeManager EmployeeManager => _employeeManager;
        public MenuHelper(EmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public enum MenuOptions
        {
            None,
            ShowEmployees = 'a',
            CalculateEmployeesAveragePay = 'b',
            ShowHighestPaidEmployee = 'c',
            ShowLowestPaidEmployee = 'd',
            ShowEmployeePercentage = 'e',
            Exit = 'x'
        }

        public void ShowMenuOptions()
        { 
            Console.WriteLine("Please select an option:");
            Console.WriteLine("a) Show all employees");
            Console.WriteLine("b) Calculate employees average pay");
            Console.WriteLine("c) Show highest paid employee");
            Console.WriteLine("d) Show lowest paid employee");
            Console.WriteLine("e) Show employee percentage");
            Console.WriteLine("x) Exit");
            Console.Write("Enter your choice: ");
            Console.WriteLine();
        }
    }
}
