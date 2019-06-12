using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation.Actions
{
    public abstract class TileAction
    {
        abstract public List<Tile> Handle(Tile tile, List<Tile> tiles);
    }
}
