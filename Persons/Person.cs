using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Persons
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private int _age;

        public Person(string firstName, string lastName, string email, string phoneNumber, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phoneNumber = phoneNumber;
            _age = age;
        }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public int Age { get => _age; set => _age = value; }
    }
}
