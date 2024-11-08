﻿using Mtf.HardwareKey.Models;

namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyInfoProvider
    {
        public static HardwareKeyInfo Get(ulong[] apiPacket)
        {
            var result = new HardwareKeyInfo();
            var status = SentinelAPI.RNBOsproGetKeyType(apiPacket, out var family, out var form, out var memorySize);
            StatusCodeChecker.CheckForError(status);
            result.Family = family;
            result.Form = form;
            result.MemorySize = memorySize;

            status = SentinelAPI.RNBOsproGetVersion(apiPacket, out var majorVersion, out var minorVersion, out var revision, out var driverType);
            StatusCodeChecker.CheckForError(status);
            result.MajorVersion = majorVersion;
            result.MinorVersion = minorVersion;
            result.Revision = revision;
            result.DriverType = driverType;

            //var monitorInfo = new NSPRO_monitorInfo();
            //monitorInfo.Initialize();
            //status = SentinelAPI.RNBOsproGetKeyInfo(apiPacket, 0xFFFF, hardwareKeyIndex, out monitorInfo);
            //status = SentinelAPI.RNBOsproGetKeyInfo(apiPacket, developerId, hardwareKeyIndex, ref monitorInfo);
            //var monitorInfo = new byte[288];
            //status = SentinelAPI.RNBOsproGetKeyInfo(apiPacket, developerId, hardwareKeyIndex, out monitorInfo);
            //StatusCodeChecker.CheckForError(status);
            //MonitorInfo = monitorInfo;

            status = SentinelAPI.RNBOsproGetHardLimit(apiPacket, out var hardLimit);
            StatusCodeChecker.CheckForError(status);
            result.HardLimit = hardLimit;

            var contactServer = new char[Constants.MaxNameLength];
            status = SentinelAPI.RNBOsproGetContactServer(apiPacket, contactServer, Constants.MaxNameLength);
            StatusCodeChecker.CheckForError(status);
            result.ContactServer = contactServer.ToString();
            return result;
        }

        ////Under construction
        //public static void GetKeyInfo(HardwareKeyDeveloper developerId, ushort hardwareKeyIndex = 0)
        //{

        //var nsproMonitorInfo = new NSPRO_monitorInfoEx();
        //var array = new byte[Marshal.SizeOf<NSPRO_monitorInfoEx>()];
        //var status = SentinelAPI.RNBOsproGetKeyInfoEx(apiPacket, 0, hardwareKeyIndex, 0, array, Constants.NsproMonitorInfoExLength);
        //if ((status == SentinelStatusCode.Success) || (status == SentinelStatusCode.InternalError)) // ???
        //{
        //    var usedLicenses = nsproMonitorInfo.sproKeyMonitorInfo.inUse;
        //    var usedSublicenses = nsproMonitorInfo.sproKeyMonitorInfo.subLicInUse;
        //}

        //    var apiPacket = HardwareKeyPacketBuilder.Create();
        //    HardwareKeySelector.Select(developerId, apiPacket, hardwareKeyIndex);

        //    //	var monitorInfo = new NSPRO_monitorInfoEx();
        //    //	monitorInfo.Initialize();
        //    //status = SentinelAPI.RNBOsproGetKeyInfo(apiPacket, 0xFFFF, hardwareKeyIndex, out monitorInfo);
        //    //status = SentinelAPI.RNBOsproGetKeyInfo(apiPacket, developerId, hardwareKeyIndex, ref monitorInfo);
        //    var monitorInfo = new byte[1000];

        //    //developerId = 0xFFFF;

        //    //	var size = (ushort)1;// (ushort)Marshal.SizeOf(typeof(NSPRO_monitorInfoEx));
        //    //			var size = (ushort)204;// (ushort)Marshal.SizeOf(typeof(NSPRO_monitorInfoEx));
        //    //			var size = (ushort)Marshal.SizeOf(monitorInfo);

        //    //FindKey(HardwareKeyType.Sziltech, hardwareKeyIndex, apiPacket);

        //    for (var i = 0; i < 1000; i++)
        //    {
        //        var monitorInfo2 = new byte[i];
        //        var status2 = SentinelAPI.RNBOsproGetKeyInfo(apiPacket, (HardwareKeyDeveloper)developerId, hardwareKeyIndex, ref monitorInfo2);
        //        //var status2 = SentinelAPI.RNBOsproGetKeyInfoEx(apiPacket, (ushort)type, hardwareKeyIndex, 0, monitorInfo2, (ushort)i);
        //        if ((status2 == SentinelStatusCode.Success) || (type == (ushort)HardwareKeyDeveloper.Sziltech))
        //        {
        //            throw new Exception(String.Concat("RNBOsproGetKeyInfo status code: ", status2, Environment.NewLine, GetStatusMessageDetails(status2)));
        //        }
        //    }

        //    var status = SentinelAPI.RNBOsproGetKeyInfo(apiPacket, (HardwareKeyType)type, hardwareKeyIndex, monitorInfo);
        //    var status = SentinelAPI.RNBOsproGetKeyInfoEx(apiPacket, type, hardwareKeyIndex, 0, out monitorInfo, size);
        //    StatusCodeChecker.CheckForError(status);

        //    MonitorInfo = monitorInfo;

        //    // Bit values
        //    var nspro_monitorInfo = new NSPRO_monitorInfoEx();
        //    nspro_monitorInfo.Initialize();

        //    var size = (ushort)Marshal.SizeOf(typeof(NSPRO_monitorInfoEx));
        //    //var size = (ulong)sizeof(NSPRO_monitorInfoEx);
        //    //var size = (ulong)Marshal.SizeOf(nspro_monitorInfo);
        //    var status = SentinelAPI.RNBOsproGetKeyInfoEx(apiPacket, developerId, hardwareKeyIndex, (ushort)MemoryAddress._00, out nspro_monitorInfo, size);
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