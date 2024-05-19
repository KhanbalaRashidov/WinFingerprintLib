﻿using System;
using System.Diagnostics;

namespace WinFingerprintLib.Unused
{
    public abstract class WinBioResource
        : WinBioObject
        , IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.KeepAlive(this);
        }

        ~WinBioResource()
        {
            Trace.TraceWarning(ToString() + " leaked!");
            Dispose(false);
        }

        protected abstract void Dispose(bool manual);
    }
}
