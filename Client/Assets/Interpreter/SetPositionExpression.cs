using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Interpreter
{
    class SetPositionExpression : AbstractExpression
    {
        private NumberExpression param1;
        private NumberExpression param2;

        public SetPositionExpression(NumberExpression param1, NumberExpression param2)
        {
            this.param1 = param1;
            this.param2 = param2;
        }
        public override int Execute(Stack<string> context)
        {
            LocalPlayer player = GameState.Instance.gameLevel.Find<LocalPlayer>().FirstOrDefault();
            player?.SetPosition(param1.Execute(context), param2.Execute(context));
            return 0;
        }
    }
}
