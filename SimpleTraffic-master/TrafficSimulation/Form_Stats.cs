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
    public partial class Form_Stats : Form
    {

        private int carsSpawned;
        private int carsQuit;
        private TimeSpan time;

        public Form_Stats(int carsspawned, int carsquit, TimeSpan ts)
        {
            InitializeComponent();
            carsSpawned = carsspawned;
            carsQuit = carsquit;
            time = ts;
            tbCarsSpawned.Text = carsspawned.ToString();
            tbCarsQuit.Text = carsquit.ToString();
            if (ts != null)
            {
                tb_timeran.Text = ts.ToString(@"hh\:mm\:ss");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using(System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        file.WriteLine("Cars spawned: " + carsSpawned.ToString());
                        file.WriteLine("Cars arrived at destination: " + carsQuit.ToString());
                        file.WriteLine("Simulation ran for: " + time.ToString(@"hh\:mm\:ss"));
                    }
                    MessageBox.Show("Statistics were successfully saved!");
                }
            }
            catch
            {
            }
        }

        private void lblCarsQuit_Click(object sender, EventArgs e)
        {

        }
    }
}
