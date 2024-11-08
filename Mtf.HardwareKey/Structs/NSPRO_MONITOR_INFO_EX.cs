namespace Mtf.HardwareKey.Structs
{
    public struct NSPRO_monitorInfoEx
    {
        public byte[] serverName;

        /// <summary>
        /// Server's IP address.
        /// </summary>
        public byte[] serverIPAddress;

        /// <summary>
        /// Server's IPX address.
        /// </summary>
        public byte[] serverIPXAddress;

        /// <summary>
        /// Version of the server.
        /// </summary>
        public byte[] version;

        /// <summary>
        /// Protocols supported by the server.
        /// </summary>
        public ulong protocol;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public ulong reserved;

        public NSPRO_KEY_monitorInfoEx sproKeyMonitorInfo;

        public void Initialize()
        {
            serverName = new byte[Constants.MaxNameLength];
            serverIPAddress = new byte[Constants.MaxIpAddressLength];
            serverIPXAddress = new byte[Constants.MaxHostAddressLength];
            version = new byte[Constants.MaxNameLength];
        }
    }
}
