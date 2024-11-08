using System;

namespace Mtf.HardwareKey.Exceptions
{
    public class WritePasswordNotFoundException : Exception
    {
        public WritePasswordNotFoundException() : base("Write password not found") { }
    }
}
