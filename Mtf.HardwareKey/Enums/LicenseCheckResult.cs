using System;

namespace Mtf.HardwareKey.Enums
{
    [Flags]
    public enum LicenseCheckResult : byte
    {
        HardwareKeyInitialization = 0, // ToDo: Consider removing this...
        HardwareKeyAlgorithmError = 1,
        HardwareKeyChecksumError = 2,
        VideoSupervisorNotLicensed = 4,
        LiveViewNotLicensed = 8,
        VideoSupervisorLicensed = 16,
        LiveViewLicensed = 32,
        Licensed = VideoSupervisorLicensed | LiveViewLicensed
    }
}
