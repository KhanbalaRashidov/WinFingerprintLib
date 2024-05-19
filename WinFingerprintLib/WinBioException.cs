﻿using System;
using WinFingerprintLib.Enums;

namespace WinFingerprintLib
{
    public class WinBioException
        : Exception
    {
        public WinBioErrorCode ErrorCode { get; private set; }

        public WinBioException(string message)
            : base(message)
        {
        }

        public WinBioException(WinBioErrorCode errorCode)
            : base(errorCode.ToString())
        {
            ErrorCode = errorCode;
        }

        public WinBioException(WinBioErrorCode errorCode, string message)
            : base(string.Format("{0}: {1}", message, errorCode))
        {
            HResult = (int)errorCode;
            ErrorCode = errorCode;
        }

        public static void ThrowOnError(WinBioErrorCode errorCode, string message)
        {
            if (errorCode == WinBioErrorCode.Ok) return;
            throw new WinBioException(errorCode, message);
        }

        public static void ThrowOnError(Enums.WinBioErrorCode code, WinBioErrorCode errorCode)
        {
            if (errorCode == WinBioErrorCode.Ok) return;
            throw new WinBioException(errorCode);
        }
    }
}
