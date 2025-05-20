// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0022:Use block body for method")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "type", Target = "~T:Mtf.HardwareKey.VirtualHardwareKey")]
[assembly: SuppressMessage("Design", "CA1028:Enum Storage should be Int32")]
[assembly: SuppressMessage("Design", "CA1008:Enums should have zero value")]
[assembly: SuppressMessage("Design", "CA1032:Implement standard exception constructors")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields")]
[assembly: SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types")]
[assembly: SuppressMessage("Usage", "CA2225:Operator overloads have named alternates")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
[assembly: SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "<Pending>", Scope = "type", Target = "~T:Mtf.HardwareKey.VirtualHardwareKey")]
[assembly: SuppressMessage("Security", "CA5351:Do Not Use Broken Cryptographic Algorithms", Justification = "<Pending>", Scope = "member", Target = "~M:Mtf.HardwareKey.Services.HashProvider.MD5Hash(System.String)~System.String")]
[assembly: SuppressMessage("Design", "CA1065:Do not raise exceptions in unexpected locations", Justification = "<Pending>", Scope = "member", Target = "~M:Mtf.HardwareKey.Models.MemoryAddress.op_Implicit(System.UInt16)~Mtf.HardwareKey.Models.MemoryAddress")]
[assembly: SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "<Pending>", Scope = "member", Target = "~M:Mtf.HardwareKey.VirtualHardwareKey.Dispose")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix")]
[assembly: SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "<Pending>", Scope = "member", Target = "~F:Mtf.HardwareKey.SentinelSuperProHardwareKey.licenseMaintainer")]
[assembly: SuppressMessage("Security", "CA5393:Do not use unsafe DllImportSearchPath value", Justification = "<Pending>", Scope = "type", Target = "~T:Mtf.HardwareKey.SentinelAPI")]
[assembly: SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "<Pending>", Scope = "member", Target = "~F:Mtf.HardwareKey.SziltechHardwareKey.timer")]
