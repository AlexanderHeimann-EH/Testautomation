// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultDataSetterAttribute.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implements an attribute class for the method that sets the default data into an instance object, to be used during deserialization.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Common.Utilities.Serialization.Attributes
{
    using System;

    /// <summary>
    /// Implements an attribute class for the method that sets the default data into an instance object, to be used during deserialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DefaultDataSetterAttribute : Attribute
    {
    }
}