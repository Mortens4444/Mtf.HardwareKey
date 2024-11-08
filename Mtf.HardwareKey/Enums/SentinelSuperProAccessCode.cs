namespace Mtf.HardwareKey.Enums
{
    public enum SentinelSuperProAccessCode : byte
    {
        ReadWrite = 0,
        ReadOnly = 1,
        Counter = 2,
        AlgorithmOrHidden = 3,
        AESAlgorithm = 7
    }
}
