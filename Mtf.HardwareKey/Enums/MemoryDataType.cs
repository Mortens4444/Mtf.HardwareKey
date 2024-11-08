using System.ComponentModel;

namespace Mtf.HardwareKey.Enums
{
    public enum MemoryDataType
    {
        [Description("BurlyWood")]
        SafeNetKeySerialNumber = 0x00,

        [Description("Chocolate")]
        SafeNetDeveloperId = 0x01,

        [Description("Brown")]
        SafeNetOverwritePassword1 = 0x02,

        [Description("Brown")]
        SafeNetOverwritePassword2 = 0x03,

        [Description("Firebrick")]
        SafeNetWritePassword = 0x04,

        [Description("Gainsboro")]
        SafeNetHardLicenseLimit = 0x05, //?

        [Description("Goldenrod")]
        SafeNetC6 = 0x06, //?

        [Description("Moccasin")]
        SafeNet = 0x07,

        [Description("Green")]
        License = 0x0A,

        [Description("Salmon")]
        UnknownActiveAlgorithm = 300,

        [Description("Violet")]
        UnknownInactiveAlgorithm,

        [Description("YellowGreen")]
        Unknown,

        [Description("White")]
        Undefined
    }
}
