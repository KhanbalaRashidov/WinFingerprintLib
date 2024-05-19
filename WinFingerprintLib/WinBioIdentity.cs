﻿using System.IO;
using System;
using WinFingerprintLib.Enums;
using System.Security.Principal;

namespace WinFingerprintLib
{
    public class WinBioIdentity
    {
        public const int Size = 76;

        public WinBioIdentityType Type;
        public int Null;
        public int Wildcard;
        public Guid TemplateGuid;
        public int AccountSidSize;
        public SecurityIdentifier AccountSid;

        public WinBioIdentity(byte[] bytes)
        {
            FromBytes(bytes);
        }

        public void FromBytes(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes, false))
            using (var reader = new BinaryReader(stream))
            {
                Type = (WinBioIdentityType)reader.ReadInt32();
                switch (Type)
                {
                    case WinBioIdentityType.Null:
                        Null = reader.ReadInt32();
                        break;
                    case WinBioIdentityType.Wildcard:
                        Wildcard = reader.ReadInt32();
                        break;
                    case WinBioIdentityType.GUID:
                        TemplateGuid = new Guid(reader.ReadBytes(16));
                        break;
                    case WinBioIdentityType.SID:
                        AccountSidSize = reader.ReadInt32();
                        AccountSid = new SecurityIdentifier(reader.ReadBytes(AccountSidSize), 0);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public byte[] GetBytes()
        {
            var bytes = new byte[Size];
            using (var stream = new MemoryStream(bytes, true))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write((int)Type);
                switch (Type)
                {
                    case WinBioIdentityType.Null:
                        writer.Write(Null);
                        break;
                    case WinBioIdentityType.Wildcard:
                        writer.Write(Wildcard);
                        break;
                    case WinBioIdentityType.GUID:
                        writer.Write(TemplateGuid.ToByteArray());
                        break;
                    case WinBioIdentityType.SID:
                        writer.Write(AccountSidSize);
                        AccountSid.GetBinaryForm(bytes, (int)stream.Position);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return bytes;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case WinBioIdentityType.Null: return string.Format("Null ({0})", Null);
                case WinBioIdentityType.Wildcard: return string.Format("Wildcard ({0})", Wildcard);
                case WinBioIdentityType.GUID: return string.Format("GUID ({0})", TemplateGuid);
                case WinBioIdentityType.SID: return string.Format("SID ({0})", AccountSid);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
