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

#if !DEV12_OR_LATER

using Microsoft.VisualStudio.Text;

namespace Microsoft.PythonTools.Django.TemplateParsing {
    /// <summary>
    /// This is a custom span which is like an EdgeInclusive span.  We need a custom span because elision buffers
    /// do not allow EdgeInclusive unless it spans the entire buffer.  We create snippets of our language spans
    /// and these are initially zero length.  When we insert at the beginning of these we'll end up keeping the
    /// span zero length if we're just EdgePostivie tracking.
    /// </summary>
    class CustomTrackingSpan : ITrackingSpan {
        private readonly ITrackingPoint _start, _end;
        private readonly ITextBuffer _buffer;

        public CustomTrackingSpan(ITextSnapshot snapshot, Span span, PointTrackingMode startTrackingMode, PointTrackingMode endTrackingMode) {
            _buffer = snapshot.TextBuffer;
            _start = snapshot.CreateTrackingPoint(span.Start, startTrackingMode);
            _end = snapshot.CreateTrackingPoint(span.End, endTrackingMode);
        }

        #region ITrackingSpan Members

        public SnapshotPoint GetEndPoint(ITextSnapshot snapshot) {
            return _end.GetPoint(snapshot);
        }

        public Span GetSpan(ITextVersion version) {
            var start = _start.GetPosition(version);
            var end = _end.GetPosition(version);

            if (start > end) {
                // start has positive tracking, end has negative, everything has been deleted
                // and our spans have become inverted.
                return new Span(
                    start,
                    0
                );
            }
            return Span.FromBounds(
                _start.GetPosition(version),
                _end.GetPosition(version)
            );
        }

        public SnapshotSpan GetSpan(ITextSnapshot snapshot) {
            return new SnapshotSpan(
                snapshot,
                GetSpan(snapshot.Version)
            );
        }

        public SnapshotPoint GetStartPoint(ITextSnapshot snapshot) {
            return _start.GetPoint(snapshot);
        }

        public string GetText(ITextSnapshot snapshot) {
            return GetSpan(snapshot).GetText();
        }

        public ITextBuffer TextBuffer {
            get { return _buffer; }
        }

        public TrackingFidelityMode TrackingFidelity {
            get { return TrackingFidelityMode.Forward; }
        }

        public SpanTrackingMode TrackingMode {
            get { return SpanTrackingMode.Custom; }
        }

        #endregion
    }
}

#endif