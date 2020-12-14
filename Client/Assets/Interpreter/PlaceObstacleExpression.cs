using System;
using System.Collections.Generic;

namespace Client.Interpreter
{
    public class PlaceObstacleExpression : AbstractExpression
    {
        private NumberExpression param1;
        private NumberExpression param2;
        private NumberExpression param3;

        public PlaceObstacleExpression(NumberExpression param1, NumberExpression param2, NumberExpression param3)
        {
            this.param1 = param1;
            this.param2 = param2;
            this.param3 = param3;
        }

        public override int Execute(Stack<string> context)
        {
            int size = 20;
            int posX = param2.Execute(context);
            int posY = param3.Execute(context);

            GameObject obj = null;

            switch (param1.Execute(context))
            {
                case 1:
                    obj = new OutlineObstacle(new Tree(new Obstacle(posX, posY, size, size)));
                    break;
                case 2:
                    obj = new OutlineObstacle(new Wall(new Obstacle(posX, posY, size, size)));
                    break;
                case 3:
                    obj = new OutlineObstacle(new Boulder(new Obstacle(posX, posY, size, size)));
                    break;
                case 4:
                    obj = new OutlineObstacle(new Water(new Obstacle(posX, posY, size, size)));
                    break;
            }

            if (obj != null)
            {
                obj.Decorate();
                GameObject.Instantiate(obj);

            }

            return 0;
        }
    }
}
