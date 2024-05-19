using System;

namespace WinFingerprintLib.Enums
{
    [Flags]
    public enum WinBioSessionFlag
    {
        /// <summary>
        /// Group: configuration
        /// </summary>
        Default = 0,

        /// <summary>
        /// Group: configuration
        /// </summary>
        Basic = 1 << 16,

        /// <summary>
        /// Group: configuration
        /// </summary>
        Advanced = 2 << 16,

        /// <summary>
        /// Group: access
        /// </summary>
        Raw = 1,

        /// <summary>
        /// Group: access
        /// </summary>
        Maintenance = 2
    }
}
