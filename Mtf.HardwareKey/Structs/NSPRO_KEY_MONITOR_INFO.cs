namespace Mtf.HardwareKey.Structs
{
    public struct NSPRO_KEY_monitorInfo
    {
        /// <summary>
        /// developer id of the key 
        /// </summary>
        public ushort devId;

        /// <summary>
        /// hardlimit of the key 
        /// </summary>
        public ushort hardLimit;

        /// <summary>
        /// Number of licenses in use for the key.
        /// </summary>
        public ushort inUse;

        /// <summary>
        /// Number of timeouts recorded for the key.
        /// </summary>
        public ushort numTimeOut;

        /// <summary>
        /// Highest number of licenses issued from the key throughout the life of server.
        /// </summary>
        public ushort highestUse;
    }
}
