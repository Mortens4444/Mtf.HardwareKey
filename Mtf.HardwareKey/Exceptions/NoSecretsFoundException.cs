using System;

namespace Mtf.HardwareKey.Exceptions
{
    public class NoSecretsFoundException : Exception
    {
        public NoSecretsFoundException(string message) : base(message) { }
    }
}
