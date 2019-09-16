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
using System.Numerics;
using Microsoft.VisualStudio.Debugger;

namespace Microsoft.PythonTools.DkmDebugger.Proxies.Structs {
    internal class PyLongObject : PyVarObject {
        private class Fields {
            public StructField<ByteProxy> ob_digit; // this is actually either uint16 or uint32, depending on Python bitness
        }

        private readonly Fields _fields;

        public PyLongObject(DkmProcess process, ulong address)
            : this(process, address, true) {
        }

        protected PyLongObject(DkmProcess process, ulong address, bool checkType)
            : base(process, address) {
            InitializeStruct(this, out _fields);
            if (checkType) {
                CheckPyType<PyLongObject>();
            }
        }

        public static PyLongObject Create(DkmProcess process, BigInteger value) {
            var allocator = process.GetDataItem<PyObjectAllocator>();
            Debug.Assert(allocator != null);

            var bitsInDigit = process.Is64Bit() ? 30 : 15;
            var bytesInDigit = process.Is64Bit() ? 4 : 2;

            var absValue = BigInteger.Abs(value);
            long numDigits = 0;
            for (var t = absValue; t != 0; ) {
                ++numDigits;
                t >>= bitsInDigit;
            }

            var result = allocator.Allocate<PyLongObject>(numDigits * bytesInDigit);

            if (value == 0) {
                result.ob_size.Write(0);
            } else if (value > 0) {
                result.ob_size.Write(numDigits);
            } else if (value < 0) {
                result.ob_size.Write(-numDigits);
            }

            if (bitsInDigit == 15) {
                for (var digitPtr = new UInt16Proxy(process, result.ob_digit.Address); absValue != 0; digitPtr = digitPtr.GetAdjacentProxy(1)) {
                    digitPtr.Write((ushort)(absValue % (1 << bitsInDigit)));
                    absValue >>= bitsInDigit;
                }
            } else {
                for (var digitPtr = new UInt32Proxy(process, result.ob_digit.Address); absValue != 0; digitPtr = digitPtr.GetAdjacentProxy(1)) {
                    digitPtr.Write((uint)(absValue % (1 << bitsInDigit)));
                    absValue >>= bitsInDigit;
                }
            }

            return result;
        }

        private ByteProxy ob_digit {
            get { return GetFieldProxy(_fields.ob_digit); }
        }

        public BigInteger ToBigInteger() {
            var bitsInDigit = Process.Is64Bit() ? 30 : 15;

            long ob_size = this.ob_size.Read();
            if (ob_size == 0) {
                return 0;
            } 
            long count = Math.Abs(ob_size);

            // Read and parse digits in reverse, starting from the most significant ones.
            var result = new BigInteger(0);
            if (bitsInDigit == 15) {
                var digitPtr = new UInt16Proxy(Process, ob_digit.Address).GetAdjacentProxy(count);
                for (long i = 0; i != count; ++i) {
                    digitPtr = digitPtr.GetAdjacentProxy(-1);
                    result <<= bitsInDigit;
                    result += digitPtr.Read();
                }
            } else {
                var digitPtr = new UInt32Proxy(Process, ob_digit.Address).GetAdjacentProxy(count);
                for (long i = 0; i != count; ++i) {
                    digitPtr = digitPtr.GetAdjacentProxy(-1);
                    result <<= bitsInDigit;
                    result += digitPtr.Read();
                }
            }

            return ob_size > 0 ? result : -result;
        }

        public override void Repr(ReprBuilder builder) {
            builder.AppendLiteral(ToBigInteger());
        }
    }
}
