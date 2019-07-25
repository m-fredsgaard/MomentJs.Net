using System;

namespace MomentJs.Net.Exceptions
{
    public class UnsupportedFormatException : Exception
    {
        public UnsupportedFormatException(string message) : base(message)
        {
        }
    }
}