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
    
    public class ExpressionStatement : Statement {
        private readonly Expression _expression;

        public ExpressionStatement(Expression expression) {
            _expression = expression;
        }

        public Expression Expression {
            get { return _expression; }
        }

        public override void Walk(PythonWalker walker) {
            if (walker.Walk(this)) {
                if (_expression != null) {
                    _expression.Walk(walker);
                }
            }
            walker.PostWalk(this);
        }

        public override string Documentation {
            get {
                ConstantExpression ce = _expression as ConstantExpression;
                if (ce != null) {
                    if (ce.Value is string) {
                        return ce.Value as string;
                    } else if (ce.Value is AsciiString) {
                        return ((AsciiString)ce.Value).String;
                    }
                }
                return null;
            }
        }

        internal override void AppendCodeStringStmt(StringBuilder res, PythonAst ast, CodeFormattingOptions format) {
            _expression.AppendCodeString(res, ast, format);
        }

        public override string GetLeadingWhiteSpace(PythonAst ast) {
            return _expression.GetLeadingWhiteSpace(ast);
        }

        public override void SetLeadingWhiteSpace(PythonAst ast, string whiteSpace) {
            _expression.SetLeadingWhiteSpace(ast, whiteSpace);
        }
    }
}
