using System;
using System.Collections.Generic;
using System.Text;
//using EH.PCPS.TestAutomation.Common.Attributes;
//using EH.PCPS.TestAutomation.Common.Enumerations;

namespace MyAssembly
{
    //this attribute is required for creation of instance in seperate appdomain.
    [Serializable]
    /*to enable the class to cross the appdomain limits we have 
        to inherit the class from Marshelby refe object.*/
    public class ClassLibrary1 : MarshalByRefObject // , BaseInterface.IBaseInterface
    {
		#region BaseInterface Members

		public string ReturnBaseValue()
		{
            return "Value=Assembly Version 2.0";
		}

		public string ReverseValue(string Value)
		{
            return ReverseString(Value);
		}

		#endregion

        private string ReverseString(string Value)
        {
            StringBuilder tmp = new StringBuilder();
            for (int i = Value.Length - 1; i >= 0; i--)
            {
                tmp.Append(Value.Substring(i, 1));
            }
            return tmp.ToString();
        }


        //[TestScriptInformation("e1e92283-264e-4952-a11a-f7c6d6d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        //public string TestBlub1()
        //{
        //    return "Value=Assembly Version 1.0";
        //}


        //[TestScriptInformation("e1e97303-264e-4952-a11a-f766d6d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        //public string TestBlub2()
        //{
        //    return "Value=Assembly Version 1.0";
        //}

        //[TestScriptInformation("e1e97243-264e-4952-a11a-f7c6d5d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        //public string TestBlub3()
        //{
        //    return "Value=Assembly Version 1.0";
        //}

        //[TestScriptInformation("e1e97205-264e-4952-a11a-f7c6d4d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        //public string TestBlub4()
        //{
        //    return "Value=Assembly Version 1.0";
        //}

        //[TestScriptInformation("e1e97305-264e-4952-a11a-f7c6d4d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        //public string TestBlub5()
        //{
        //    return "Value=Assembly Version 1.0";
        //}
	}
}
