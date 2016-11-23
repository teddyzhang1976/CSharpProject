namespace Chapter_9_CSharp
{
    partial class StateBuilder
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
            this.LabelIntro = new System.Windows.Forms.Label();
            this.ActionTabs = new System.Windows.Forms.TabControl();
            this.TabAdd = new System.Windows.Forms.TabPage();
            this.AddSQL = new System.Windows.Forms.Label();
            this.LabelAddSQL = new System.Windows.Forms.Label();
            this.AddAbbreviation = new System.Windows.Forms.TextBox();
            this.LabelAddAbbreviation = new System.Windows.Forms.Label();
            this.LabelAddName = new System.Windows.Forms.Label();
            this.AddName = new System.Windows.Forms.TextBox();
            this.ActAdd = new System.Windows.Forms.Button();
            this.TabEdit = new System.Windows.Forms.TabPage();
            this.EditSQL = new System.Windows.Forms.Label();
            this.LabelEditSQL = new System.Windows.Forms.Label();
            this.EditID = new System.Windows.Forms.Label();
            this.LabelEditID = new System.Windows.Forms.Label();
            this.EditAbbreviation = new System.Windows.Forms.TextBox();
            this.LabelEditAbbreviation = new System.Windows.Forms.Label();
            this.LabelEditName = new System.Windows.Forms.Label();
            this.EditName = new System.Windows.Forms.TextBox();
            this.ActEdit = new System.Windows.Forms.Button();
            this.TabDelete = new System.Windows.Forms.TabPage();
            this.DeleteSQL = new System.Windows.Forms.Label();
            this.LabelDeleteSQL = new System.Windows.Forms.Label();
            this.DeleteAbbreviation = new System.Windows.Forms.Label();
            this.DeleteName = new System.Windows.Forms.Label();
            this.DeleteID = new System.Windows.Forms.Label();
            this.LabelDeleteID = new System.Windows.Forms.Label();
            this.LabelDeleteAbbreviation = new System.Windows.Forms.Label();
            this.LabelDeleteName = new System.Windows.Forms.Label();
            this.ActDelete = new System.Windows.Forms.Button();
            this.ActionTabs.SuspendLayout();
            this.TabAdd.SuspendLayout();
            this.TabEdit.SuspendLayout();
            this.TabDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelIntro
            // 
            this.LabelIntro.AutoSize = true;
            this.LabelIntro.Location = new System.Drawing.Point(12, 6);
            this.LabelIntro.Name = "LabelIntro";
            this.LabelIntro.Size = new System.Drawing.Size(371, 13);
            this.LabelIntro.TabIndex = 0;
            this.LabelIntro.Text = "Take control of the nation. Use the fields below to add, edit, or delete a state." +
                "";
            // 
            // ActionTabs
            // 
            this.ActionTabs.Controls.Add(this.TabAdd);
            this.ActionTabs.Controls.Add(this.TabEdit);
            this.ActionTabs.Controls.Add(this.TabDelete);
            this.ActionTabs.Location = new System.Drawing.Point(8, 32);
            this.ActionTabs.Name = "ActionTabs";
            this.ActionTabs.SelectedIndex = 0;
            this.ActionTabs.Size = new System.Drawing.Size(432, 216);
            this.ActionTabs.TabIndex = 1;
            // 
            // TabAdd
            // 
            this.TabAdd.Controls.Add(this.AddSQL);
            this.TabAdd.Controls.Add(this.LabelAddSQL);
            this.TabAdd.Controls.Add(this.AddAbbreviation);
            this.TabAdd.Controls.Add(this.LabelAddAbbreviation);
            this.TabAdd.Controls.Add(this.LabelAddName);
            this.TabAdd.Controls.Add(this.AddName);
            this.TabAdd.Controls.Add(this.ActAdd);
            this.TabAdd.Location = new System.Drawing.Point(4, 22);
            this.TabAdd.Name = "TabAdd";
            this.TabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.TabAdd.Size = new System.Drawing.Size(424, 190);
            this.TabAdd.TabIndex = 0;
            this.TabAdd.Text = "Add a State";
            this.TabAdd.UseVisualStyleBackColor = true;
            // 
            // AddSQL
            // 
            this.AddSQL.Location = new System.Drawing.Point(120, 58);
            this.AddSQL.Name = "AddSQL";
            this.AddSQL.Size = new System.Drawing.Size(296, 102);
            this.AddSQL.TabIndex = 5;
            this.AddSQL.Text = "N/A";
            this.AddSQL.UseMnemonic = false;
            // 
            // LabelAddSQL
            // 
            this.LabelAddSQL.AutoSize = true;
            this.LabelAddSQL.Location = new System.Drawing.Point(8, 58);
            this.LabelAddSQL.Name = "LabelAddSQL";
            this.LabelAddSQL.Size = new System.Drawing.Size(82, 13);
            this.LabelAddSQL.TabIndex = 4;
            this.LabelAddSQL.Text = "SQL Statement:";
            // 
            // AddAbbreviation
            // 
            this.AddAbbreviation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AddAbbreviation.Location = new System.Drawing.Point(120, 32);
            this.AddAbbreviation.MaxLength = 2;
            this.AddAbbreviation.Name = "AddAbbreviation";
            this.AddAbbreviation.Size = new System.Drawing.Size(64, 20);
            this.AddAbbreviation.TabIndex = 3;
            this.AddAbbreviation.TextChanged += new System.EventHandler(this.AddFields_TextChanged);
            this.AddAbbreviation.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelAddAbbreviation
            // 
            this.LabelAddAbbreviation.AutoSize = true;
            this.LabelAddAbbreviation.Location = new System.Drawing.Point(8, 34);
            this.LabelAddAbbreviation.Name = "LabelAddAbbreviation";
            this.LabelAddAbbreviation.Size = new System.Drawing.Size(94, 13);
            this.LabelAddAbbreviation.TabIndex = 2;
            this.LabelAddAbbreviation.Text = "New Abbreviation:";
            // 
            // LabelAddName
            // 
            this.LabelAddName.AutoSize = true;
            this.LabelAddName.Location = new System.Drawing.Point(8, 10);
            this.LabelAddName.Name = "LabelAddName";
            this.LabelAddName.Size = new System.Drawing.Size(91, 13);
            this.LabelAddName.TabIndex = 0;
            this.LabelAddName.Text = "New State Name:";
            // 
            // AddName
            // 
            this.AddName.Location = new System.Drawing.Point(120, 8);
            this.AddName.MaxLength = 50;
            this.AddName.Name = "AddName";
            this.AddName.Size = new System.Drawing.Size(216, 20);
            this.AddName.TabIndex = 1;
            this.AddName.TextChanged += new System.EventHandler(this.AddFields_TextChanged);
            this.AddName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // ActAdd
            // 
            this.ActAdd.Location = new System.Drawing.Point(344, 32);
            this.ActAdd.Name = "ActAdd";
            this.ActAdd.Size = new System.Drawing.Size(75, 23);
            this.ActAdd.TabIndex = 6;
            this.ActAdd.Text = "Add";
            this.ActAdd.UseVisualStyleBackColor = true;
            this.ActAdd.Click += new System.EventHandler(this.ActAdd_Click);
            // 
            // TabEdit
            // 
            this.TabEdit.Controls.Add(this.EditSQL);
            this.TabEdit.Controls.Add(this.LabelEditSQL);
            this.TabEdit.Controls.Add(this.EditID);
            this.TabEdit.Controls.Add(this.LabelEditID);
            this.TabEdit.Controls.Add(this.EditAbbreviation);
            this.TabEdit.Controls.Add(this.LabelEditAbbreviation);
            this.TabEdit.Controls.Add(this.LabelEditName);
            this.TabEdit.Controls.Add(this.EditName);
            this.TabEdit.Controls.Add(this.ActEdit);
            this.TabEdit.Location = new System.Drawing.Point(4, 22);
            this.TabEdit.Name = "TabEdit";
            this.TabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.TabEdit.Size = new System.Drawing.Size(424, 190);
            this.TabEdit.TabIndex = 1;
            this.TabEdit.Text = "Rename a State";
            this.TabEdit.UseVisualStyleBackColor = true;
            // 
            // EditSQL
            // 
            this.EditSQL.Location = new System.Drawing.Point(120, 82);
            this.EditSQL.Name = "EditSQL";
            this.EditSQL.Size = new System.Drawing.Size(296, 102);
            this.EditSQL.TabIndex = 7;
            this.EditSQL.Text = "N/A";
            this.EditSQL.UseMnemonic = false;
            // 
            // LabelEditSQL
            // 
            this.LabelEditSQL.AutoSize = true;
            this.LabelEditSQL.Location = new System.Drawing.Point(8, 82);
            this.LabelEditSQL.Name = "LabelEditSQL";
            this.LabelEditSQL.Size = new System.Drawing.Size(82, 13);
            this.LabelEditSQL.TabIndex = 6;
            this.LabelEditSQL.Text = "SQL Statement:";
            // 
            // EditID
            // 
            this.EditID.AutoSize = true;
            this.EditID.Location = new System.Drawing.Point(120, 10);
            this.EditID.Name = "EditID";
            this.EditID.Size = new System.Drawing.Size(27, 13);
            this.EditID.TabIndex = 1;
            this.EditID.Text = "N/A";
            this.EditID.UseMnemonic = false;
            // 
            // LabelEditID
            // 
            this.LabelEditID.AutoSize = true;
            this.LabelEditID.Location = new System.Drawing.Point(8, 10);
            this.LabelEditID.Name = "LabelEditID";
            this.LabelEditID.Size = new System.Drawing.Size(49, 13);
            this.LabelEditID.TabIndex = 0;
            this.LabelEditID.Text = "State ID:";
            // 
            // EditAbbreviation
            // 
            this.EditAbbreviation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EditAbbreviation.Location = new System.Drawing.Point(120, 56);
            this.EditAbbreviation.MaxLength = 2;
            this.EditAbbreviation.Name = "EditAbbreviation";
            this.EditAbbreviation.Size = new System.Drawing.Size(64, 20);
            this.EditAbbreviation.TabIndex = 5;
            this.EditAbbreviation.TextChanged += new System.EventHandler(this.EditFields_TextChanged);
            this.EditAbbreviation.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelEditAbbreviation
            // 
            this.LabelEditAbbreviation.AutoSize = true;
            this.LabelEditAbbreviation.Location = new System.Drawing.Point(8, 58);
            this.LabelEditAbbreviation.Name = "LabelEditAbbreviation";
            this.LabelEditAbbreviation.Size = new System.Drawing.Size(94, 13);
            this.LabelEditAbbreviation.TabIndex = 4;
            this.LabelEditAbbreviation.Text = "New Abbreviation:";
            // 
            // LabelEditName
            // 
            this.LabelEditName.AutoSize = true;
            this.LabelEditName.Location = new System.Drawing.Point(8, 34);
            this.LabelEditName.Name = "LabelEditName";
            this.LabelEditName.Size = new System.Drawing.Size(91, 13);
            this.LabelEditName.TabIndex = 2;
            this.LabelEditName.Text = "New State Name:";
            // 
            // EditName
            // 
            this.EditName.Location = new System.Drawing.Point(120, 32);
            this.EditName.MaxLength = 50;
            this.EditName.Name = "EditName";
            this.EditName.Size = new System.Drawing.Size(216, 20);
            this.EditName.TabIndex = 3;
            this.EditName.TextChanged += new System.EventHandler(this.EditFields_TextChanged);
            this.EditName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // ActEdit
            // 
            this.ActEdit.Location = new System.Drawing.Point(344, 56);
            this.ActEdit.Name = "ActEdit";
            this.ActEdit.Size = new System.Drawing.Size(75, 23);
            this.ActEdit.TabIndex = 8;
            this.ActEdit.Text = "Rename";
            this.ActEdit.UseVisualStyleBackColor = true;
            this.ActEdit.Click += new System.EventHandler(this.ActEdit_Click);
            // 
            // TabDelete
            // 
            this.TabDelete.Controls.Add(this.DeleteSQL);
            this.TabDelete.Controls.Add(this.LabelDeleteSQL);
            this.TabDelete.Controls.Add(this.DeleteAbbreviation);
            this.TabDelete.Controls.Add(this.DeleteName);
            this.TabDelete.Controls.Add(this.DeleteID);
            this.TabDelete.Controls.Add(this.LabelDeleteID);
            this.TabDelete.Controls.Add(this.LabelDeleteAbbreviation);
            this.TabDelete.Controls.Add(this.LabelDeleteName);
            this.TabDelete.Controls.Add(this.ActDelete);
            this.TabDelete.Location = new System.Drawing.Point(4, 22);
            this.TabDelete.Name = "TabDelete";
            this.TabDelete.Size = new System.Drawing.Size(424, 190);
            this.TabDelete.TabIndex = 2;
            this.TabDelete.Text = "Delete a State";
            this.TabDelete.UseVisualStyleBackColor = true;
            // 
            // DeleteSQL
            // 
            this.DeleteSQL.Location = new System.Drawing.Point(120, 82);
            this.DeleteSQL.Name = "DeleteSQL";
            this.DeleteSQL.Size = new System.Drawing.Size(296, 102);
            this.DeleteSQL.TabIndex = 7;
            this.DeleteSQL.Text = "N/A";
            this.DeleteSQL.UseMnemonic = false;
            // 
            // LabelDeleteSQL
            // 
            this.LabelDeleteSQL.AutoSize = true;
            this.LabelDeleteSQL.Location = new System.Drawing.Point(8, 82);
            this.LabelDeleteSQL.Name = "LabelDeleteSQL";
            this.LabelDeleteSQL.Size = new System.Drawing.Size(82, 13);
            this.LabelDeleteSQL.TabIndex = 6;
            this.LabelDeleteSQL.Text = "SQL Statement:";
            // 
            // DeleteAbbreviation
            // 
            this.DeleteAbbreviation.AutoSize = true;
            this.DeleteAbbreviation.Location = new System.Drawing.Point(120, 58);
            this.DeleteAbbreviation.Name = "DeleteAbbreviation";
            this.DeleteAbbreviation.Size = new System.Drawing.Size(27, 13);
            this.DeleteAbbreviation.TabIndex = 5;
            this.DeleteAbbreviation.Text = "N/A";
            this.DeleteAbbreviation.UseMnemonic = false;
            // 
            // DeleteName
            // 
            this.DeleteName.AutoSize = true;
            this.DeleteName.Location = new System.Drawing.Point(120, 34);
            this.DeleteName.Name = "DeleteName";
            this.DeleteName.Size = new System.Drawing.Size(27, 13);
            this.DeleteName.TabIndex = 3;
            this.DeleteName.Text = "N/A";
            this.DeleteName.UseMnemonic = false;
            // 
            // DeleteID
            // 
            this.DeleteID.AutoSize = true;
            this.DeleteID.Location = new System.Drawing.Point(120, 10);
            this.DeleteID.Name = "DeleteID";
            this.DeleteID.Size = new System.Drawing.Size(27, 13);
            this.DeleteID.TabIndex = 1;
            this.DeleteID.Text = "N/A";
            this.DeleteID.UseMnemonic = false;
            // 
            // LabelDeleteID
            // 
            this.LabelDeleteID.AutoSize = true;
            this.LabelDeleteID.Location = new System.Drawing.Point(8, 10);
            this.LabelDeleteID.Name = "LabelDeleteID";
            this.LabelDeleteID.Size = new System.Drawing.Size(49, 13);
            this.LabelDeleteID.TabIndex = 0;
            this.LabelDeleteID.Text = "State ID:";
            // 
            // LabelDeleteAbbreviation
            // 
            this.LabelDeleteAbbreviation.AutoSize = true;
            this.LabelDeleteAbbreviation.Location = new System.Drawing.Point(8, 58);
            this.LabelDeleteAbbreviation.Name = "LabelDeleteAbbreviation";
            this.LabelDeleteAbbreviation.Size = new System.Drawing.Size(94, 13);
            this.LabelDeleteAbbreviation.TabIndex = 4;
            this.LabelDeleteAbbreviation.Text = "New Abbreviation:";
            // 
            // LabelDeleteName
            // 
            this.LabelDeleteName.AutoSize = true;
            this.LabelDeleteName.Location = new System.Drawing.Point(8, 34);
            this.LabelDeleteName.Name = "LabelDeleteName";
            this.LabelDeleteName.Size = new System.Drawing.Size(91, 13);
            this.LabelDeleteName.TabIndex = 2;
            this.LabelDeleteName.Text = "New State Name:";
            // 
            // ActDelete
            // 
            this.ActDelete.Location = new System.Drawing.Point(344, 56);
            this.ActDelete.Name = "ActDelete";
            this.ActDelete.Size = new System.Drawing.Size(75, 23);
            this.ActDelete.TabIndex = 8;
            this.ActDelete.Text = "Delete";
            this.ActDelete.UseVisualStyleBackColor = true;
            this.ActDelete.Click += new System.EventHandler(this.ActDelete_Click);
            // 
            // StateBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 255);
            this.Controls.Add(this.LabelIntro);
            this.Controls.Add(this.ActionTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StateBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 9 - State Builder";
            this.Load += new System.EventHandler(this.StateBuilder_Load);
            this.ActionTabs.ResumeLayout(false);
            this.TabAdd.ResumeLayout(false);
            this.TabAdd.PerformLayout();
            this.TabEdit.ResumeLayout(false);
            this.TabEdit.PerformLayout();
            this.TabDelete.ResumeLayout(false);
            this.TabDelete.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LabelIntro;
        internal System.Windows.Forms.TabControl ActionTabs;
        internal System.Windows.Forms.TabPage TabAdd;
        internal System.Windows.Forms.Label AddSQL;
        internal System.Windows.Forms.Label LabelAddSQL;
        internal System.Windows.Forms.TextBox AddAbbreviation;
        internal System.Windows.Forms.Label LabelAddAbbreviation;
        internal System.Windows.Forms.Label LabelAddName;
        internal System.Windows.Forms.TextBox AddName;
        internal System.Windows.Forms.Button ActAdd;
        internal System.Windows.Forms.TabPage TabEdit;
        internal System.Windows.Forms.Label EditSQL;
        internal System.Windows.Forms.Label LabelEditSQL;
        internal System.Windows.Forms.Label EditID;
        internal System.Windows.Forms.Label LabelEditID;
        internal System.Windows.Forms.TextBox EditAbbreviation;
        internal System.Windows.Forms.Label LabelEditAbbreviation;
        internal System.Windows.Forms.Label LabelEditName;
        internal System.Windows.Forms.TextBox EditName;
        internal System.Windows.Forms.Button ActEdit;
        internal System.Windows.Forms.TabPage TabDelete;
        internal System.Windows.Forms.Label DeleteSQL;
        internal System.Windows.Forms.Label LabelDeleteSQL;
        internal System.Windows.Forms.Label DeleteAbbreviation;
        internal System.Windows.Forms.Label DeleteName;
        internal System.Windows.Forms.Label DeleteID;
        internal System.Windows.Forms.Label LabelDeleteID;
        internal System.Windows.Forms.Label LabelDeleteAbbreviation;
        internal System.Windows.Forms.Label LabelDeleteName;
        internal System.Windows.Forms.Button ActDelete;
    }
}

