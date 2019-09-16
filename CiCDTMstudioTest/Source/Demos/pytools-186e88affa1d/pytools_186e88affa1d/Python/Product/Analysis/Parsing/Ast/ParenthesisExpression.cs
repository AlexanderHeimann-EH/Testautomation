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

    public class ParenthesisExpression : Expression {
        private readonly Expression _expression;

        public ParenthesisExpression(Expression expression) {
            _expression = expression;
        }

        public Expression Expression {
            get { return _expression; }
        }

        internal override string CheckAssign() {
            return _expression.CheckAssign();
        }

        internal override string CheckDelete() {
            return _expression.CheckDelete();
        }

        public override void Walk(PythonWalker walker) {
            if (walker.Walk(this)) {
                if (_expression != null) {
                    _expression.Walk(walker);
                }
            }
            walker.PostWalk(this);
        }

        internal override void AppendCodeString(StringBuilder res, PythonAst ast, CodeFormattingOptions format) {
            format.ReflowComment(res, this.GetProceedingWhiteSpace(ast));
            res.Append('(');
            
            _expression.AppendCodeString(
                res, 
                ast, 
                format,
                format.SpacesWithinParenthesisExpression != null ? format.SpacesWithinParenthesisExpression.Value ? " " : "" : null
            );
            if (!this.IsMissingCloseGrouping(ast)) {
                format.Append(
                    res,
                    format.SpacesWithinParenthesisExpression,
                    " ",
                    "",
                    this.GetSecondWhiteSpace(ast)
                );

                res.Append(')');
            }
        }
    }
}
