using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Persons
{
    public class Doctor : Person
    {
        private Guid _ID;

        public Doctor(string firstName, string lastName, string email, string phoneNumber, int age, Guid ID)
            : base(firstName, lastName, email, phoneNumber, age)
        {
            _ID = ID;
        }
        public Guid Id
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
