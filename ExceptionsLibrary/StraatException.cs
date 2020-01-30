using System;
using System.Collections.Generic;
using System.Text;

namespace AdresBeheerExceptions
{
    public class StraatException : Exception
    {
        public StraatException(string message) : base(message)
        {
        }
    }
}
