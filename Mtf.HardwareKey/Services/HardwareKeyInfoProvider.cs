using Mtf.HardwareKey.Models;

namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyInfoProvider
    {
        public static HardwareKeyInfo Get(ulong[] apiPacket)
        {
            var result = new HardwareKeyInfo();
            _ = SentinelAPI.GetKeyType(apiPacket, out var family, out var form, out var memorySize);
            result.Family = family;
            result.Form = form;
            result.MemorySize = memorySize;

            _ = SentinelAPI.GetVersion(apiPacket, out var majorVersion, out var minorVersion, out var revision, out var driverType);
            result.MajorVersion = majorVersion;
            result.MinorVersion = minorVersion;
            result.Revision = revision;
            result.DriverType = driverType;

            //var monitorInfo = new NSPRO_monitorInfo();
            //monitorInfo.Initialize();
            //_ = SentinelAPI.GetKeyInfo(apiPacket, 0xFFFF, hardwareKeyIndex, out monitorInfo);
            //_ = SentinelAPI.GetKeyInfo(apiPacket, developerId, hardwareKeyIndex, ref monitorInfo);
            //var monitorInfo = new byte[288];
            //_ = SentinelAPI.GetKeyInfo(apiPacket, developerId, hardwareKeyIndex, out monitorInfo);
            //MonitorInfo = monitorInfo;

            _ = SentinelAPI.GetHardLimit(apiPacket, out var hardLimit);
            result.HardLimit = hardLimit;

            var contactServer = new char[Constants.MaxNameLength];
            _ = SentinelAPI.GetContactServer(apiPacket, contactServer, Constants.MaxNameLength);
            result.ContactServer = contactServer.ToString();
            return result;
        }

        ////Under construction
        //public static void GetKeyInfo(HardwareKeyDeveloper developerId, ushort hardwareKeyIndex = 0)
        //{

        //var nsproMonitorInfo = new NSPRO_monitorInfoEx();
        //var array = new byte[Marshal.SizeOf<NSPRO_monitorInfoEx>()];
        //var status = SentinelAPI.GetKeyInfoEx(apiPacket, 0, hardwareKeyIndex, 0, array, Constants.NsproMonitorInfoExLength);
        //if ((status == SentinelStatusCode.Success) || (status == SentinelStatusCode.InternalError)) // ???
        //{
        //    var usedLicenses = nsproMonitorInfo.sproKeyMonitorInfo.inUse;
        //    var usedSublicenses = nsproMonitorInfo.sproKeyMonitorInfo.subLicInUse;
        //}

        //    var apiPacket = HardwareKeyPacketBuilder.Create();
        //    HardwareKeySelector.Select(developerId, apiPacket, hardwareKeyIndex);

        //    //	var monitorInfo = new NSPRO_monitorInfoEx();
        //    //	monitorInfo.Initialize();
        //    //status = SentinelAPI.GetKeyInfo(apiPacket, 0xFFFF, hardwareKeyIndex, out monitorInfo);
        //    //status = SentinelAPI.GetKeyInfo(apiPacket, developerId, hardwareKeyIndex, ref monitorInfo);
        //    var monitorInfo = new byte[1000];

        //    //developerId = 0xFFFF;

        //    //	var size = (ushort)1;// (ushort)Marshal.SizeOf(typeof(NSPRO_monitorInfoEx));
        //    //			var size = (ushort)204;// (ushort)Marshal.SizeOf(typeof(NSPRO_monitorInfoEx));
        //    //			var size = (ushort)Marshal.SizeOf(monitorInfo);

        //    //FindKey(HardwareKeyType.Sziltech, hardwareKeyIndex, apiPacket);

        //    for (var i = 0; i < 1000; i++)
        //    {
        //        var monitorInfo2 = new byte[i];
        //        var status2 = SentinelAPI.GetKeyInfo(apiPacket, (HardwareKeyDeveloper)developerId, hardwareKeyIndex, ref monitorInfo2);
        //        //var status2 = SentinelAPI.GetKeyInfoEx(apiPacket, (ushort)type, hardwareKeyIndex, 0, monitorInfo2, (ushort)i);
        //        if ((status2 == SentinelStatusCode.Success) || (type == (ushort)HardwareKeyDeveloper.Sziltech))
        //        {
        //            throw new Exception(String.Concat("RNBOsproGetKeyInfo status code: ", status2, Environment.NewLine, GetStatusMessageDetails(status2)));
        //        }
        //    }

        //    var status = SentinelAPI.GetKeyInfo(apiPacket, (HardwareKeyType)type, hardwareKeyIndex, monitorInfo);
        //    var status = SentinelAPI.GetKeyInfoEx(apiPacket, type, hardwareKeyIndex, 0, out monitorInfo, size);
        //    StatusCodeChecker.CheckForError(status);

        //    MonitorInfo = monitorInfo;

        //    // Bit values
        //    var nspro_monitorInfo = new NSPRO_monitorInfoEx();
        //    nspro_monitorInfo.Initialize();

        //    var size = (ushort)Marshal.SizeOf(typeof(NSPRO_monitorInfoEx));
        //    //var size = (ulong)sizeof(NSPRO_monitorInfoEx);
        //    //var size = (ulong)Marshal.SizeOf(nspro_monitorInfo);
        //    var status = SentinelAPI.GetKeyInfoEx(apiPacket, developerId, hardwareKeyIndex, (ushort)MemoryAddress._00, out nspro_monitorInfo, size);
        //    if ((status == SentinelStatusCode.Success) || (status == SentinelStatusCode.InternalError))
        //    {
        //        var l = nspro_monitorInfo.sproKeyMonitorInfo.inUse;
        //        l = nspro_monitorInfo.sproKeyMonitorInfo.subLicInUse;
        //        l += 0;
        //    }

        //    HardwareKeyCleanupService.Cleanup(apiPacket);
        //}
    }
}
