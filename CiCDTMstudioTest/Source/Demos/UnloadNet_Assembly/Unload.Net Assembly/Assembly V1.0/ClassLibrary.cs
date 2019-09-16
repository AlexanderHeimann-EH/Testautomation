using System;
using System.Collections.Generic;
using System.Text;
using EH.PCPS.TestAutomation.Common.Attributes;
using EH.PCPS.TestAutomation.Common.Enumerations;

namespace MyAssembly
{
    //this attribute is required for creation of instance in seperate appdomain.
    [Serializable]
    /*to enable the class to cross the appdomain limits we 
     * have to inherit the class from Marshelby refe object.*/
    public class ClassLibrary : MarshalByRefObject //, BaseInterface.IBaseInterface
    {
		#region BaseInterface Members

		public string ReturnBaseValue()
		{
            return "Value=Assembly Version 1.0";
		}

		public string ReverseValue(string Value)
		{
            return ReverseString(Value);
		}

        [TestScriptInformation("e1e92203-264e-4952-a11a-f7c6d6d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        public string Test1()
        {
            return "Value=Assembly Version 1.0";
        }


        [TestScriptInformation("e1e97303-264e-4952-a11a-f7c6d6d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        public string Test2()
        {
            return "Value=Assembly Version 1.0";
        }

        [TestScriptInformation("e1e97243-264e-4952-a11a-f7c6d6d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        public string Test3()
        {
            return "Value=Assembly Version 1.0";
        }

        [TestScriptInformation("e1e97205-264e-4952-a11a-f7c6d6d5311b", TestDefinition.UserDefined, TestScript.TestCase)]
        public string Test4()
        {
            return "Value=Assembly Version 1.0";
        }

		#endregion


        private string ReverseString(string Value)
        {
            StringBuilder tmp = new StringBuilder();
            //the actual requirement is >=0. intentionaly made an error in alggoritum to make an error.
            for (int i = Value.Length - 1; i > 1; i--)
            {
                tmp.Append(Value.Substring(i, 1));
            }
            return tmp.ToString();
        }
	}
}
