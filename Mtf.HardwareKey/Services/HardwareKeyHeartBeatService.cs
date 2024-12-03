using Mtf.HardwareKey.Models;

namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyHeartBeatService
    {
        public static void SetHeartBeat(HardwareKeyDeveloper developerId, ushort index, uint second)
        {
            if (second < 60)
            {
                second = 60;
            }

            var heartbeatApiPacket = HardwareKeyPacketBuilder.Create(developerId);
            HardwareKeySelector.Select(developerId, heartbeatApiPacket, index);

            _ = SentinelAPI.SetHeartBeat(heartbeatApiPacket, second);

            HardwareKeyCleanupService.Cleanup(heartbeatApiPacket);
        }
    }
}
