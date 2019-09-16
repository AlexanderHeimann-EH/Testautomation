// Guids.cs
// MUST match guids.h
using System;

namespace EndressHauserProcessSolutionsAG.VSPackage1
{
    static class GuidList
    {
        public const string guidVSPackage1PkgString = "17d6a70c-0b27-4ea7-a604-bd9f92aaea1f";
        public const string guidVSPackage1CmdSetString = "4f18908a-ff17-4b47-bfba-de533c5dd7f9";
        public const string guidToolWindowPersistanceString = "0743443d-4c8c-4eca-a14d-c214bb360d6d";

        public static readonly Guid guidVSPackage1CmdSet = new Guid(guidVSPackage1CmdSetString);
    };
}