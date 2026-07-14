using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.CustomExceptions
{
    public class NegativeValueException : ApplicationException
    {
        public NegativeValueException(string msg) : base(msg)
        {
            
        }
    }
}
