using System.Runtime.InteropServices;
using System.Security;
using System;
using System.Threading;

namespace Mtf.HardwareKey.Models
{
    public class PasswordStorage : IDisposable
    {
        private volatile int disposed;

        private SecureString secretCode;

        public ushort WritePassword { get; set; }

        public ushort OverwritePassword1 { get; set; }

        public ushort OverwritePassword2 { get; set; }

        public string SecretCode
        {
            get
            {
                if (secretCode == null)
                {
                    return String.Empty;
                }

                var unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secretCode);
                    return Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    secretCode = new SecureString();
                }

                var secureString = new SecureString();
                foreach (var ch in value)
                {
                    secureString.AppendChar(ch);
                }
                secureString.MakeReadOnly();
                secretCode = secureString;
            }
        }

        ~PasswordStorage()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposed, 1) != 0)
            {
                return;
            }

            if (disposing)
            {
                secretCode.Dispose();
            }
        }
    }
}
