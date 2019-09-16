// Guids.cs
// MUST match guids.h
using System;

namespace EndressHauserProcessSolutionsAG.EH_DTMstudioTest_Solution
{
    static class GuidList
    {
        public const string guidEH_DTMstudioTest_SolutionPkgString = "0aa6dd08-02e6-4719-b8a8-d7f1b0a592cb";
        public const string guidEH_DTMstudioTest_SolutionCmdSetString = "90956547-c1de-4c4e-98c3-6b9b6c4a0062";
        public const string guidToolWindowPersistanceString = "1051f894-7128-41bd-8c9d-fc83fb32e063";
        public const string guidEH_DTMstudioTest_SolutionEditorFactoryString = "4d955fea-2993-4d74-9292-bf00a580008f";

        public static readonly Guid guidEH_DTMstudioTest_SolutionCmdSet = new Guid(guidEH_DTMstudioTest_SolutionCmdSetString);
        public static readonly Guid guidEH_DTMstudioTest_SolutionEditorFactory = new Guid(guidEH_DTMstudioTest_SolutionEditorFactoryString);
    };
}