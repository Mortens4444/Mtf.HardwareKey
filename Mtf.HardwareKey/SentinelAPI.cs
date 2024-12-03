using Mtf.HardwareKey.Enums;
using Mtf.HardwareKey.Models;
using Mtf.HardwareKey.Services;
using Mtf.HardwareKey.Structs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Mtf.HardwareKey
{
    internal class SentinelAPI
    {
        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproActivate(ulong[] thePacket, ushort writePassword, ushort activatePassword1, ushort activatePassword2, ushort address);

        /// <summary>
        /// This function activates an inactive algorithm at the specified cell address.
        /// You can call this function anytime after obtaining a license.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="writePassword">The write password for the key.</param>
        /// <param name="activate_password_1">The first word of the activation password.</param>
        /// <param name="activate_password_2">The second word of the activation password.</param>
        /// <param name="address">The address of the first word of an inactive algorithm.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode Activate(ulong[] thePacket, ushort writePassword, ushort activatePassword1, ushort activatePassword2, MemoryAddress address,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproActivate(thePacket, writePassword, activatePassword1, activatePassword2, (ushort)address);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern void RNBOsproCleanup();

        /// <summary>
        /// This function releases the memory resources acquired by the SuperPro client library.
        /// You can call this function immediately after calling RNBOsproReleaseLicense.
        /// </summary>
        public static void Cleanup()
        {
            RNBOsproCleanup();
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproDecrement(ulong[] thePacket, ushort writePassword, MemoryAddress address);

        /// <summary>
        /// This function is used to decrement a counter word by one.
        /// If the counter is associated with an active algorithm, and the counter is decremented to 0, the associated algorithm is made inactive.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="writePassword">The write password for the SuperPro key.</param>
        /// <param name="address">The address of the counter to decrement.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode Decrement(ulong[] thePacket, ushort writePassword, MemoryAddress address,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproDecrement(thePacket, writePassword, (ushort)address);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproEnumServer(EnumServer enumFlag, ushort developerId, NSPRO_SERVER_INFO[] serverInfo, ref ushort numberOfSentinelProtectionServerFound);

        /// <summary>
        /// This function enumerates the number of Sentinel Protection Servers running in the subnet for the developer ID specified.
        /// </summary>
        /// <param name="enumFlag">The flag used for contacting any of the following: NSPRO_RET_ON_FIRST_AVAILABLE, NSPRO_RET_ON_FIRST, NSPRO_GET_ALL_SERVERS.</param>
        /// <param name="developerId">The developer ID of the SuperPro key to find. The Sentinel Protection Servers running on the system having a key of matching developer ID ONLY will respond. If developer ID is specified as 0xFFFF, then all the Sentinel Protection Servers (for a specified protocol) will respond.</param>
        /// <param name="serverInfo">A pointer to a buffer that will contain the Sentinel Protection Server information, such as the system address and the number of licenses available. A developer needs to allocate memory for the buffer.</param>
        /// <param name="numberOfSentinelProtectionServerFound">A pointer to a variable that contains the desired number of the Sentinel Protection Servers. When the function returns, this variable contains the actual number of Sentinel Protection Servers found running on the network.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode EnumServer(EnumServer enumFlag, HardwareKeyDeveloper developerId, NSPRO_SERVER_INFO[] serverInfo, ref ushort numberOfSentinelProtectionServerFound,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproEnumServer(enumFlag, (ushort)developerId, serverInfo, ref numberOfSentinelProtectionServerFound);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        public static SentinelStatusCode EnumServer(EnumServer enumFlag, NSPRO_SERVER_INFO[] serverInfo, ref ushort numberOfSentinelProtectionServerFound,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproEnumServer(enumFlag, 0xFFFF, serverInfo, ref numberOfSentinelProtectionServerFound);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproExtendedRead(ulong[] thePacket, MemoryAddress address, out ushort data, out SentinelSuperProAccessCode accessCode);

        /// <summary>
        /// This function reads the word and access code at the specified address. On success, the data variable contains the information from the SuperPro key and the access code variable contains the access code.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="address">The address to be read.</param>
        /// <param name="data">A pointer to the variable that will contain the data read from the key.</param>
        /// <param name="accessCode">A pointer to the variable that will contain the access code associated with the word that was read.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode ExtendedRead(ulong[] thePacket, MemoryAddress address, out ushort data, out SentinelSuperProAccessCode accessCode,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproExtendedRead(thePacket, (ushort)address, out data, out accessCode);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproFindFirstUnit(ulong[] thePacket, HardwareKeyDeveloper developerId);

        /// <summary>
        /// This function finds the first SuperPro key with the specified developer ID and obtains a license, if available.
        /// If RNBOsproFindFirstUnit is called with an API packet that already has a license, gives Success.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="developerId">The developer ID of the SuperPro key to find.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode FindFirstUnit(ulong[] thePacket, HardwareKeyDeveloper developerId,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            // Connects to Internet?
            var status = RNBOsproFindFirstUnit(thePacket, (ushort)developerId);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproFindFirstUnit(ulong[] thePacket, ushort developerId);

        /// <summary>
        /// This function finds the first SuperPro key with the specified developer ID and obtains a license, if available.
        /// If RNBOsproFindFirstUnit is called with an API packet that already has a license, gives Success.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="developerId">The developer ID of the SuperPro key to find.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static ushort FindFirstUnit(ulong[] thePacket, ushort developerId,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproFindFirstUnit(thePacket, developerId);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproFindNextUnit(ulong[] thePacket);

        /// <summary>
        /// This API finds the next SuperPro key based on the developer ID maintained in the RB_SPRO_APIPACKET structure.
        /// This function should be called when RNBOsproFindFirstUnit has returned the NO_LICENSE_AVAILABLE error.
        /// If RNBOsproFindNextUnit returns success, the application will release the license obtained by the RNBOsproFindFirstUnit API call
        /// and will contain the data for the next SuperPro key. However, if the function returns an error, the RB_SPRO_APIPACKET structure will
        /// be marked invalid. To re-initialize the structure, use RNBOsproFindFirstUnit and optionally, RNBOsproFindNextUnit depending on the number of SuperPro keys found.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode FindNextUnit(ulong[] thePacket,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproFindNextUnit(thePacket);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproFormatPacket(ulong[] thePacket, ushort packetSize);

        /// <summary>
        /// This function initializes and validates the API packet based on its size.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="packetSize">The size of the RB_SPRO_APIPACKET structure.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode FormatPacket(ulong[] thePacket, ushort packetSize,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproFormatPacket(thePacket, packetSize);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll", CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        //private static extern SentinelStatusCode RNBOsproGetContactServer(ulong[] thePacket, StringBuilder serverName, ushort serverNameLength);
        private static extern ushort RNBOsproGetContactServer(ulong[] thePacket, char[] serverName, ushort serverNameLength);

        /// <summary>
        /// This function returns the access mode set to obtain a license.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="serverName">A pointer to the buffer in which the Sentinel Protection Server name is copied. Memory needs to be allocated for the buffer.</param>
        /// <param name="serverNameLength">The length of the buffer. The maximum length recommended is 64 bytes.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode GetContactServer(ulong[] thePacket, char[] serverName, ushort serverNameLength,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproGetContactServer(thePacket, serverName, serverNameLength);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproGetFullStatus(ulong[] thePacket);

        /// <summary>
        /// This function obtains the return code of the last-called API function.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode GetFullStatus(ulong[] thePacket,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproGetFullStatus(thePacket);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproGetHardLimit(ulong[] thePacket, out ushort hardLimit);

        /// <summary>
        /// This function retrieves the hard limit of the key from which the license was obtained.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="hardLimit">A pointer to the location that holds the hard limit of the key. It defines the maximum number of licenses that can be issued by this key.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode GetHardLimit(ulong[] thePacket, out ushort hardLimit,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproGetHardLimit(thePacket, out hardLimit);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [Obsolete]
        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        //private static extern ushort RNBOsproGetKeyInfo(ulong[] thePacket, ushort devId, ushort keyIndex, ref NSPRO_monitorInfo nsproMonitorInfo);
        private static extern ushort RNBOsproGetKeyInfo(ulong[] thePacket, HardwareKeyDeveloper developerId, ushort keyIndex, ref byte[] monitorInfo);

        /// <summary>
        /// This function retrieves the following information about the key attached on a stand-alone system or a network computer
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="developerId">If 0xFFFF is specified, the function will return the developer ID of the key along with other information.</param>
        /// <param name="keyIndex">The index of the key whose information is sought.</param>
        /// <param name="monitorInfo">A pointer to the nsproMonitorInfo structure. This structure has various fields that contain information about the key. Refer to spromeps.h for details.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        [Obsolete]
        public static SentinelStatusCode GetKeyInfo(ulong[] thePacket, HardwareKeyDeveloper developerId, ushort keyIndex, ref byte[] monitorInfo,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproGetKeyInfo(thePacket, (ushort)developerId, keyIndex, ref monitorInfo);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }
        //private static extern SentinelStatusCode RNBOsproGetKeyInfo(ulong[] thePacket, HardwareKeyType developerId, ushort keyIndex, ref NSPRO_monitorInfo monitorInfo);

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproGetKeyType(ulong[] thePacket, out KeyFamily keyFamily, out KeyFormFactor keyFormFactor, out ushort keyMemorySize);

        /// <summary>
        /// This function returns the following information about the key attached to a system:
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="keyFamily">The key family parameter will return 0 or 1, where 0 denotes the SuperPro keys (the SSP keys) and 1 denotes the UltraPro keys (the SUP keys).</param>
        /// <param name="keyFormFactor">The form factor parameter will return 0 or 1, where 0 denotes the parallel keys and 1 denotes the USB keys.</param>
        /// <param name="keyMemorySize">The number of cells (inclusive of the reserved cells).</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode GetKeyType(ulong[] thePacket, out KeyFamily keyFamily, out KeyFormFactor keyFormFactor, out ushort keyMemorySize,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproGetKeyType(thePacket, out keyFamily, out keyFormFactor, out keyMemorySize);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproGetSubLicense(ulong[] thePacket, MemoryAddress address);

        /// <summary>
        /// This function obtains a sublicense from a locked data word (has an access code 1). You can call the RNBOsproGetSubLicense function only after calling the RNBOsproFindFirstUnit function.
        /// Note: The key’s hard limit is decremented first, then the sublicense limit is decremented for the requested application.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="address">The cell address of a locked data word from which the sublicense will be obtained.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode GetSubLicense(ulong[] thePacket, MemoryAddress address,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproGetSubLicense(thePacket, (ushort)address);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproGetVersion(ulong[] thePacket, out byte majorVersion, out byte minorVersion, out byte revision, out OperatingSystemDriverType osDriverType);

        /// <summary>
        /// This function returns the Sentinel system driver's version and type.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="majorVersion">A pointer to the location for the major version number returned.</param>
        /// <param name="minorVersion">A pointer to the location for the minor version number returned.</param>
        /// <param name="revision">A pointer to the location for the revision number returned.</param>
        /// <param name="osDriverType">A pointer to the location where the operating system driver type information is stored.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode GetVersion(ulong[] thePacket, out byte majorVersion, out byte minorVersion, out byte revision, out OperatingSystemDriverType osDriverType,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproGetVersion(thePacket, out majorVersion, out minorVersion, out revision, out osDriverType);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproInitialize(ulong[] thePacket);

        /// <summary>
        /// This function initializes the API packet and sets the values specified (if any) in the configuration file or the NSP_HOST environment variable.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode Initialize(ulong[] thePacket,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproInitialize(thePacket);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproOverwrite(ulong[] thePacket, ushort writePassword, ushort overwritePassword1, ushort overwritePassword2, MemoryAddress address, ushort data, SentinelSuperProAccessCode accessCode);

        /// <summary>
        /// This function is used to change the value and access code of a word at the specified address.
        /// The word data is placed in the data variable and its associated access code in the access code variable.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="writePassword">The write password for the SuperPro key.</param>
        /// <param name="overwritePassword1">The overwrite password 1 for the SuperPro key.</param>
        /// <param name="overwritePassword2">The overwrite password 2 for the SuperPro key.</param>
        /// <param name="address">Contains the cell address where write is to be performed.</param>
        /// <param name="data">Contains the word to write in the key.</param>
        /// <param name="accessCode">Contains the access code associated with the word to write.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode Overwrite(ulong[] thePacket, ushort writePassword, ushort overwritePassword1, ushort overwritePassword2, MemoryAddress address, ushort data, SentinelSuperProAccessCode accessCode,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproOverwrite(thePacket, writePassword, overwritePassword1, overwritePassword2, (ushort)address, data, accessCode);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        //private static extern SentinelStatusCode RNBOsproQuery(ulong[] thePacket, ushort address, byte[] queryData, out byte[] response, out ulong[] response32, ushort length);
        private static extern ushort RNBOsproQuery(ulong[] thePacket, ushort address, byte[] queryData, byte[] response, ulong[] response32, ushort length);

        /// <summary>
        /// This function is used to query an algorithm at the specified address. The query data pointer will point to the first byte of the data to be passed to
        /// the algorithm. The length of the query data (in bytes) is specified in the length variable. The minimum length is 4 bytes and the maximum length is
        /// 56 bytes. On success, the query response will be placed in the buffer pointed to by the response pointer. It will have the same length as the query data. The last
        /// four bytes of the query response will also be placed in the Response32 variable. It is the programmer’s responsibility to allocate the memory for the buffers.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="address">The address of the word to query. It must point to the first word of an active algorithm.</param>
        /// <param name="queryData">The pointer to the first byte of the query bytes.</param>
        /// <param name="response">The pointer to the first byte of the response bytes.</param>
        /// <param name="response32">The pointer to the location that will contain a copy of the last four bytes of the query response.</param>
        /// <param name="length">This is the number of  query bytes to send to the active algorithm and also the length of the response buffer.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode Query(ulong[] thePacket, MemoryAddress address, byte[] queryData, byte[] response, ulong[] response32, ushort length,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproQuery(thePacket, address, queryData, response, response32, length);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproRead(ulong[] thePacket, ushort address, out ushort data);

        /// <summary>
        /// This function reads a word at the specified address. If successful, the data variable will contain the word value.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="address">The cell address to be read.</param>
        /// <param name="data">A pointer to the variable that will contain the data read from the key.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode Read(ulong[] thePacket, MemoryAddress address, out ushort data,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproRead(thePacket, (ushort)address, out data);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        public static bool CanRead(ulong[] thePacket, MemoryAddress address)
        {
            var status = RNBOsproRead(thePacket, (ushort)address, out _);
            return status == SentinelStatusCode.Success;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproReleaseLicense(ulong[] thePacket, ushort address, ushort[] numberOfSublicensesToBeRelease);

        /// <summary>
        /// This function can be used to either release a license or sublicense(s).
        /// You can call this function anytime after obtaining a license; followed by RNBOsproCleanUp.
        /// You can call this function before your application terminates. For example, the handler of the exit command button in your user interface can make use of this function.
        /// We recommend you to use this function in order to release the idle licenses for other clients in queue. This function is especially useful in cases where you have set the heartbeat interval as infinite. The Sentinel Protection Server will not release the license unless you call this function.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="address">Specify zero to release the main license. Else, specify the cell address to release the sublicense from a particular cell.</param>
        /// <param name="numberOfSublicensesToBeRelease">The pointer to the variable containing the number of sublicenses to be released. If the main license is to be released, this can be specified as null.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode ReleaseLicense(ulong[] thePacket, MemoryAddress address, ushort[] numberOfSublicensesToBeRelease,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproReleaseLicense(thePacket, (ushort)address, numberOfSublicensesToBeRelease);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll", EntryPoint = "RNBOsproReleaseLicense")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproReleaseMainLicense(ulong[] thePacket, ushort address, ushort[] numberOfSublicensesToBeRelease);

        /// <summary>
        /// This function can be used to either release a license or sublicense(s).
        /// You can call this function anytime after obtaining a license; followed by RNBOsproCleanUp.
        /// You can call this function before your application terminates. For example, the handler of the exit command button in your user interface can make use of this function.
        /// We recommend you to use this function in order to release the idle licenses for other clients in queue. This function is especially useful in cases where you have set the heartbeat interval as infinite. The Sentinel Protection Server will not release the license unless you call this function.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="address">Specify zero to release the main license. Else, specify the cell address to release the sublicense from a particular cell.</param>
        /// <param name="numberOfSublicensesToBeRelease">The pointer to the variable containing the number of sublicenses to be released. If the main license is to be released, this can be specified as null.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode ReleaseMainLicense(ulong[] thePacket, MemoryAddress address, ushort[] numberOfSublicensesToBeRelease,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproReleaseMainLicense(thePacket, address, numberOfSublicensesToBeRelease);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        /// <summary>
        /// This function can be used to either release a license or sublicense(s).
        /// You can call this function anytime after obtaining a license; followed by RNBOsproCleanUp.
        /// You can call this function before your application terminates. For example, the handler of the exit command button in your user interface can make use of this function.
        /// We recommend you to use this function in order to release the idle licenses for other clients in queue. This function is especially useful in cases where you have set the heartbeat interval as infinite. The Sentinel Protection Server will not release the license unless you call this function.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode ReleaseMainLicense(ulong[] thePacket,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproReleaseMainLicense(thePacket, (ushort)MemoryAddress.SafeNet_KeySerialNumber, null);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll", CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproSetContactServer(ulong[] thePacket, string serverName);

        /// <summary>
        /// This function sets the access mode for finding the key. You may also set this function to the IP or IPX address, NetBEUI name or name of the system where the Sentinel Protection Server is running.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="serverName">A pointer to the location that contains one of the following values:
        /// RNBO_STANDALONE, RNBO_SPN_DRIVER, RNBO_SPN_LOCAL, RNBO_SPN_BROADCAST, RNBO_SPN_ALL_MODES, RNBO_SPN_SERVER_MODES, IP address, IPX address, NetBEUI name or the workstation name. However, the name length cannot exceed 63 single-byte characters</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode SetContactServer(ulong[] thePacket, string serverName,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproSetContactServer(thePacket, serverName);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproSetHeartBeat(ulong[] thePacket, uint heartBeatValue);

        /// <summary>
        /// This function sets the heartbeat interval for maintaining the communication between a client and the Sentinel Protection Server. The heartbeat time
        /// can be set to INFINITE_HEARTBEAT or from 1 minute to 30 days, in multiples of 1 second. The heartbeat represents the interval within which your
        /// application notifies the Sentinel Protection Server that it is still running. If this function is not called, the protection server assumes the
        /// default value as two minutes (120 seconds). As a result, if no call is made to the key at least every two minutes, the license will be released and
        /// the SP_INVALID_LICENSE error will be returned if any call is made using the same packet.
        /// You should call this function after calling RNBOsproFindFirstUnit.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="heartBeatValue">A value that represents time in seconds. The valid values are: LIC_UPDATE_INT = 120, MAX_HEARTBEAT = 2592000, MIN_HEARTBEAT = 60, INFINITE_HEARTBEAT = 0xFFFFFFFF</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode SetHeartBeat(ulong[] thePacket, uint heartBeatValue,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproSetHeartBeat(thePacket, heartBeatValue);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproSetProtocol(ulong[] thePacket, Protocol protocol);

        /// <summary>
        /// This function sets the network protocol for allowing communication between the client and Sentinel Protection Server. You can choose from the
        /// following protocols: NetBEUI, TCP/IP, and IPX. By default, TCP/IP is used.
        /// This function can be called after successfully calling RNBOsproInitialize and before calling RNBOsproFindFirstUnit.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="protocol">The protocol chosen by a client for communication with the Sentinel Protection Server.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode SetProtocol(ulong[] thePacket, Protocol protocol,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproSetProtocol(thePacket, protocol);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproCheckTerminalService(ulong[] thePacket, TerminalService terminalService);

        /// <summary>
        /// This function allows you to enable/disable the application execution on terminal clients while RNBOsproFindFirstUnit, or RNBOsproFindNextUnit API
        /// is executed. This function shall be called before RNBOsproFindFirstUnit if the user wants to enable the support for Terminal Client.
        /// This API function should be called after calling the RNBOsproFormatPacket and RNBOsproInitialize API functions and before calling the RNBOsproFindFirstUnit API function.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="terminalService">The valid values are: SP_TERM_SERV_CHECK_ON, SP_TERM_SERV_CHECK_OFF.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode CheckTerminalService(ulong[] thePacket, TerminalService terminalService,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproCheckTerminalService(thePacket, terminalService);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproSetSharedLicense(ulong[] thePacket, ShareMainLicense shareMainLicense, ShareSublicense shareSublicense);

        /// <summary>
        /// This function allows you to enable/disable the main and sublicense sharing. The licenses issued to users from the same seat (a user name and MAC
        /// address combination) are shared. This function also allows you to enable/disable device sharing.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="shareMainLicense">Enables/disables the main license sharing. By default, main license sharing and device sharing are enabled.</param>
        /// <param name="shareSublicense">Enables/disables the sublicense sharing. By default, sublicense sharing is disabled.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode SetSharedLicense(ulong[] thePacket, ShareMainLicense shareMainLicense, ShareSublicense shareSublicense,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproSetSharedLicense(thePacket, shareMainLicense, shareSublicense);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern ushort RNBOsproWrite(ulong[] thePacket, ushort writePassword, ushort address, ushort data, SentinelSuperProAccessCode accessCode);

        /// <summary>
        /// This function is used to write a word and its associated access code at the specified address.
        /// The word data is placed in the data variable and its associated access code in the access code variable.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="writePassword">The write password for the SuperPro key.</param>
        /// <param name="address">Contains the cell address where write is to be performed.</param>
        /// <param name="data">Contains the word to write in the key.</param>
        /// <param name="accessCode">Contains the access code associated with the word to write.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode Write(ulong[] thePacket, ushort writePassword, MemoryAddress address, ushort data, SentinelSuperProAccessCode accessCode,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproWrite(thePacket, writePassword, address, data, accessCode);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        private static extern unsafe ushort RNBOsproSetDeveloperCode(ulong[] thePacket, void* devCode, ulong size);
        //private static extern unsafe ushort RNBOsproSetDeveloperCode(ulong[] thePacket, UIntPtr devCode, ulong size);

        /// <summary>
        /// The function sets and validates Developer Code to create a Secure Communication Tunnel between the client and SuperPro key. Developer Code
        /// contains the information required for creating the Secure Communication Tunnel.
        /// You can call this function before calling RNBOsproFindFirst.
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="devCode">A pointer to the buffer that contains Developer Code.</param>
        /// <param name="size">Size of Developer Code.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static unsafe SentinelStatusCode SetDeveloperCode(ulong[] thePacket, void* devCode, ulong size,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproSetDeveloperCode(thePacket, devCode, size);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }

        [DllImport("sx32w.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.ApplicationDirectory)]
        //private static extern SentinelStatusCode RNBOsproGetKeyInfoEx(ulong[] thePacket, HardwareKeyType developerId, ushort keyIndex, MemoryAddress sublicenseAddress, out NSPRO_monitorInfoEx monitorInfoEx, ulong size);
        //private static extern SentinelStatusCode RNBOsproGetKeyInfoEx(ulong[] thePacket, HardwareKeyType developerId, ushort keyIndex, MemoryAddress sublicenseAddress, ref NSPRO_monitorInfoEx monitorInfoEx, ulong size);
        //private static extern SentinelStatusCode RNBOsproGetKeyInfoEx(ulong[] thePacket, ulong developerId, ulong keyIndex, ulong sublicenseAddress, out NSPRO_monitorInfoEx monitorInfoEx, ulong size);
        //private static extern ushort RNBOsproGetKeyInfoEx(ulong[] thePacket, ulong devId, ulong keyIndex, ulong subLicAddress, ref NSPRO_monitorInfoEx nsproMonitorInfoEx, ulong size);

        private static extern ushort RNBOsproGetKeyInfoEx(ulong[] thePacket, ushort developerId, ushort keyIndex, ushort sublicenseAddress, byte[] monitorInfoEx, ushort size);
        //private static extern SentinelStatusCode RNBOsproGetKeyInfoEx(ulong[] thePacket, ulong developerId, ulong keyIndex, ulong sublicenseAddress, ref NSPRO_monitorInfoEx monitorInfoEx, ulong size);

        /// <summary>
        /// The function is an enhanced version of RNBOsproGetKeyInfo, which has been deprecated from SuperPro 6.6. This function retrieves the following
        /// information about the key attached to a stand-alone system or a network computer, on which the Sentinel Protection Server is running:
        /// </summary>
        /// <param name="thePacket">A pointer to the API packet.</param>
        /// <param name="developerId">The developer ID of the SuperPro key to find. If 0xFFFFFFFF or 0xFFFF is specified, the function will return the
        /// developer ID of the key along with other information. If 0 is specified, the function will return the information of the key from which you
        /// have obtained the license. If 0 is specified, you must obtain the license before calling this function; otherwise, the function returns
        /// SP_INVALID_PARAMETER.</param>
        /// <param name="keyIndex">The index of the key that provides following information of the key being sought: For cascaded parallel port keys: The
        /// sequential position of the key in the queue. For multiple USB keys: The order in which the key is plugged into the USB port/hub. If devId is 0,
        /// this parameter is ignored.</param>
        /// <param name="sublicenseAddress">The cell address of a locked data word from which the sublicense will be queried. If the cell is reserved (cell
        /// address less than 8) or not locked (cell access code is not 1), the field subLicLimit in the structure NSPRO_KEY_monitorInfoEx will
        /// be set to 0. Set it to 0 if you do not want to retrieve the information of the sublicense.</param>
        /// <param name="monitorInfoEx">A pointer to the NSPRO_monitorInfoEx structure, which contains information about the key. Refer to spromeps.h for details.</param>
        /// <param name="size">The size of the NSPRO_monitorInfoEx structure, in bytes. Set this member to sizeof(NSPRO_monitorInfoEx) before calling this function.</param>
        /// <returns>Returns a SentinelStatusCode.</returns>
        public static SentinelStatusCode GetKeyInfoEx(ulong[] thePacket, ushort developerId, ushort keyIndex, ushort sublicenseAddress, byte[] monitorInfoEx, ushort size,
            [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            var status = RNBOsproGetKeyInfoEx(thePacket, developerId, keyIndex, sublicenseAddress, monitorInfoEx, size);
            StatusCodeChecker.CheckForError(status, callerFilePath, callerFunctionName, callerFunctionLine);
            return status;
        }
    }
}
