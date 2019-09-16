﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.PythonTools.DkmDebugger.Proxies.Structs;
using Microsoft.VisualStudio.Debugger;

namespace Microsoft.PythonTools.DkmDebugger.Proxies {

    /// <summary>
    ///  Represents a proxy for a typed memory location in a process being debugged. 
    /// </summary>
    internal interface IDataProxy : IValueStore {
        DkmProcess Process { get; }
        ulong Address { get; }
        long ObjectSize { get; }
    }

    internal interface IWritableDataProxy : IDataProxy {
        void Write(object value);
    }

    /// <summary>
    ///  Represents a proxy for a typed memory location in a process being debugged. 
    /// </summary>
    internal interface IDataProxy<T> : IDataProxy, IValueStore<T> {
    }

    internal interface IWritableDataProxy<T> : IDataProxy<T>, IWritableDataProxy {
        /// <summary>
        /// Replace the value in the memory location with the one provided.
        /// </summary>
        void Write(T value);
    }

    /// <summary>
    /// Provides various helper extension and static methods for <see cref="IDataProxy"/>.
    /// </summary>
    internal static class DataProxy {
        private static class FactoryBuilder<TProxy> where TProxy : IDataProxy {
            public delegate TProxy FactoryFunc(DkmProcess process, ulong address, bool polymorphic);

            public static readonly FactoryFunc Factory;

            static FactoryBuilder() {
                FactoryFunc nonPolymorphicFactory;
                var ctor = typeof(TProxy).GetConstructor(new[] { typeof(DkmProcess), typeof(ulong) });
                if (ctor != null) {
                var processParam = Expression.Parameter(typeof(DkmProcess));
                    var addressParam = Expression.Parameter(typeof(ulong));
                    var polymorphicParam = Expression.Parameter(typeof(bool));
                    nonPolymorphicFactory = Expression.Lambda<FactoryFunc>(
                        Expression.New(ctor, processParam, addressParam),
                        new[] { processParam, addressParam, polymorphicParam })
                        .Compile();
                } else {
                    nonPolymorphicFactory = (process, address, polymorphic) => {
                        Debug.Fail("IDebuggeeReference-derived type " + typeof(TProxy).Name + " does not have a (DkmProcess, ulong) constructor.");
                        throw new NotSupportedException();
                    };
                }

                if (typeof(IPyObject).IsAssignableFrom(typeof(TProxy))) {
                    Factory = (process, address, polymorphic) => {
                        if (polymorphic) {
                            return (TProxy)(object)PyObject.FromAddress(process, address);
                        } else {
                            return nonPolymorphicFactory(process, address, polymorphic);
                        }
                    };
                } else {
                    Factory = nonPolymorphicFactory;
                }
            }
        }

        /// <summary>
        /// Create a new proxy of a given type. This method exists to facilitate generic programming, as a workaround for the lack
        /// of parametrized constructor constraint in CLR generics.
        /// </summary>
        public static TProxy Create<TProxy>(DkmProcess process, ulong address, bool polymorphic = true)
            where TProxy : IDataProxy {
            return FactoryBuilder<TProxy>.Factory(process, address, polymorphic);
        }

        /// <summary>
        /// Returns a proxy for an object that is shifted by <paramref name="elementOffset"/> elements (not bytes!) relative to the object represeted
        /// by the current proxy.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of operator+ on pointers in C. Negative values are permitted.
        /// </remarks>
        /// <param name="elementOffset">Number of elements to shift by.</param>
        /// <returns></returns>
        public static TProxy GetAdjacentProxy<TProxy>(this TProxy r, long elementOffset)
            where TProxy : IDataProxy {
            return Create<TProxy>(r.Process, r.Address.OffsetBy(elementOffset * r.ObjectSize));
        }
    }
}
