// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MySpace;

namespace MyApp
{
    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The default proxy.
        /// </summary>
        private Proxy DefaultProxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The form 1_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // loads lower version of the assembly during the startup
            // Creates a new Assembly Proxy
            DefaultProxy =
                new Proxy(
                    @"L:\Public\P\EH.PCSW.Testautomation.TestFramework\ReleaseBin\Release\EH.PCPS.TestAutomation.Testlibrary.dll", 
                    "Domain1");
            lblCurrentAppDomain.Text = DefaultProxy.DefaultAppDomain;
            lblCurrentAssembly.Text = DefaultProxy.DefaultAssemblyFileName;
            lblMainAppDomian.Text = AppDomain.CurrentDomain.FriendlyName;
        }

        /// <summary>
        /// The load assembly version 1.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void LoadAssemblyVersion1(object sender, EventArgs e)
        {
            // Creates a new Assembly Proxy. Here GC is clearing the old Appdomin automaticaly
            DefaultProxy = new Proxy("Assembly v1.0.dll", "Domain1");
            lblCurrentAppDomain.Text = DefaultProxy.DefaultAppDomain;
            lblCurrentAssembly.Text = DefaultProxy.DefaultAssemblyFileName;
            lblMainAppDomian.Text = AppDomain.CurrentDomain.FriendlyName;


            // Extras
            errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            errorProvider1.SetError(radioAssembly2, string.Empty);
            errorProvider1.SetError(radioAssembly1, "This Dll is a Beta Version. It won't reverse the string properly");
        }

        // loads the second version of assembly
        /// <summary>
        /// The load assembly version 2.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void LoadAssemblyVersion2(object sender, EventArgs e)
        {
            // Creates a new Assembly Proxy. Here GC is clearing the old Appdomin automaticaly
            DefaultProxy = new Proxy("Assembly v2.0.dll", "Domain2");
            lblCurrentAppDomain.Text = DefaultProxy.DefaultAppDomain;
            lblCurrentAssembly.Text = DefaultProxy.DefaultAssemblyFileName;
            lblMainAppDomian.Text = AppDomain.CurrentDomain.FriendlyName;

            // Extras.
            errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            errorProvider1.SetError(radioAssembly1, string.Empty);
            errorProvider1.SetError(radioAssembly2, "This Dll is the Final Version");
        }

        /// <summary>
        /// The btn calculate_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // txtReverseData.Text =  DefaultProxy.ReverseValue(txtReverseData.Text);
        }

        // returns the data from currently loaded assembly
        /// <summary>
        /// The btn get value_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnGetValue_Click(object sender, EventArgs e)
        {
            List<MethodInfo> methodInfoList = DefaultProxy.GetMethodInfoFromAssembly();
            MessageBox.Show(methodInfoList.Count.ToString());

            //List<Stream> streamList = DefaultProxy.GetEmbeddedResources();
            //MessageBox.Show(streamList.Count.ToString());
        }

        /// <summary>
        /// The button 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<MethodInfo> methodInfoList = DefaultProxy.GetMethodInfoFromAssembly();

            var Test = string.Empty;
        }
    }
}