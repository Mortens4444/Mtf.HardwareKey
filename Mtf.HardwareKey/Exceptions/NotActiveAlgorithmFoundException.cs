using System;

namespace Mtf.HardwareKey.Exceptions
{
    public class NotActiveAlgorithmFoundException : Exception
    {
        public NotActiveAlgorithmFoundException() : base("The address is not the first word of an active algorithm") { }
    }
}
