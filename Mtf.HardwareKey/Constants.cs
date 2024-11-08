namespace Mtf.HardwareKey
{
    public static class Constants
    {
        public const ushort MaxNameLength = 64;

        /// <summary>
        /// Maximum host address length.
        /// </summary>
        public const byte MaxHostAddressLength = 32;

        /// <summary>
        /// Maximum IP address length.
        /// </summary>
        public const byte MaxIpAddressLength = 64;

        public const ushort NsproMonitorInfoExLength = 320;

        public const int NsproApiPacketSize = 1028;

        public const string RnboStandAlone = "RNBO_STANDALONE";

        public const string RnboSpnDriver = "RNBO_SPN_DRIVER";
    }
}
