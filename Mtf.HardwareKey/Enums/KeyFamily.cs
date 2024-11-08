using System.ComponentModel;

namespace Mtf.HardwareKey.Enums
{
    public enum KeyFamily : ushort
    {
        [Description("SSP")]
        SuperPro,

        [Description("SUP")]
        UltraPro
    }
}
