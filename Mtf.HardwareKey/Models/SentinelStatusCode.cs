using System;
using System.Collections.Generic;

namespace Mtf.HardwareKey.Models
{
    public sealed class SentinelStatusCode
    {
        public static readonly SortedList<ushort, SentinelStatusCode> Values = new SortedList<ushort, SentinelStatusCode>();

        public static readonly SentinelStatusCode Success = new SentinelStatusCode(0, "The function completed successfully.");
        public static readonly SentinelStatusCode InvalidFunctionCode = new SentinelStatusCode(1, "You specified an invalid function code.See the include file for your language /interface (for example, spromeps.h) for valid API function codes.Generally, this error should not occur if you are using an interface provided by us to communicate with the Sentinel system driver.However, it may occur when a stand-alone “only” function is used in a network situation.");
        public static readonly SentinelStatusCode InvalidPacket = new SentinelStatusCode(2, "A checksum error was detected in the command packet, indicating an internal inconsistency.The packet record has not been initialized, or may have been tampered with.Generally, this error should not occur if you are using an interface provided by us to communicate with the Sentinel system driver.");
        public static readonly SentinelStatusCode UnitNotFound = new SentinelStatusCode(3, "Unable to find the desired hardware key.Please verify if the key has been attached properly.Make sure you are sending the correct parameters.");
        public static readonly SentinelStatusCode AccessDenied = new SentinelStatusCode(4, "You attempted to perform an illegal action on a cell.For example, you may have tried to read an algorithm word, write to a locked cell, or decrement a cell that is not a data or counter word.");
        public static readonly SentinelStatusCode InvalidMemoryAddress = new SentinelStatusCode(5, "You specified an invalid memory address.You cannot operate on the reserved cells.");
        public static readonly SentinelStatusCode InvalidAccessCode = new SentinelStatusCode(6, "You specified an invalid access code.The access code must be 0(read / write data), 1(read - only data), 2(counter), 3(algorithm / hidden), or 7(AES algorithm).");
        public static readonly SentinelStatusCode PortIsBusy = new SentinelStatusCode(7, "The requested operation could not be completed because the port is busy.This can occur if there is considerable printer activity, or if a unit on the port is performing a write operation and is blocking the port.Try the function again.");
        public static readonly SentinelStatusCode WriteNotReady = new SentinelStatusCode(8, "The write or decrement operation could not be performed due to lack of sufficient power.Try the function again.");
        public static readonly SentinelStatusCode NoPortFound = new SentinelStatusCode(9, "No parallel ports could be found, or there was a problem with the protocol being used on the network.");
        public static readonly SentinelStatusCode AlreadyZero = new SentinelStatusCode(10, "You tried to decrement a counter that contains the value zero.");
        public static readonly SentinelStatusCode DriverOpenError = new SentinelStatusCode(11, "SP_DRIVER_OPEN_ERROR");
        public static readonly SentinelStatusCode DriverNotInstalled = new SentinelStatusCode(12, "The Sentinel system driver was not installed or detected.Communication to the hardware key was not possible.Verify the device driver is correctly installed.");
        public static readonly SentinelStatusCode IOCommunicationError = new SentinelStatusCode(13, "The system device driver is having problems communicating.Verify the device driver is correctly installed.");
        public static readonly SentinelStatusCode PacketTooSmall = new SentinelStatusCode(15, "The memory allocated for the API packet is less than the required size.");
        public static readonly SentinelStatusCode InvalidParameter = new SentinelStatusCode(16, "Arguments and values passed to the API function are invalid.");
        public static readonly SentinelStatusCode MemAccessError = new SentinelStatusCode(17, "SP_MEM_ACCESS_ERROR");
        public static readonly SentinelStatusCode VersionNotSupported = new SentinelStatusCode(18, "The current system device driver is outdated.Update the driver.");
        public static readonly SentinelStatusCode OSNotSupported = new SentinelStatusCode(19, "The operating system or environment is not supported by the client library.Contact Technical Support for assistance.");
        public static readonly SentinelStatusCode QueryTooLong = new SentinelStatusCode(20, "You sent a query string longer than 56 characters.Send a shorter string.");
        public static readonly SentinelStatusCode InvalidCommand = new SentinelStatusCode(21, "An invalid command was specified in the API call.");
        public static readonly SentinelStatusCode MemAlignmentError = new SentinelStatusCode(29, "SP_MEM_ALIGNMENT_ERROR");
        public static readonly SentinelStatusCode DriverIsBusy = new SentinelStatusCode(30, "The Sentinel system driver is busy. Try the function again.");
        public static readonly SentinelStatusCode PortAllocationFailure = new SentinelStatusCode(31, "Failure to allocate a parallel port through the operating system’s parallel port contention handler.");
        public static readonly SentinelStatusCode PortReleaseFailure = new SentinelStatusCode(32, "Failure to release a previously allocated parallel port through the operating system’s parallel port contention handler.");
        public static readonly SentinelStatusCode AcquirePortTimeout = new SentinelStatusCode(39, "Failure to access the parallel port within the defined time.");
        public static readonly SentinelStatusCode SignalNotSupported = new SentinelStatusCode(42, "The particular system does not support a signal line.For example, an attempt may have been made to use the ACK line on an NEC 9800 computer.");
        public static readonly SentinelStatusCode UnknownMachine = new SentinelStatusCode(44, "SP_UNKNOWN_MACHINE");
        public static readonly SentinelStatusCode SysApiError = new SentinelStatusCode(45, "SP_SYS_API_ERROR");
        public static readonly SentinelStatusCode UnitIsBusy = new SentinelStatusCode(46, "SP_UNIT_IS_BUSY");
        public static readonly SentinelStatusCode InvalidPortType = new SentinelStatusCode(47, "SP_INVALID_PORT_TYPE");
        public static readonly SentinelStatusCode InvalidMachType = new SentinelStatusCode(48, "SP_INVALID_MACH_TYPE");
        public static readonly SentinelStatusCode InvalidIrqMask = new SentinelStatusCode(49, "SP_INVALID_IRQ_MASK");
        public static readonly SentinelStatusCode InvalidContMethod = new SentinelStatusCode(50, "SP_INVALID_CONT_METHOD");
        public static readonly SentinelStatusCode InvalidPortFlags = new SentinelStatusCode(51, "SP_INVALID_PORT_FLAGS");
        public static readonly SentinelStatusCode InvalidLogPortCfg = new SentinelStatusCode(52, "SP_INVALID_LOG_PORT_CFG");
        public static readonly SentinelStatusCode InvalidOsType = new SentinelStatusCode(53, "SP_INVALID_OS_TYPE");
        public static readonly SentinelStatusCode InvalidLogPortNum = new SentinelStatusCode(54, "SP_INVALID_LOG_PORT_NUM");
        public static readonly SentinelStatusCode InvalidRouterFlags = new SentinelStatusCode(56, "SP_INVALID_ROUTER_FLGS");
        public static readonly SentinelStatusCode InitNotCalled = new SentinelStatusCode(57, "The key is not initialized.");
        public static readonly SentinelStatusCode DriverTypeNotSupported = new SentinelStatusCode(58, "The type of driver access, either direct I / O or system driver, is not supported for the defined operating system and client library.");
        public static readonly SentinelStatusCode FailOnDriverComm = new SentinelStatusCode(59, "The client library failed to communicate with the Sentinel system driver.");
        public static readonly SentinelStatusCode ServerProbablyNotUp = new SentinelStatusCode(60, "The Sentinel Protection Server is not responding or the client has timed -out.");
        public static readonly SentinelStatusCode UnknownHost = new SentinelStatusCode(61, "The Sentinel Protection Server host is unknown or not on the network, or an invalid host name was specified.");
        public static readonly SentinelStatusCode SendToFailed = new SentinelStatusCode(62, "The client was unable to send a message to the Sentinel Protection Server.");
        public static readonly SentinelStatusCode SocketCreationFailed = new SentinelStatusCode(63, "Client was unable to open a network socket.Make sure the TCP / IP or IPX protocol stack is properly installed on the system.");
        public static readonly SentinelStatusCode NoResources = new SentinelStatusCode(64, "Could not locate enough licensing requirements.Insufficient resources(such as memory) are available to complete the request.");
        public static readonly SentinelStatusCode BroadcastNotSupported = new SentinelStatusCode(65, "Broadcast is not supported by the network interface on the system.");
        public static readonly SentinelStatusCode BadServerMessage = new SentinelStatusCode(66, "Could not understand the message received from the Sentinel Protection Server.An error occurred in decrypting(or decoding) the message at the client - end.");
        public static readonly SentinelStatusCode NoServerRunning = new SentinelStatusCode(67, "Cannot communicate to the SentinelProtection Server.It may not be available for processing the license request on the specified host.Verify if the SentinelProtection Server is running on the system.");
        public static readonly SentinelStatusCode NoNetwork = new SentinelStatusCode(68, "Unable to talk to the specified host. Network communication problems encountered.");
        public static readonly SentinelStatusCode NoServerResponse = new SentinelStatusCode(69, "There is no Sentinel Protection Server running in the subnet, or the desired key is not available.");
        public static readonly SentinelStatusCode NoLicenseAvailable = new SentinelStatusCode(70, "All licenses are currently in use.The key has no more licenses to issue or Standalone mode application has been executed through terminal client and check terminal service is enable.");
        public static readonly SentinelStatusCode InvalidLicense = new SentinelStatusCode(71, "License is no longer valid. It probably expired due to time -out or the key not initialized yet.");
        public static readonly SentinelStatusCode InvalidOperation = new SentinelStatusCode(72, "Specified operation cannot be performed.Probably, you tried setting the Sentinel Protection Server after obtaining a license.");
        public static readonly SentinelStatusCode BufferTooSmall = new SentinelStatusCode(73, "The size of the buffer is not sufficient to hold the expected data.");
        public static readonly SentinelStatusCode InternalError = new SentinelStatusCode(74, "An internal error, such as failure toencrypt or decrypt a message being sent or received, has occurred.");
        public static readonly SentinelStatusCode PacketAlreadyInitialized = new SentinelStatusCode(75, "The API packet was already initialized.");
        public static readonly SentinelStatusCode ProtocolNotInstalled = new SentinelStatusCode(76, "The specified protocol is not installed.");
        public static readonly SentinelStatusCode NoLeaseFeature = new SentinelStatusCode(101, "SP_NO_LEASE_FEATURE");
        public static readonly SentinelStatusCode LeaseExpired = new SentinelStatusCode(102, "SP_LEASE_EXPIRED");
        public static readonly SentinelStatusCode CounterLimitReached = new SentinelStatusCode(103, "SP_COUNTER_LIMIT_REACHED");
        public static readonly SentinelStatusCode NoDigitalSignature = new SentinelStatusCode(104, "The Sentinel system driver binary is not signed by a valid authority.");
        public static readonly SentinelStatusCode SysFileCorrupted = new SentinelStatusCode(105, "The digital certificate of the Sentinel system driver is not valid.");
        public static readonly SentinelStatusCode StringBufferTooLong = new SentinelStatusCode(106, "SP_STRING_BUFFER_TOO_LONG");
        public static readonly SentinelStatusCode InvalidDevCode = new SentinelStatusCode(107, "You have specified an invalid Developer Code.");
        public static readonly SentinelStatusCode DevIdDoesNotMatch = new SentinelStatusCode(108, "The Developer ID doesn't match the one in Developer Code you have specified.");
        public static readonly SentinelStatusCode DeviceSharingDetected = new SentinelStatusCode(109, "Device is shared by more than one system or shared in virtual machine environment.");
        public static readonly SentinelStatusCode ServerVersionNotSupported = new SentinelStatusCode(110, "The Sentinel Protection Server from which you are trying to obtain a license is outdated.");
        public static readonly SentinelStatusCode BadAlgo = new SentinelStatusCode(401, "SH_SP_BAD_ALGO");
        public static readonly SentinelStatusCode LongMsg = new SentinelStatusCode(402, "SH_SP_LONG_MSG");
        public static readonly SentinelStatusCode ReadError = new SentinelStatusCode(403, "SH_SP_READ_ERROR");
        public static readonly SentinelStatusCode NotEnoughMemory = new SentinelStatusCode(404, "SH_SP_NOT_ENOUGH_MEMORY");
        public static readonly SentinelStatusCode CannotOpen = new SentinelStatusCode(405, "SH_SP_CANNOT_OPEN");
        public static readonly SentinelStatusCode WriteError = new SentinelStatusCode(406, "SH_SP_WRITE_ERROR");
        public static readonly SentinelStatusCode CannotOverwrite = new SentinelStatusCode(407, "SH_SP_CANNOT_OVERWRITE");
        public static readonly SentinelStatusCode InvalidHeader = new SentinelStatusCode(408, "SH_SP_INVALID_HEADER");
        public static readonly SentinelStatusCode TmpCreateError = new SentinelStatusCode(409, "SH_SP_TMP_CREATE_ERROR");
        public static readonly SentinelStatusCode PathNotThere = new SentinelStatusCode(410, "SH_SP_PATH_NOT_THERE");
        public static readonly SentinelStatusCode BadFileInfo = new SentinelStatusCode(411, "SH_SP_BAD_FILE_INFO");
        public static readonly SentinelStatusCode NotWin32File = new SentinelStatusCode(412, "SH_SP_NOT_WIN32_FILE");
        public static readonly SentinelStatusCode InvalidMachine = new SentinelStatusCode(413, "SH_SP_INVALID_MACHINE");
        public static readonly SentinelStatusCode InvalidSection = new SentinelStatusCode(414, "SH_SP_INVALID_SECTION");
        public static readonly SentinelStatusCode InvalidReloc = new SentinelStatusCode(415, "SH_SP_INVALID_RELOC");
        public static readonly SentinelStatusCode CryptError = new SentinelStatusCode(416, "SH_SP_CRYPT_ERROR");
        public static readonly SentinelStatusCode SmartheapError = new SentinelStatusCode(417, "SH_SP_SMARTHEAP_ERROR");
        public static readonly SentinelStatusCode ImportOverwriteError = new SentinelStatusCode(418, "SH_SP_IMPORT_OVERWRITE_ERROR");
        public static readonly SentinelStatusCode NoPeshell = new SentinelStatusCode(420, "SH_SP_NO_PESHELL");
        public static readonly SentinelStatusCode FrameworkRequired = new SentinelStatusCode(421, "SH_SP_FRAMEWORK_REQUIRED");
        public static readonly SentinelStatusCode CannotHandleFile = new SentinelStatusCode(422, "SH_SP_CANNOT_HANDLE_FILE");
        public static readonly SentinelStatusCode ImportDllError = new SentinelStatusCode(423, "SH_SP_IMPORT_DLL_ERROR");
        public static readonly SentinelStatusCode ImportFunctionError = new SentinelStatusCode(424, "SH_SP_IMPORT_FUNCTION_ERROR");
        public static readonly SentinelStatusCode X64ShellEngine = new SentinelStatusCode(425, "SH_SP_X64_SHELL_ENGINE");
        public static readonly SentinelStatusCode StrongName = new SentinelStatusCode(426, "SH_SP_STRONG_NAME");
        public static readonly SentinelStatusCode Framework10 = new SentinelStatusCode(427, "SH_SP_FRAMEWORK_10");
        public static readonly SentinelStatusCode FrameworkSdk10 = new SentinelStatusCode(428, "SH_SP_FRAMEWORK_SDK_10");
        public static readonly SentinelStatusCode Framework11 = new SentinelStatusCode(429, "SH_SP_FRAMEWORK_11");
        public static readonly SentinelStatusCode FrameworkSdk11 = new SentinelStatusCode(430, "SH_SP_FRAMEWORK_SDK_11");
        public static readonly SentinelStatusCode Framework20Or30 = new SentinelStatusCode(431, "SH_SP_FRAMEWORK_20_OR_30");
        public static readonly SentinelStatusCode FrameworkSdk20 = new SentinelStatusCode(432, "SH_SP_FRAMEWORK_SDK_20");
        public static readonly SentinelStatusCode AppNotSupported = new SentinelStatusCode(433, "SH_SP_APP_NOT_SUPPORTED");
        public static readonly SentinelStatusCode FileCopy = new SentinelStatusCode(434, "SH_SP_FILE_COPY");
        public static readonly SentinelStatusCode HeaderSizeExceed = new SentinelStatusCode(435, "SH_SP_HEADER_SIZE_EXCEED");
        public static readonly SentinelStatusCode UnknownError = new SentinelStatusCode(ushort.MaxValue, "Unknown error occured, check if Sentinel's driver is installed.");

        private readonly ushort code;

        private SentinelStatusCode(ushort code, string description)
        {
            this.code = code;
            Description = description;
            Values.Add(code, this);
        }

        public string Description { get; }

        public static implicit operator SentinelStatusCode(ushort value)
        {
            return Values.TryGetValue(value, out var errorCode) ? errorCode : UnknownError;
        }

        public static implicit operator ushort(SentinelStatusCode errorCode)
        {
            return errorCode?.code ?? UnknownError;
        }

        public override string ToString() => $"{code}{Environment.NewLine}{Description}";
    }
}
