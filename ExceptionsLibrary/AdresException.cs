using System;
using System.Collections.Generic;
using System.Text;

namespace AdresBeheerExceptions
{
    public class AdresException : Exception
    {
        public AdresException(string message) : base(message)
        {
        }
    }
}
