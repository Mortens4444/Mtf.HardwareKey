namespace Mtf.HardwareKey.Enums
{
    public enum EnumServer : ushort
    {
        /// <summary>
        /// First-found Sentinel Protection Server that has a license to offer.
        /// </summary>
        FirstAvailableSentinalProtectionServerWithLicense,

        /// <summary>
        /// First-found Sentinel Protection Server that may have a license.
        /// </summary>
        FirstAvailableSentinalProtectionServer,

        /// <summary>
        /// All the Sentinel Protection Servers in the subnet.
        /// </summary>
        AllSentinalProtectionServer
    }
}
