using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using EH.PCPS.TestAutomation.Common.Attributes;

namespace MySpace
{
	public class Proxy //:BaseInterface.IBaseInterface
	{
		//main controller for Appdomain
        AppDomainCore _appDomainController;

        //main controller for Assembly
		AssemblyCore _assemblyController;
        
        /// <summary>
        /// Gets the currenlty Active Appdomain Name
        /// </summary>
        public string DefaultAppDomain
        {
            get { return _appDomainController.DefaultAppdomainName; }
        }

        /// <summary>
        /// Gets the Default Assembly's FileName
        /// </summary>
        public string DefaultAssemblyFileName
        {
            get { return _assemblyController.ActiveAssemblyFile; }
        }

        /// <summary>
        /// Creates an instance of the proxy.
        /// </summary>
        /// <param name="AssemblyFileName">Name of Assembly File to be loaded</param>
        /// <param name="AppDomainName">Friendly Name for the new Appdomain</param>
		public Proxy(string AssemblyFileName,string AppDomainName)
		{
            Init(AssemblyFileName, AppDomainName, "MyAssembly.ClassLibrary");
            //sInit(AssemblyFileName, AppDomainName, "EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.Parameterization.TS_SetupDelivery");
		}

		/// <summary>
        /// /// <summary>
        /// Creates an instance of the proxy.
        /// </summary>
        /// <param name="AssemblyFileName">Name of Assembly File to be loaded</param>
        /// <param name="AppDomainName">Friendly Name for the new Appdomain</param>
		/// <param name="CurrentType">Name of Object type that is to loaded from the Assembly</param>
        public Proxy(string AssemblyFileName, string AppDomainName,string CurrentType)
		{
			Init(AssemblyFileName, AppDomainName, CurrentType);
		}

		private bool Init(string AssemblyFileName, string AppDomainName, string CurrentType)
		{
			//Creates an instance of Assembly controller and Appdomain controller
            //_assemblyController = new AssemblyCore(AssemblyFileName, CurrentType);
			_appDomainController = new AppDomainCore(AppDomainName);

		    //_appDomainController.DefaultAppDomain.("Assembly v2.0.dll");
			return true;
		}

        public List<MethodInfo> GetMethodInfoFromAssembly()
        {
            try
            {
                //object proxy = _appDomainController.DefaultAppDomain.CreateInstanceFromAndUnwrap(_assemblyController.DefaultAssemblyFileName, _assemblyController.CurrentType);
                var proxy = _appDomainController.DefaultAppDomain.CreateInstanceFrom(_assemblyController.DefaultAssemblyFileName, _assemblyController.CurrentType);

                if (proxy != null)
                {
                    foreach (var type in proxy.GetType().Assembly.GetTypes())
                    {
                        try
                        {
                            var methods = type.GetMethods();
                            foreach (var method in methods)
                            {
                                try
                                {
                                    //Console.WriteLine(method.Name);
                                    IList<CustomAttributeData> customAttributes = method.GetCustomAttributesData(); //typeof(TestScriptInformation), false);
                                    if (customAttributes.Count > 0)
                                    {
                                        foreach (var attribut in customAttributes)
                                        {
                                            if (attribut.GetType() == typeof(TestScriptInformation))
                                            { 
                                                Console.WriteLine(attribut.ToString()); 
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    return null;
                    //return proxy.GetType().Assembly.GetTypes().SelectMany(t => t.GetMethods()).Where(m => m.GetCustomAttributes(typeof(TestScriptInformation), false).Length > 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public List<Stream> GetEmbbededResources()
        {
            object proxy = _appDomainController.DefaultAppDomain.CreateInstanceFrom(_assemblyController.DefaultAssemblyFileName, _assemblyController.CurrentType);

            //object proxy3 = _appDomainController.DefaultAppDomain.Load(_assemblyController.DefaultAssemblyFileName);

            var ResultList = new List<Stream>();

            if (proxy != null)
            {
                var assembly = proxy.GetType().Assembly;

                foreach (var resource in assembly.GetManifestResourceNames())
                {
                    if (resource.EndsWith(".xml"))
                    {
                        var stream = assembly.GetManifestResourceStream(resource);
                        ResultList.Add(stream);


                        var tempname = Path.GetTempFileName();
                        var path = Path.GetTempPath();
                        var file = "UserDefined_" + Path.ChangeExtension( Path.GetFileName(tempname), ".xml");

                        var fileName = Path.Combine(path, file);


                        using (System.IO.FileStream output = new System.IO.FileStream(fileName, FileMode.Create))
                        {
                            stream.CopyTo(output);
                        }

                    }
                }

            }

            return ResultList;
        }
	}
}
