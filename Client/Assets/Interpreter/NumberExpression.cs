using System;
using System.Collections.Generic;

namespace Client.Interpreter
{
    public class NumberExpression : AbstractExpression
    {
        private int value;

        public NumberExpression(int value)
        {
            this.value = value;
        }

        public override int Execute(Stack<string> context)
        {
            return value;
        }
    }
}
