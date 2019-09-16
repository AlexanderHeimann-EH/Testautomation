/*
 * Created by Ranorex
 * User: Tina Bertos
 * Date: 07/10/2015
 * Time: 16:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers.Generics
{
	/// <summary>
	/// Description of IGoOnline.
	/// </summary>
	public interface IGoOnline
	{

        /// <summary>
        /// 
        /// </summary>
        string ProtocolName {get; set;}

        /// <summary>
        /// 
        /// </summary>
        string CommUnit {get; set;}

        /// <summary>
        /// 
        /// </summary>
        void GoOnline();
	}
}
