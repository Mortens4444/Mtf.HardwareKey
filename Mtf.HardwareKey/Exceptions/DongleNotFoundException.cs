using System;

namespace Mtf.HardwareKey.Exceptions
{
    public class DongleNotFoundException : Exception
    {
        public DongleNotFoundException() : base("Hardware key not found") { }
    }
}
