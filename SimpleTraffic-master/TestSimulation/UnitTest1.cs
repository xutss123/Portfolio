using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficSimulation;
using System.Collections.Generic;
using TrafficSimulation.Actions;
using TrafficSimulation.Rules;

namespace TestSimulation
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void PathFindingDownSpawnPointLeftExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }
            
            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.DownSpawnPoints[0]; 
            Tile exit = grid.LeftExitPoints[0];            
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X + 1;
            exitarr[1] = exit.Position.Y;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);
            
            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++) {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X + 1 && t.Position.Y == exit.Position.Y && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        

        [TestMethod]
        public void PathFindingDownSpawnPointUpExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.DownSpawnPoints[0];
            Tile exit = grid.UpExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X;
            exitarr[1] = exit.Position.Y + 1;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X && t.Position.Y == exit.Position.Y + 1 && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        [TestMethod]
        public void PathFindingDownSpawnPointRightExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.DownSpawnPoints[0];
            Tile exit = grid.RightExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X - 1;
            exitarr[1] = exit.Position.Y;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X - 1 && t.Position.Y == exit.Position.Y && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }
        [TestMethod]
        public void PathFindingLeftSpawnPointUpExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.LeftSpawnPoints[0];
            Tile exit = grid.UpExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X;
            exitarr[1] = exit.Position.Y + 1;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X && t.Position.Y == exit.Position.Y + 1 && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }
        [TestMethod]
        public void PathFindingLeftSpawnPointRightExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.LeftSpawnPoints[0];
            Tile exit = grid.RightExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X - 1;
            exitarr[1] = exit.Position.Y;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X - 1 && t.Position.Y == exit.Position.Y && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        [TestMethod]
        public void PathFindingLeftSpawnPointDownExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.LeftSpawnPoints[0];
            Tile exit = grid.DownExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X;
            exitarr[1] = exit.Position.Y - 1;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X && t.Position.Y == exit.Position.Y - 1 && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }


        [TestMethod]
        public void PathFindingUpSpawnPointLeftExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.UpSpawnPoints[0];
            Tile exit = grid.LeftExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X + 1;
            exitarr[1] = exit.Position.Y;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X + 1 && t.Position.Y == exit.Position.Y && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        [TestMethod]
        public void PathFindingUpSpawnPointDownExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.UpSpawnPoints[0];
            Tile exit = grid.DownExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X;
            exitarr[1] = exit.Position.Y - 1;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X && t.Position.Y == exit.Position.Y - 1 && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        public void TestMethod3()
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
        }

        [TestMethod]
        public void PathFindingUpSpawnPointRightExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.UpSpawnPoints[0];
            Tile exit = grid.RightExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X - 1;
            exitarr[1] = exit.Position.Y;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 15; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X - 1 && t.Position.Y == exit.Position.Y && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        [TestMethod]
        public void PathFindingRightSpawnPointUpExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.RightSpawnPoints[0];
            Tile exit = grid.UpExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X;
            exitarr[1] = exit.Position.Y + 1;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X && t.Position.Y == exit.Position.Y + 1 && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        [TestMethod]
        public void PathFindingRightSpawnPointLeftExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.RightSpawnPoints[0];
            Tile exit = grid.LeftExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X + 1;
            exitarr[1] = exit.Position.Y;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X + 1 && t.Position.Y == exit.Position.Y && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        [TestMethod]
        public void PathFindingRightSpawnPointDownExitPointTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 24; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(5, 5, 0, IntersectionType.Plus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.RightSpawnPoints[0];
            Tile exit = grid.DownExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X;
            exitarr[1] = exit.Position.Y - 1;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> tl = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Position.X == exit.Position.X && t.Position.Y == exit.Position.Y - 1 && t.Type == TileType.Car)
                    {
                        tl.Add(t);
                        break;
                    }
                }
                if (tl.Count == 1)
                {
                    break;
                }
                grid.Tick(5, 3, i);
            }
            int[] cararr = new int[2];
            cararr[0] = tl[0].Position.X;
            cararr[1] = tl[0].Position.Y;
            //Assert
            Assert.AreEqual(exitarr[0], cararr[0]);
            Assert.AreEqual(exitarr[1], cararr[1]);

        }

        [TestMethod]
        public void TrafficLightsRecognitionCarGoingUpwardsTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(1, 1, 0, IntersectionType.TrafficPlus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.RightSpawnPoints[0];
            Tile exit = grid.DownExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            int[] exitarr = new int[2];
            exitarr[0] = exit.Position.X + 1;
            exitarr[1] = exit.Position.Y;
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> carls = new List<Tile>();
            int check = 0;
            for (int i = 0; i < 10; i++)
            {
                if (carls.Count != 0 && carls.Count != 1)
                {
                    if (carls[carls.Count - 1] == carls[carls.Count - 2])
                    {
                        break;
                    }
                }
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Type == TileType.Car)
                    {
                        carls.Add(t);
                        break;
                    }
                }
                grid.Tick(7, 3, i);
                check = i;
            }
            grid.Tick(7, 3, check);
            int[] cararr = new int[2];
            cararr[0] = carls[carls.Count - 1].Position.X;
            cararr[1] = carls[carls.Count - 1].Position.Y;
            int[] carnext = new int[2];
            carnext[0] = carls[carls.Count - 2].Position.X;
            carnext[1] = carls[carls.Count - 2].Position.Y;
            //Assert
            Assert.AreEqual(carnext[0], cararr[0]);
            Assert.AreEqual(carnext[1], cararr[1]);
        }

        [TestMethod]
        public void TrafficLightsRecognitionCarGoingLeftTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(1, 1, 0, IntersectionType.TrafficPlus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.RightSpawnPoints[0];
            Tile exit = grid.LeftExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> carls = new List<Tile>();
            int check = 0;
            for (int i = 0; i < 10; i++)
            {
                if (carls.Count != 0 && carls.Count != 1)
                {
                    if (carls[carls.Count - 1] == carls[carls.Count - 2])
                    {
                        break;
                    }
                }
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Type == TileType.Car)
                    {
                        carls.Add(t);
                        break;
                    }
                }
                grid.Tick(7, 3, i);
                check = i;
            }
            grid.Tick(7, 3, check);
            int[] cararr = new int[2];
            cararr[0] = carls[carls.Count - 1].Position.X;
            cararr[1] = carls[carls.Count - 1].Position.Y;
            int[] carnext = new int[2];
            carnext[0] = carls[carls.Count - 2].Position.X;
            carnext[1] = carls[carls.Count - 2].Position.Y;
            //Assert
            Assert.AreEqual(carnext[0], cararr[0]);
            Assert.AreEqual(carnext[1], cararr[1]);
        }

        [TestMethod]
        public void TrafficLightsRecognitionCarGoingDownwardsTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(1, 1, 0, IntersectionType.TrafficPlus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.UpSpawnPoints[0];
            Tile exit = grid.LeftExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> carls = new List<Tile>();
            int check = 0;
            for (int i = 0; i < 10; i++)
            {
                if (carls.Count != 0 && carls.Count != 1)
                {
                    if (carls[carls.Count - 1] == carls[carls.Count - 2])
                    {
                        break;
                    }
                }
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Type == TileType.Car)
                    {
                        carls.Add(t);
                        break;
                    }
                }
                grid.Tick(7, 1, i);
                check = i;
            }
            grid.Tick(7, 3, check);
            int[] cararr = new int[2];
            cararr[0] = carls[carls.Count - 1].Position.X;
            cararr[1] = carls[carls.Count - 1].Position.Y;
            int[] carnext = new int[2];
            carnext[0] = carls[carls.Count - 2].Position.X;
            carnext[1] = carls[carls.Count - 2].Position.Y;
            //Assert
            Assert.AreEqual(carnext[0], cararr[0]);
            Assert.AreEqual(carnext[1], cararr[1]);
        }

        [TestMethod]
        public void TrafficLightsRecognitionCarGoingRightTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(1, 1, 0, IntersectionType.TrafficPlus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.LeftSpawnPoints[0];
            Tile exit = grid.DownExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);

            List<Tile> carls = new List<Tile>();
            int check = 0;
            for (int i = 0; i < 10; i++)
            {
                if (carls.Count != 0 && carls.Count != 1)
                {
                    if (carls[carls.Count - 1] == carls[carls.Count - 2])
                    {
                        break;
                    }
                }
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Type == TileType.Car)
                    {
                        carls.Add(t);
                        break;
                    }
                }
                grid.Tick(7, 3, i);
                check = i;
            }
            grid.Tick(7, 3, check);
            int[] cararr = new int[2];
            cararr[0] = carls[carls.Count - 1].Position.X;
            cararr[1] = carls[carls.Count - 1].Position.Y;
            int[] carnext = new int[2];
            carnext[0] = carls[carls.Count - 2].Position.X;
            carnext[1] = carls[carls.Count - 2].Position.Y;
            //Assert
            Assert.AreEqual(carnext[0], cararr[0]);
            Assert.AreEqual(carnext[1], cararr[1]);
        }

        [TestMethod]
        public void DeadLockTest()
        {
            //Arrange
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            //Act
            Grid grid = new Grid(tiles);
            grid.Draw_Intersection(1, 1, 0, IntersectionType.TrafficPlus);
            grid.CheckGrid();
            List<TileAction> actions = new List<TileAction>();
            Tile spawn = grid.LeftSpawnPoints[0];
            Tile exit = grid.DownExitPoints[0];
            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions);
            car.Actions = car.getRoute(spawn, tiles, grid, exit);
            grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);
            List<TileAction> actions1 = new List<TileAction>();
            Tile spawn1 = grid.LeftSpawnPoints[0];
            Tile exit1 = grid.DownExitPoints[0];
            Tile car1 = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, actions1);
            car1.Actions = car1.getRoute(spawn1, tiles, grid, exit1);
            grid.UpdateTile(spawn1.Position.X, spawn1.Position.Y, TileType.Car, car1.Actions);
            List<TileAction> actions2 = new List<TileAction>();
            Tile spawn2 = grid.LeftSpawnPoints[0];
            Tile exit2 = grid.DownExitPoints[0];
            Tile car2 = new Tile(spawn2.Position.X, spawn2.Position.Y, TileType.Car, actions2);
            car2.Actions = car2.getRoute(spawn2, tiles, grid, exit2);
            grid.UpdateTile(spawn2.Position.X, spawn2.Position.Y, TileType.Car, car2.Actions);
            List<TileAction> actions3 = new List<TileAction>();
            Tile spawn3 = grid.LeftSpawnPoints[0];
            Tile exit3 = grid.DownExitPoints[0];
            Tile car3 = new Tile(spawn3.Position.X, spawn3.Position.Y, TileType.Car, actions3);
            car3.Actions = car3.getRoute(spawn3, tiles, grid, exit3);
            grid.UpdateTile(spawn3.Position.X, spawn3.Position.Y, TileType.Car, car3.Actions);

            List<Tile> carls = new List<Tile>();
            int check = 0;
            for (int i = 0; i < 10; i++)
            {
                if (carls.Count != 0 && carls.Count != 1)
                {
                    if (carls[carls.Count - 1] == carls[carls.Count - 2])
                    {
                        break;
                    }
                }
                foreach (Tile t in grid.Tiles)
                {
                    if (t.Type == TileType.Car)
                    {
                        carls.Add(t);
                        break;
                    }
                }
                grid.Tick(7, 3, i);
                check = i;
            }
            grid.Tick(7, 3, check);
            int[] cararr = new int[2];
            cararr[0] = carls[carls.Count - 1].Position.X;
            cararr[1] = carls[carls.Count - 1].Position.Y;
            int[] carnext = new int[2];
            carnext[0] = carls[carls.Count - 2].Position.X;
            carnext[1] = carls[carls.Count - 2].Position.Y;
            //Assert
            Assert.AreEqual(carnext[0], cararr[0]);
            Assert.AreEqual(carnext[1], cararr[1]);
        }
    }
}