using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficSimulation;

namespace TrafficSimulationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }
            //Act
            Grid sosat = new Grid(tiles);

            sosat.Draw_Intersection(0, 0, 0, IntersectionType.Plus);
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = sosat.DownSpawnPoints[0];
            Tile exit = sosat.LeftExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);

            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));
            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));
            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));
            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));
            sosat.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.getRoute(spawn, sosat.Tiles, sosat, exit));

            int[] cararr = new int[2];
            cararr[0] = car.Position.X;
            cararr[1] = car.Position.Y;
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X;
            exitarr[1] = exit.Position.Y;
            //Assert
            //This unit test should be checking position before car checked the red traffic light and position of the same car one tick after
        }
    }
}
