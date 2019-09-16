// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigStorage.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   General reading and writing of [name, value] pairs in an xml configuration file
//   Value naming:
//   The path is the name of the value. It has the form of [name]/[name]/[name] (interpreted as a node chain in an xml document)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using EH.ImsOpcBridge.Configurator.Properties;

    using log4net;

    /// <summary>
    /// General reading and writing of [name, value] pairs in an xml configuration file
    /// </summary>
    public class ConfigStorage
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Lock to be used to synchronize access to <see cref="configurationXmlDoc"/>.
        /// </summary>
        private readonly object configurationXmlLock = new object();

        /// <summary>
        /// The configuration XML document.
        /// </summary>
        private XDocument configurationXmlDoc;

        /// <summary>
        /// is true if the configuration file has been changed
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// The fileName.
        /// </summary>
        private string xmlFilename;

        #endregion

        #region Public Methods

        /// <summary>
        /// Closes the storage.
        /// </summary>
        public void Close()
        {
            if (this.configurationXmlDoc != null)
            {
                lock (this.configurationXmlLock)
                {
                    this.configurationXmlDoc = null;
                    this.isDirty = false;
                }
            }
        }

        /// <summary>
        /// Gets the value defined by path. The default value is added if not contained in the storage.
        /// </summary>
        /// <param name="path">The path. [name]/[name]/[name]</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Is accepted by lupus alpha")]
        public double GetValue(string path, double defaultValue)
        {
            var value = defaultValue;

            if (this.configurationXmlDoc == null)
            {
                return value;
            }

            try
            {
                List<XElement> elms = ((IEnumerable)this.configurationXmlDoc.Root.XPathEvaluate(path)).Cast<XElement>().ToList();
                if (elms.Count == 1)
                {
                    value = double.Parse(elms[0].Value, CultureInfo.InvariantCulture);
                }
                else if (elms.Count == 0)
                {
                    this.AddElementIfNotExists(path, defaultValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsDebugEnabled)
                {
                    string logMessage = string.Format(CultureInfo.CurrentCulture, @"Failed to read configuration value '{0}'  -> {1}.", path, ex.Message);
                    Logger.Debug(logMessage);
                }
            }

            return value;
        }

        /// <summary>
        /// Gets the value defined by path. The default value is added if not contained in the storage.
        /// </summary>
        /// <param name="path">The path. [name]/[name]/[name]</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Is accepted by lupus alpha")]
        public int GetValue(string path, int defaultValue)
        {
            var value = defaultValue;

            if (this.configurationXmlDoc == null)
            {
                return value;
            }

            try
            {
                List<XElement> elms = ((IEnumerable)this.configurationXmlDoc.Root.XPathEvaluate(path)).Cast<XElement>().ToList();
                if (elms.Count == 1)
                {
                    value = int.Parse(elms[0].Value, CultureInfo.InvariantCulture);
                }
                else if (elms.Count == 0)
                {
                    this.AddElementIfNotExists(path, defaultValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsDebugEnabled)
                {
                    string logMessage = string.Format(CultureInfo.CurrentCulture, @"Failed to read configuration value '{0}'  -> {1}.", path, ex.Message);
                    Logger.Debug(logMessage);
                }
            }

            return value;
        }

        /// <summary>
        /// Gets the value defined by path. The default value is added if not contained in the storage.
        /// </summary>
        /// <param name="path">The path. [name]/[name]/[name]</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Is accepted by lupus alpha")]
        public bool GetValue(string path, bool? defaultValue)
        {
            var value = defaultValue;

            if (this.configurationXmlDoc == null)
            {
                return value == true;
            }

            try
            {
                List<XElement> elms = ((IEnumerable)this.configurationXmlDoc.Root.XPathEvaluate(path)).Cast<XElement>().ToList();
                if (elms.Count == 1)
                {
                    value = bool.Parse(elms[0].Value);
                }
                else if (elms.Count == 0)
                {
                    if (value != null)
                    {
                        this.AddElementIfNotExists(path, defaultValue.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsDebugEnabled)
                {
                    string logMessage = string.Format(CultureInfo.CurrentCulture, @"Failed to read configuration value '{0}'  -> {1}.", path, ex.Message);
                    Logger.Debug(logMessage);
                }
            }

            return value == true;
        }

        /// <summary>
        /// Gets the value defined by path. The default value is added if not contained in the storage.
        /// </summary>
        /// <param name="path">The path. [name]/[name]/[name]</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Is accepted by lupus alpha")]
        public string GetValue(string path, string defaultValue)
        {
            var value = defaultValue;

            if (this.configurationXmlDoc == null)
            {
                return value;
            }

            try
            {
                List<XElement> elms = ((IEnumerable)this.configurationXmlDoc.Root.XPathEvaluate(path)).Cast<XElement>().ToList();
                if (elms.Count == 1)
                {
                    value = elms[0].Value;
                }
                else if (elms.Count == 0)
                {
                    if (!string.IsNullOrEmpty(defaultValue))
                    {
                        this.AddElementIfNotExists(path, defaultValue);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsDebugEnabled)
                {
                    string logMessage = string.Format(CultureInfo.CurrentCulture, @"Failed to read configuration value '{0}'  -> {1}.", path, ex.Message);
                    Logger.Debug(logMessage);
                }
            }

            return value;
        }

        /// <summary>
        /// Loads the configuration. The file is created if not found.
        /// </summary>
        /// <param name="fileName">The xmlFilename with full path</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Is accepted by lupus alpha")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        public void Load(string fileName)
        {
            this.xmlFilename = fileName;

            var mutex = new Mutex(false, @"Local\EH.ImsOpcBridge.Configurator.Model.ConfigStorage.Save");

            try
            {
                mutex.WaitOne();

                if (!Directory.Exists(Path.GetDirectoryName(this.xmlFilename)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(this.xmlFilename));
                }

                if (!File.Exists(this.xmlFilename))
                {
                    // create default config file
                    this.configurationXmlDoc = new XDocument();

                    // set default root element (name of the root element is not important)
                    this.configurationXmlDoc.Add(new XElement("config"));
                    this.configurationXmlDoc.Save(this.xmlFilename);
                }

                if (File.Exists(fileName))
                {
                    if (Logger.IsDebugEnabled)
                    {
                        string logMessage = string.Format(CultureInfo.CurrentCulture, @"Loading configuration from '{0}'.", fileName);
                        Logger.Debug(logMessage);
                    }

                    this.configurationXmlDoc = XDocument.Load(fileName);

                    this.isDirty = false;
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsDebugEnabled)
                {
                    string logMessage = string.Format(CultureInfo.CurrentCulture, @"Failed to load configuration from '{0}'  -> {1}.", fileName, ex.Message);
                    Logger.Debug(logMessage);
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = @"OK here.")]
        public void Save()
        {
            if (this.isDirty)
            {
                var mutex = new Mutex(false, @"Local\EH.ImsOpcBridge.Configurator.Model.ConfigStorage.Save");

                try
                {
                    mutex.WaitOne();

                    this.configurationXmlDoc.Save(this.xmlFilename);
                    this.isDirty = false;

                    if (Logger.IsDebugEnabled)
                    {
                        var logMessage = string.Format(CultureInfo.CurrentCulture, Resources.SavingConfigurationTo_, this.xmlFilename);
                        Logger.Debug(logMessage);
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }

        /// <summary>
        /// Sets the value defined by path. The value is added if not contained in the storage.
        /// </summary>
        /// <param name="path">The path. [name]/[name]/[name]</param>
        /// <param name="value">The value.</param>
        public void SetValue(string path, string value)
        {
            if (this.configurationXmlDoc == null)
            {
                return;
            }

            lock (this.configurationXmlLock)
            {
                List<XElement> elms = ((IEnumerable)this.configurationXmlDoc.Root.XPathEvaluate(path)).Cast<XElement>().ToList();
                if (elms.Count == 1)
                {
                    var currentValue = elms[0].Value;
                    if (currentValue != value)
                    {
                        elms[0].Value = value;
                        this.isDirty = true;

                        if (Logger.IsDebugEnabled)
                        {
                            string logMessage = string.Format(CultureInfo.CurrentCulture, @"Value '{0}' changed from '{1}' to '{2}'.", path, currentValue, value);
                            Logger.Debug(logMessage);
                        }
                    }
                }
                else if (elms.Count == 0)
                {
                    this.AddElementIfNotExists(path, value);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The add element if not exists.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="value">The value.</param>
        private void AddElementIfNotExists(string path, string value)
        {
            if (this.configurationXmlDoc == null)
            {
                return;
            }

            string[] nodeNames = path.Split('/');
            XElement currentElm = this.configurationXmlDoc.Root;
            bool childAdded = false;
            foreach (string nodeName in nodeNames)
            {
                XElement child = currentElm.Element(nodeName);
                if (child == null)
                {
                    child = new XElement(nodeName);
                    currentElm.Add(child);
                    childAdded = true;
                }

                currentElm = child;
            }

            if (childAdded)
            {
                currentElm.Value = value;
                this.isDirty = true;

                if (Logger.IsDebugEnabled)
                {
                    string logMessage = string.Format(CultureInfo.CurrentCulture, @"Value added: Name: '{0}'   value: '{1}'.", path, value);
                    Logger.Debug(logMessage);
                }
            }
        }

        #endregion
    }
}
