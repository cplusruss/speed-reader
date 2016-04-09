namespace SpeedReader
{
    partial class Main
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
            this.lblTextView = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWPM = new System.Windows.Forms.Label();
            this.numClusterSize = new System.Windows.Forms.NumericUpDown();
            this.numWPM = new System.Windows.Forms.NumericUpDown();
            this.chkPlayPause = new System.Windows.Forms.CheckBox();
            this.cmdOpenFile = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.trbLocation = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.numClusterSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWPM)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTextView
            // 
            this.lblTextView.BackColor = System.Drawing.Color.White;
            this.lblTextView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextView.Font = new System.Drawing.Font("Calibri Light", 111.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextView.ForeColor = System.Drawing.Color.Black;
            this.lblTextView.Location = new System.Drawing.Point(0, 0);
            this.lblTextView.Name = "lblTextView";
            this.lblTextView.Size = new System.Drawing.Size(1005, 627);
            this.lblTextView.TabIndex = 0;
            this.lblTextView.Text = "Drag text or files ...";
            this.lblTextView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(212, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ClusterSize";
            // 
            // lblWPM
            // 
            this.lblWPM.AutoSize = true;
            this.lblWPM.BackColor = System.Drawing.SystemColors.Control;
            this.lblWPM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWPM.Location = new System.Drawing.Point(102, 11);
            this.lblWPM.Name = "lblWPM";
            this.lblWPM.Size = new System.Drawing.Size(34, 13);
            this.lblWPM.TabIndex = 4;
            this.lblWPM.Text = "WPM";
            // 
            // numClusterSize
            // 
            this.numClusterSize.Location = new System.Drawing.Point(277, 5);
            this.numClusterSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numClusterSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numClusterSize.Name = "numClusterSize";
            this.numClusterSize.Size = new System.Drawing.Size(49, 20);
            this.numClusterSize.TabIndex = 3;
            this.numClusterSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numClusterSize.ValueChanged += new System.EventHandler(this.numClusterSize_ValueChanged);
            // 
            // numWPM
            // 
            this.numWPM.Location = new System.Drawing.Point(148, 6);
            this.numWPM.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWPM.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numWPM.Name = "numWPM";
            this.numWPM.Size = new System.Drawing.Size(56, 20);
            this.numWPM.TabIndex = 3;
            this.numWPM.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numWPM.ValueChanged += new System.EventHandler(this.numWPM_ValueChanged);
            // 
            // chkPlayPause
            // 
            this.chkPlayPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPlayPause.AutoSize = true;
            this.chkPlayPause.BackColor = System.Drawing.SystemColors.Control;
            this.chkPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPlayPause.ForeColor = System.Drawing.Color.Black;
            this.chkPlayPause.Location = new System.Drawing.Point(55, 3);
            this.chkPlayPause.Name = "chkPlayPause";
            this.chkPlayPause.Size = new System.Drawing.Size(41, 23);
            this.chkPlayPause.TabIndex = 2;
            this.chkPlayPause.Text = "Play";
            this.chkPlayPause.UseVisualStyleBackColor = false;
            this.chkPlayPause.CheckedChanged += new System.EventHandler(this.chkPlayPause_CheckedChanged);
            // 
            // cmdOpenFile
            // 
            this.cmdOpenFile.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenFile.ForeColor = System.Drawing.Color.Black;
            this.cmdOpenFile.Location = new System.Drawing.Point(3, 3);
            this.cmdOpenFile.Name = "cmdOpenFile";
            this.cmdOpenFile.Size = new System.Drawing.Size(46, 23);
            this.cmdOpenFile.TabIndex = 0;
            this.cmdOpenFile.Text = "Open";
            this.cmdOpenFile.UseVisualStyleBackColor = false;
            this.cmdOpenFile.Click += new System.EventHandler(this.cmdOpenFile_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Controls.Add(this.trbLocation);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.cmdOpenFile);
            this.panel.Controls.Add(this.lblWPM);
            this.panel.Controls.Add(this.chkPlayPause);
            this.panel.Controls.Add(this.numClusterSize);
            this.panel.Controls.Add(this.numWPM);
            this.panel.Location = new System.Drawing.Point(-1, 596);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1006, 31);
            this.panel.TabIndex = 3;
            // 
            // trbLocation
            // 
            this.trbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trbLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trbLocation.LargeChange = 1;
            this.trbLocation.Location = new System.Drawing.Point(332, 2);
            this.trbLocation.Name = "trbLocation";
            this.trbLocation.Size = new System.Drawing.Size(671, 42);
            this.trbLocation.TabIndex = 5;
            this.trbLocation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbLocation.Scroll += new System.EventHandler(this.trbLocation_Scroll);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1005, 627);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lblTextView);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Main";
            this.Text = "Speed Reader";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numClusterSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWPM)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTextView;
        private System.Windows.Forms.Button cmdOpenFile;
        private System.Windows.Forms.CheckBox chkPlayPause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWPM;
        private System.Windows.Forms.NumericUpDown numClusterSize;
        private System.Windows.Forms.NumericUpDown numWPM;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TrackBar trbLocation;
    }
}

