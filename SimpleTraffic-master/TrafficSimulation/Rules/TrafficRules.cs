using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation.Rules
{
    public abstract class TrafficRules
    {
        abstract public List<Tile> Handle(List<Tile> tiles);

        public List<Tile> CleanDirtyTiles(List<Tile> tiles)
        {
            List<Tile> updatedTiles = tiles;

            for(int i = 0; i < tiles.Count(); i++)
            {
                updatedTiles[i].Dirty = false;
            }

            return updatedTiles;
        }
    }
}
