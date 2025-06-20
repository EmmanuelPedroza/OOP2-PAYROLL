using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Classes
{
    internal class Salaried : Employee
    {
        private double _salary;
        public double Salary => _salary;
        public Salaried(string id, string name, string address, string phoneNumber, int ssn, string dob, string department, double salary)
            : base(id, name, address, phoneNumber, ssn, dob, department)
        {
            _salary = salary;
        }

        public override string ToString()
        {
            string display = 
                string.Format("ID : {0}", ID) + "\n" +
                string.Format("Name : {0}", Name) + "\n" +
                string.Format("Address : {0}", Address) + "\n" +
                string.Format("Phone Number : {0}", PhoneNumber) + "\n" +
                string.Format("SSN : {0}", SSN) + "\n" +
                string.Format("DOB : {0}", DOB) + "\n" +
                string.Format("Department : {0}", Department) + "\n" +
                string.Format("Salary : {0:C}", Salary) + "\n" +
                string.Format("Salary: {0}", CalculatePay());
            return display;
        }

        public double CalculatePay()
        {
            return Salary / 12; // Assuming salary is annual, return monthly pay
        }

        public string DisplayNameAndSalary()
        {
            return string.Format("Name: {0}, Salary: {1:C}", Name, CalculatePay());
        }
    }
}
