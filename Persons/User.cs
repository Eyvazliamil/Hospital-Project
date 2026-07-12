using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Persons
{
    public class User : Person
    {
        private Guid _ID;
        private string _password; 
        public User(string firstName, string lastName, string email, string phoneNumber, string password, int age, Guid Id)
            : base(firstName, lastName, email, phoneNumber, age)
        {
            _ID = Id;
            Password = password;
        } 
        public Guid Id
        {
            get { return _ID; }
            set { _ID = Guid.NewGuid(); }
        } 
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
