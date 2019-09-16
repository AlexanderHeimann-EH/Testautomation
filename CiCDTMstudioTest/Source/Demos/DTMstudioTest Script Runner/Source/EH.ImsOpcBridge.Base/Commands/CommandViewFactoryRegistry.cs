// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandViewFactoryRegistry.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Commands
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The command view factory registry.
    /// </summary>
    public static class CommandViewFactoryRegistry
    {
        #region Fields

        /// <summary>
        /// The dictionary, which holds all registered command view factories.
        /// </summary>
        private static readonly Dictionary<Type, ICommandViewFactory> CommandViewFactories = new Dictionary<Type, ICommandViewFactory>();

        /// <summary>
        /// The default command view factory.
        /// </summary>
        private static readonly ICommandViewFactory DefaultCommandViewFactory = new CommandViewFactoryBase();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the command view factory by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The command view factory.</returns>
        public static ICommandViewFactory GetCommandViewFactoryByCommandProvider(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(@"key");
            }

            var internalType = key.GetType();

            lock (CommandViewFactories)
            {
                return CommandViewFactories.ContainsKey(internalType) ? CommandViewFactories[internalType] : DefaultCommandViewFactory;
            }
        }

        /// <summary>
        /// Registers the command view factory.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="handler">The handler.</param>
        public static void RegisterCommandViewFactory(Type key, ICommandViewFactory handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(@"handler");
            }

            lock (CommandViewFactories)
            {
                if (CommandViewFactories.ContainsKey(key))
                {
                    CommandViewFactories.Remove(key);
                }

                CommandViewFactories.Add(key, handler);
            }
        }

        #endregion
    }
}
