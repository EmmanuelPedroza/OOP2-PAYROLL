using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.DataManager;
using Payroll.Helpers;

namespace Payroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            MenuHelper menu = new MenuHelper(employeeManager);
            MenuHelper.MenuOptions option = MenuHelper.MenuOptions.None;

            while (option != MenuHelper.MenuOptions.Exit)
            {
                menu.ShowMenuOptions();
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Length == 1) 
                {
                    char charInput = input.ToLower()[0]; // Convert to lowercase to handle case insensitivity

                    if (Enum.IsDefined(typeof(MenuHelper.MenuOptions), (int)charInput))
                    {
                        option = (MenuHelper.MenuOptions) charInput;
                        switch (option)
                        {
                            case MenuHelper.MenuOptions.ShowEmployees:
                                employeeManager.ShowAllEmployees();
                                break;
                            case MenuHelper.MenuOptions.CalculateEmployeesAveragePay:
                                employeeManager.CalculateAveragePay();
                                break;
                            case MenuHelper.MenuOptions.ShowHighestPaidEmployee:
                                employeeManager.ShowHighestPaidEmployee();
                                break;
                            case MenuHelper.MenuOptions.ShowLowestPaidEmployee:
                                employeeManager.ShowLowestPaidEmployee();
                                break;
                            case MenuHelper.MenuOptions.ShowEmployeePercentage:
                                employeeManager.ShowEmployeePercentage();
                                break;
                            case MenuHelper.MenuOptions.Exit:
                                Console.WriteLine("Exiting the application. Goodbye!");
                                break;
                            default:
                                Console.WriteLine("Invalid option. Please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                    }
                }
            }
        }
    }
}
