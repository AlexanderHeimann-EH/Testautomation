// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestSystem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 11/6/2013
 * Time: 8:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment
{
    using System.Collections.Generic;

    /// <summary>
    /// Description of SystemComponent.
    /// </summary>
    public class TestSystem    
    {
        /// <summary>
        /// The id.
        /// </summary>
        private int id;

        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The parameters.
        /// </summary>
        private Dictionary<string, string> parameters;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int ID
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get { return this.parameters; }
            set { this.parameters = value; }
        }    
    }
}
