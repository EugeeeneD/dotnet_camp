using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Validators.Stubs
{
    public class StubEmailValidator : IEmailValidator
    {
        public bool IsValid(string email)
        {
            return true; ;
        }
    }
}
