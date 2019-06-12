using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation.Actions
{
    class NoAction : TileAction
    {
        public override List<Tile> Handle(Tile tile, List<Tile> tiles)
        {
            tiles[tiles.IndexOf(tile)].Dirty = true;
            return tiles;
        }

    }
}
