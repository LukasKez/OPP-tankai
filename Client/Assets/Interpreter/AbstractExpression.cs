using System;
using System.Collections.Generic;

namespace Client
{
    public abstract class AbstractExpression
    {
        public abstract int Execute(Stack<string> context);
    }
}
