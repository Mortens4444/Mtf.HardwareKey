using System;

namespace Mtf.HardwareKey.Enums
{
    [Flags]
    public enum ShareMainLicense : ushort
    {
        /// <summary>
        /// Enables main license sharing.
        /// </summary>
        EnableMainLicenseSharing,

        /// <summary>
        /// Disables main license sharing.
        /// </summary>
        DisableMainLicenseSharing,

        //Combination of SP_DISABLE_DEVICE_SHARING flag with SP_ENABLE_MAINLIC_SHARING or SP_DISABLE_MAINLIC_SHARING (
    }
}
