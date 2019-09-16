/* ****************************************************************************
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

using System.Text;

namespace Microsoft.PythonTools.Parsing.Ast {
    public class IndexExpression : Expression {
        private readonly Expression _target;
        private readonly Expression _index;

        public IndexExpression(Expression target, Expression index) {
            _target = target;
            _index = index;
        }

        public Expression Target {
            get { return _target; }
        }

        public Expression Index {
            get { return _index; }
        }

        internal override string CheckAssign() {
            return null;
        }

        internal override string CheckDelete() {
            return null;
        }

        public override void Walk(PythonWalker walker) {
            if (walker.Walk(this)) {
                if (_target != null) {
                    _target.Walk(walker);
                }
                if (_index != null) {
                    _index.Walk(walker);
                }
            }
            walker.PostWalk(this);
        }

        private bool IsSlice {
            get {
                return _index is SliceExpression;
            }
        }

        internal override void AppendCodeString(StringBuilder res, PythonAst ast, CodeFormattingOptions format) {
            Target.AppendCodeString(res, ast, format);
            format.Append(
                res,
                format.SpaceBeforeIndexBracket,
                " ",
                "",
                this.GetProceedingWhiteSpace(ast)
            );

            res.Append('[');
            _index.AppendCodeString(
                res, 
                ast, 
                format, 
                format.SpaceWithinIndexBrackets != null ? format.SpaceWithinIndexBrackets.Value ? " " : "" : null
            );

            if (!this.IsMissingCloseGrouping(ast)) {
                format.Append(
                    res,
                    format.SpaceWithinIndexBrackets,
                    " ",
                    "",
                    this.GetSecondWhiteSpace(ast)
                );
                res.Append(']');
            }
        }

        public override string GetLeadingWhiteSpace(PythonAst ast) {
            return Target.GetLeadingWhiteSpace(ast);
        }

        public override void SetLeadingWhiteSpace(PythonAst ast, string whiteSpace) {
            Target.SetLeadingWhiteSpace(ast, whiteSpace);
        }
    }
}
