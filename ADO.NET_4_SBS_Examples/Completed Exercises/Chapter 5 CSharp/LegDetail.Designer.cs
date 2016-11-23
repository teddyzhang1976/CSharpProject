namespace Chapter_5_CSharp
{
    partial class LegDetail
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
            this.LabelEndCity = new System.Windows.Forms.Label();
            this.EndCity = new System.Windows.Forms.TextBox();
            this.ParentFlightID = new System.Windows.Forms.Label();
            this.LabelParentID = new System.Windows.Forms.Label();
            this.ActCancel = new System.Windows.Forms.Button();
            this.ActOK = new System.Windows.Forms.Button();
            this.LabelDistance = new System.Windows.Forms.Label();
            this.LabelStartCity = new System.Windows.Forms.Label();
            this.FlightDistance = new System.Windows.Forms.NumericUpDown();
            this.StartCity = new System.Windows.Forms.TextBox();
            this.LabelID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FlightID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlightDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // FlightID
            // 
            this.FlightID.Location = new System.Drawing.Point(96, 32);
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
            this.FlightID.TabIndex = 3;
            this.FlightID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelEndCity
            // 
            this.LabelEndCity.AutoSize = true;
            this.LabelEndCity.Location = new System.Drawing.Point(8, 82);
            this.LabelEndCity.Name = "LabelEndCity";
            this.LabelEndCity.Size = new System.Drawing.Size(49, 13);
            this.LabelEndCity.TabIndex = 6;
            this.LabelEndCity.Text = "&End City:";
            // 
            // EndCity
            // 
            this.EndCity.Location = new System.Drawing.Point(96, 80);
            this.EndCity.Name = "EndCity";
            this.EndCity.Size = new System.Drawing.Size(168, 20);
            this.EndCity.TabIndex = 7;
            this.EndCity.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // ParentFlightID
            // 
            this.ParentFlightID.AutoSize = true;
            this.ParentFlightID.Location = new System.Drawing.Point(96, 10);
            this.ParentFlightID.Name = "ParentFlightID";
            this.ParentFlightID.Size = new System.Drawing.Size(64, 13);
            this.ParentFlightID.TabIndex = 1;
            this.ParentFlightID.Text = "Not Defined";
            // 
            // LabelParentID
            // 
            this.LabelParentID.AutoSize = true;
            this.LabelParentID.Location = new System.Drawing.Point(8, 10);
            this.LabelParentID.Name = "LabelParentID";
            this.LabelParentID.Size = new System.Drawing.Size(79, 13);
            this.LabelParentID.TabIndex = 0;
            this.LabelParentID.Text = "Flight Table ID:";
            // 
            // ActCancel
            // 
            this.ActCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActCancel.Location = new System.Drawing.Point(190, 136);
            this.ActCancel.Name = "ActCancel";
            this.ActCancel.Size = new System.Drawing.Size(75, 23);
            this.ActCancel.TabIndex = 11;
            this.ActCancel.Text = "Cancel";
            this.ActCancel.UseVisualStyleBackColor = true;
            // 
            // ActOK
            // 
            this.ActOK.Location = new System.Drawing.Point(110, 136);
            this.ActOK.Name = "ActOK";
            this.ActOK.Size = new System.Drawing.Size(75, 23);
            this.ActOK.TabIndex = 10;
            this.ActOK.Text = "OK";
            this.ActOK.UseVisualStyleBackColor = true;
            this.ActOK.Click += new System.EventHandler(this.ActOK_Click);
            // 
            // LabelDistance
            // 
            this.LabelDistance.AutoSize = true;
            this.LabelDistance.Location = new System.Drawing.Point(8, 106);
            this.LabelDistance.Name = "LabelDistance";
            this.LabelDistance.Size = new System.Drawing.Size(52, 13);
            this.LabelDistance.TabIndex = 8;
            this.LabelDistance.Text = "&Distance:";
            // 
            // LabelStartCity
            // 
            this.LabelStartCity.AutoSize = true;
            this.LabelStartCity.Location = new System.Drawing.Point(8, 58);
            this.LabelStartCity.Name = "LabelStartCity";
            this.LabelStartCity.Size = new System.Drawing.Size(52, 13);
            this.LabelStartCity.TabIndex = 4;
            this.LabelStartCity.Text = "&Start City:";
            // 
            // FlightDistance
            // 
            this.FlightDistance.Location = new System.Drawing.Point(96, 104);
            this.FlightDistance.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.FlightDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FlightDistance.Name = "FlightDistance";
            this.FlightDistance.Size = new System.Drawing.Size(168, 20);
            this.FlightDistance.TabIndex = 9;
            this.FlightDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // StartCity
            // 
            this.StartCity.Location = new System.Drawing.Point(96, 56);
            this.StartCity.Name = "StartCity";
            this.StartCity.Size = new System.Drawing.Size(168, 20);
            this.StartCity.TabIndex = 5;
            this.StartCity.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelID
            // 
            this.LabelID.AutoSize = true;
            this.LabelID.Location = new System.Drawing.Point(8, 34);
            this.LabelID.Name = "LabelID";
            this.LabelID.Size = new System.Drawing.Size(49, 13);
            this.LabelID.TabIndex = 2;
            this.LabelID.Text = "Flight &ID:";
            // 
            // LegDetail
            // 
            this.AcceptButton = this.ActOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActCancel;
            this.ClientSize = new System.Drawing.Size(272, 169);
            this.ControlBox = false;
            this.Controls.Add(this.FlightID);
            this.Controls.Add(this.LabelEndCity);
            this.Controls.Add(this.EndCity);
            this.Controls.Add(this.ParentFlightID);
            this.Controls.Add(this.LabelParentID);
            this.Controls.Add(this.ActCancel);
            this.Controls.Add(this.ActOK);
            this.Controls.Add(this.LabelDistance);
            this.Controls.Add(this.LabelStartCity);
            this.Controls.Add(this.FlightDistance);
            this.Controls.Add(this.StartCity);
            this.Controls.Add(this.LabelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LegDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 5 - Edit Leg";
            ((System.ComponentModel.ISupportInitialize)(this.FlightID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlightDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown FlightID;
        internal System.Windows.Forms.Label LabelEndCity;
        internal System.Windows.Forms.TextBox EndCity;
        internal System.Windows.Forms.Label ParentFlightID;
        internal System.Windows.Forms.Label LabelParentID;
        internal System.Windows.Forms.Button ActCancel;
        internal System.Windows.Forms.Button ActOK;
        internal System.Windows.Forms.Label LabelDistance;
        internal System.Windows.Forms.Label LabelStartCity;
        internal System.Windows.Forms.NumericUpDown FlightDistance;
        internal System.Windows.Forms.TextBox StartCity;
        internal System.Windows.Forms.Label LabelID;
    }
}