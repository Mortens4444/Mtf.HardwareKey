using Mtf.HardwareKey.Interfaces;
using Mtf.HardwareKey.Models;
using Mtf.HardwareKey.Services;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Timers;

namespace Mtf.HardwareKey
{
    public class SentinelSuperProHardwareKey : HardwareKey, IHardwareKey
    {
        private readonly Timer licenseMaintainer; // ToDo: Check if it is needed? What about HardwareKeyHeartBeatService?

        public HardwareKeyInfo HardwareKeyInfo { get; protected set; }

        /// <summary>
        /// Not unique
        /// </summary>
        public ushort SentinelSerial { get; private set; }

        protected SentinelSuperProHardwareKey(ushort hardwareKeyIndex, bool autoSelect)
            : this(HardwareKeyDeveloper.Test1, hardwareKeyIndex, null, autoSelect)
        {
        }

        public SentinelSuperProHardwareKey(HardwareKeyDeveloper developerId, ushort hardwareKeyIndex, string contactServer, bool autoSelect)
            : base(developerId, hardwareKeyIndex, contactServer, autoSelect)
        {
            licenseMaintainer = new Timer(TimeSpan.FromSeconds(55).TotalMilliseconds)
            {
                AutoReset = false,
                Enabled = false,
            };
        }

        public void Initialize()
        {
            licenseMaintainer.Elapsed += (sender, args) => MaintainLicense();
            licenseMaintainer.Start();

            HardwareKeyInfo = HardwareKeyInfoProvider.Get(ApiPacket);
            SentinelSerial = ReadCellValue(MemoryAddress.SafeNet_KeySerialNumber);
        }

        public string this[ushort index] => ReadCellValue((MemoryAddress)index).ToString(CultureInfo.InvariantCulture);

        protected override void ReleaseManagedResources()
        {
            licenseMaintainer.Dispose();
        }

        private void MaintainLicense()
        {
            if (!PeriodicCheck())
            {
                Dispose();
                throw new LicenseException(GetType());
            }
        }

        public virtual bool PeriodicCheck()
        {
            _ = ReadCellValue(MemoryAddress.SafeNet_KeySerialNumber);
            return true;
        }
    }
}
