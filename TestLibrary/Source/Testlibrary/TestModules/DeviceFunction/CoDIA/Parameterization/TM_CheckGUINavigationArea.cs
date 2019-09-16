//------------------------------------------------------------------------------
// <copyright file="- TM_CheckDialogAddDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 05.04.2011
 * Time: 7:08 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Reflection;
using Common.Tools;
using Ranorex;
using Ranorex.Core;
using DeviceDTMs.CoDIA.Modules.Parameterization.MainView.Areas;

using Validation;

namespace Testlibrary.TestModules.DeviceDTM.Parameterization
{
	/// <summary>
	/// Check if intended Dialog-objects could be accessed by using defined paths
	/// </summary>
	public class TM_CheckNavigationArea
	{
		/// <summary>
		/// Execute test module
		/// </summary>
		/// <returns>
		/// <br>True: If call worked fine</br>
		/// <br>False: If an error occured</br>
		/// </returns>
		public static bool Run()
		{
			bool isPassed = true;  
			isPassed &= CheckGUI.Tree(NavigationPaths.strNaviAreaTree, "ParameterisationPaths.strNaviAreaTree");
//			isPassed &= CheckGUI.ScrollBarVertical(ParameterisationPaths.strNaviAreaVerticalScrollBar, 
//			                                      "ParameterisationPaths.strNaviAreaVerticalScrollBar");
//			isPassed &= CheckGUI.ScrollBarHoricontal(ParameterisationPaths.strNaviAreaHoricontalScrollBar, 
//			                                        "ParameterisationPaths.strNaviAreaHoricontalScrollBar");
			isPassed &= Loader.DeviceDTM.Parameterization.Areas.NavigationArea.NumberOfColums(NavigationPaths.strNaviAreaTreeColumns, 3);
			
			if(isPassed){ Report.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Elements checked successfully."); }
			else { Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Elements checked with errors."); }
			
			return isPassed;
		}
	}
}
