using System.Collections;
using ConsoleApplication1;

namespace TestReflection
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Remoting;
    using EH.PCPS.TestAutomation.Common.Attributes;

    public class AssemblyHandler
    {
        public static List<MethodInfo> GetTestScriptMethodsFromAssembly(string assemblyPath)
        {
            //var tempFileName = CreateAssemblyTempFile(assemblyPath);
            //File.Copy(assemblyPath, tempFileName);
            var seperateAppDomainAssemblyLoader = new SeperateAppDomainAssemblyLoader();
            var types = seperateAppDomainAssemblyLoader.LoadAssemblyTypes(new FileInfo(assemblyPath));

            var methodInfo = new List<MethodInfo>(); 

            foreach (var type in types)
            {
                try
                {
                    ObjectHandle oh = Activator.CreateInstanceFrom(assemblyPath, type);
                    object o = oh.Unwrap();
                    Type to = o.GetType();

                    foreach (var method in to.GetMethods())
                    {
                        var customAttributes = method.GetCustomAttributes(false);

                        if (customAttributes.Length > 0)
                        {
                            foreach (var customAttribut in customAttributes)
                            {
                                if (customAttribut is TestScriptInformation)
                                {
                                    methodInfo.Add(method);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            try
            {
                //File.Delete(tempFileName);
            }
            catch
            {
            }
            

            return methodInfo;
        }

        /// <summary>
        /// The create assembly temp file.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string CreateAssemblyTempFile(string assemblyName)
        {
            var orginalFileName = GetOrginalAssemblyName(assemblyName);

            return Path.Combine(Path.GetTempPath(), orginalFileName + "_" + GetTempFileName(".dll"));
        }

        public static string GetTempFilePath(string extension)
        {
            var path = Path.GetTempPath();
            var fileName = GetTempFileName(extension);
            return Path.Combine(path, fileName);
        }

        public static string GetTempFileName(string extension)
        {
            return Guid.NewGuid().ToString() + extension;
        }

        /// <summary>
        /// The get orginal assembly name.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetOrginalAssemblyName(string assemblyName)
        {
            // dann ist es eine Temporäre Datei.
            var orgAssemblyName = assemblyName.Split(new[] { ".cs" }, StringSplitOptions.None);
            if (orgAssemblyName.Length > 1)
            {
                return orgAssemblyName[0] + ".cs";
            }

            orgAssemblyName = assemblyName.Split(new[] { ".dll" }, StringSplitOptions.None);
            if (orgAssemblyName.Length > 1)
            {
                return orgAssemblyName[0] + ".dll";
            }

            return Path.GetFileName(assemblyName);
        }


        public static List<MethodInfo> GetTestScriptMethodsFromAssemblyLinq(string assemblyPath)
        {
            Byte[] bytes = File.ReadAllBytes(assemblyPath);
            var assembly = Assembly.ReflectionOnlyLoad(bytes);
            var methodInfo = new List<MethodInfo>();

            foreach (var type in assembly.GetTypes())
            {
                try
                {
                    ObjectHandle oh = Activator.CreateInstanceFrom(assemblyPath, type.ToString());
                    object o = oh.Unwrap();
                    Type to = o.GetType();

                    methodInfo.AddRange(from method in to.GetMethods() let customAttributes = method.GetCustomAttributes(false) where customAttributes.Length > 0 from customAttribut in customAttributes where customAttribut is TestScriptInformation select method);
                }
                catch (Exception)
                {
                }
            }

            return methodInfo;
        }

        public static List<string> GetTestSuitesListFromAssembly(string assemblyPath)
        {
            Byte[] bytes = File.ReadAllBytes(assemblyPath);
            var assembly = Assembly.ReflectionOnlyLoad(bytes);
            var resources = assembly.GetManifestResourceNames();
            var resourceList = new List<string>();

            foreach (var resource in resources)
            {
                if (resource.EndsWith(".xml"))
                {
                    resourceList.Add(resource);
                }
            }

            return resourceList;
        }

        public static List<string> GetTestSuitesFilesFromAssembly(string assemblyPath)
        {
            var resultList = new List<string>();
            Byte[] bytes = File.ReadAllBytes(assemblyPath);
            var assembly = Assembly.ReflectionOnlyLoad(bytes);

            foreach (var resource in assembly.GetManifestResourceNames())
            {
                if (resource.EndsWith(".xml"))
                {
                    var stream = assembly.GetManifestResourceStream(resource);

                    var path = Path.GetTempPath();
                    var file = "UserDefined_" + GetTempFileName(".xml");

                    var fileName = Path.Combine(path, file);

                    using (var output = new FileStream(fileName, FileMode.Create))
                    {
                        stream.CopyTo(output);
                        resultList.Add(fileName);
                    }
                }
            }

            return resultList;
        }

        public static List<Stream> GetTestSuitesStreamFromAssembly(string assemblyPath)
        {
            var ResultList = new List<Stream>();
            Byte[] bytes = File.ReadAllBytes(assemblyPath);
            var assembly = Assembly.ReflectionOnlyLoad(bytes);

            foreach (var resource in assembly.GetManifestResourceNames())
            {
                if (resource.EndsWith(".xml"))
                {
                    var stream = assembly.GetManifestResourceStream(resource);
                    ResultList.Add(stream);
                    
                    var path = Path.GetTempPath();
                    var file = "UserDefined_" + GetTempFileName(".xml"); 

                    var fileName = Path.Combine(path, file);


                    using (var output = new FileStream(fileName, FileMode.Create))
                    {
                        stream.CopyTo(output);
                    }
                }
            }

            return ResultList;
        }

        //public static List<Stream> GetTestSuitesFromAssembly(string assemblyPath)
        //{
        //    var tempFileName = CreateAssemblyTempFile(assemblyPath);
        //    File.Copy(assemblyPath, tempFileName);
        //    var seperateAppDomainAssemblyLoader = new SeperateAppDomainAssemblyLoader();
        //    return seperateAppDomainAssemblyLoader.LoadAssemblyXmlResources(new FileInfo(tempFileName));
        //}

        public static List<string> GetTestSuitesFileFromAssemby(string assemblyPath)
        {
            //var tempFileName = CreateAssemblyTempFile(assemblyPath);
            //File.Copy(assemblyPath, tempFileName);
            var seperateAppDomainAssemblyLoader = new SeperateAppDomainAssemblyLoader();
            var resultList = seperateAppDomainAssemblyLoader.LoadAssemblyXmlResources(new FileInfo(assemblyPath));

            //File.Delete(tempFileName);

            return resultList;
        }
    }
}
