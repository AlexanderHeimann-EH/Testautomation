// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using EH.DTMstudioTest.Proxy;

namespace TestReflection
{
    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {

            var assemblyPath = @"P:\EH.PCSW.Testautomation.TestFramework\ReleaseBin\Release\EH.PCPS.TestAutomation.Testlibrary.dll";
            
            //for (int i = 0; i < 100; i++)
            //{
            //    var methodIndos = AssemblyProxy.GetTestScriptMethodsFromAssembly(assemblyPath);

            //    foreach (var methodIndo in methodIndos)
            //    {
            //        Console.WriteLine(methodIndo.DeclaringType.FullName + "." + methodIndo.Name);
            //    }

            //    Console.WriteLine("-------------------------------------------------------------");
            //}


            for (int i = 0; i < 100; i++)
            {
                var methodIndos = AssemblyProxy.GetTestSuitesFileFromAssemby(@"Assembly v1.0.dll");

                foreach (var methodIndo in methodIndos)
                {
                    Console.WriteLine(methodIndo);

                    File.Delete(methodIndo);
                }   

                Console.WriteLine("-------------------------------------------------------------");
            }
            
            Console.ReadLine();
        }

        ///// <summary>
        ///// The load assembly in app domain.
        ///// </summary>
        ///// <param name="assemblyPath">
        ///// The assembly path.
        ///// </param>
        //private static void LoadAssemblyInAppDomain(string assemblyPath)
        //{
        //    var DefaultProxy = new Proxy(assemblyPath, "Domain1");

        //    List<MethodInfo> methodInfoList = DefaultProxy.GetMethodInfoFromAssembly();
        //}


        ///// <summary>
        ///// The load byte assembly.
        ///// </summary>
        ///// <param name="path">
        ///// The path.
        ///// </param>
        //private static void LoadByteAssembly(string path)
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        byte[] readAllBytes = File.ReadAllBytes(path);

        //        var assembly = Assembly.Load(readAllBytes);
        //        readAllBytes = null;

        //        var methodInfos =
        //            assembly.GetTypes()
        //                    .SelectMany(t => t.GetMethods())
        //                    .Where(
        //                        m =>
        //                        m.GetCustomAttributes(typeof (TestScriptInformation), false).Length > 0 ||
        //                        m.GetCustomAttributes(typeof (TestSuideGuids), false).Length > 0)
        //                    .ToList();

        //        Console.WriteLine(i);
        //    }
        //}

        /// <summary>
        /// The get reflection only.
        /// </summary>
        /// <param name="AssemblyPath">
        /// The assembly path.
        /// </param>
        private static void GetReflectionOnly(string AssemblyPath)
        {
            Assembly.ReflectionOnlyLoad(AssemblyPath);

            ReflectionOnlyLoadTest.Main1(AssemblyPath);
        }

        //private void Test(string assemblyPath)
        //{
        //    var resourcesList2 = new List<string>();

        //    resourcesList2 = AssemblyHandler.GetTestSuitesFilesFromAssembly(@"Assembly v1.0.dll");

        //    foreach (var resource in resourcesList2)
        //    {
        //        Console.WriteLine(resource);
        //    }

        //    Console.WriteLine("Fertig: " + resourcesList2.Count);
        //    Console.ReadKey();

        //    resourcesList2 = AssemblyHandler.GetTestSuitesFilesFromAssembly(@"Assembly v2.0.dll");

        //    foreach (var resource in resourcesList2)
        //    {
        //        Console.WriteLine(resource);
        //    }

        //    Console.WriteLine("Fertig: " + resourcesList2.Count);
        //    Console.ReadKey();

        //    var resourcesList = AssemblyHandler.GetTestSuitesListFromAssembly(assemblyPath);

        //    foreach (var resource in resourcesList)
        //    {
        //        Console.WriteLine(resource);
        //    }

        //    Console.WriteLine("Fertig: " + resourcesList.Count);
        //    Console.ReadKey();

        //    var path = @"Assembly v2.0.dll";

        //    var resourcesList1 = AssemblyHandler.GetTestSuitesListFromAssembly(path);

        //    foreach (var resource in resourcesList1)
        //    {
        //        Console.WriteLine(resource);
        //    }

        //    Console.WriteLine("Fertig: " + resourcesList1.Count);
        //    Console.ReadKey();


        //    var streamList = AssemblyHandler.GetTestSuitesStreamFromAssembly(path);

        //    Console.WriteLine("Fertig: " + streamList.Count);
        //    Console.ReadKey();


        //    var summe = new TimeSpan();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var startTime = DateTime.Now;
        //        var methodIntos = AssemblyHandler.GetTestScriptMethodsFromAssemblyLinq(assemblyPath);
        //        var stopTime = DateTime.Now;

        //        TimeSpan runTime = startTime - stopTime;
        //        summe += runTime;
        //        Console.WriteLine(runTime);

        //        Console.WriteLine("-------------------------------------------------------");
        //    }

        //    Console.WriteLine("Summe: " + summe);

        //    Console.WriteLine("-------------------------------------------------------");
        //    Console.WriteLine("-------------------------------------------------------");
        //    Console.WriteLine("-------------------------------------------------------");
        //    Console.WriteLine("-------------------------------------------------------");
        //    summe = new TimeSpan();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var startTime = DateTime.Now;
        //        var methodIntos = AssemblyHandler.GetTestScriptMethodsFromAssembly(assemblyPath);
        //        var stopTime = DateTime.Now;

        //        TimeSpan runTime = startTime - stopTime;
        //        summe += runTime;
        //        Console.WriteLine(runTime);

        //        Console.WriteLine("-------------------------------------------------------");
        //    }

        //    Console.WriteLine("Summe: " + summe);


        //}

    }


    /// <summary>
    /// The reflection only load test.
    /// </summary>
    public class ReflectionOnlyLoadTest
    {
        /// <summary>
        /// The m_root assembly.
        /// </summary>
        private readonly string m_rootAssembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionOnlyLoadTest"/> class.
        /// </summary>
        /// <param name="rootAssembly">
        /// The root assembly.
        /// </param>
        public ReflectionOnlyLoadTest(string rootAssembly)
        {
            m_rootAssembly = rootAssembly;
        }

        /// <summary>
        /// The main 1.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public static void Main1(string path)
        {
            try
            {
                ReflectionOnlyLoadTest rolt = new ReflectionOnlyLoadTest(path);
                rolt.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}!!!", e.Message);
            }
        }

        /// <summary>
        /// The run.
        /// </summary>
        internal void Run()
        {
            AppDomain curDomain = AppDomain.CurrentDomain;
            curDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(MyReflectionOnlyResolveEventHandler);
            Assembly asm = Assembly.ReflectionOnlyLoadFrom(m_rootAssembly);

            // force loading all the dependencies
            Type[] types = asm.GetTypes();

            // show reflection only assemblies in current appdomain
            Console.WriteLine("------------- Inspection Context --------------");
            foreach (Assembly a in curDomain.ReflectionOnlyGetAssemblies())
            {
                Console.WriteLine("Assembly Location: {0}", a.Location);
                Console.WriteLine("Assembly Name: {0}", a.FullName);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// The my reflection only resolve event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="Assembly"/>.
        /// </returns>
        private Assembly MyReflectionOnlyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            AssemblyName name = new AssemblyName(args.Name);
            string asmToCheck = Path.GetDirectoryName(m_rootAssembly) + "\\" + name.Name + ".dll";
            if (File.Exists(asmToCheck))
            {
                return Assembly.ReflectionOnlyLoadFrom(asmToCheck);
            }

            return Assembly.ReflectionOnlyLoad(args.Name);
        }
    }
}