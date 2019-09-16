namespace Spark.Compiler
{
    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class BatchCompiler
    {
        public Assembly Compile(bool debug, string languageOrExtension, params string[] sourceCode)
        {
            CodeDomProvider provider;
            CompilerParameters parameters;
            CompilerResults results;
            string language = languageOrExtension;
            if (!CodeDomProvider.IsDefinedLanguage(languageOrExtension) && CodeDomProvider.IsDefinedExtension(languageOrExtension))
            {
                language = CodeDomProvider.GetLanguageFromExtension(languageOrExtension);
            }
            if (ConfigurationManager.GetSection("system.codedom") != null)
            {
                CompilerInfo compilerInfo = CodeDomProvider.GetCompilerInfo(language);
                provider = compilerInfo.CreateProvider();
                parameters = compilerInfo.CreateDefaultCompilerParameters();
            }
            else
            {
                if ((!language.Equals("c#", StringComparison.OrdinalIgnoreCase) && !language.Equals("cs", StringComparison.OrdinalIgnoreCase)) && !language.Equals("csharp", StringComparison.OrdinalIgnoreCase))
                {
                    throw new CompilerException(string.Format("When running the {0} in an AppDomain without a system.codedom config section only the csharp language is supported. This happens if you are precompiling your views.", typeof(BatchCompiler).FullName));
                }
                string compilerVersion = GetCompilerVersion();
                Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
                dictionary2.Add("CompilerVersion", compilerVersion);
                Dictionary<string, string> providerOptions = dictionary2;
                provider = new CSharpCodeProvider(providerOptions);
                parameters = new CompilerParameters();
            }
            parameters.TreatWarningsAsErrors = false;
            string fileExtension = provider.FileExtension;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!assembly.IsDynamic())
                {
                    parameters.ReferencedAssemblies.Add(assembly.Location);
                }
            }
            string tempDir = AppDomain.CurrentDomain.SetupInformation.DynamicBase ?? Path.GetTempPath();
            parameters.TempFiles = new TempFileCollection(tempDir);
            if (debug)
            {
                parameters.IncludeDebugInformation = true;
                string str5 = Path.Combine(tempDir, Guid.NewGuid().ToString("n"));
                List<string> list = new List<string>();
                int num = 0;
                foreach (string str6 in sourceCode)
                {
                    num++;
                    string path = string.Concat(new object[] { str5, "-", num, ".", fileExtension });
                    using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(str6);
                        }
                    }
                    list.Add(path);
                }
                if (!string.IsNullOrEmpty(this.OutputAssembly))
                {
                    parameters.OutputAssembly = Path.Combine(tempDir, this.OutputAssembly);
                }
                else
                {
                    parameters.OutputAssembly = str5 + ".dll";
                }
                results = provider.CompileAssemblyFromFile(parameters, list.ToArray());
            }
            else
            {
                if (!string.IsNullOrEmpty(this.OutputAssembly))
                {
                    parameters.OutputAssembly = Path.Combine(tempDir, this.OutputAssembly);
                }
                else
                {
                    parameters.GenerateInMemory = true;
                }
                results = provider.CompileAssemblyFromSource(parameters, sourceCode);
            }
            if (!results.Errors.HasErrors)
            {
                return results.CompiledAssembly;
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Dynamic view compilation failed.");
            foreach (CompilerError error in results.Errors)
            {
                builder.AppendFormat("{4}({0},{1}): {2} {3}: ", new object[] { error.Line, error.Column, error.IsWarning ? "warning" : "error", error.ErrorNumber, error.FileName });
                builder.AppendLine(error.ErrorText);
            }
            builder.AppendLine();
            foreach (string str8 in sourceCode)
            {
                using (StringReader reader = new StringReader(str8))
                {
                    int num2 = 1;
                    while (true)
                    {
                        string str9 = reader.ReadLine();
                        if (str9 != null)
                        {
                            builder.Append(num2).Append(' ').AppendLine(str9);
                            num2++;
                        }
                    }
                }
            }
            throw new BatchCompilerException(builder.ToString(), results);
        }

        private static string GetCompilerVersion()
        {
            return "v4.0";
        }

        public string OutputAssembly { get; set; }
    }
}

