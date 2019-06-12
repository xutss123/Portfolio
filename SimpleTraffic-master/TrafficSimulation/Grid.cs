using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSimulation.Rules;
using TrafficSimulation.Actions;

namespace TrafficSimulation
{
    //heat map line 107
    public class Grid
    {
        private TrafficRules trafficRules;

        public List<Tile> Tiles { get; private set; }
        public List<Tile> CarTiles { get; private set; }
        public List<Tile> RoadGrassTiles { get; private set; }
        public List<Tile> comparePoints { get; private set; }
        public List<Tile> spawnPoints { get; private set; }
        public List<Tile> DownSpawnPoints { get; private set; }
        public List<Tile> UpSpawnPoints { get; private set; }
        public List<Tile> LeftSpawnPoints { get; private set; }
        public List<Tile> RightSpawnPoints { get; private set; }

        public List<Tile> exitPoints { get; private set; }
        public List<Tile> DownExitPoints { get; private set; }
        public List<Tile> UpExitPoints { get; private set; }
        public List<Tile> LeftExitPoints { get; private set; }
        public List<Tile> RightExitPoints { get; private set; }

        

        public List<Tile> StartRed { get; set; }
        public List<Tile> StartGreen { get; set; }
        public bool TrafficLightsNeeded = false;

        public Grid(List<Tile> tiles)
        {
            this.Tiles = tiles;
            comparePoints = new List<Tile>();
            trafficRules = new SimpleTrafficRules();
        }

        public void Tick(int nrred, int nrgreen, int timesUpdated)
        {
            if (TrafficLightsNeeded)
            {
                int nryellow = nrred - nrgreen;
                int nrstart = timesUpdated + 1;
                if (timesUpdated >= 0)
                {
                    if (nrstart % nrred == 0)
                    {
                        ChangeTrafficLightsRed(StartRed);
                        ChangeTrafficLightsYellow(StartGreen);
                    }
                    
                    if (nrstart % (nrred + nrgreen) == 0)
                    {
                        ChangeTrafficLightsGreen(StartRed);
                    }
                    if (nrstart % nrgreen == 0)
                    {
                        ChangeTrafficLightsGreen(StartGreen);
                    }
                    if (nrstart % (nrred + nryellow + nrgreen) == 0)
                    {
                        ChangeTrafficLightsYellow(StartRed);
                        ChangeTrafficLightsRed(StartGreen);
                    }
                }
            }
            this.Tiles = this.trafficRules.Handle(this.Tiles);
            this.Tiles = this.trafficRules.CleanDirtyTiles(this.Tiles);
        }


        public void UpdateTile(int x, int y, TileType type, List<TileAction> actions)
        {
            Tile newTile = new Tile(x, y, type, actions);
            int tileIndex = this.Tiles.FindIndex(tile => tile.Position.X == x && tile.Position.Y == y);
            this.Tiles[tileIndex] = newTile;
            this.Tiles[tileIndex].counter++;
        }

        public void Draw_Intersection(int x, int y, int intersectionCounter, IntersectionType section_type)
        {
            var replaceSwitch1 = new Dictionary<IntersectionType, Action>
            {
                {IntersectionType.Plus, () => AddPlusToGrid(x,y)},
                {IntersectionType.TUp, () => AddT_UpToGrid(x,y)},
                {IntersectionType.TDown, () => AddT_DownToGrid(x,y) },
                {IntersectionType.TLeft, () => AddT_LeftToGrid(x,y) },
                {IntersectionType.TRight, () => AddT_RightToGrid(x,y) },
                {IntersectionType.Corner1, () => Add_Corner1(x,y) },
                {IntersectionType.Corner2, () => Add_Corner2(x,y) },
                {IntersectionType.Corner3, () => AddT_DownToGrid(x,y) },
                {IntersectionType.Corner4, () => AddT_DownToGrid(x,y) },
            };


            if (x + 7 < Tiles[Tiles.Count - 1].Position.X && y + 7 < Tiles[Tiles.Count - 1].Position.Y)
            {
                if (intersectionCounter == 0)
                {
                    switch (section_type)
                    {
                        case IntersectionType.Plus:
                            AddPlusToGrid(x, y);
                            break;
                        case IntersectionType.TUp:
                            AddT_UpToGrid(x, y);
                            break;
                        case IntersectionType.TDown:
                            AddT_DownToGrid(x, y);
                            break;
                        case IntersectionType.TLeft:
                            AddT_LeftToGrid(x, y);
                            break;
                        case IntersectionType.TRight:
                            AddT_RightToGrid(x, y);
                            break;
                        case IntersectionType.Corner1:
                            Add_Corner1(x, y);
                            break;
                        case IntersectionType.Corner2:
                            Add_Corner2(x, y);
                            break;
                        case IntersectionType.Corner3:
                            Add_Corner3(x, y);
                            break;
                        case IntersectionType.Corner4:
                            Add_Corner4(x, y);
                            break;
                        case IntersectionType.TrafficPlus:
                            AddTrafficPlusToGrid(x,y);
                            break;
                    }
                }
                else
                {
                    int _distance;

                    int _newValueX = Int32.MaxValue;
                    int _newValueY = Int32.MaxValue;

                    int _closestX = 0;
                    int _closestY = 0;

                    Tile e = this.Tiles.Find(tile => tile.Position.X == x && tile.Position.Y == y);



                    foreach (Tile t in comparePoints)
                    {
                        _distance = Math.Abs(t.Position.X - e.Position.X);

                        if (_distance < _newValueX)
                        {
                            _newValueX = _distance;
                            _closestX = t.Position.X;
                        }
                    }

                    foreach (Tile a in comparePoints)
                    {
                        if (a.Position.X == _closestX)
                        {
                            _distance = Math.Abs(a.Position.Y - e.Position.Y);

                            if (_distance < _newValueY)
                            {
                                _newValueY = _distance;
                                _closestY = a.Position.Y;
                            }
                        }
                    }

                    Tile _closest = this.Tiles.Find(tile => tile.Position.X == _closestX && tile.Position.Y == _closestY);




                    if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X < _closest.Position.X) // Add Left
                    {
                        switch (section_type)
                        {
                            case IntersectionType.Plus:
                                AddPlusToGrid(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.TUp:
                                AddT_UpToGrid(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.TDown:
                                AddT_DownToGrid(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.TLeft:
                                AddT_LeftToGrid(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.TRight:
                                AddT_RightToGrid(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.Corner1:
                                Add_Corner1(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.Corner2:
                                Add_Corner2(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.Corner3:
                                Add_Corner3(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.Corner4:
                                Add_Corner4(_closestX - 8, _closestY);
                                break;
                            case IntersectionType.TrafficPlus:
                                AddTrafficPlusToGrid(_closestX - 8, _closestY);
                                break;
                        }
                    }
                    else if (e.Position.Y >= _closest.Position.Y && e.Position.Y < _closest.Position.Y + 8 && e.Position.X > _closest.Position.X) // Add Right
                    {
                        switch (section_type)
                        {
                            case IntersectionType.Plus:
                                AddPlusToGrid(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.TUp:
                                AddT_UpToGrid(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.TDown:
                                AddT_DownToGrid(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.TLeft:
                                AddT_LeftToGrid(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.TRight:
                                AddT_RightToGrid(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.Corner1:
                                Add_Corner1(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.Corner2:
                                Add_Corner2(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.Corner3:
                                Add_Corner3(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.Corner4:
                                Add_Corner4(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.TrafficPlus:
                                AddTrafficPlusToGrid(_closestX + 8, _closestY);
                                break;
                        }
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y < _closest.Position.Y) // Add up
                    {
                        switch (section_type)
                        {
                            case IntersectionType.Plus:
                                AddPlusToGrid(_closestX, _closestY - 8);
                                break;
                            case IntersectionType.TUp:
                                AddT_UpToGrid(_closestX + 8, _closestY);
                                break;
                            case IntersectionType.TDown:
                                AddT_DownToGrid(_closestX, _closestY - 8);
                                break;
                            case IntersectionType.TLeft:
                                AddT_LeftToGrid(_closestX, _closestY - 8);
                                break;
                            case IntersectionType.TRight:
                                AddT_RightToGrid(_closestX, _closestY - 8);
                                break;
                            case IntersectionType.Corner1:
                                Add_Corner1(_closestX, _closestY - 8);
                                break;
                            case IntersectionType.Corner2:
                                Add_Corner2(_closestX, _closestY - 8);
                                break;
                            case IntersectionType.Corner3:
                                Add_Corner3(_closestX, _closestY - 8);
                                break;
                            case IntersectionType.Corner4:
                                Add_Corner4(_closestX, _closestY - 8);
                                break;
                            case IntersectionType.TrafficPlus:
                                AddTrafficPlusToGrid(_closestX, _closestY - 8);
                                break;
                        }
                    }
                    else if (e.Position.X >= _closest.Position.X &&
                             e.Position.X < _closest.Position.X + 8 &&
                             e.Position.Y > _closest.Position.Y) // Add Down
                    {
                        switch (section_type)
                        {
                            case IntersectionType.Plus:
                                AddPlusToGrid(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.TUp:
                                AddT_UpToGrid(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.TDown:
                                AddT_DownToGrid(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.TLeft:
                                AddT_LeftToGrid(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.TRight:
                                AddT_RightToGrid(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.Corner1:
                                Add_Corner1(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.Corner2:
                                Add_Corner2(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.Corner3:
                                Add_Corner3(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.Corner4:
                                Add_Corner4(_closestX, _closestY + 8);
                                break;
                            case IntersectionType.TrafficPlus:
                                AddTrafficPlusToGrid(_closestX, _closestY + 8);
                                break;
                        }
                    }
                }
            }
        }

        public void AddPlusToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();

            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 2 || a >= x + 6 && a < x + 8)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 2)
                    {
                        if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //leftcontrol point
                        }
                        else if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 5)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //right control point
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 3)
                    {
                        if (b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //up control point
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); // down
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }



                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddTrafficPlusToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            TrafficLightsNeeded = true;

            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 2 || a >= x + 6 && a < x + 8)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 2)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.TrafficLightGreen, new List<TileAction>()));
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //leftcontrol point
                        }
                        else if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.TrafficLightRed, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 3)
                    {
                        if (b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //upcontrol point
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //down
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 5)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //right control point
                        }
                        else if (b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.TrafficLightRed, new List<TileAction>()));
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.TrafficLightGreen, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddT_UpToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 2 || a >= x + 6 && a <= x + 7)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 2)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); // left
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 3)
                    {
                        if (b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //up

                        }
                        else if (b == y + 5 || b == y + 6 || b == y + 7)
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b == y + 5 || b == y + 6 || b == y + 7)
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 5)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //right
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddT_DownToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 2 || a >= x + 6 && a <= x + 7)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 2)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); // left
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 3)
                    {
                        if (b == y + 3 || b == y + 4 || b == y + 5 || b == y + 6 || b == y + 7)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b == y + 3 || b == y + 4 || b == y + 6 || b == y + 7)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //down
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 5)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //right
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }

                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddT_LeftToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 2)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 2)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); // left
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 3)
                    {
                        if (b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //up
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //down
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a >= x + 5 && a <= x + 8)
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }
                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void AddT_RightToGrid(int x, int y) // Add method
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 3)
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }
                    else if (a == x + 3)
                    {
                        if (b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //up
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //up
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 5)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //right
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a >= x + 6 && a <= x + 7)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {

                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void Add_Corner1(int x, int y)
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 2)
                    {
                        if (b == y + 3 || b == y + 4)

                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 2)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //left
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 3)
                    {
                        if (b == y || b == y + 1 || b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 2)
                        {

                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); // upcontrol

                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b >= y && b <= y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }

                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void Add_Corner2(int x, int y)
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a <= x + 2)
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }
                    else if (a == x + 3)
                    {
                        if (b == y || b == y + 1 || b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //up
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b >= y && b <= y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }

                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 5)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //right
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }

                    }
                    else if (a >= x + 6 && a <= x + 7)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }


                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void Add_Corner3(int x, int y)
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a < x + 2)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 2)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //leftcontrol
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 3)
                    {
                        if (b >= y + 3 && b <= y + 7)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b >= y && b < y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                        else if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //down
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }

                    }
                    else
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }

                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }

        public void Add_Corner4(int x, int y)
        {
            List<Tile> tiles = new List<Tile>();
            for (int a = x; a < x + 8; a++)
            {
                for (int b = y; b < y + 8; b++)
                {
                    if (a >= x && a <= x + 2)
                    {
                        tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                    }
                    else if (a == x + 3)
                    {
                        if (b >= y + 3 && b <= y + 7)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }

                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 4)
                    {
                        if (b >= y && b <= y + 2)
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                        else if (b == y + 5)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //down
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                    }
                    else if (a == x + 5)
                    {
                        if (b == y + 3)
                        {
                            tiles.Add(new Tile(a, b, TileType.ControlPoint, new List<TileAction>())); //right
                        }
                        else if (b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }
                    else if (a >= x + 6 && a <= x + 7)
                    {
                        if (b == y + 3 || b == y + 4)
                        {
                            tiles.Add(new Tile(a, b, TileType.Road, new List<TileAction>()));
                        }
                        else
                        {
                            tiles.Add(new Tile(a, b, TileType.Grass, new List<TileAction>()));
                        }
                    }


                }
            }

            for (int g = 0; g < Tiles.Count; g++)
            {
                for (int m = 0; m < tiles.Count; m++)
                {
                    if (Tiles[g].Position.X == tiles[m].Position.X && Tiles[g].Position.Y == tiles[m].Position.Y)
                    {
                        Tiles[g] = tiles[m];
                    }
                }
            }

            foreach (Tile t in Tiles)
            {
                if (t.Position.X == x && t.Position.Y == y)
                {
                    comparePoints.Add(t);
                }
            }
        }




        public void CheckGrid()
        {
            spawnPoints = new List<Tile>();
            exitPoints = new List<Tile>();
            LeftSpawnPoints = new List<Tile>();
            RightSpawnPoints = new List<Tile>();
            UpSpawnPoints = new List<Tile>();
            DownSpawnPoints = new List<Tile>();

            exitPoints = new List<Tile>();
            LeftExitPoints = new List<Tile>();
            RightExitPoints = new List<Tile>();
            UpExitPoints = new List<Tile>();
            DownExitPoints = new List<Tile>();
            StartRed = new List<Tile>();
            StartGreen = new List<Tile>();


            try
            {
                foreach (Tile t in Tiles)
                {   //Finding all the spawnpoints
                    Tile t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y + 1);
                    Tile t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X - 1 && tile.Position.Y == t.Position.Y);
                    if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty)
                    {
                        t.Type = TileType.SpawnPoint;
                        spawnPoints.Add(t);
                        LeftSpawnPoints.Add(t);
                    }

                    t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X - 1 && tile.Position.Y == t.Position.Y);
                    t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y - 1);
                    if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty)
                    {
                        t.Type = TileType.SpawnPoint;
                        spawnPoints.Add(t);
                        UpSpawnPoints.Add(t);
                    }

                    t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y - 1);
                    t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X + 1 && tile.Position.Y == t.Position.Y);
                    if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty)
                    {
                        t.Type = TileType.SpawnPoint;
                        spawnPoints.Add(t);
                        RightSpawnPoints.Add(t);
                    }

                    t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X + 1 && tile.Position.Y == t.Position.Y);
                    t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y + 1);
                    if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty)
                    {
                        t.Type = TileType.SpawnPoint;
                        spawnPoints.Add(t);
                        DownSpawnPoints.Add(t);
                    }

                    //Finding all the exitpoints
                    t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X + 1 && tile.Position.Y == t.Position.Y);
                    t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y - 1);
                    if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty) // upper exitpoint
                    {
                        t.Type = TileType.ExitPoint;
                        exitPoints.Add(t);
                        UpExitPoints.Add(t);
                    }

                    t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y - 1);
                    t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X - 1 && tile.Position.Y == t.Position.Y);
                    if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty) // left exitpoint
                    {
                        t.Type = TileType.ExitPoint;
                        exitPoints.Add(t);
                        LeftExitPoints.Add(t);
                    }

                    t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X - 1 && tile.Position.Y == t.Position.Y);
                    t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y + 1);
                    if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty) // down exipoint
                    {
                        t.Type = TileType.ExitPoint;
                        exitPoints.Add(t);
                        DownExitPoints.Add(t);
                    }

                    t1 = this.Tiles.Find(tile => tile.Position.X == t.Position.X && tile.Position.Y == t.Position.Y + 1);
                    t2 = this.Tiles.Find(tile => tile.Position.X == t.Position.X + 1 && tile.Position.Y == t.Position.Y);
                    if (t.Type == TileType.Road && t1.Type == TileType.Grass && t2.Type == TileType.Empty) // right exitpoint
                    {
                        t.Type = TileType.ExitPoint;
                        exitPoints.Add(t);
                        RightExitPoints.Add(t);
                    }
                    if (t.Type == TileType.TrafficLightGreen)
                    {
                        StartGreen.Add(t);
                    }
                    if (t.Type == TileType.TrafficLightRed)
                    {
                        StartRed.Add(t);
                    }

                }
                
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Please don't use the margin to build the map!");
            }

        }
        public void Clear()
        {
            foreach (Tile t in Tiles)
            {
                t.Type = TileType.Empty;
            }
        }
        public void ChangeTrafficLightsRed(List<Tile> trafficlights)
        {
            ((SimpleTrafficRules)trafficRules).ChangeRed(trafficlights);
        }
        public void ChangeTrafficLightsGreen(List<Tile> trafficlights)
        {
            ((SimpleTrafficRules)trafficRules).ChangeGreen(trafficlights);
        }
        public void ChangeTrafficLightsYellow(List<Tile> trafficlights)
        {
            ((SimpleTrafficRules)trafficRules).ChangeYellow(trafficlights);
        }
    }
}
