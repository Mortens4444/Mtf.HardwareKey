using Mtf.HardwareKey.Interfaces;
using Mtf.HardwareKey.Models;
using System;

namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeySelector
    {
        public static void Select(IHardwareKey hardwareKey)
        {
            if (hardwareKey == null)
            {
                throw new ArgumentNullException(nameof(hardwareKey));
            }
            Select(hardwareKey.DeveloperId, hardwareKey.ApiPacket, hardwareKey.HardwareKeyIndex);
        }

        public static void Select(HardwareKeyDeveloper developerId, ulong[] apiPacket, ushort hardwareKeyIndex)
        {
            if (developerId == null)
            {
                throw new ArgumentNullException(nameof(developerId));
            }

            // Connects to Internet?
            var status = SentinelAPI.RNBOsproFindFirstUnit(apiPacket, developerId);
            //if (status == SentinelStatusCode.NoLicenseAvailable)
            //{
            //    //status = SentinelAPI.RNBOsproReleaseMainLicense(apiPacket);
            //    status = SentinelAPI.RNBOsproReleaseLicense(apiPacket, MemoryAddress.Get(developerId, MemoryDataType.SafeNetKeySerialNumber), new ushort[] { 0 });
            //    StatusCodeChecker.CheckForError(status);

            //    status = SentinelAPI.RNBOsproFindFirstUnit(apiPacket, developerId);
            //}
            StatusCodeChecker.CheckForError(status);

            while ((hardwareKeyIndex > 0) && ((status = SentinelAPI.RNBOsproFindNextUnit(apiPacket)) == SentinelStatusCode.Success))
            {
                hardwareKeyIndex--;
            }

            StatusCodeChecker.CheckForError(status);
        }
    }
}
