using Client.Assets.Levels.Obstacles;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Windows.Media.TextFormatting;
using System.Diagnostics;
using System.Drawing;

namespace Client.Assets.Levels.GameLevels
{
    abstract class GameLevel
    {
        public float levelWidth { get; private set; }
        public float levelHeight { get; private set; }

        public float blockWidth { get; private set; }
        public float blockHeight { get; private set; }


        protected Obstacle[,] horizontalBorders;
        protected Obstacle[,] verticalBorders;
        protected int checks;

        public GameLevel(float levelWidth, float levelHeight, float blockWidth, float blockHeight)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;

            this.blockWidth = blockWidth;
            this.blockHeight = blockHeight;


            int horizontalCount =(int)Math.Floor((levelWidth / blockWidth));
            int verticalCount = (int)Math.Floor((levelHeight / blockHeight));

            horizontalBorders = new Obstacle[horizontalCount, 2];
            verticalBorders = new Obstacle[verticalCount, 2];
        }
        public void SetupBorder(string levelType)
        {
            int i = 0;
            int j = 0;
            

            while (i < horizontalBorders.Length/2 || j < verticalBorders.Length / 2)
            {
                if (i < horizontalBorders.Length / 2)
                {
                    if (string.Compare(levelType.ToLower(), "cave") != 0)
                    {
                        horizontalBorders[i, 0] = new Water(i * blockWidth, 0, blockWidth, blockHeight);
                        horizontalBorders[i, 1] = new Water(i * blockWidth, levelHeight - blockHeight, blockWidth, blockHeight);
                    }
                    else
                    {
                        horizontalBorders[i, 0] = new Boulder(i * blockWidth, 0, blockWidth, blockHeight);
                        horizontalBorders[i, 1] = new Boulder(i * blockWidth, levelHeight - blockHeight, blockWidth, blockHeight);
                    }
                    i++;
                }
                if(j < verticalBorders.Length / 2)
                {
                    if (string.Compare(levelType.ToLower(), "cave") != 0)
                    {
                        verticalBorders[j, 0] = new Water(0, j * blockHeight, blockWidth, blockHeight);
                        verticalBorders[j, 1] = new Water(levelWidth - blockWidth, j * blockHeight, blockWidth, blockHeight);
                    }
                    else
                    {
                        verticalBorders[j, 0] = new Boulder(0, j * blockHeight, blockWidth, blockHeight);
                        verticalBorders[j, 1] = new Boulder(levelWidth - blockWidth, j * blockHeight, blockWidth, blockHeight);
                    }
                    j++;
                }
            }

        }

        public Dictionary<string,float[]> GetCollisionCoordinates(float x, float y, float width, float height, float r)
        {
            Dictionary<string, float[]> coordinates = new Dictionary<string, float[]>();

            float[] topRight = GetTopRight(x, y, width, height,r);
            float[] topLeft = GetTopLeft(x, y, width, height, r);
            float[] bottomRight = GetBottomRight(x, y, width, height, r);
            float[] bottomLeft = GetBottomLeft(x, y, width, height, r);

            checks = 0;


            //Check borders

            coordinates = CheckBorders(horizontalBorders, coordinates, x, levelWidth, topRight, topLeft, bottomRight, bottomLeft);

            if (checks>=4)
            {
                return coordinates;
            }
            coordinates = CheckBorders(verticalBorders, coordinates, y, levelHeight, topRight, topLeft, bottomRight, bottomLeft);



            /*
            var lines = coordinates.Select(kvp => kvp.Key + ": " + kvp.Value[0].ToString() + ": " + kvp.Value[1].ToString());
            Debug.Print(string.Join(Environment.NewLine, lines));*/
            
            return coordinates;
        }

        private Dictionary<string,float[]> CheckBorders(Obstacle[,] borders , Dictionary<string, float[]> coordinates,float axis, float levelSize,
            float[] topRight, float[] topLeft, float[] bottomRight, float[] bottomLeft)
        {
            int start, end;
            if (axis <= (levelSize / 2))
            {
                start = 0;
                end = (borders.Length / 4 + 1);
            }
            else
            {
                start = (borders.Length / 4 - 1);
                end = borders.Length/2;
            }

            var varam = borders;
            for (int i = start; i < end; i++)
            {
                //Top right
                if(coordinates.ContainsKey("topRight")!=true)
                {
                    if (CheckObstacle(borders[i, 0], topRight) == true)
                    {
                        coordinates.Add("topRight", topRight);
                        checks++;
                    }
                    else if (CheckObstacle(borders[i, 1], topRight) == true)
                    {
                        coordinates.Add("topRight", topRight);
                        checks++;
                    }
                }
                //Top left
                if (coordinates.ContainsKey("topLeft") != true)
                {
                    if (CheckObstacle(borders[i, 0], topLeft) == true)
                    {
                        coordinates.Add("topLeft", topLeft);
                        checks++;
                    }
                    else if (CheckObstacle(borders[i, 1], topLeft) == true)
                    {
                        coordinates.Add("topLeft", topLeft);
                        checks++;
                    }
                }
                //Bottom right
                if (coordinates.ContainsKey("bottomRight") != true)
                {
                    if (CheckObstacle(borders[i, 0], bottomRight) == true)
                    {
                        coordinates.Add("bottomRight", bottomRight);
                        checks++;
                    }
                    else if (CheckObstacle(borders[i, 1], bottomRight) == true)
                    {
                        coordinates.Add("bottomRight", bottomRight);
                        checks++;
                    }
                }
                //Bottom left

                if (coordinates.ContainsKey("bottomLeft") != true)
                {
                    if (CheckObstacle(borders[i, 0], bottomLeft) == true)
                    {
                        coordinates.Add("bottomLeft", bottomLeft);
                        checks++;
                    }
                    else if (CheckObstacle(borders[i, 1], bottomLeft) == true)
                    {
                        coordinates.Add("bottomLeft", bottomLeft);
                        checks++;
                    }
                }

                if (checks >= 4)
                {
                    return coordinates;
                }
            }
            return coordinates; 
        }
        private bool CheckObstacle(Obstacle obstacle,float[] coordinate)
        {
            if(coordinate[0]>obstacle.x&&coordinate[0]<(obstacle.x+obstacle.width))
            {
                if(coordinate[1]>obstacle.y&&coordinate[1]<(obstacle.y+ obstacle.height))
                {
                    return true;
                }
            }
            return false;
        }


        private float[] GetTopRight(float x,float y,float width,float height,float r)
        {
            float[] coordinates = new float[2];
            coordinates[0] = (float)(((x + width/ 2) ) + ((width / 2) * Math.Cos(r)) - ((height / 2) * Math.Sin(r)));
            coordinates[1] = (float)(((y + height/ 2) ) + ((width / 2) * Math.Sin(r)) + ((height / 2) * Math.Cos(r)));

            return coordinates;
        }
        private float[] GetTopLeft(float x, float y, float width, float height, float r)
        {
            float[] coordinates = new float[2];
            coordinates[0] = (float)(((x + width / 2)) - ((width / 2) * Math.Cos(r)) - ((height / 2) * Math.Sin(r)));
            coordinates[1] = (float)(((y + height/ 2) ) - ((width / 2) * Math.Sin(r)) + ((height / 2) * Math.Cos(r)));

            return coordinates;
        }
        private float[] GetBottomLeft(float x, float y, float width, float height, float r)
        {
            float[] coordinates = new float[2];
            coordinates[0] = (float)(((x + width/ 2) ) - ((width / 2) * Math.Cos(r)) + ((height / 2) * Math.Sin(r)));
            coordinates[1] = (float)(((y + height/ 2) ) - ((width / 2) * Math.Sin(r)) - ((height / 2) * Math.Cos(r)));

            return coordinates;
        }
        private float[] GetBottomRight(float x, float y, float width, float height, float r)
        {
            float[] coordinates = new float[2];
            coordinates[0] = (float)(((x + width/ 2) ) + ((width / 2) * Math.Cos(r)) + ((height / 2) * Math.Sin(r)));
            coordinates[1] = (float)(((y + height/ 2) ) + ((width / 2) * Math.Sin(r)) - ((height / 2) * Math.Cos(r)));

            return coordinates;
        }
        public virtual void Render(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, 0, 0, levelWidth, levelHeight);

            int i = 0;
            int j = 0;

            while (i < horizontalBorders.Length / 2 || j < verticalBorders.Length / 2)
            {
                if (i < horizontalBorders.Length / 2)
                {
                    horizontalBorders[i, 0].Render(e);
                    horizontalBorders[i, 1].Render(e);
                    i++;
                }
                if (j < verticalBorders.Length / 2)
                {
                    verticalBorders[j, 0].Render(e);
                    verticalBorders[j, 1].Render(e);
                    j++;
                }
            }
        }
    }
}
