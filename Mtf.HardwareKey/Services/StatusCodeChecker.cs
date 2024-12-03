using Mtf.HardwareKey.Models;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Mtf.HardwareKey.Services
{
    public static class StatusCodeChecker
    {
        public static void CheckForError(ushort status, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            if (status != SentinelStatusCode.Success)
            {
                throw new InvalidOperationException($"{Path.GetFileName(callerFilePath)} - {callerFunctionName}:{callerFunctionLine}{Environment.NewLine}Returned status code: {(SentinelStatusCode)status}");
            }
        }
    }
}
