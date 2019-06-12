using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficSimulation.Rules;
using TrafficSimulation.Actions;
using System.Timers;

namespace TrafficSimulation
{
    public partial class Form1 : Form
    {
        private Grid grid;
        private int pictureBoxSize = 50;
        private int pictureBoxGap = 5;
        private List<PictureBox> pictureBoxes;
        private int simulationUpdateInterval = 1000;
        private int timesUpdated = 0;
        private int nrred = 5;
        private int nrgreen = 3;

        public Form1()
        {
            // Form1 will be used for displaying statistics at the end of the Simulation             
             




            InitializeComponent();
            //this.grid = this.createDemoGrid();
            // this.pictureBoxes = new List<PictureBox>();
            //drawGrid(this.grid);
            //createTimer();
            this.Hide();
            Form f2 = new Form2();
            f2.ShowDialog();
        }

        private void createTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer(this.simulationUpdateInterval);
            timer.Elapsed += this.updateSimulation;
            timer.Enabled = true;
        }

        private void updateSimulation(object source, ElapsedEventArgs e)
        {

            this.grid.Tick(nrred,nrgreen,timesUpdated);
            drawGrid(this.grid);
            this.timesUpdated++;
            // For demo purposes I will spawn a new car with random
            // actions every 3 ticks
            if(this.timesUpdated % 3 == 0)
            {
                this.spawnDemoCar();
            }

        }

        private void drawGrid(Grid grid)
        {
            bool isFirstTime = this.pictureBoxes.Count() == 0;

            foreach(Tile tile in grid.Tiles)
            {
                if (isFirstTime)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(
                        tile.Position.X * (this.pictureBoxSize + this.pictureBoxGap), 
                        tile.Position.Y * (this.pictureBoxSize + this.pictureBoxGap)
                    );
                    pictureBox.Size = new Size(this.pictureBoxSize, this.pictureBoxSize);
                    pictureBox.BackColor = this.getTileColor(tile.Type);
                    this.pictureBoxes.Add(pictureBox);
                    this.Controls.Add(pictureBox);
                }
                else
                {
                    PictureBox pictureBox = this.pictureBoxes.Find(box =>
                        box.Location.X == tile.Position.X * (this.pictureBoxSize + this.pictureBoxGap) && 
                        box.Location.Y == tile.Position.Y * (this.pictureBoxSize + this.pictureBoxGap)
                    );
                    pictureBox.BackColor = this.getTileColor(tile.Type);
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
                    return Color.LightGray;
                // Compiler is stupid and cannot realize that
                // there is no other type, so this will
                // never happen
                default:
                    return Color.Red;
            }
        }

        // Just an example function showing how to 
        // make grids by hand
        private Grid createDemoGrid()
        {
            List<TileAction> actions = new List<TileAction>() {
               new MoveAction(Direction.Up),
               new MoveAction(Direction.Right),
               new MoveAction(Direction.Right),
               // A bug with Dirty tiles... somehow need an extra move to remove the tile
               // from the screen
               new MoveAction(Direction.Right)
            };

            List<Tile> tiles = new List<Tile>() {
                new Tile(0, 0, TileType.Grass, new List<TileAction>()),
                new Tile(1, 0, TileType.Road, new List<TileAction>()),
                new Tile(2, 0, TileType.Road, new List<TileAction>()),
                new Tile(3, 0, TileType.Grass, new List<TileAction>()),

                new Tile(0, 1, TileType.Road, new List<TileAction>()),
                new Tile(1, 1, TileType.Road, new List<TileAction>()),
                new Tile(2, 1, TileType.Road, new List<TileAction>()),
                new Tile(3, 1, TileType.Road, new List<TileAction>()),

                new Tile(0, 2, TileType.Road, new List<TileAction>()),
                new Tile(1, 2, TileType.Road, new List<TileAction>()),
                new Tile(2, 2, TileType.Road, new List<TileAction>()),
                new Tile(3, 2, TileType.Road, new List<TileAction>()),

                new Tile(0, 3, TileType.Grass, new List<TileAction>()),
                new Tile(1, 3, TileType.Road, new List<TileAction>()),
                new Tile(2, 3, TileType.Car, actions),
                new Tile(3, 3, TileType.Grass, new List<TileAction>()),
            };

            return new Grid(tiles, new SimpleTrafficRules());
        }

        // For this demo I will spawn a car with one of three hardcoded action lists.
        // For this to happen I will need to expose a function from Grid class
        // to modify a tile on the grid, which is a bad thing and should be
        // removed later when our Grid can spawn cars itself
        private void spawnDemoCar()
        {
            List<TileAction> actions;
            Random random = new Random();

            switch (random.Next(3))
            {
                case 0:
                    actions = new List<TileAction>() {
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left),
                        new MoveAction(Direction.Left)
                    };
                    break;
                case 1:
                    actions = new List<TileAction>() {
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right),
                        new MoveAction(Direction.Right)
                    };
                    break;
                default:
                case 2:
                    actions = new List<TileAction>() {
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up),
                        new MoveAction(Direction.Up)
                    };
                    break;
            }


            this.grid.UpdateTile(2, 3, TileType.Car, actions);
            this.drawGrid(this.grid);
        }
    }
    
}
