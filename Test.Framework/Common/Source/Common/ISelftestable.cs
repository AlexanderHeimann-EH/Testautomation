//using NUnit.Framework;

namespace EH.PCPS.TestAutomation.Common
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    using DateTime = System.DateTime;

    /// <summary>
    ///     An abstract class, to enable selftest-functionality for Element-Classes in the framework
    /// </summary>
    //[TestFixture]
    public class ISelftestable
    {
        /// <summary>
        ///     The Setup function describes the initial steps, that are neccessary to make the tested elements in the Elements-Class visible. Can be overriden if neccessary.
        /// </summary>
        public virtual void Setup()
        {
        }

        /// <summary>
        ///     The Setup function describes the final steps, to clean up after a selftest. Should be the inverse of Setup(). Can be overriden if neccessary.
        /// </summary>
        public virtual void Cleanup()
        {
        }

        /// <summary>
        ///     This function will reflect over all Properties in an Element-Class and test them. If subclasses of ISelftestable type are included, they are also tested recursively.
        /// </summary>
        /// <returns>The number of Errors found</returns>
        public virtual int SelfTest()
        {
            this.Setup();

            Type currentType = MethodBase.GetCurrentMethod().DeclaringType;
            string currentName = this.GetType().Namespace + " / " + this.GetType().Name;
            DateTime start = DateTime.Now;

            PropertyInfo[] propertyInfos = this.GetType().GetProperties(BindingFlags.Public |
                                                                   BindingFlags.Static);

            int errorCount = 0;

            foreach (PropertyInfo  pI in propertyInfos)
            {
                //object value = obj.GetType().GetProperty("PropertyName").GetValue (obj,null);


                //object value = this.GetType().GetProperty(pI.Name).GetValue(this, null);


                if (pI.GetCustomAttributes(typeof (SelftestIgnore), false).Length > 0)
                {
                    //Console.WriteLine("!Warning! Ignoring property " + pI.Name);
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "!Warning! Ignoring property " + pI.Name);
                    continue;
                }

                DateTime startprop = DateTime.Now;
                object value = null;
                try
                {
                    value = pI.GetValue(this, null);
                }
                catch (Exception Exc)
                {
                    //Console.WriteLine("Exception in Reflection: " + Exc.Message);
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Exception in Reflection: " + Exc.Message);
                    value = null;
                }


                if (value == null)
                {
                    //Console.WriteLine("Property failed: " + pI.Name);
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Property failed: " + pI.Name);
                    errorCount++;
                    continue;
                }

                //Console.WriteLine("Property success: " + pI.Name + " " + value.ToString());
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Property success: " + pI.Name + " " + value + " in: " +
                            ((DateTime.Now - startprop).TotalMilliseconds/1000).ToString() + "s");

                if (value != null)
                {
                    //if (value is Ranorex.Core.Element) EH.PCPS.TestAutomation.Common.Tools.Log.Screenshot((Ranorex.Core.Element)value);
                    if (value is Adapter) ((Adapter) value).MoveTo(Location.CenterLeft);
                    if (value is Adapter) Log.Screenshot();
                }
            }

            //If the class contains further classes that are Selftestable, then execute their test too
            Type[] subclasses = this.GetType().GetNestedTypes();
            foreach (Type t in subclasses)
            {
                //Create an instance
                object i = Activator.CreateInstance(t);

                if (i is ISelftestable)
                {
                    errorCount += ((ISelftestable) i).SelfTest();
                }
            }

            this.Cleanup();

            if (errorCount == 0)
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selftest of " + currentName + " completet without errors in:" +
                               (DateTime.Now - start).TotalSeconds.ToString() + "s");
            else
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selftest of " + currentName + " failed in:" +
                               (DateTime.Now - start).TotalSeconds.ToString() + "s");
            return errorCount;
        }

        // /// <summary>
        // /// Just a wrapper to make SelfTest-function Nunit-Compatible
        // /// </summary>
        //[Test]
        //public void nunitSelfTest()
        //{
        //   Assert.AreEqual(0, SelfTest());
        //}
    }

    /// <summary>
    ///     There are some Properties inside a Element-Class, which might not be selftestable in some way. Then you might give them the SelftestIgnore-Attribute, to make them
    ///     be ignored by the selftest.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SelftestIgnore : Attribute
    {
        //private string name;
        //public double version;

        //public Author(string name)
        //{
        //    this.name = name;
        //    version = 1.0;
        //}
    }
}