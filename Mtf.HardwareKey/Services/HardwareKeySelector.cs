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

            //_ = SentinelAPI.SetDeveloperCode(apiPacket, developerCode, size);

            _ = SentinelAPI.FindFirstUnit(apiPacket, developerId);
            //if (status == SentinelStatusCode.NoLicenseAvailable)
            //{
            //    //status = SentinelAPI.ReleaseMainLicense(apiPacket);
            //    status = SentinelAPI.ReleaseLicense(apiPacket, MemoryAddress.Get(developerId, MemoryDataType.SafeNetKeySerialNumber), new ushort[] { 0 });
            //    StatusCodeChecker.CheckForError(status);

            //    status = SentinelAPI.FindFirstUnit(apiPacket, developerId);
            //}

            while ((hardwareKeyIndex > 0) && (SentinelAPI.FindNextUnit(apiPacket) == SentinelStatusCode.Success))
            {
                hardwareKeyIndex--;
            }
        }
    }
}
