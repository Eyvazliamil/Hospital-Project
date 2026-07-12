using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.CustomExceptions
{
    public class SymboleException : ApplicationException
    {
        public SymboleException(string msg) : base(msg)
        {
            
        }
    }
}
