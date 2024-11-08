namespace Mtf.HardwareKey.Structs
{
    public struct NSPRO_SERVER_INFO
    {
        public byte[] serverAddress;

        public ushort numLicAvail;

        public void Initialize()
        {
            serverAddress = new byte[Constants.MaxHostAddressLength];
        }
    }
}
