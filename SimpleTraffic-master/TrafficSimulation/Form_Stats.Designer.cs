namespace TrafficSimulation
{
    partial class Form_Stats
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCarsSpawned = new System.Windows.Forms.Label();
            this.tbCarsSpawned = new System.Windows.Forms.TextBox();
            this.tbCarsQuit = new System.Windows.Forms.TextBox();
            this.lblCarsQuit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_timeran = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCarsSpawned
            // 
            this.lblCarsSpawned.AutoSize = true;
            this.lblCarsSpawned.Location = new System.Drawing.Point(81, 37);
            this.lblCarsSpawned.Name = "lblCarsSpawned";
            this.lblCarsSpawned.Size = new System.Drawing.Size(79, 13);
            this.lblCarsSpawned.TabIndex = 0;
            this.lblCarsSpawned.Text = "Cars Spawned:";
            // 
            // tbCarsSpawned
            // 
            this.tbCarsSpawned.Location = new System.Drawing.Point(164, 34);
            this.tbCarsSpawned.Name = "tbCarsSpawned";
            this.tbCarsSpawned.ReadOnly = true;
            this.tbCarsSpawned.Size = new System.Drawing.Size(52, 20);
            this.tbCarsSpawned.TabIndex = 1;
            // 
            // tbCarsQuit
            // 
            this.tbCarsQuit.Location = new System.Drawing.Point(164, 68);
            this.tbCarsQuit.Margin = new System.Windows.Forms.Padding(2);
            this.tbCarsQuit.Name = "tbCarsQuit";
            this.tbCarsQuit.ReadOnly = true;
            this.tbCarsQuit.Size = new System.Drawing.Size(52, 20);
            this.tbCarsQuit.TabIndex = 10;
            // 
            // lblCarsQuit
            // 
            this.lblCarsQuit.AutoSize = true;
            this.lblCarsQuit.Location = new System.Drawing.Point(25, 71);
            this.lblCarsQuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarsQuit.Name = "lblCarsQuit";
            this.lblCarsQuit.Size = new System.Drawing.Size(135, 13);
            this.lblCarsQuit.TabIndex = 9;
            this.lblCarsQuit.Text = "Cars Arrived at Destination:";
            this.lblCarsQuit.Click += new System.EventHandler(this.lblCarsQuit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Simulation ran for:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_timeran
            // 
            this.tb_timeran.Location = new System.Drawing.Point(164, 100);
            this.tb_timeran.Margin = new System.Windows.Forms.Padding(2);
            this.tb_timeran.Name = "tb_timeran";
            this.tb_timeran.ReadOnly = true;
            this.tb_timeran.Size = new System.Drawing.Size(52, 20);
            this.tb_timeran.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 182);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_timeran);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCarsQuit);
            this.Controls.Add(this.lblCarsQuit);
            this.Controls.Add(this.tbCarsSpawned);
            this.Controls.Add(this.lblCarsSpawned);
            this.Name = "Form_Stats";
            this.Text = "Statistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCarsSpawned;
        private System.Windows.Forms.TextBox tbCarsSpawned;
        private System.Windows.Forms.TextBox tbCarsQuit;
        private System.Windows.Forms.Label lblCarsQuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_timeran;
        private System.Windows.Forms.Button button1;
    }
}

