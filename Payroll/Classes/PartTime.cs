using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Classes
{
    internal class PartTime : Employee
    {
        private double _rate;
        private int _hoursWorked;

        public double Rate => _rate;
        public int HoursWorked => _hoursWorked;

        public PartTime(string id, string name, string address, string phoneNumber, int ssn, string dob, string department, double rate, int hoursWorked)
            : base(id, name, address, phoneNumber, ssn, dob, department)
        {
            _rate = rate;
            _hoursWorked = hoursWorked;
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
                string.Format("Rate : {0:C}", Rate) + "\n" +
                string.Format("Hours Worked : {0}", HoursWorked) + "\n" +
                string.Format("Salary: {0}", CalculatePay());
            return display;
        }

        public double CalculatePay()
        {
            return Rate * HoursWorked;
        }

        public string DisplayNameAndSalary() 
        {
            return string.Format("Name: {0}, Salary: {1:C}", Name, CalculatePay());
        }
    }
}
