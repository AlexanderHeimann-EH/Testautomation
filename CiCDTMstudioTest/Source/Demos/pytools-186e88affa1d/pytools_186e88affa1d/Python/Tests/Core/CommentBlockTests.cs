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

using Microsoft.PythonTools;
using Microsoft.PythonTools.Editor.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.Text;
using TestUtilities.Mocks;

namespace PythonToolsTests {
    [TestClass]
    public class CommentBlockTests {
        [TestMethod, Priority(0)]
        public void TestCommentCurrentLine() {
            var view = new MockTextView(
                MockTextBuffer(@"print 'hello'
print 'goodbye'
"));

            view.Caret.MoveTo(view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(0).Start);

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"#print 'hello'
print 'goodbye'
",
                view.TextBuffer.CurrentSnapshot.GetText());

            view.Caret.MoveTo(view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(1).Start);

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"#print 'hello'
#print 'goodbye'
",
                 view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestUnCommentCurrentLine() {
            var view = new MockTextView(
                MockTextBuffer(@"#print 'hello'
#print 'goodbye'"));

            view.Caret.MoveTo(view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(0).Start);

            view.CommentOrUncommentBlock(false);

            Assert.AreEqual(@"print 'hello'
#print 'goodbye'", 
                 view.TextBuffer.CurrentSnapshot.GetText());

            view.Caret.MoveTo(view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(1).Start);

            view.CommentOrUncommentBlock(false);

            Assert.AreEqual(@"print 'hello'
print 'goodbye'",
                view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestComment() {
            var view = new MockTextView(
                MockTextBuffer(@"print 'hello'
print 'goodbye'
"));

            view.Selection.Select(
                new SnapshotSpan(view.TextBuffer.CurrentSnapshot, new Span(0, view.TextBuffer.CurrentSnapshot.Length)),
                false
            );

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"#print 'hello'
#print 'goodbye'
",
                 view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestCommentEmptyLine() {
            var view = new MockTextView(
                MockTextBuffer(@"print 'hello'

print 'goodbye'
"));

            view.Selection.Select(
                new SnapshotSpan(view.TextBuffer.CurrentSnapshot, new Span(0, view.TextBuffer.CurrentSnapshot.Length)),
                false
            );

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"#print 'hello'

#print 'goodbye'
",
                 view.TextBuffer.CurrentSnapshot.GetText());
        }

        private static MockTextBuffer MockTextBuffer(string code) {
            return new MockTextBuffer(code, PythonCoreConstants.ContentType, "C:\\fob.py");
        }

        [TestMethod, Priority(0)]
        public void TestCommentWhiteSpaceLine() {
            var view = new MockTextView(
                MockTextBuffer(@"print 'hello'
   
print 'goodbye'
"));

            view.Selection.Select(
                new SnapshotSpan(view.TextBuffer.CurrentSnapshot, new Span(0, view.TextBuffer.CurrentSnapshot.Length)),
                false
            );

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"#print 'hello'
   
#print 'goodbye'
",
                 view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestCommentIndented() {
            var view = new MockTextView(
                MockTextBuffer(@"def f():
    print 'hello'
    print 'still here'
    print 'goodbye'"));

            view.Selection.Select(
                new SnapshotSpan(
                    view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(1).Start,
                    view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(2).End
                ),
                false
            );

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"def f():
    #print 'hello'
    #print 'still here'
    print 'goodbye'",
                    view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestCommentIndentedBlankLine() {
            var view = new MockTextView(
                MockTextBuffer(@"def f():
    print 'hello'

    print 'still here'
    print 'goodbye'"));

            view.Selection.Select(
                new SnapshotSpan(
                    view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(1).Start,
                    view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(3).End
                ),
                false
            );

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"def f():
    #print 'hello'

    #print 'still here'
    print 'goodbye'",
                    view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestCommentBlankLine() {
            var view = new MockTextView(
                MockTextBuffer(@"print('hi')

print('bye')"));

            view.Caret.MoveTo(view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(1).Start);

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"print('hi')

print('bye')",
             view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestCommentIndentedWhiteSpaceLine() {
            var view = new MockTextView(
                MockTextBuffer(@"def f():
    print 'hello'
  
    print 'still here'
    print 'goodbye'"));

            view.Selection.Select(
                new SnapshotSpan(
                    view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(1).Start,
                    view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(3).End
                ),
                false
            );

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"def f():
    #print 'hello'
  
    #print 'still here'
    print 'goodbye'",
                    view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestUnCommentIndented() {
            var view = new MockTextView(
                MockTextBuffer(@"def f():
    #print 'hello'
    #print 'still here'
    print 'goodbye'"));

            view.Selection.Select(
                new SnapshotSpan(
                    view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(1).Start,
                    view.TextBuffer.CurrentSnapshot.GetLineFromLineNumber(2).End
                ),
                false
            );

            view.CommentOrUncommentBlock(false);

            Assert.AreEqual(@"def f():
    print 'hello'
    print 'still here'
    print 'goodbye'",
                    view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestUnComment() {
            var view = new MockTextView(
                MockTextBuffer(@"#print 'hello'
#print 'goodbye'"));

            view.Selection.Select(
                new SnapshotSpan(view.TextBuffer.CurrentSnapshot, new Span(0, view.TextBuffer.CurrentSnapshot.Length)),
                false
            );

            view.CommentOrUncommentBlock(false);

            Assert.AreEqual(@"print 'hello'
print 'goodbye'",
                view.TextBuffer.CurrentSnapshot.GetText());
        }

        /// <summary>
        /// http://pytools.codeplex.com/workitem/814
        /// </summary>
        [TestMethod, Priority(0)]
        public void TestCommentStartOfLastLine() {
            var view = new MockTextView(
                MockTextBuffer(@"print 'hello'
print 'goodbye'"));

            view.Selection.Select(
                new SnapshotSpan(view.TextBuffer.CurrentSnapshot, new Span(0, view.TextBuffer.CurrentSnapshot.GetText().IndexOf("print 'goodbye'"))),
                false
            );

            view.CommentOrUncommentBlock(true);

            Assert.AreEqual(@"#print 'hello'
print 'goodbye'",
                view.TextBuffer.CurrentSnapshot.GetText());
        }

        [TestMethod, Priority(0)]
        public void TestCommentAfterCodeIsNotUncommented()
        {
            var view = new MockTextView(
                MockTextBuffer(@"print 'hello' #comment that should stay a comment
#print 'still here' # another comment that should stay a comment
print 'goodbye'"));

            view.Selection.Select(
                new SnapshotSpan(view.TextBuffer.CurrentSnapshot, new Span(0, view.TextBuffer.CurrentSnapshot.GetText().IndexOf("print 'goodbye'"))),
                false
            );

            view.CommentOrUncommentBlock(false);

            Assert.AreEqual(@"print 'hello' #comment that should stay a comment
print 'still here' # another comment that should stay a comment
print 'goodbye'",
                view.TextBuffer.CurrentSnapshot.GetText());
        }
    }
}
