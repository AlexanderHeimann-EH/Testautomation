// Guids.cs
// MUST match guids.h
using System;

namespace EndressHauserProcessSolutionsAG.VSPackage1
{
    static class GuidList
    {
        public const string guidVSPackage1PkgString = "f66d30c0-911c-40fc-a598-a35eab43779d";
        public const string guidVSPackage1CmdSetString = "45b7eaee-2907-4371-8a61-abca6592bf5d";

        public static readonly Guid guidVSPackage1CmdSet = new Guid(guidVSPackage1CmdSetString);
    };
}