// Guids.cs
// MUST match guids.h
using System;

namespace EndressHauser.DTMstudioTest
{
    static class GuidList
    {
        public const string guidDTMstudioTestPkgString = "69ed8e48-6154-4e34-b061-86290d427a55";
        public const string guidDTMstudioTestCmdSetString = "a93ef65a-d459-42e4-a4a5-359a7f725d5b";
        public const string guidToolWindowPersistanceString = "8abfb1c2-bdee-4fec-b6fb-86b84303b398";
        public const string guidDTMstudioTestEditorFactoryString = "05a6653e-73f2-431a-8f2f-2d8d37241585";
        public const string guidDTTestProjectFactoryString = "80B2028F-E2C7-48E7-98ED-BCFC4B094216";

        public static readonly Guid guidDTMstudioTestCmdSet = new Guid(guidDTMstudioTestCmdSetString);
        public static readonly Guid guidDTMstudioTestEditorFactory = new Guid(guidDTMstudioTestEditorFactoryString);
        public static readonly Guid guidDTTestProjectFactory = new Guid(guidDTTestProjectFactoryString);
    };
}