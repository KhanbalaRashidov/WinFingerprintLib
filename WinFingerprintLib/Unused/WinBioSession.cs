﻿using System;
using System.Drawing;
using WinFingerprintLib.Enums;

namespace WinFingerprintLib.Unused
{
    public class WinBioSession
        : WinBioResource
    {
        private readonly WinBioSessionHandle _handle;

        public WinBioSession()
        {
            _handle = WinBio.OpenSession(WinBioBiometricType.Fingerprint);
            SetID(_handle.Value);
            Console.WriteLine("WinBioSession opened: " + _handle.Value);
        }

        protected override void Dispose(bool manual)
        {
            WinBio.CloseSession(_handle);
            Console.WriteLine("WinBioSession closed");
        }

        public int LocateSensor()
        {
            return WinBio.LocateSensor(_handle);
        }

        public void Identify()
        {
            WinBioIdentity identity;
            WinBioBiometricSubType subFactor;
            WinBioRejectDetail rejectDetail;
            var unitId = WinBio.Identify(_handle, out identity, out subFactor, out rejectDetail);
            Console.WriteLine("Unit Id: {0}", unitId);
            Console.WriteLine("Identity: {0}", identity);
            Console.WriteLine("Sub factor: {0}", subFactor);
            Console.WriteLine("Reject details: {0}", rejectDetail);
        }

        public void CaptureSample(WinBioBirPurpose purpose, WinBioBirDataFlags dataFlags)
        {
            Bitmap image;
            WinBioRejectDetail rejectDetail;
            var unitId = WinBio.CaptureSample(_handle, purpose, dataFlags, out rejectDetail, out image);
            Console.WriteLine("Unit id: {0}", unitId);
            Console.WriteLine("Captured sample size: {0}x{1}", image.Width, image.Height);
            Console.WriteLine("Reject details: {0}", rejectDetail);
        }
    }
}
