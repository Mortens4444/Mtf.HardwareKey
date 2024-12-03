namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyCleanupService
    {
        public static void Cleanup(ulong[] apiPacket)
        {
            _ = SentinelAPI.ReleaseMainLicense(apiPacket);
            SentinelAPI.Cleanup();

            //var i = 0;
            //ushort status;
            //do
            //{
            //    _ = SentinelAPI.ReleaseLicense(apiPacket, 0x00, new ushort[] { 0 });
            //    Thread.Sleep(100);
            //    i++;
            //    if (i == 10)
            //    {
            //        SentinelAPI.Cleanup(); // ToDo: This seems wrong!
            //    }
            //}
            //while (i < 10);
            //SentinelAPI.Cleanup();
        }
    }
}
