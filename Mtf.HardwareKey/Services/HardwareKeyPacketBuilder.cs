using Mtf.HardwareKey.Models;
using Mtf.HardwareKey.Structs;
using System;

namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyPacketBuilder
    {
        public static ulong[] Create(HardwareKeyDeveloper developerId, string contactServer = "")
        {
            var apiPacket = new ulong[Constants.NsproApiPacketSize];

            _ = SentinelAPI.FormatPacket(apiPacket, (ushort)apiPacket.Length);
            _ = SentinelAPI.Initialize(apiPacket);

            //ushort numberOfProtectionServers = 0;
            //var serverInfo = new NSPRO_SERVER_INFO[10];
            //for (var i = 0; i < serverInfo.Length; i++)
            //{
            //    serverInfo[i] = new NSPRO_SERVER_INFO();
            //    serverInfo[i].Initialize();
            //}
            //_ = SentinelAPI.EnumServer(Enums.EnumServer.AllSentinalProtectionServer, serverInfo, ref numberOfProtectionServers);

            if (!String.IsNullOrEmpty(contactServer))
            {
                //status = SentinelAPI.SetContactServer(apiPacket, Constants.RnboStandAlone);
                //status = SentinelAPI.SetContactServer(apiPacket, Constants.RnboSpnDriver);
                _ = SentinelAPI.SetContactServer(apiPacket, contactServer);
            }
            //_ = SentinelAPI.GetContactServer(apiPacket, "no-net".ToCharArray(), 6);
            //_ = SentinelAPI.SetContactServer(apiPacket, "no-net");
            return apiPacket;
        }
    }
}
