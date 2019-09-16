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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Microsoft.VisualStudio.Debugger;
using Microsoft.VisualStudio.Debugger.ComponentInterfaces;

namespace Microsoft.PythonTools.DkmDebugger {
    public abstract class ComponentBase : IDkmCustomMessageForwardReceiver, IDkmCustomMessageCallbackReceiver {
        private static readonly List<DataContractJsonSerializer> _messageSerializers = new List<DataContractJsonSerializer>();
        private readonly Guid _sourceId; // This is a misnomer, since we actually use DkmCustomMessage.SourceId to identify the target component, not the source one.

        internal interface IMessage {
            int MessageCode { get; }
            DkmCustomMessage Handle(DkmProcess process);
        }

        [DataContract]
        internal abstract class MessageBase<TInput> : IMessage
            where TInput : MessageBase<TInput> {

            private static readonly Guid _sourceId;
            private static readonly int _messageCode;
            private static readonly DataContractJsonSerializer _serializer;

            static MessageBase() {
                var msgAttr = (MessageToAttribute)typeof(TInput).GetCustomAttributes(typeof(MessageToAttribute), false).SingleOrDefault();
                if (msgAttr == null) {
                    Debug.Fail("Message type " + typeof(TInput).FullName + " has no [RequestTo] attribute");
                    throw new InvalidDataContractException();
                }
                _sourceId = msgAttr.ComponentId;

                lock (_messageSerializers) {
                    _messageCode = _messageSerializers.Count;
                    _serializer = new DataContractJsonSerializer(typeof(TInput));
                    _messageSerializers.Add(_serializer);
                }
            }

            public int MessageCode {
                get { return _messageCode; }
            }

            public void SendLower(DkmProcess process) {
                var stream = new MemoryStream();
                _serializer.WriteObject(stream, this);
                var message = DkmCustomMessage.Create(process.Connection, process, _sourceId, MessageCode, stream.ToArray(), null);
                message.SendLower();
            }

            public void SendHigher(DkmProcess process) {
                var stream = new MemoryStream();
                _serializer.WriteObject(stream, this);
                var message = DkmCustomMessage.Create(process.Connection, process, _sourceId, MessageCode, stream.ToArray(), null);
                message.SendHigher();
            }

            public abstract void Handle(DkmProcess process);

            DkmCustomMessage IMessage.Handle(DkmProcess process) {
                Handle(process);
                return null;
            }
        }

        [DataContract]
        internal abstract class MessageBase<TInput, TOutput> : IMessage
            where TInput : MessageBase<TInput, TOutput> {

            private static readonly Guid _sourceId;
            private static readonly int _messageCode;
            private static readonly DataContractJsonSerializer _inputSerializer, _outputSerializer;

            static MessageBase() {
                var msgAttr = (MessageToAttribute)typeof(TInput).GetCustomAttributes(typeof(MessageToAttribute), false).SingleOrDefault();
                if (msgAttr == null) {
                    Debug.Fail("Message type " + typeof(TInput).FullName + " has no [RequestTo] attribute");
                    throw new InvalidDataContractException();
                }
                _sourceId = msgAttr.ComponentId;

                lock (_messageSerializers) {
                    _messageCode = _messageSerializers.Count;
                    _messageSerializers.Add(_inputSerializer = new DataContractJsonSerializer(typeof(TInput)));
                    _messageSerializers.Add(_outputSerializer = new DataContractJsonSerializer(typeof(TOutput)));
                }
            }

            public int MessageCode {
                get { return _messageCode; }
            }

            public TOutput SendLower(DkmProcess process) {
                var stream = new MemoryStream();
                _inputSerializer.WriteObject(stream, this);
                var message = DkmCustomMessage.Create(process.Connection, process, _sourceId, MessageCode, stream.ToArray(), null);
                var response = message.SendLower();
                stream = new MemoryStream((byte[])response.Parameter1);
                return (TOutput)_outputSerializer.ReadObject(stream);
            }

            public TOutput SendHigher(DkmProcess process) {
                var stream = new MemoryStream();
                _inputSerializer.WriteObject(stream, this);
                var message = DkmCustomMessage.Create(process.Connection, process, _sourceId, MessageCode, stream.ToArray(), null);
                var response = message.SendHigher();
                stream = new MemoryStream((byte[])response.Parameter1);
                return (TOutput)_outputSerializer.ReadObject(stream);
            }

            public abstract TOutput Handle(DkmProcess process);

            DkmCustomMessage IMessage.Handle(DkmProcess process) {
                var response = Handle(process);
                var stream = new MemoryStream();
                _outputSerializer.WriteObject(stream, response);
                return DkmCustomMessage.Create(process.Connection, process, Guid.Empty, -1, stream.ToArray(), null);
            }
        }

        static ComponentBase() {
            // Register all known message types. 
            foreach (var type in typeof(ComponentBase).Assembly.GetTypes()) {
                var baseType = type.BaseType;
                if (baseType != null && baseType.IsGenericType) {
                    var genTypeDef = baseType.GetGenericTypeDefinition();
                    if (genTypeDef == typeof(MessageBase<>) || genTypeDef == typeof(MessageBase<,>)) {
                        RuntimeHelpers.RunClassConstructor(baseType.TypeHandle);
                    }
                }
            }
        }

        public ComponentBase(Guid sourceId) {
            _sourceId = sourceId;
        }

        DkmCustomMessage IDkmCustomMessageForwardReceiver.SendLower(DkmCustomMessage customMessage) {
            return (customMessage.SourceId == _sourceId) ? Handle(customMessage) : null;
        }

        DkmCustomMessage IDkmCustomMessageCallbackReceiver.SendHigher(DkmCustomMessage customMessage) {
            return (customMessage.SourceId == _sourceId) ? Handle(customMessage) : null;
        }

        private DkmCustomMessage Handle(DkmCustomMessage customMessage) {
            var requestSerializer = _messageSerializers[customMessage.MessageCode];
            var requestData = (byte[])customMessage.Parameter1;
            var request = (IMessage)requestSerializer.ReadObject(new MemoryStream(requestData, false));
            return request.Handle(customMessage.Process);
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class MessageToAttribute : Attribute {
        public Guid ComponentId { get; private set; }

        public MessageToAttribute(string id) {
            ComponentId = new Guid(id);
        }
    }
}
