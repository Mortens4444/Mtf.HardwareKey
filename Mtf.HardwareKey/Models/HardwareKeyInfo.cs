using Mtf.HardwareKey.Enums;

namespace Mtf.HardwareKey.Models
{
    public class HardwareKeyInfo
    {
        public KeyFamily Family { get; set; }

        public KeyFormFactor Form { get; set; }

        public ushort MemorySize { get; set; }

        public byte MajorVersion { get; set; }

        public byte MinorVersion { get; set; }

        public byte Revision { get; set; }

        public OperatingSystemDriverType DriverType { get; set; }

        public ushort HardLimit { get; set; }

        public string ContactServer { get; set; }

        //public NSPRO_monitorInfo MonitorInfo { get; set; }
    }
}
