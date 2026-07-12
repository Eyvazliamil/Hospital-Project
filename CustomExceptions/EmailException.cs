using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.CustomExceptions
{
    public class EmailException: ApplicationException
    {
        public EmailException(string msg) : base(msg)
        {
            
        }
    }
}
