using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Classes
{
    internal class Wage : Employee
    {
        private double _rate;
        private int _hoursWorked;
        public double Rate => _rate;
        public int HoursWorked => _hoursWorked;
        public Wage(string id, string name, string address, string phoneNumber, int ssn, string dob, string department, double rate, int hoursWorked)
            : base(id, name, address, phoneNumber, ssn, dob, department)
        {
            _rate = rate;
            _hoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            string display =
                String.Format("ID : {0}", ID) + "\n" +
                String.Format("Name : {0}", Name) + "\n" +
                String.Format("Address : {0}", Address) + "\n" +
                String.Format("Phone Number : {0}", PhoneNumber) + "\n" +
                String.Format("SSN : {0}", SSN) + "\n" +
                String.Format("DOB : {0}", DOB) + "\n" +
                String.Format("Department : {0}", Department) + "\n" +
                String.Format("Rate : {0:C}", Rate) + "\n" +
                String.Format("Hours Worked : {0}", HoursWorked) + "\n" +
                string.Format("Salary: {0}", CalculatePay());
            return display;
        }

        public double CalculatePay()
        {
            return HoursWorked > 40
                ? (Rate * 40) + ((Rate * 1.5) * (HoursWorked - 40))
                : Rate * _hoursWorked;
        }

        public string DisplayNameAndSalary()
        {
            return string.Format("Name: {0}, Salary: {1:C}", Name, CalculatePay());
        }
    }
}
