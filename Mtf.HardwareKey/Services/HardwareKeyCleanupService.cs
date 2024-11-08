namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyCleanupService
    {
        public static void Cleanup(ulong[] apiPacket)
        {
            var status = SentinelAPI.RNBOsproReleaseMainLicense(apiPacket);
            StatusCodeChecker.CheckForError(status);
            SentinelAPI.RNBOsproCleanup();

            //var i = 0;
            //ushort status;
            //do
            //{
            //    status = SentinelAPI.RNBOsproReleaseLicense(apiPacket, 0x00, new ushort[] { 0 });
            //    Thread.Sleep(100);
            //    i++;
            //    if (i == 10)
            //    {
            //        SentinelAPI.RNBOsproCleanup(); // ToDo: This seems wrong!
            //    }
            //}
            //while (status != SentinelStatusCode.Success && i < 10);
            //SentinelAPI.RNBOsproCleanup();
        }
    }
}
