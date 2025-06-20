using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Classes
{
    public abstract class Employee
    {
        private string _id;
        private string _name;
        private string _address;
        private string _phoneNumber;
        private int _ssn;
        private string _dob;
        private string _department;

        public string ID => _id;
        public string Name => _name;
        public string Address => _address;
        public string PhoneNumber => _phoneNumber;
        public int SSN => _ssn;
        public string DOB => _dob;
        public string Department => _department;

        public enum EmployeeType
        {
            Unknown = -1,
            Salaried,
            Wage,
            PartTime
        }

        public static Dictionary<EmployeeType, List<int>> EmployeeTypes = new Dictionary<EmployeeType, List<int>>
        {
            { EmployeeType.Salaried, new List<int> {0,1,2,3,4} },
            { EmployeeType.Wage, new List<int> {5,6,7} },
            { EmployeeType.PartTime, new List<int> {8,9} }
        };


        public Employee(string id, string name, string address, string phoneNumber, int ssn, string dob, string department)
        {
            _id = id;
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _address = address;
            _ssn = ssn;
            _dob = dob;
            _department = department;
        }
    }
}
