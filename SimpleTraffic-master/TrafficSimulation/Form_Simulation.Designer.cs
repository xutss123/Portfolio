namespace TrafficSimulation
{
    partial class Form_Simulation
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
            this.rbPlusIntersection = new System.Windows.Forms.RadioButton();
            this.rbTUp = new System.Windows.Forms.RadioButton();
            this.rbTDown = new System.Windows.Forms.RadioButton();
            this.rbTLeft = new System.Windows.Forms.RadioButton();
            this.rbTRight = new System.Windows.Forms.RadioButton();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblCarsSpawned = new System.Windows.Forms.Label();
            this.tbSpawnedCars = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.rbCorner1 = new System.Windows.Forms.RadioButton();
            this.rbCorner2 = new System.Windows.Forms.RadioButton();
            this.rbCorner3 = new System.Windows.Forms.RadioButton();
            this.rbCorner4 = new System.Windows.Forms.RadioButton();
            this.gbIntersections = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rbTrafficPlus = new System.Windows.Forms.RadioButton();
            this.Corner4 = new System.Windows.Forms.PictureBox();
            this.Corner2 = new System.Windows.Forms.PictureBox();
            this.Corner3 = new System.Windows.Forms.PictureBox();
            this.PlusIntersection = new System.Windows.Forms.PictureBox();
            this.TLeft = new System.Windows.Forms.PictureBox();
            this.TUp = new System.Windows.Forms.PictureBox();
            this.TrafficPlusIntersection = new System.Windows.Forms.PictureBox();
            this.TRight = new System.Windows.Forms.PictureBox();
            this.TDown = new System.Windows.Forms.PictureBox();
            this.Corner1 = new System.Windows.Forms.PictureBox();
            this.lblCarsQuit = new System.Windows.Forms.Label();
            this.tbCarsQuit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_redlight = new System.Windows.Forms.TextBox();
            this.tb_greenlight = new System.Windows.Forms.TextBox();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.tbTimeElapsed = new System.Windows.Forms.TextBox();
            this.tbTickFrequency = new System.Windows.Forms.TrackBar();
            this.gbTickFrequency = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMap = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_trafficflow = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_cars_tick = new System.Windows.Forms.TextBox();
            this.gbIntersections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Corner4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlusIntersection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficPlusIntersection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTickFrequency)).BeginInit();
            this.gbTickFrequency.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbPlusIntersection
            // 
            this.rbPlusIntersection.AutoSize = true;
            this.rbPlusIntersection.Location = new System.Drawing.Point(23, 55);
            this.rbPlusIntersection.Name = "rbPlusIntersection";
            this.rbPlusIntersection.Size = new System.Drawing.Size(14, 13);
            this.rbPlusIntersection.TabIndex = 0;
            this.rbPlusIntersection.TabStop = true;
            this.rbPlusIntersection.UseVisualStyleBackColor = true;
            // 
            // rbTUp
            // 
            this.rbTUp.AutoSize = true;
            this.rbTUp.Location = new System.Drawing.Point(23, 135);
            this.rbTUp.Name = "rbTUp";
            this.rbTUp.Size = new System.Drawing.Size(14, 13);
            this.rbTUp.TabIndex = 1;
            this.rbTUp.TabStop = true;
            this.rbTUp.UseVisualStyleBackColor = true;
            // 
            // rbTDown
            // 
            this.rbTDown.AutoSize = true;
            this.rbTDown.Location = new System.Drawing.Point(140, 135);
            this.rbTDown.Name = "rbTDown";
            this.rbTDown.Size = new System.Drawing.Size(14, 13);
            this.rbTDown.TabIndex = 2;
            this.rbTDown.TabStop = true;
            this.rbTDown.UseVisualStyleBackColor = true;
            // 
            // rbTLeft
            // 
            this.rbTLeft.AutoSize = true;
            this.rbTLeft.Location = new System.Drawing.Point(23, 217);
            this.rbTLeft.Name = "rbTLeft";
            this.rbTLeft.Size = new System.Drawing.Size(14, 13);
            this.rbTLeft.TabIndex = 3;
            this.rbTLeft.TabStop = true;
            this.rbTLeft.UseVisualStyleBackColor = true;
            // 
            // rbTRight
            // 
            this.rbTRight.AutoSize = true;
            this.rbTRight.Location = new System.Drawing.Point(140, 217);
            this.rbTRight.Name = "rbTRight";
            this.rbTRight.Size = new System.Drawing.Size(14, 13);
            this.rbTRight.TabIndex = 4;
            this.rbTRight.TabStop = true;
            this.rbTRight.UseVisualStyleBackColor = true;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(1069, 629);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(2);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(56, 19);
            this.btnLaunch.TabIndex = 5;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(1139, 629);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(56, 19);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblCarsSpawned
            // 
            this.lblCarsSpawned.AutoSize = true;
            this.lblCarsSpawned.Location = new System.Drawing.Point(1121, 658);
            this.lblCarsSpawned.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarsSpawned.Name = "lblCarsSpawned";
            this.lblCarsSpawned.Size = new System.Drawing.Size(79, 13);
            this.lblCarsSpawned.TabIndex = 7;
            this.lblCarsSpawned.Text = "Cars Spawned:";
            // 
            // tbSpawnedCars
            // 
            this.tbSpawnedCars.Location = new System.Drawing.Point(1204, 655);
            this.tbSpawnedCars.Margin = new System.Windows.Forms.Padding(2);
            this.tbSpawnedCars.Name = "tbSpawnedCars";
            this.tbSpawnedCars.ReadOnly = true;
            this.tbSpawnedCars.Size = new System.Drawing.Size(57, 20);
            this.tbSpawnedCars.TabIndex = 8;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(104, 437);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 9;
            this.btn_Clear.Text = "Clear Grid";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // rbCorner1
            // 
            this.rbCorner1.AutoSize = true;
            this.rbCorner1.Location = new System.Drawing.Point(23, 379);
            this.rbCorner1.Name = "rbCorner1";
            this.rbCorner1.Size = new System.Drawing.Size(14, 13);
            this.rbCorner1.TabIndex = 10;
            this.rbCorner1.TabStop = true;
            this.rbCorner1.UseVisualStyleBackColor = true;
            // 
            // rbCorner2
            // 
            this.rbCorner2.AutoSize = true;
            this.rbCorner2.Location = new System.Drawing.Point(140, 299);
            this.rbCorner2.Name = "rbCorner2";
            this.rbCorner2.Size = new System.Drawing.Size(14, 13);
            this.rbCorner2.TabIndex = 11;
            this.rbCorner2.TabStop = true;
            this.rbCorner2.UseVisualStyleBackColor = true;
            // 
            // rbCorner3
            // 
            this.rbCorner3.AutoSize = true;
            this.rbCorner3.Location = new System.Drawing.Point(23, 296);
            this.rbCorner3.Name = "rbCorner3";
            this.rbCorner3.Size = new System.Drawing.Size(14, 13);
            this.rbCorner3.TabIndex = 12;
            this.rbCorner3.TabStop = true;
            this.rbCorner3.UseVisualStyleBackColor = true;
            // 
            // rbCorner4
            // 
            this.rbCorner4.AutoSize = true;
            this.rbCorner4.Location = new System.Drawing.Point(140, 379);
            this.rbCorner4.Name = "rbCorner4";
            this.rbCorner4.Size = new System.Drawing.Size(14, 13);
            this.rbCorner4.TabIndex = 13;
            this.rbCorner4.TabStop = true;
            this.rbCorner4.UseVisualStyleBackColor = true;
            // 
            // gbIntersections
            // 
            this.gbIntersections.Controls.Add(this.btnLoad);
            this.gbIntersections.Controls.Add(this.btnSave);
            this.gbIntersections.Controls.Add(this.rbTrafficPlus);
            this.gbIntersections.Controls.Add(this.btn_Clear);
            this.gbIntersections.Controls.Add(this.Corner4);
            this.gbIntersections.Controls.Add(this.rbCorner4);
            this.gbIntersections.Controls.Add(this.Corner2);
            this.gbIntersections.Controls.Add(this.Corner3);
            this.gbIntersections.Controls.Add(this.rbCorner1);
            this.gbIntersections.Controls.Add(this.PlusIntersection);
            this.gbIntersections.Controls.Add(this.TLeft);
            this.gbIntersections.Controls.Add(this.TUp);
            this.gbIntersections.Controls.Add(this.TrafficPlusIntersection);
            this.gbIntersections.Controls.Add(this.rbCorner3);
            this.gbIntersections.Controls.Add(this.TRight);
            this.gbIntersections.Controls.Add(this.rbCorner2);
            this.gbIntersections.Controls.Add(this.TDown);
            this.gbIntersections.Controls.Add(this.Corner1);
            this.gbIntersections.Controls.Add(this.rbTRight);
            this.gbIntersections.Controls.Add(this.rbPlusIntersection);
            this.gbIntersections.Controls.Add(this.rbTLeft);
            this.gbIntersections.Controls.Add(this.rbTUp);
            this.gbIntersections.Controls.Add(this.rbTDown);
            this.gbIntersections.Location = new System.Drawing.Point(1021, 12);
            this.gbIntersections.Name = "gbIntersections";
            this.gbIntersections.Size = new System.Drawing.Size(257, 497);
            this.gbIntersections.TabIndex = 14;
            this.gbIntersections.TabStop = false;
            this.gbIntersections.Text = "Interections";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(142, 466);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(61, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbTrafficPlus
            // 
            this.rbTrafficPlus.AutoSize = true;
            this.rbTrafficPlus.Location = new System.Drawing.Point(142, 55);
            this.rbTrafficPlus.Name = "rbTrafficPlus";
            this.rbTrafficPlus.Size = new System.Drawing.Size(14, 13);
            this.rbTrafficPlus.TabIndex = 14;
            this.rbTrafficPlus.TabStop = true;
            this.rbTrafficPlus.UseVisualStyleBackColor = true;
            // 
            // Corner4
            // 
            this.Corner4.Location = new System.Drawing.Point(160, 347);
            this.Corner4.Name = "Corner4";
            this.Corner4.Size = new System.Drawing.Size(80, 74);
            this.Corner4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Corner4.TabIndex = 9;
            this.Corner4.TabStop = false;
            // 
            // Corner2
            // 
            this.Corner2.Location = new System.Drawing.Point(160, 264);
            this.Corner2.Name = "Corner2";
            this.Corner2.Size = new System.Drawing.Size(80, 74);
            this.Corner2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Corner2.TabIndex = 8;
            this.Corner2.TabStop = false;
            // 
            // Corner3
            // 
            this.Corner3.Location = new System.Drawing.Point(43, 347);
            this.Corner3.Name = "Corner3";
            this.Corner3.Size = new System.Drawing.Size(80, 74);
            this.Corner3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Corner3.TabIndex = 0;
            this.Corner3.TabStop = false;
            // 
            // PlusIntersection
            // 
            this.PlusIntersection.Location = new System.Drawing.Point(43, 19);
            this.PlusIntersection.Name = "PlusIntersection";
            this.PlusIntersection.Size = new System.Drawing.Size(80, 74);
            this.PlusIntersection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlusIntersection.TabIndex = 4;
            this.PlusIntersection.TabStop = false;
            // 
            // TLeft
            // 
            this.TLeft.Location = new System.Drawing.Point(43, 184);
            this.TLeft.Name = "TLeft";
            this.TLeft.Size = new System.Drawing.Size(80, 74);
            this.TLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TLeft.TabIndex = 2;
            this.TLeft.TabStop = false;
            // 
            // TUp
            // 
            this.TUp.Location = new System.Drawing.Point(43, 101);
            this.TUp.Name = "TUp";
            this.TUp.Size = new System.Drawing.Size(80, 74);
            this.TUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TUp.TabIndex = 3;
            this.TUp.TabStop = false;
            // 
            // TrafficPlusIntersection
            // 
            this.TrafficPlusIntersection.Location = new System.Drawing.Point(160, 19);
            this.TrafficPlusIntersection.Name = "TrafficPlusIntersection";
            this.TrafficPlusIntersection.Size = new System.Drawing.Size(80, 73);
            this.TrafficPlusIntersection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TrafficPlusIntersection.TabIndex = 5;
            this.TrafficPlusIntersection.TabStop = false;
            // 
            // TRight
            // 
            this.TRight.Location = new System.Drawing.Point(160, 184);
            this.TRight.Name = "TRight";
            this.TRight.Size = new System.Drawing.Size(80, 74);
            this.TRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TRight.TabIndex = 7;
            this.TRight.TabStop = false;
            // 
            // TDown
            // 
            this.TDown.Location = new System.Drawing.Point(160, 101);
            this.TDown.Name = "TDown";
            this.TDown.Size = new System.Drawing.Size(80, 74);
            this.TDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TDown.TabIndex = 6;
            this.TDown.TabStop = false;
            // 
            // Corner1
            // 
            this.Corner1.Location = new System.Drawing.Point(43, 264);
            this.Corner1.Name = "Corner1";
            this.Corner1.Size = new System.Drawing.Size(80, 74);
            this.Corner1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Corner1.TabIndex = 1;
            this.Corner1.TabStop = false;
            // 
            // lblCarsQuit
            // 
            this.lblCarsQuit.AutoSize = true;
            this.lblCarsQuit.Location = new System.Drawing.Point(1065, 686);
            this.lblCarsQuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarsQuit.Name = "lblCarsQuit";
            this.lblCarsQuit.Size = new System.Drawing.Size(135, 13);
            this.lblCarsQuit.TabIndex = 7;
            this.lblCarsQuit.Text = "Cars Arrived at Destination:";
            // 
            // tbCarsQuit
            // 
            this.tbCarsQuit.Location = new System.Drawing.Point(1203, 679);
            this.tbCarsQuit.Margin = new System.Windows.Forms.Padding(2);
            this.tbCarsQuit.Name = "tbCarsQuit";
            this.tbCarsQuit.ReadOnly = true;
            this.tbCarsQuit.Size = new System.Drawing.Size(57, 20);
            this.tbCarsQuit.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1064, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Red light time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1064, 544);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Green light time";
            // 
            // tb_redlight
            // 
            this.tb_redlight.Location = new System.Drawing.Point(1150, 515);
            this.tb_redlight.Name = "tb_redlight";
            this.tb_redlight.Size = new System.Drawing.Size(50, 20);
            this.tb_redlight.TabIndex = 17;
            this.tb_redlight.TextChanged += new System.EventHandler(this.tb_redlight_TextChanged);
            // 
            // tb_greenlight
            // 
            this.tb_greenlight.Location = new System.Drawing.Point(1150, 541);
            this.tb_greenlight.Name = "tb_greenlight";
            this.tb_greenlight.Size = new System.Drawing.Size(50, 20);
            this.tb_greenlight.TabIndex = 18;
            this.tb_greenlight.TextChanged += new System.EventHandler(this.tb_greenlight_TextChanged);
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Location = new System.Drawing.Point(1042, 706);
            this.lblTimeElapsed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(158, 13);
            this.lblTimeElapsed.TabIndex = 7;
            this.lblTimeElapsed.Text = "Simulation has been running for:";
            // 
            // tbTimeElapsed
            // 
            this.tbTimeElapsed.Location = new System.Drawing.Point(1204, 703);
            this.tbTimeElapsed.Margin = new System.Windows.Forms.Padding(2);
            this.tbTimeElapsed.Name = "tbTimeElapsed";
            this.tbTimeElapsed.ReadOnly = true;
            this.tbTimeElapsed.Size = new System.Drawing.Size(57, 20);
            this.tbTimeElapsed.TabIndex = 8;
            // 
            // tbTickFrequency
            // 
            this.tbTickFrequency.LargeChange = 1;
            this.tbTickFrequency.Location = new System.Drawing.Point(6, 19);
            this.tbTickFrequency.Maximum = 6;
            this.tbTickFrequency.Name = "tbTickFrequency";
            this.tbTickFrequency.Size = new System.Drawing.Size(234, 45);
            this.tbTickFrequency.TabIndex = 19;
            this.tbTickFrequency.Value = 2;
            this.tbTickFrequency.Scroll += new System.EventHandler(this.tbTickFrequency_Scroll);
            // 
            // gbTickFrequency
            // 
            this.gbTickFrequency.Controls.Add(this.label10);
            this.gbTickFrequency.Controls.Add(this.label9);
            this.gbTickFrequency.Controls.Add(this.label8);
            this.gbTickFrequency.Controls.Add(this.label7);
            this.gbTickFrequency.Controls.Add(this.label6);
            this.gbTickFrequency.Controls.Add(this.label5);
            this.gbTickFrequency.Controls.Add(this.label4);
            this.gbTickFrequency.Controls.Add(this.label1);
            this.gbTickFrequency.Controls.Add(this.tbTickFrequency);
            this.gbTickFrequency.Location = new System.Drawing.Point(1021, 736);
            this.gbTickFrequency.Name = "gbTickFrequency";
            this.gbTickFrequency.Size = new System.Drawing.Size(257, 145);
            this.gbTickFrequency.TabIndex = 20;
            this.gbTickFrequency.TabStop = false;
            this.gbTickFrequency.Text = "Ticks/Second";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(249, 39);
            this.label10.TabIndex = 21;
            this.label10.Text = "Warning: Setting this value to 5 or more ticks per\r\nsecond will cause the cars to" +
    " be replaced by black \r\nsquares so that the simulation can run smoothly";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "20";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "0.5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "0.25";
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(1201, 627);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 23);
            this.btnMap.TabIndex = 21;
            this.btnMap.Text = "HeatMap";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1068, 569);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Traffic Flow";
            // 
            // tb_trafficflow
            // 
            this.tb_trafficflow.Location = new System.Drawing.Point(1150, 568);
            this.tb_trafficflow.Name = "tb_trafficflow";
            this.tb_trafficflow.Size = new System.Drawing.Size(50, 20);
            this.tb_trafficflow.TabIndex = 23;
            this.tb_trafficflow.TextChanged += new System.EventHandler(this.tb_trafficflow_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1068, 593);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Cars/Tick";
            // 
            // tb_cars_tick
            // 
            this.tb_cars_tick.Location = new System.Drawing.Point(1150, 595);
            this.tb_cars_tick.Name = "tb_cars_tick";
            this.tb_cars_tick.Size = new System.Drawing.Size(50, 20);
            this.tb_cars_tick.TabIndex = 25;
            this.tb_cars_tick.TextChanged += new System.EventHandler(this.tb_cars_tick_TextChanged);
            // 
            // Form_Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 881);
            this.Controls.Add(this.tb_cars_tick);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tb_trafficflow);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.gbTickFrequency);
            this.Controls.Add(this.tb_greenlight);
            this.Controls.Add(this.tb_redlight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbIntersections);
            this.Controls.Add(this.tbCarsQuit);
            this.Controls.Add(this.tbTimeElapsed);
            this.Controls.Add(this.tbSpawnedCars);
            this.Controls.Add(this.lblCarsQuit);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.lblCarsSpawned);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLaunch);
            this.Name = "Form_Simulation";
            this.Text = "Simulation";
            this.gbIntersections.ResumeLayout(false);
            this.gbIntersections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Corner4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlusIntersection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficPlusIntersection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Corner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTickFrequency)).EndInit();
            this.gbTickFrequency.ResumeLayout(false);
            this.gbTickFrequency.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbPlusIntersection;
        private System.Windows.Forms.RadioButton rbTUp;
        private System.Windows.Forms.RadioButton rbTDown;
        private System.Windows.Forms.RadioButton rbTLeft;
        private System.Windows.Forms.RadioButton rbTRight;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblCarsSpawned;
        private System.Windows.Forms.TextBox tbSpawnedCars;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.RadioButton rbCorner1;
        private System.Windows.Forms.RadioButton rbCorner2;
        private System.Windows.Forms.RadioButton rbCorner3;
        private System.Windows.Forms.RadioButton rbCorner4;
        private System.Windows.Forms.GroupBox gbIntersections;
        private System.Windows.Forms.RadioButton rbTrafficPlus;
        private System.Windows.Forms.PictureBox Corner4;
        private System.Windows.Forms.PictureBox Corner2;
        private System.Windows.Forms.PictureBox TRight;
        private System.Windows.Forms.PictureBox TDown;
        private System.Windows.Forms.PictureBox TrafficPlusIntersection;
        private System.Windows.Forms.PictureBox PlusIntersection;
        private System.Windows.Forms.PictureBox TUp;
        private System.Windows.Forms.PictureBox TLeft;
        private System.Windows.Forms.PictureBox Corner1;
        private System.Windows.Forms.PictureBox Corner3;
        private System.Windows.Forms.Label lblCarsQuit;
        private System.Windows.Forms.TextBox tbCarsQuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_redlight;
        private System.Windows.Forms.TextBox tb_greenlight;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.TextBox tbTimeElapsed;
        private System.Windows.Forms.TrackBar tbTickFrequency;
        private System.Windows.Forms.GroupBox gbTickFrequency;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_trafficflow;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_cars_tick;
    }
}