namespace Chapter_5_CSharp
{
    partial class FlightDetail
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
            this.FlightID = new System.Windows.Forms.NumericUpDown();
            this.ActCancel = new System.Windows.Forms.Button();
            this.ActOK = new System.Windows.Forms.Button();
            this.LabelPerWeek = new System.Windows.Forms.Label();
            this.LabelRegion = new System.Windows.Forms.Label();
            this.FlightsPerWeek = new System.Windows.Forms.NumericUpDown();
            this.RegionName = new System.Windows.Forms.TextBox();
            this.LabelFlightID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FlightID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlightsPerWeek)).BeginInit();
            this.SuspendLayout();
            // 
            // FlightID
            // 
            this.FlightID.Location = new System.Drawing.Point(104, 8);
            this.FlightID.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.FlightID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FlightID.Name = "FlightID";
            this.FlightID.Size = new System.Drawing.Size(168, 20);
            this.FlightID.TabIndex = 1;
            this.FlightID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ActCancel
            // 
            this.ActCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActCancel.Location = new System.Drawing.Point(198, 88);
            this.ActCancel.Name = "ActCancel";
            this.ActCancel.Size = new System.Drawing.Size(75, 23);
            this.ActCancel.TabIndex = 7;
            this.ActCancel.Text = "Cancel";
            this.ActCancel.UseVisualStyleBackColor = true;
            // 
            // ActOK
            // 
            this.ActOK.Location = new System.Drawing.Point(118, 88);
            this.ActOK.Name = "ActOK";
            this.ActOK.Size = new System.Drawing.Size(75, 23);
            this.ActOK.TabIndex = 6;
            this.ActOK.Text = "OK";
            this.ActOK.UseVisualStyleBackColor = true;
            this.ActOK.Click += new System.EventHandler(this.ActOK_Click);
            // 
            // LabelPerWeek
            // 
            this.LabelPerWeek.AutoSize = true;
            this.LabelPerWeek.Location = new System.Drawing.Point(8, 58);
            this.LabelPerWeek.Name = "LabelPerWeek";
            this.LabelPerWeek.Size = new System.Drawing.Size(90, 13);
            this.LabelPerWeek.TabIndex = 4;
            this.LabelPerWeek.Text = "Flights per &Week:";
            // 
            // LabelRegion
            // 
            this.LabelRegion.AutoSize = true;
            this.LabelRegion.Location = new System.Drawing.Point(8, 34);
            this.LabelRegion.Name = "LabelRegion";
            this.LabelRegion.Size = new System.Drawing.Size(77, 13);
            this.LabelRegion.TabIndex = 2;
            this.LabelRegion.Text = "&Region / Area:";
            // 
            // FlightsPerWeek
            // 
            this.FlightsPerWeek.Location = new System.Drawing.Point(104, 56);
            this.FlightsPerWeek.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.FlightsPerWeek.Name = "FlightsPerWeek";
            this.FlightsPerWeek.Size = new System.Drawing.Size(168, 20);
            this.FlightsPerWeek.TabIndex = 5;
            this.FlightsPerWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RegionName
            // 
            this.RegionName.Location = new System.Drawing.Point(104, 32);
            this.RegionName.Name = "RegionName";
            this.RegionName.Size = new System.Drawing.Size(168, 20);
            this.RegionName.TabIndex = 3;
            this.RegionName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelFlightID
            // 
            this.LabelFlightID.AutoSize = true;
            this.LabelFlightID.Location = new System.Drawing.Point(8, 10);
            this.LabelFlightID.Name = "LabelFlightID";
            this.LabelFlightID.Size = new System.Drawing.Size(49, 13);
            this.LabelFlightID.TabIndex = 0;
            this.LabelFlightID.Text = "Flight &ID:";
            // 
            // FlightDetail
            // 
            this.AcceptButton = this.ActOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActCancel;
            this.ClientSize = new System.Drawing.Size(281, 119);
            this.ControlBox = false;
            this.Controls.Add(this.FlightID);
            this.Controls.Add(this.ActCancel);
            this.Controls.Add(this.ActOK);
            this.Controls.Add(this.LabelPerWeek);
            this.Controls.Add(this.LabelRegion);
            this.Controls.Add(this.FlightsPerWeek);
            this.Controls.Add(this.RegionName);
            this.Controls.Add(this.LabelFlightID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FlightDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 5 - Edit Flight";
            ((System.ComponentModel.ISupportInitialize)(this.FlightID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlightsPerWeek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown FlightID;
        internal System.Windows.Forms.Button ActCancel;
        internal System.Windows.Forms.Button ActOK;
        internal System.Windows.Forms.Label LabelPerWeek;
        internal System.Windows.Forms.Label LabelRegion;
        internal System.Windows.Forms.NumericUpDown FlightsPerWeek;
        internal System.Windows.Forms.TextBox RegionName;
        internal System.Windows.Forms.Label LabelFlightID;
    }
}