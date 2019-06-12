using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation.Actions
{
    class RemoveCar : TileAction
    {
        public override List<Tile> Handle(Tile tile, List<Tile> tiles)
        {
            int removeIndex = tiles.IndexOf(tile);
            List<TileAction> actions = new List<TileAction>();
            tiles[removeIndex] = new Tile(tile.Position.X, tile.Position.Y, TileType.Road, actions);
            return tiles;
        }

        public List<Tile> Remove(Tile tile, List<Tile> tiles)
        {
            int removeIndex = tiles.IndexOf(tile);
            List<TileAction> actions;
            actions = null;
            tiles[removeIndex] = new Tile(tile.Position.X, tile.Position.Y, TileType.Road, actions);
            return tiles;
        }
    }
}
