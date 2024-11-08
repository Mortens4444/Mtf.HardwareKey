namespace Mtf.HardwareKey.Structs
{
    public struct NSPRO_monitorInfo
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
        public ushort protocol;

        public void Initialize()
        {

            serverName = new byte[Constants.MaxNameLength];
            serverIPAddress = new byte[Constants.MaxHostAddressLength];
            serverIPXAddress = new byte[Constants.MaxHostAddressLength];
            version = new byte[Constants.MaxNameLength];
            //80 + 208

            sproKeyMonitorInfo = new NSPRO_KEY_monitorInfo();
        }

        public NSPRO_KEY_monitorInfo sproKeyMonitorInfo;
    }
}
