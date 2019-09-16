﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Build.Framework;

namespace Microsoft.PythonTools.BuildTasks {
    /// <summary>
    /// Base class used for constructing tasks with static properties.
    /// </summary>
    /// <typeparam name="T">Type of the task that will be created.</typeparam>
    public abstract class TaskFactory<T> : ITaskFactory {
        public readonly Dictionary<string, string> Properties = new Dictionary<string, string>();

        private TaskPropertyInfo[] _parameters;

        public virtual void CleanupTask(ITask task) {
        }

        public abstract ITask CreateTask(IBuildEngine taskFactoryLoggingHost);

        public string FactoryName {
            get { return GetType().Name; }
        }

        private static TaskPropertyInfo CreatePropertyFromReflection(PropertyInfo info) {
            return new TaskPropertyInfo(
                info.Name,
                info.PropertyType,
                info.GetCustomAttributes().OfType<OutputAttribute>().Any(),
                info.GetCustomAttributes().OfType<RequiredAttribute>().Any()
            );
        }

        public TaskPropertyInfo[] GetTaskParameters() {
            return _parameters = _parameters ?? typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(CreatePropertyFromReflection)
                .ToArray();
        }

        public bool Initialize(
            string taskName,
            IDictionary<string, TaskPropertyInfo> parameterGroup,
            string taskBody,
            IBuildEngine taskFactoryLoggingHost
        ) {
            var doc = XElement.Parse(taskBody);

            foreach (var e in doc.Elements()) {
                Properties[e.Name.LocalName] = e.Value;
            }
            return true;
        }

        public Type TaskType {
            get { return typeof(T); }
        }
    }
}
