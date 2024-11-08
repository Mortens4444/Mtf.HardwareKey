namespace Mtf.HardwareKey.Structs
{
    public struct NSPRO_KEY_monitorInfoEx
    {
        /// <summary>
        /// developer id of the key
        /// </summary>
        public ulong devId;

        /// <summary>
        /// serial number of the key
        /// </summary>
        public ulong serialNum;

        /// <summary>
        /// capabilities of the key
        /// </summary>
        public ulong capabilities;

        /// <summary>
        /// hard limit of the key
        /// </summary>
        public ulong hardLimit;

        /// <summary>
        /// number of licenses in use for the key
        /// </summary>
        public ulong inUse;

        /// <summary>
        /// number of timeouts recorded for the key
        /// </summary>
        public ulong numTimeOut;

        /// <summary>
        /// highest number of licenses issued from the key throughout the life of server
        /// </summary>
        public ulong highestUse;

        /// <summary>
        /// the sub-license limit of certain cell
        /// </summary>
        public ulong subLicLimit;

        /// <summary>
        /// the number of sub-licenses in use for certain cell
        /// </summary>
        public ulong subLicInUse;

        /// <summary>
        /// reserved for future use
        /// </summary>
        public ulong reserved;
    }
}
