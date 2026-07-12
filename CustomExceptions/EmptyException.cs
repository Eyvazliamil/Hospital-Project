using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.CustomExceptions
{
    public class EmptyException : ApplicationException
    {
        public EmptyException(string msg) : base(msg)
        {
            
        }
    }
}
