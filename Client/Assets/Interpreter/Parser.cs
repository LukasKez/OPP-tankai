using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interpreter
{
    static class Parser
    {
        private const char CommandChar = '/';

        public static bool ParseAndExecute(string command)
        {
            if (command[0] != CommandChar)
                return false;

            AbstractExpression expression = null;
            command = command.TrimStart(CommandChar);
            var context = new Stack<string>(command.Split(' ').Reverse());

            while (context.Count != 0)
            {
                var currParam = context.Pop();
                List<NumberExpression> numberParams;

                switch (currParam)
                {
                    case "place-obstacle":
                        numberParams = GetNumberParameters(context, 3);
                        expression = new PlaceObstacleExpression(numberParams[0], numberParams[1], numberParams[2]);
                        break;
                    case "set-position":
                        numberParams = GetNumberParameters(context, 2);
                        expression = new SetPositionExpression(numberParams[0], numberParams[1]);
                        break;
                }
            }

            expression?.Execute(context);
            return true;
        }

        private static List<NumberExpression> GetNumberParameters(Stack<string> context, int n)
        {
            List<NumberExpression> numberParams = new List<NumberExpression>();
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(context.Pop(), out int result))
                    return null;
                numberParams.Add(new NumberExpression(result));
            }
            return numberParams;
        }
    }
}
