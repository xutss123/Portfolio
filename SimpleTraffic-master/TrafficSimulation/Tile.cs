using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSimulation.Actions;

namespace TrafficSimulation
{
    public class Tile
    {
        private int speed;
        public int counter { get; set; }
        public Position Position { get; }
        public List<TileAction> Actions { get; set; }
        public bool Dirty { get; set; }
        public TileType Type { get; set; }

        public static int Cars_Removed { get; set; }

        public Tile(int x, int y, TileType type, List<TileAction> actions)
        {
            this.Position = new Position(x, y);
            this.Actions = actions;
            this.Type = type;
            this.Dirty = false;
            this.speed = 3;
        }

        public String getSaveableCode()
        {
            switch (Type)
            {
                case TileType.Grass:
                    return "A";
                case TileType.SpawnPoint:
                case TileType.ExitPoint:
                case TileType.ControlPoint:
                case TileType.LeftExitPoint:
                case TileType.RightExitPoint:
                case TileType.UpExitPoint:
                case TileType.DownExitPoint:
                case TileType.Road:
                    return "B";
                case TileType.TrafficLightRed:
                    return "C";
                case TileType.TrafficLightGreen:
                    return "D";
                case TileType.TrafficLightYellow:
                    return "F";
                case TileType.Empty:
                default:
                    return "G";
            }
        }

        public static TileType GetTileTypeByCode(char code)
        {
            switch (code)
            {
                case 'A':
                    return TileType.Grass;
                case 'B':
                    return TileType.Road;
                case 'C':
                    return TileType.TrafficLightRed;
                case 'D':
                    return TileType.TrafficLightGreen;
                case 'F':
                    return TileType.TrafficLightYellow;
                case 'G':
                default:
                    return TileType.Empty;
            }
        }


        public void AdjustRouteBySpeed()
        {
            List<TileAction> nw = new List<TileAction>();
            nw = Actions;
            for (int d = 0; d < Actions.Count - 1; d++)
            {
                if (!(Actions[d] is NoAction))
                {
                    for (int i = 0; i < this.speed; i++)
                    {
                        d++;
                        NoAction n = new NoAction();
                        Actions.Insert(d, n);
                    }
                }
            }
        }


        private MoveAction CheckDirection(Tile spawn, Grid grid)
        {
            if (grid.UpSpawnPoints.Contains(spawn))
            {
                return new MoveAction(Direction.Down);
            }
            else if (grid.LeftSpawnPoints.Contains(spawn))
            {
                return new MoveAction(Direction.Right);
            }
            else if (grid.RightSpawnPoints.Contains(spawn))
            {
                return new MoveAction(Direction.Left);
            }
            else
            {
                return new MoveAction(Direction.Up);
            }
        }


        public List<TileAction> getRoute(Tile spawn, List<Tile> Tiles, Grid grid)
        {
            MoveAction LeadAction = CheckDirection(spawn, grid);
            Tile currentTile = spawn;
            
            Random random = new Random();
            int number;

            try
            { 
                while (currentTile.Type != TileType.ExitPoint)
                {
                    currentTile = GetNextTile(currentTile, LeadAction.direction, Tiles);

                    if (currentTile.Type == TileType.ControlPoint)
                    {
                        Actions.Add(LeadAction);

                        bool checkFront = false;
                        bool checkLeft = false;
                        bool checkRight = false;

                        void TurnLeft()
                        {
                            currentTile = GetNextTile(currentTile, LeadAction.direction, Tiles);
                            Actions.Add(LeadAction);
                            currentTile = GetNextTile(currentTile, LeadAction.direction, Tiles);
                            Actions.Add(LeadAction);

                            if (LeadAction.direction == Direction.Up)
                            {
                                LeadAction = new MoveAction(Direction.Left);
                            }
                            else if (LeadAction.direction == Direction.Down)
                            {
                                LeadAction = new MoveAction(Direction.Right);
                            }
                            else if (LeadAction.direction == Direction.Right)
                            {
                                LeadAction = new MoveAction(Direction.Up);
                            }
                            else if (LeadAction.direction == Direction.Left)
                            {
                                LeadAction = new MoveAction(Direction.Down);
                            }

                            currentTile = GetNextTile(currentTile, LeadAction.direction, Tiles);
                            Actions.Add(LeadAction);
                        }
                        void TurnRight()
                        {
                            currentTile = GetNextTile(currentTile, LeadAction.direction, Tiles);
                            Actions.Add(LeadAction);

                            if (LeadAction.direction == Direction.Up)
                            {
                                LeadAction = new MoveAction(Direction.Right);
                            }
                            else if (LeadAction.direction == Direction.Down)
                            {
                                LeadAction = new MoveAction(Direction.Left);
                            }
                            else if (LeadAction.direction == Direction.Right)
                            {
                                LeadAction = new MoveAction(Direction.Down);
                            }
                            else if (LeadAction.direction == Direction.Left)
                            {
                                LeadAction = new MoveAction(Direction.Up);
                            }

                            currentTile = GetNextTile(currentTile, LeadAction.direction, Tiles);
                            Actions.Add(LeadAction);
                        }

                        if (LeadAction.direction == Direction.Up)
                        {
                            if (FindSpecificTile(0, -3, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkFront = true;
                            }

                            if (FindSpecificTile(-2, -2, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkLeft = true;
                            }

                            if (FindSpecificTile(1, -1, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkRight = true;
                            }

                            if (checkFront && checkLeft && checkRight) // Car is in a plus intersection
                            {
                                number = random.Next(3);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnLeft();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;

                                    case 2: //going right
                                        TurnRight();
                                        break;
                                }
                            }
                            else if (checkFront && checkLeft && !checkRight) // T-left intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnLeft();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;
                                }
                            }
                            else if (checkFront && !checkLeft && checkRight) // T-right intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going right
                                        TurnRight();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;
                                }
                            }
                            else if (!checkFront && checkLeft && checkRight) // T-down intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going right
                                        TurnRight();
                                        break;

                                    case 1: //going left
                                        TurnLeft();
                                        break;
                                }
                            }
                            else if (!checkFront && checkLeft && !checkRight) // Corner Left
                            {
                                TurnLeft();
                            }
                            else if (!checkFront && !checkLeft && checkRight) // Corner Right
                            {
                                TurnRight();
                            }

                        }
                        else if (LeadAction.direction == Direction.Down)
                        {

                            if (FindSpecificTile(0, 3, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkFront = true;
                            }

                            if (FindSpecificTile(2, 2, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkLeft = true;
                            }

                            if (FindSpecificTile(-1, 1, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkRight = true;
                            }

                            if (checkFront && checkLeft && checkRight) // Car is in a plus intersection
                            {
                                number = random.Next(3);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnLeft();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;

                                    case 2: //going right
                                        TurnRight();
                                        break;
                                }
                            }
                            else if (checkFront && !checkLeft && checkRight) // T-left intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnRight();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;
                                }
                            }
                            else if (checkFront && checkLeft && !checkRight) // T-right intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going right
                                        TurnLeft();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;
                                }
                            }
                            else if (!checkFront && checkLeft && checkRight) // T-up intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going right
                                        TurnRight();
                                        break;

                                    case 1: //going left
                                        TurnLeft();
                                        break;
                                }
                            }
                            else if (!checkFront && checkLeft && !checkRight) // Corner Right
                            {
                                TurnLeft();
                            }
                            else if (!checkFront && !checkLeft && checkRight) // Corner Left
                            {
                                TurnRight();
                            }
                        }
                        else if (LeadAction.direction == Direction.Left)
                        {
                            if (FindSpecificTile(-3, 0, Tiles, currentTile).Type == TileType.Road) // Checking front
                            {
                                checkFront = true;
                            }

                            if (FindSpecificTile(-2, 2, Tiles, currentTile).Type == TileType.Road) // Checking left
                            {
                                checkLeft = true;
                            }

                            if (FindSpecificTile(-1, -1, Tiles, currentTile).Type == TileType.Road) // Checking right
                            {
                                checkRight = true;
                            }

                            if (checkFront && checkLeft && checkRight) // Car is in a plus intersection
                            {
                                number = random.Next(3);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnLeft();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;

                                    case 2: //going right
                                        TurnRight();
                                        break;
                                }
                            } // Plus intersection
                            else if (!checkFront && checkLeft && checkRight) // T-right intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnLeft();
                                        break;

                                    case 1: //going right
                                        TurnRight();
                                        break;
                                }
                            } // T-Left
                            else if (checkFront && checkLeft && !checkRight) // T-down intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnLeft();
                                        break;

                                    case 1: //going right
                                        Actions.Add(LeadAction);
                                        break;
                                }
                            } 
                            else if (checkFront && !checkLeft && checkRight) // T-up intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnRight();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;
                                }
                            } 
                            else if (!checkFront && checkLeft && !checkRight) // Corner Left
                            {
                                TurnLeft();
                            }
                            else if (!checkFront && !checkLeft && checkRight)
                            {
                                TurnRight();
                            } 


                        }
                        else if (LeadAction.direction == Direction.Right)
                        {
                            if (FindSpecificTile(3, 0, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkFront = true;
                            }

                            if (FindSpecificTile(2, -2, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkLeft = true;
                            }

                            if (FindSpecificTile(1, 1, Tiles, currentTile).Type == TileType.Road)
                            {
                                checkRight = true;
                            }

                            if (checkFront && checkLeft && checkRight) // Car is in a plus intersection
                            {
                                number = random.Next(3);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnLeft();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;

                                    case 2: //going right
                                        TurnRight();
                                        break;
                                }
                            }
                            else if (!checkFront && checkLeft && checkRight) // T-left intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going Left
                                        TurnRight();
                                        break;

                                    case 1: //going forward
                                        TurnLeft();
                                        break;
                                }
                            }
                            else if (checkFront && checkLeft && !checkRight) // T-up intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going right
                                        TurnLeft();
                                        break;

                                    case 1: //going forward
                                        Actions.Add(LeadAction);
                                        break;
                                }
                            }
                            else if (checkFront && !checkLeft && checkRight) // T-Down intersection
                            {
                                number = random.Next(2);

                                switch (number)
                                {
                                    case 0: //going forward
                                        Actions.Add(LeadAction);
                                        break;

                                    case 1: //going left
                                        TurnRight();
                                        break;
                                }
                            }
                            else if (!checkFront && checkLeft && !checkRight) // Corner Right
                            {
                                TurnLeft();
                            }
                            else if (!checkFront && !checkLeft && checkRight) // Corner Left
                            {
                                TurnRight();
                            }
                        }
                    }
                    else
                    {
                        Actions.Add(LeadAction);
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Something happened");
            }

            return Actions;

        }


        public Tile FindSpecificTile(int x, int y, List<Tile> Tiles,Tile t)
        {
            Tile tile = Tiles.Find(box =>
                           box.Position.X == t.Position.X + x &&
                           box.Position.Y == t.Position.Y + y
                        ); ;

            return tile;
        }

        public Tile GetNextTile(Tile t, Direction d, List<Tile> Tiles)
        {
            Tile NextTile = t;
            if (d == Direction.Up)
            {
                NextTile = Tiles.Find(box => 
                           box.Position.X == t.Position.X &&
                           box.Position.Y == t.Position.Y - 1           
                        );
            }
            else if (d == Direction.Down)
            {
                NextTile = Tiles.Find(box =>
                           box.Position.X == t.Position.X &&
                           box.Position.Y == t.Position.Y + 1
                        );
            }
            else if (d == Direction.Left)
            {
                NextTile = Tiles.Find(box =>
                           box.Position.X == t.Position.X - 1 &&
                           box.Position.Y == t.Position.Y
                        );
            }
            else if (d == Direction.Right)
            {
                NextTile = Tiles.Find(box =>
                           box.Position.X == t.Position.X + 1 &&
                           box.Position.Y == t.Position.Y 
                        );
            }

            return NextTile;
        }


        public TileAction getNextAction()
        {
            if (this.Actions == null)
            {
                if (this.Type == TileType.Car)
                {
                    return new RemoveCar();
                }
                return new NoAction();
            }

            if (this.Actions.Count != 0)
            {
                TileAction nextAction = this.Actions[0];
                this.Actions.RemoveAt(0);
                return nextAction;
            }

            if (this.Type == TileType.Car && this.Actions.Count == 0)
            {
                Cars_Removed++;
                return new RemoveCar();
            }

            return new NoAction();
        }
    }
}

/*
 *  public List<TileAction> getRoute(Tile spawn, List<Tile> Tiles, Grid grid, Tile exit)
        {
            List<Tile> routeList = new List<Tile>();

            MoveAction LeadAction;
            Tile currentTile = spawn;
            Tile nextTile = currentTile;

            if (grid.DownSpawnPoints.Contains(spawn))
            {
                LeadAction = new MoveAction(Direction.Up);

                while (currentTile.Position.Y != exit.Position.Y)
                {
                    nextTile = Tiles.Find(box =>
                                box.Position.X == currentTile.Position.X &&
                                box.Position.Y == currentTile.Position.Y - 1
                            );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                }

                if (exit.Position.X < currentTile.Position.X)
                {
                    LeadAction = new MoveAction(Direction.Left);

                    while (currentTile.Position.X != exit.Position.X)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X - 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }

                }
                else if (exit.Position.X > currentTile.Position.X)
                {
                    LeadAction = new MoveAction(Direction.Right);

                    while (currentTile.Position.X != exit.Position.X)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X + 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }
                }




            }
            else if (grid.RightSpawnPoints.Contains(spawn))
            {
                LeadAction = new MoveAction(Direction.Left);


                while (currentTile.Position.X != exit.Position.X)
                {
                    nextTile = Tiles.Find(box =>
                        box.Position.X == currentTile.Position.X - 1 &&
                        box.Position.Y == currentTile.Position.Y
                    );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                }

                if (exit.Position.Y < currentTile.Position.Y)
                {
                    LeadAction = new MoveAction(Direction.Up);

                    while (currentTile.Position.Y != exit.Position.Y)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X &&
                                    box.Position.Y == currentTile.Position.Y - 1
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }

                }
                else if (exit.Position.Y > currentTile.Position.Y)
                {
                    LeadAction = new MoveAction(Direction.Down);
                    while (currentTile.Position.Y != exit.Position.Y)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X &&
                                    box.Position.Y == currentTile.Position.Y + 1
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }
                }




            }
            else if (grid.LeftSpawnPoints.Contains(spawn))
            {
                LeadAction = new MoveAction(Direction.Right);

                while (currentTile.Position.X != exit.Position.X)
                {
                    nextTile = Tiles.Find(box =>
                        box.Position.X == currentTile.Position.X + 1 &&
                        box.Position.Y == currentTile.Position.Y
                    );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                }

                if (exit.Position.Y < currentTile.Position.Y)
                {
                    LeadAction = new MoveAction(Direction.Up);

                    while (currentTile.Position.Y != exit.Position.Y)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X &&
                                    box.Position.Y == currentTile.Position.Y - 1
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }

                }
                else if (exit.Position.Y > currentTile.Position.Y)
                {
                    LeadAction = new MoveAction(Direction.Down);
                    while (currentTile.Position.Y != exit.Position.Y)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X &&
                                    box.Position.Y == currentTile.Position.Y + 1
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }
                }




            }
            else if (grid.UpSpawnPoints.Contains(spawn))
            {
                LeadAction = new MoveAction(Direction.Down);
                while (currentTile.Position.Y != exit.Position.Y)
                {
                    nextTile = Tiles.Find(box =>
                                box.Position.X == currentTile.Position.X &&
                                box.Position.Y == currentTile.Position.Y + 1
                            );
                    currentTile = nextTile;
                    Actions.Add(LeadAction);
                }

                if (exit.Position.X < currentTile.Position.X)
                {
                    LeadAction = new MoveAction(Direction.Left);

                    while (currentTile.Position.X != exit.Position.X)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X - 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }

                }
                else if (exit.Position.X > currentTile.Position.X)
                {
                    LeadAction = new MoveAction(Direction.Right);
                    while (currentTile.Position.X != exit.Position.X)
                    {
                        nextTile = Tiles.Find(box =>
                                    box.Position.X == currentTile.Position.X + 1 &&
                                    box.Position.Y == currentTile.Position.Y
                                );
                        currentTile = nextTile;
                        Actions.Add(LeadAction);
                    }
                }
            }


            return Actions;

        }
*/