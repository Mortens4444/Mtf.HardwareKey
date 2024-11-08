using System;

namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyPacketBuilder
    {
        public static ulong[] Create(string contactServer = "")
        {
            var apiPacket = new ulong[Constants.NsproApiPacketSize];

            var status = SentinelAPI.RNBOsproFormatPacket(apiPacket, (ushort)apiPacket.Length);
            StatusCodeChecker.CheckForError(status);

            status = SentinelAPI.RNBOsproInitialize(apiPacket);
            StatusCodeChecker.CheckForError(status);

            //ushort numberOfProtectionServers = 0;
            //var serverInfo = new byte[10000];
            //var serverInfo = new NSPRO_SERVER_INFO[10];
            //for (var i = 0; i < serverInfo.Length; i++)
            //{
            //    serverInfo[i] = new NSPRO_SERVER_INFO();
            //}
            //var status = SentinelAPI.RNBOsproEnumServer(ENUM_SERVER_FLAG.NSPRO_GET_ALL_SERVERS, 0xFFFF, serverInfo, ref numberOfProtectionServers);
            //StatusCodeChecker.CheckForError(status);

            //status = SentinelAPI.RNBOsproSetContactServer(apiPacket, Constants.RnboStandAlone);
            status = SentinelAPI.RNBOsproSetContactServer(apiPacket, String.IsNullOrEmpty(contactServer) ? Constants.RnboSpnDriver : contactServer);
            StatusCodeChecker.CheckForError(status);

            return apiPacket;
        }
    }
}
