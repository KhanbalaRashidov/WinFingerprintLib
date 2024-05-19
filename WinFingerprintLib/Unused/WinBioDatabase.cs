using System;
using System.Collections.Generic;
using System.Text;
using WinFingerprintLib.Enums;

namespace WinFingerprintLib.Unused
{
    public class WinBioDatabase
    {
        public static void EnumDatabases()
        {
            var schemaArray = WinBio.EnumDatabases(WinBioBiometricType.Fingerprint);
            Console.WriteLine("Databases found: {0}", schemaArray.Length);
            for (var i = 0; i < schemaArray.Length; i++)
            {
                Console.WriteLine("Database {0}", i);
                var id = schemaArray[i].DatabaseId;
                Console.WriteLine("Id: {0}", id);
            }
        }
    }
}
