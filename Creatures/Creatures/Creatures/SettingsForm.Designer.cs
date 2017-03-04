namespace Creatures
{
    partial class SettingsForm
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
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonAbort = new System.Windows.Forms.Button();
            this.CBrfov = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AmountM = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.AmountG = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.AmountP = new System.Windows.Forms.NumericUpDown();
            this.AmountF = new System.Windows.Forms.NumericUpDown();
            this.AmountC = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.SpeedBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBrci = new System.Windows.Forms.CheckBox();
            this.CBmusic = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(321, 349);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 0;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonAbort
            // 
            this.ButtonAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonAbort.Location = new System.Drawing.Point(240, 349);
            this.ButtonAbort.Name = "ButtonAbort";
            this.ButtonAbort.Size = new System.Drawing.Size(75, 23);
            this.ButtonAbort.TabIndex = 1;
            this.ButtonAbort.Text = "Abort";
            this.ButtonAbort.UseVisualStyleBackColor = true;
            this.ButtonAbort.Click += new System.EventHandler(this.ButtonAbort_Click);
            // 
            // CBrfov
            // 
            this.CBrfov.AutoSize = true;
            this.CBrfov.Location = new System.Drawing.Point(9, 95);
            this.CBrfov.Name = "CBrfov";
            this.CBrfov.Size = new System.Drawing.Size(125, 17);
            this.CBrfov.TabIndex = 2;
            this.CBrfov.Text = "Render fields of view";
            this.CBrfov.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AmountM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.AmountG);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.AmountP);
            this.groupBox1.Controls.Add(this.AmountF);
            this.groupBox1.Controls.Add(this.AmountC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ButtonStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 182);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start a simulation with new parameters";
            // 
            // AmountM
            // 
            this.AmountM.Location = new System.Drawing.Point(112, 75);
            this.AmountM.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AmountM.Name = "AmountM";
            this.AmountM.Size = new System.Drawing.Size(266, 20);
            this.AmountM.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mutation (%):";
            // 
            // AmountG
            // 
            this.AmountG.Location = new System.Drawing.Point(112, 49);
            this.AmountG.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AmountG.Name = "AmountG";
            this.AmountG.Size = new System.Drawing.Size(266, 20);
            this.AmountG.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "New generation at: ";
            // 
            // AmountP
            // 
            this.AmountP.Location = new System.Drawing.Point(112, 127);
            this.AmountP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AmountP.Name = "AmountP";
            this.AmountP.Size = new System.Drawing.Size(266, 20);
            this.AmountP.TabIndex = 7;
            // 
            // AmountF
            // 
            this.AmountF.Location = new System.Drawing.Point(112, 101);
            this.AmountF.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AmountF.Name = "AmountF";
            this.AmountF.Size = new System.Drawing.Size(266, 20);
            this.AmountF.TabIndex = 6;
            // 
            // AmountC
            // 
            this.AmountC.Location = new System.Drawing.Point(112, 24);
            this.AmountC.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AmountC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmountC.Name = "AmountC";
            this.AmountC.Size = new System.Drawing.Size(266, 20);
            this.AmountC.TabIndex = 5;
            this.AmountC.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Poison amount: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Food amount: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Creature amount: ";
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(303, 153);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonStart.TabIndex = 1;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // SpeedBar
            // 
            this.SpeedBar.Location = new System.Drawing.Point(6, 32);
            this.SpeedBar.Minimum = 1;
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Size = new System.Drawing.Size(372, 45);
            this.SpeedBar.TabIndex = 4;
            this.SpeedBar.Value = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Simulation speed:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CBmusic);
            this.groupBox2.Controls.Add(this.CBrci);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CBrfov);
            this.groupBox2.Controls.Add(this.SpeedBar);
            this.groupBox2.Location = new System.Drawing.Point(12, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 143);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General settings";
            // 
            // CBrci
            // 
            this.CBrci.AutoSize = true;
            this.CBrci.Location = new System.Drawing.Point(9, 118);
            this.CBrci.Name = "CBrci";
            this.CBrci.Size = new System.Drawing.Size(157, 17);
            this.CBrci.TabIndex = 6;
            this.CBrci.Text = "Render creature information";
            this.CBrci.UseVisualStyleBackColor = true;
            // 
            // CBmusic
            // 
            this.CBmusic.AutoSize = true;
            this.CBmusic.Location = new System.Drawing.Point(9, 72);
            this.CBmusic.Name = "CBmusic";
            this.CBmusic.Size = new System.Drawing.Size(76, 17);
            this.CBmusic.TabIndex = 7;
            this.CBmusic.Text = "Play music";
            this.CBmusic.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonAbort;
            this.ClientSize = new System.Drawing.Size(409, 383);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonAbort);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Creatures - Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonAbort;
        private System.Windows.Forms.CheckBox CBrfov;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown AmountG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown AmountP;
        private System.Windows.Forms.NumericUpDown AmountF;
        private System.Windows.Forms.NumericUpDown AmountC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.NumericUpDown AmountM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar SpeedBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CBmusic;
        private System.Windows.Forms.CheckBox CBrci;
    }
}