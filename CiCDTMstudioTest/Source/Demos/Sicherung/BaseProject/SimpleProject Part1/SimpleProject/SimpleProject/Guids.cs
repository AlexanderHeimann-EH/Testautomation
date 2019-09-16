// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="">
//   
// </copyright>
// <summary>
//   
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleProject
{
    using System;

    static class GuidList
    {
        public const string guidSimpleProjectPkgString = "96bf4c26-d94e-43bf-a56a-f8500b52bfad";
        public const string guidSimpleProjectCmdSetString = "72c23e1d-f389-410a-b5f1-c938303f1391";
        public const string guidSimpleProjectFactoryString = "471EC4BB-E47E-4229-A789-D1F5F83B52D4";

        public static readonly Guid guidSimpleProjectCmdSet = new Guid(guidSimpleProjectCmdSetString);
        public static readonly Guid guidSimpleProjectFactory = new Guid(guidSimpleProjectFactoryString);
    };
}