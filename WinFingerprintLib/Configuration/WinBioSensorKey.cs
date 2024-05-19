using System;
using WinFingerprintLib.Enums;

namespace WinFingerprintLib.Configuration
{
    public class WinBioSensorKey
       : WinBioRegistryKeyBase
    {
        public WinBioSensorMode SensorMode;
        public int SystemSensor;
        public Guid DatabaseId;
        public string SensorAdapterBinary;
        public string EngineAdapterBinary;
        public string StorageAdapterBinary;
    }
}
