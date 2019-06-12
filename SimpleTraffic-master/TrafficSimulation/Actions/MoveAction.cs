using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation.Actions
{   //heatmap line 111
    public enum Direction
    {
        Up, Down, Right, Left 
    }

    class MoveAction : TileAction
    {
        public Direction direction;
        private int ControlPoint = 100;
        public MoveAction(Direction direction)
        {
            this.direction = direction;
        }

        public override List<Tile> Handle(Tile car, List<Tile> tiles)
        {
            List<Tile> updatedTiles;

            switch (this.direction)
            {
                case Direction.Up:
                    updatedTiles = this.MoveUp(car, tiles);
                    break;
                case Direction.Right:
                    updatedTiles = this.MoveRight(car, tiles);
                    break;
                case Direction.Left:
                    updatedTiles = this.MoveLeft(car, tiles);
                    break;
                case Direction.Down:
                    updatedTiles = this.MoveDown(car, tiles);
                    break;
                default:
                    updatedTiles = tiles;
                    break;
            }

            return updatedTiles;
        }

        private List<Tile> MoveUp(Tile car, List<Tile> tiles)
        {
            int newCarIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y - 1 &&
                tile.Position.X == car.Position.X
            );

            Tile t = tiles.Find(tile =>
                tile.Position.Y == car.Position.Y - 1 &&
                tile.Position.X == car.Position.X
            );

            if (t.Type == TileType.ControlPoint)
            {
                ControlPoint = 0;
            }
            

            return this.Move(newCarIndex, car, tiles);
        }

        private List<Tile> MoveRight(Tile car, List<Tile> tiles)
        {
            int newCarIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y &&
                tile.Position.X == car.Position.X + 1
            );

            Tile t = tiles.Find(tile =>
                tile.Position.Y == car.Position.Y &&
                tile.Position.X == car.Position.X + 1
            );

            if (t.Type == TileType.ControlPoint)
            {
                ControlPoint = 0;
            }

            return this.Move(newCarIndex, car, tiles);
        }

        private List<Tile> MoveLeft(Tile car, List<Tile> tiles)
        {
            int newCarIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y &&
                tile.Position.X == car.Position.X - 1
            );

            Tile t = tiles.Find(tile =>
                tile.Position.Y == car.Position.Y &&
                tile.Position.X == car.Position.X - 1
            );

            if (t.Type == TileType.ControlPoint)
            {
                ControlPoint = 0;
            }

            return this.Move(newCarIndex, car, tiles);
        }

        private List<Tile> MoveDown(Tile car, List<Tile> tiles)
        {
            int newCarIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y + 1 &&
                tile.Position.X == car.Position.X
            );

            Tile t = tiles.Find(tile =>
                tile.Position.Y == car.Position.Y + 1 &&
                tile.Position.X == car.Position.X
            );

            if (t.Type == TileType.ControlPoint)
            {
                ControlPoint = 0;
            }

            return this.Move(newCarIndex, car, tiles);
        }


        private List<Tile> Move(int newCarIndex, Tile car, List<Tile> tiles)
        {
            List<Tile> updatedTiles = tiles;

            int newRoadIndex = tiles.FindIndex(tile =>
                tile.Position.Y == car.Position.Y &&
                tile.Position.X == car.Position.X
            );

            if (tiles[newCarIndex].Type == TileType.Road || tiles[newCarIndex].Type == TileType.ControlPoint)
            {
                if (newCarIndex != -1)
                {
                    updatedTiles[newCarIndex].Type = TileType.Car;
                    updatedTiles[newCarIndex].Actions = car.Actions;
                    updatedTiles[newCarIndex].Dirty = true;
                }

                updatedTiles[newRoadIndex].Actions = new List<TileAction>();

                if (ControlPoint == 0)
                {
                    updatedTiles[newRoadIndex].Type = TileType.Road;
                    ControlPoint++;
                }
                else if (ControlPoint == 1)
                {
                    updatedTiles[newRoadIndex].Type = TileType.ControlPoint;
                    ControlPoint++;
                }
                else
                {
                    updatedTiles[newRoadIndex].Type = TileType.Road;
                    ControlPoint = 100;
                }


                updatedTiles[newRoadIndex].Dirty = true;
                updatedTiles[newRoadIndex].counter++;
                return updatedTiles;
            }
            else
            {
                return tiles;
            }           
        }
    }
}
