namespace Chapter_5_CSharp
{
    partial class FlightInfo
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
            this.EnforceConstraints = new System.Windows.Forms.CheckBox();
            this.LabelDeleteRule = new System.Windows.Forms.Label();
            this.LabelUpdateRule = new System.Windows.Forms.Label();
            this.DeleteRule = new System.Windows.Forms.ComboBox();
            this.UpdateRule = new System.Windows.Forms.ComboBox();
            this.ActResetAll = new System.Windows.Forms.Button();
            this.ActLegDelete = new System.Windows.Forms.Button();
            this.ActLegEdit = new System.Windows.Forms.Button();
            this.ActLegAdd = new System.Windows.Forms.Button();
            this.ActFlightDelete = new System.Windows.Forms.Button();
            this.ActFlightEdit = new System.Windows.Forms.Button();
            this.ActFlightAdd = new System.Windows.Forms.Button();
            this.LabelLegs = new System.Windows.Forms.Label();
            this.LegView = new System.Windows.Forms.DataGridView();
            this.LabelFlights = new System.Windows.Forms.Label();
            this.FlightView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.LegView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlightView)).BeginInit();
            this.SuspendLayout();
            // 
            // EnforceConstraints
            // 
            this.EnforceConstraints.AutoSize = true;
            this.EnforceConstraints.Checked = true;
            this.EnforceConstraints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnforceConstraints.Location = new System.Drawing.Point(128, 352);
            this.EnforceConstraints.Name = "EnforceConstraints";
            this.EnforceConstraints.Size = new System.Drawing.Size(117, 17);
            this.EnforceConstraints.TabIndex = 14;
            this.EnforceConstraints.Text = "Enforce &constraints";
            this.EnforceConstraints.UseVisualStyleBackColor = true;
            this.EnforceConstraints.CheckedChanged += new System.EventHandler(this.EnforceConstraints_CheckedChanged);
            // 
            // LabelDeleteRule
            // 
            this.LabelDeleteRule.AutoSize = true;
            this.LabelDeleteRule.Location = new System.Drawing.Point(56, 330);
            this.LabelDeleteRule.Name = "LabelDeleteRule";
            this.LabelDeleteRule.Size = new System.Drawing.Size(66, 13);
            this.LabelDeleteRule.TabIndex = 12;
            this.LabelDeleteRule.Text = "&Delete Rule:";
            // 
            // LabelUpdateRule
            // 
            this.LabelUpdateRule.AutoSize = true;
            this.LabelUpdateRule.Location = new System.Drawing.Point(56, 306);
            this.LabelUpdateRule.Name = "LabelUpdateRule";
            this.LabelUpdateRule.Size = new System.Drawing.Size(70, 13);
            this.LabelUpdateRule.TabIndex = 10;
            this.LabelUpdateRule.Text = "&Update Rule:";
            // 
            // DeleteRule
            // 
            this.DeleteRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeleteRule.FormattingEnabled = true;
            this.DeleteRule.Location = new System.Drawing.Point(128, 328);
            this.DeleteRule.Name = "DeleteRule";
            this.DeleteRule.Size = new System.Drawing.Size(264, 21);
            this.DeleteRule.TabIndex = 13;
            this.DeleteRule.SelectedIndexChanged += new System.EventHandler(this.DeleteRule_SelectedIndexChanged);
            // 
            // UpdateRule
            // 
            this.UpdateRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateRule.FormattingEnabled = true;
            this.UpdateRule.Location = new System.Drawing.Point(128, 304);
            this.UpdateRule.Name = "UpdateRule";
            this.UpdateRule.Size = new System.Drawing.Size(264, 21);
            this.UpdateRule.TabIndex = 11;
            this.UpdateRule.SelectedIndexChanged += new System.EventHandler(this.UpdateRule_SelectedIndexChanged);
            // 
            // ActResetAll
            // 
            this.ActResetAll.Location = new System.Drawing.Point(416, 304);
            this.ActResetAll.Name = "ActResetAll";
            this.ActResetAll.Size = new System.Drawing.Size(99, 23);
            this.ActResetAll.TabIndex = 15;
            this.ActResetAll.Text = "Reset Tables";
            this.ActResetAll.UseVisualStyleBackColor = true;
            this.ActResetAll.Click += new System.EventHandler(this.ActResetAll_Click);
            // 
            // ActLegDelete
            // 
            this.ActLegDelete.Enabled = false;
            this.ActLegDelete.Location = new System.Drawing.Point(520, 176);
            this.ActLegDelete.Name = "ActLegDelete";
            this.ActLegDelete.Size = new System.Drawing.Size(75, 23);
            this.ActLegDelete.TabIndex = 9;
            this.ActLegDelete.Text = "Delete";
            this.ActLegDelete.UseVisualStyleBackColor = true;
            this.ActLegDelete.Click += new System.EventHandler(this.ActLegDelete_Click);
            // 
            // ActLegEdit
            // 
            this.ActLegEdit.Enabled = false;
            this.ActLegEdit.Location = new System.Drawing.Point(520, 144);
            this.ActLegEdit.Name = "ActLegEdit";
            this.ActLegEdit.Size = new System.Drawing.Size(75, 23);
            this.ActLegEdit.TabIndex = 8;
            this.ActLegEdit.Text = "Edit...";
            this.ActLegEdit.UseVisualStyleBackColor = true;
            this.ActLegEdit.Click += new System.EventHandler(this.ActLegEdit_Click);
            // 
            // ActLegAdd
            // 
            this.ActLegAdd.Location = new System.Drawing.Point(520, 112);
            this.ActLegAdd.Name = "ActLegAdd";
            this.ActLegAdd.Size = new System.Drawing.Size(75, 23);
            this.ActLegAdd.TabIndex = 7;
            this.ActLegAdd.Text = "Add...";
            this.ActLegAdd.UseVisualStyleBackColor = true;
            this.ActLegAdd.Click += new System.EventHandler(this.ActLegAdd_Click);
            // 
            // ActFlightDelete
            // 
            this.ActFlightDelete.Enabled = false;
            this.ActFlightDelete.Location = new System.Drawing.Point(520, 72);
            this.ActFlightDelete.Name = "ActFlightDelete";
            this.ActFlightDelete.Size = new System.Drawing.Size(75, 23);
            this.ActFlightDelete.TabIndex = 4;
            this.ActFlightDelete.Text = "Delete";
            this.ActFlightDelete.UseVisualStyleBackColor = true;
            this.ActFlightDelete.Click += new System.EventHandler(this.ActFlightDelete_Click);
            // 
            // ActFlightEdit
            // 
            this.ActFlightEdit.Enabled = false;
            this.ActFlightEdit.Location = new System.Drawing.Point(520, 40);
            this.ActFlightEdit.Name = "ActFlightEdit";
            this.ActFlightEdit.Size = new System.Drawing.Size(75, 23);
            this.ActFlightEdit.TabIndex = 3;
            this.ActFlightEdit.Text = "Edit...";
            this.ActFlightEdit.UseVisualStyleBackColor = true;
            this.ActFlightEdit.Click += new System.EventHandler(this.ActFlightEdit_Click);
            // 
            // ActFlightAdd
            // 
            this.ActFlightAdd.Location = new System.Drawing.Point(520, 8);
            this.ActFlightAdd.Name = "ActFlightAdd";
            this.ActFlightAdd.Size = new System.Drawing.Size(75, 23);
            this.ActFlightAdd.TabIndex = 2;
            this.ActFlightAdd.Text = "Add...";
            this.ActFlightAdd.UseVisualStyleBackColor = true;
            this.ActFlightAdd.Click += new System.EventHandler(this.ActFlightAdd_Click);
            // 
            // LabelLegs
            // 
            this.LabelLegs.AutoSize = true;
            this.LabelLegs.Location = new System.Drawing.Point(8, 114);
            this.LabelLegs.Name = "LabelLegs";
            this.LabelLegs.Size = new System.Drawing.Size(33, 13);
            this.LabelLegs.TabIndex = 5;
            this.LabelLegs.Text = "&Legs:";
            // 
            // LegView
            // 
            this.LegView.AllowUserToAddRows = false;
            this.LegView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.LegView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LegView.Location = new System.Drawing.Point(56, 112);
            this.LegView.MultiSelect = false;
            this.LegView.Name = "LegView";
            this.LegView.ReadOnly = true;
            this.LegView.RowHeadersVisible = false;
            this.LegView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LegView.Size = new System.Drawing.Size(456, 184);
            this.LegView.TabIndex = 6;
            this.LegView.SelectionChanged += new System.EventHandler(this.LegView_SelectionChanged);
            // 
            // LabelFlights
            // 
            this.LabelFlights.AutoSize = true;
            this.LabelFlights.Location = new System.Drawing.Point(8, 10);
            this.LabelFlights.Name = "LabelFlights";
            this.LabelFlights.Size = new System.Drawing.Size(37, 13);
            this.LabelFlights.TabIndex = 0;
            this.LabelFlights.Text = "&Flights";
            // 
            // FlightView
            // 
            this.FlightView.AllowUserToAddRows = false;
            this.FlightView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.FlightView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlightView.Location = new System.Drawing.Point(56, 8);
            this.FlightView.MultiSelect = false;
            this.FlightView.Name = "FlightView";
            this.FlightView.ReadOnly = true;
            this.FlightView.RowHeadersVisible = false;
            this.FlightView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FlightView.Size = new System.Drawing.Size(456, 96);
            this.FlightView.TabIndex = 1;
            this.FlightView.SelectionChanged += new System.EventHandler(this.FlightView_SelectionChanged);
            // 
            // FlightInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 373);
            this.Controls.Add(this.EnforceConstraints);
            this.Controls.Add(this.LabelDeleteRule);
            this.Controls.Add(this.LabelUpdateRule);
            this.Controls.Add(this.DeleteRule);
            this.Controls.Add(this.UpdateRule);
            this.Controls.Add(this.ActResetAll);
            this.Controls.Add(this.ActLegDelete);
            this.Controls.Add(this.ActLegEdit);
            this.Controls.Add(this.ActLegAdd);
            this.Controls.Add(this.ActFlightDelete);
            this.Controls.Add(this.ActFlightEdit);
            this.Controls.Add(this.ActFlightAdd);
            this.Controls.Add(this.LabelLegs);
            this.Controls.Add(this.LegView);
            this.Controls.Add(this.LabelFlights);
            this.Controls.Add(this.FlightView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FlightInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 5 - Flight Information";
            this.Load += new System.EventHandler(this.FlightInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LegView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlightView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox EnforceConstraints;
        internal System.Windows.Forms.Label LabelDeleteRule;
        internal System.Windows.Forms.Label LabelUpdateRule;
        internal System.Windows.Forms.ComboBox DeleteRule;
        internal System.Windows.Forms.ComboBox UpdateRule;
        internal System.Windows.Forms.Button ActResetAll;
        internal System.Windows.Forms.Button ActLegDelete;
        internal System.Windows.Forms.Button ActLegEdit;
        internal System.Windows.Forms.Button ActLegAdd;
        internal System.Windows.Forms.Button ActFlightDelete;
        internal System.Windows.Forms.Button ActFlightEdit;
        internal System.Windows.Forms.Button ActFlightAdd;
        internal System.Windows.Forms.Label LabelLegs;
        internal System.Windows.Forms.DataGridView LegView;
        internal System.Windows.Forms.Label LabelFlights;
        internal System.Windows.Forms.DataGridView FlightView;
    }
}

