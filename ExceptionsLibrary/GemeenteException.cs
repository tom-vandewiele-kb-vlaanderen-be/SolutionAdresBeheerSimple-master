using System;
using System.Collections.Generic;
using System.Text;

namespace AdresBeheerExceptions
{
    public class GemeenteException : Exception
    {
        public GemeenteException(string message) : base(message)
        {
        }
    }
}
