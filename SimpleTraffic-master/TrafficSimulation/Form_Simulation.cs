using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TrafficSimulation.Actions;
using TrafficSimulation.Rules;
using System.Reflection;

namespace TrafficSimulation
{
    public partial class Form_Simulation : Form
    {
        private Grid grid;
        private List<PictureBox> pictureBoxes;
        private int _intersectionCounter = 0;
        private int simuationUpdateInterval = 1000;
        private int pictureBoxSize = 20;
        private int pictureBoxGap = 1;
        private int timesUpdated = 0;        
        private int carsspawned = 0;
        private bool simIsLaunched = false;
        private bool carsTurnBlack = false;
        System.Windows.Forms.Timer timer;
        private DateTime dt;
        private TimeSpan ts = TimeSpan.Zero;
        private int trafficflow;
        private int cars_tick;

        private int timered;
        private int timegreen;

        private int initialTiles = 40;

        private List<PictureBox> comparePoints = new List<PictureBox>();
        

        List<PictureBox> exitPoints = new List<PictureBox>();

        public Form_Simulation()
        {
            InitializeComponent();
            rbPlusIntersection.Checked = true;
            this.grid = CreateInitialGrid();
            this.pictureBoxes = new List<PictureBox>();
            string ImagesDirectory =
                    Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Resources"
                );
            this.PlusIntersection.Image = Properties.Resources.plus_intersection;
            this.TrafficPlusIntersection.Image = Properties.Resources.TrafficPlus;
            this.TUp.Image = Properties.Resources.TUp;
            this.TDown.Image = Properties.Resources.TDown;
            this.TLeft.Image = Properties.Resources.TLeft;
            this.TRight.Image = Properties.Resources.TRight;
            this.Corner1.Image = Properties.Resources.Corner3;
            this.Corner2.Image = Properties.Resources.Corner2;
            this.Corner3.Image = Properties.Resources.Corner1;
            this.Corner4.Image = Properties.Resources.Corner4;

            tbSpawnedCars.Text = "0";

            this.FormClosed += new FormClosedEventHandler(Form_Simulation_Closed);

            CreateGrid(grid);
            btnStop.Enabled = false;
            btnMap.Enabled = false;
        }


        #region User_Form_Interactions

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (grid.TrafficLightsNeeded)
            {
                try
                {
                    cars_tick = Convert.ToInt32(tb_cars_tick.Text);
                    trafficflow = Convert.ToInt32(tb_trafficflow.Text);
                    timegreen = Convert.ToInt32(tb_greenlight.Text);
                    timered = Convert.ToInt32(tb_redlight.Text);
                    if (timered <= timegreen)
                    {
                        MessageBox.Show("red lights should last more than green lights");
                    }
                    else if (grid.spawnPoints != null)
                    {
                        simIsLaunched = true;
                        btnStop.Enabled = true;
                        btnLaunch.Enabled = false;
                        btnSave.Enabled = false;
                        btnLoad.Enabled = false;
                        btnMap.Enabled = false;
                        createTimer();
                        dt = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Cars would drown.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("please enter valid values for green,red light time, traffic flow, cars/tick");
                }

            }
           else  if (grid.spawnPoints != null)
           {
                try
                {
                trafficflow = Convert.ToInt32(tb_trafficflow.Text);
                cars_tick = Convert.ToInt32(tb_cars_tick.Text);
                simIsLaunched = true;
                btnStop.Enabled = true;
                btnLaunch.Enabled = false;
                btnSave.Enabled = false;
                btnLoad.Enabled = false;
                btnMap.Enabled = false;
                createTimer();
                dt = DateTime.Now;
                }
                catch (FormatException)
                {
                    MessageBox.Show("please enter value for traffic flow, cars/tick");
                }
            }
            else
            {
                MessageBox.Show("Cars would drown.");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            simIsLaunched = false;
            StopTimer();
            btnStop.Enabled = false;
            btnLaunch.Enabled = true;
            btnMap.Enabled = true;
            timesUpdated = 0;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            simIsLaunched = false;
            _intersectionCounter = 0;
            grid.Clear();
            grid.comparePoints.Clear();
            grid.spawnPoints.Clear();
            carsspawned = 0;
            Tile.Cars_Removed = 0;
            tbSpawnedCars.Text = carsspawned.ToString();
            tbCarsQuit.Text = Tile.Cars_Removed.ToString();
            this.CreateGrid(grid);
            grid.TrafficLightsNeeded = false;
            ts = TimeSpan.Zero;

            btnSave.Enabled = true;
            btnLoad.Enabled = true;
            btnLaunch.Enabled = true;
            btnMap.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String saveableCode = "";

                    foreach (Tile tile in grid.Tiles)
                    {
                        saveableCode += tile.getSaveableCode();
                    }

                    File.WriteAllText(saveFileDialog.FileName, saveableCode);
                    MessageBox.Show("Grid was successfully saved!");
                }
            }
            catch
            {
                MessageBox.Show("There was an error while saving the grid.");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var reader = new StreamReader(openFileDialog.FileName);
                    String gridCode = reader.ReadToEnd();
                    int x = 0;
                    int y = 0;

                    List<Tile> tiles = new List<Tile>();
                    foreach (char code in gridCode)
                    {
                        tiles.Add(new Tile(y, x, Tile.GetTileTypeByCode(code), new List<TileAction>()));
                        x++;
                        if (x == initialTiles)
                        {
                            y++;
                            x = 0;
                        }
                    }

                    RestoreGrid();
                    grid = new Grid(tiles); ;
                    grid.CheckGrid();
                    CreateGrid(grid);

                    MessageBox.Show("Grid was successfully loaded!");
                }
            }
            catch
            {
                MessageBox.Show("There was an error while loading the grid.");
            }
        }

        private void tbTickFrequency_Scroll(object sender, EventArgs e)
        {
            switch (tbTickFrequency.Value)
            {
                case 0:
                    simuationUpdateInterval = 4000;
                    carsTurnBlack = false;
                    break;

                case 1:
                    simuationUpdateInterval = 2000;
                    carsTurnBlack = false;
                    break;

                case 2:
                    simuationUpdateInterval = 1000;
                    carsTurnBlack = false;
                    break;

                case 3:
                    simuationUpdateInterval = 500;
                    carsTurnBlack = false;
                    break;

                case 4:
                    simuationUpdateInterval = 200;
                    carsTurnBlack = true;
                    break;

                case 5:
                    simuationUpdateInterval = 100;
                    carsTurnBlack = true;
                    break;

                case 6:
                    simuationUpdateInterval = 50;
                    carsTurnBlack = true;
                    break;

                default:
                    break;
            }

            if (simIsLaunched)
            {
                timer.Interval = simuationUpdateInterval;
            }
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            foreach (Tile tile in grid.Tiles)
            {
                if (tile.Type != TileType.Grass && tile.Type != TileType.Empty && tile.Type != TileType.TrafficLightRed && tile.Type != TileType.TrafficLightGreen && tile.Type != TileType.TrafficLightYellow)
                {
                    switch (tile.counter)
                    {
                        case 0:
                        case 1:
                        case 2:
                            tile.Type = TileType.White;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            tile.Type = TileType.Bej;
                            break;
                        case 6:
                        case 7:
                        case 8:
                            tile.Type = TileType.Orange;
                            break;
                        case 9:
                        case 10:
                        case 11:
                            tile.Type = TileType.LightRed;
                            break;
                        case 12:
                        case 13:
                        case 14:
                            tile.Type = TileType.Red;
                            break;
                        case 15:
                        case 16:
                        case 17:
                            tile.Type = TileType.LightBlue;
                            break;
                        case 18:
                            tile.Type = TileType.Blue;
                            break;
                        default:
                            tile.Type = TileType.Blue;
                            break;
                    }
                }
            }
            this.CreateGrid(grid);
            btnLaunch.Enabled = false;
            btn_Clear.Enabled = true;
        }

        public void pictureBoxClick(object sender, EventArgs e) //Click event
        {
            PictureBox p = sender as PictureBox;
            if (rbPlusIntersection.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Plus);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;

            }
            else if (rbTrafficPlus.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TrafficPlus);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbTUp.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TUp);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;

            }
            else if (rbTDown.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TDown);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;

            }
            else if (rbTLeft.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TLeft);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbTRight.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.TRight);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbCorner1.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Corner1);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbCorner2.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Corner2);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbCorner3.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Corner3);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else if (rbCorner4.Checked == true)
            {
                RestoreGrid();
                grid.Draw_Intersection(p.Location.X / 21, p.Location.Y / 21, _intersectionCounter, IntersectionType.Corner4);
                grid.CheckGrid();
                this.CreateGrid(grid);
                _intersectionCounter++;
            }
            else
            {
                MessageBox.Show("Please choose a type of intersection");
            }

        }

        void Form_Simulation_Closed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            Form_Stats f = new Form_Stats(carsspawned, Tile.Cars_Removed, ts);
            f.ShowDialog();
        }

        #endregion


        #region Grid_Related_Actions

        private void spawnDemoCar()
        {
            List <List< Tile >> SpawnPoint = new List<List<Tile>>();
            Random ran = new Random();
            

            int a;
            int b;

            Tile spawn = grid.spawnPoints[0];
            Tile exit = grid.exitPoints[0];

            if (grid.DownSpawnPoints.Count > 0)
            {
                SpawnPoint.Add(grid.DownSpawnPoints);
            }

            if (grid.UpSpawnPoints.Count > 0)
            {
                SpawnPoint.Add(grid.UpSpawnPoints);
            }

            if (grid.RightSpawnPoints.Count > 0)
            {
                SpawnPoint.Add(grid.RightSpawnPoints);
            }

            if (grid.LeftSpawnPoints.Count > 0)
            {
                SpawnPoint.Add(grid.LeftSpawnPoints);
            }

            int r = ran.Next(SpawnPoint.Count);

            switch (r)
            {
                case 0:
                    a = ran.Next(SpawnPoint[0].Count);
                    spawn = SpawnPoint[0][a];
                    break;
                case 1:
                    a = ran.Next(SpawnPoint[1].Count);
                    spawn = SpawnPoint[1][a];
                    break;
                case 2:
                    a = ran.Next(SpawnPoint[2].Count);
                    spawn = SpawnPoint[2][a];
                    break;
                case 3:
                    a = ran.Next(SpawnPoint[3].Count);
                    spawn = SpawnPoint[3][a];
                    break;
                default:
                    MessageBox.Show("There are no exit and entry points");
                    break;
            }

            Tile car = new Tile(spawn.Position.X, spawn.Position.Y, TileType.Car, new List<TileAction>());
            car.Actions = car.getRoute(spawn, grid.Tiles, this.grid);
            //car.AdjustRouteBySpeed();

            this.grid.UpdateTile(spawn.Position.X, spawn.Position.Y, TileType.Car, car.Actions);
            this.CreateGrid(this.grid);
        }

        private Grid CreateInitialGrid()
        {
            List<Tile> tiles = new List<Tile>();

            for (int x = 0; x < initialTiles; x++)
            {
                for (int y = 0; y < initialTiles; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Empty, new List<TileAction>()));
                }
            }

            return new Grid(tiles);
        }

        private void CreateGrid(Grid grid)
        {
            bool isFirstTime = this.pictureBoxes.Count() == 0;

            foreach (Tile tile in grid.Tiles)
            {
                if (isFirstTime)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(
                        tile.Position.X * (this.pictureBoxSize + this.pictureBoxGap),
                        tile.Position.Y * (this.pictureBoxSize + this.pictureBoxGap)
                    );
                    pictureBox.Size = new Size(this.pictureBoxSize, this.pictureBoxSize);


                    if (tile.Type == TileType.Car && !carsTurnBlack)
                    {
                        Direction d;

                        if (tile.Actions.Count > 0)
                        {
                            if (!(tile.Actions[0] is NoAction))
                            {
                                d = ((MoveAction)tile.Actions[0]).direction;
                                pictureBox.Image = Properties.Resources.thumbnail;                      // default down

                                if (d == Direction.Up)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                }
                                else if (d == Direction.Left)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                                else if (d == Direction.Right)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                }
                            }
                        }
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox.Image = null;
                        pictureBox.BackColor = this.getTileColor(tile.Type);
                    }


                    pictureBox.Click += new EventHandler(this.pictureBoxClick);
                    this.pictureBoxes.Add(pictureBox);
                    this.Controls.Add(pictureBox);
                }
                else
                {
                    PictureBox pictureBox = this.pictureBoxes.Find(box =>
                        box.Location.X == tile.Position.X * (this.pictureBoxSize + this.pictureBoxGap) &&
                        box.Location.Y == tile.Position.Y * (this.pictureBoxSize + this.pictureBoxGap)
                    );

                    if (tile.Type == TileType.Car && !carsTurnBlack)
                    {
                        Direction d;

                        if (tile.Actions.Count > 0)
                        {
                            if (!(tile.Actions[0] is NoAction))
                            {
                                d = ((MoveAction)tile.Actions[0]).direction;
                                pictureBox.Image = Properties.Resources.thumbnail;                      // default down

                                if (d == Direction.Up)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                }
                                else if (d == Direction.Left)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                                else if (d == Direction.Right)
                                {
                                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                }
                            }
                        }
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox.Image = null;
                        pictureBox.BackColor = this.getTileColor(tile.Type);
                    }

                }

            }
        }

        private Color getTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Grass:
                    return Color.LightGreen;
                case TileType.Car:
                    return Color.Black;
                case TileType.Road:
                case TileType.ControlPoint:
                    return Color.LightGray;
                case TileType.Empty:
                    return Color.Blue;
                case TileType.SpawnPoint:
                    return Color.Red;
                case TileType.ExitPoint:
                    return Color.Pink;
                case TileType.TrafficLightRed:
                    return Color.DarkRed;
                case TileType.TrafficLightGreen:
                    return Color.DarkGreen;
                case TileType.TrafficLightYellow:
                    return Color.Yellow;

                //Cases used for Heatmap
                //Heatmap should be pressed after stop, without clearing the grid
                //MoveAction, Grid classes used for heatmap
                case TileType.White:
                    return Color.White;
                case TileType.Bej:
                    return Color.Beige;
                case TileType.Orange:
                    return Color.Orange;
                case TileType.LightRed:
                    return Color.Red;
                case TileType.Red:
                    return Color.DarkRed;
                case TileType.LightBlue:
                    return Color.LightBlue;
                case TileType.Blue:
                    return Color.DarkBlue;
                default: return Color.White;
            }
        }

        public void RestoreGrid()
        {
            foreach (Tile t in grid.Tiles)
            {
                if (t.Type == TileType.SpawnPoint || t.Type == TileType.ExitPoint)
                {
                    t.Type = TileType.Road;
                }
            }
        }

        #endregion


        private void createTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(updateSimulation);
            timer.Interval = simuationUpdateInterval;
            timer.Enabled = true;
        }

        private void StopTimer()
        {
            timer.Stop();
            btnStop.Enabled = false;
            btnLaunch.Enabled = true;
        }

        void updateSimulation(object sender, EventArgs e)
        {
            this.grid.Tick(timered,timegreen,timesUpdated);
            CreateGrid(this.grid);
            this.timesUpdated++;
            tbCarsQuit.Text = Tile.Cars_Removed.ToString();
            ts = DateTime.Now - dt;
            tbTimeElapsed.Text = ts.ToString(@"hh\:mm\:ss");
            if (this.timesUpdated >= timered + timegreen + (timered - timegreen))
            {
                timesUpdated = 0;
            }
            if (this.timesUpdated % cars_tick == 0)
            {
                if (grid.spawnPoints.Count != 0)
                {
                    if ((carsspawned - Tile.Cars_Removed) < trafficflow)
                    {
                        this.spawnDemoCar();
                        carsspawned++;
                        tbSpawnedCars.Text = carsspawned.ToString();
                    }
                }
                else
                {
                    StopTimer();
                    MessageBox.Show("No spawn Points!");
                }
            }
        }

        private void tb_cars_tick_TextChanged(object sender, EventArgs e)
        {
            cars_tick = Convert.ToInt32(tb_cars_tick.Text);
        }

        private void tb_trafficflow_TextChanged(object sender, EventArgs e)
        {
            trafficflow = Convert.ToInt32(tb_trafficflow.Text);
        }

        private void tb_greenlight_TextChanged(object sender, EventArgs e)
        {
            if (grid.TrafficLightsNeeded)
            {
                if (timered <= Convert.ToInt32(tb_greenlight.Text))
                {
                    timegreen = Convert.ToInt32(tb_greenlight.Text);
                    MessageBox.Show("red lights should last more than green lights");
                }
            }           
        }

        private void tb_redlight_TextChanged(object sender, EventArgs e)
        {
            if (grid.TrafficLightsNeeded)
            {
                if (Convert.ToInt32(tb_redlight.Text) <= timegreen)
                {
                    timered = Convert.ToInt32(tb_redlight.Text);
                    MessageBox.Show("red lights should last more than green lights");
                }
            }
        }
    }
}









