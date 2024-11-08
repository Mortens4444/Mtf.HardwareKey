using Mtf.HardwareKey.Models;
using System;
using System.Runtime.CompilerServices;

namespace Mtf.HardwareKey.Services
{
    public static class StatusCodeChecker
    {
        public static void CheckForError(ushort status, [CallerMemberName] string callerFunctionName = "", [CallerLineNumber] int callerFunctionLine = 0)
        {
            if (status != SentinelStatusCode.Success)
            {
                throw new InvalidOperationException($"{callerFunctionName}:{callerFunctionLine} status code: {(SentinelStatusCode)status}");
            }
        }
    }
}
