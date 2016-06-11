namespace Doors
{
    partial class MainForm
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
            this.frontDoor = new Doors.DoorControl();
            this.backDoor = new Doors.DoorControl();
            this.fireButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frontDoor
            // 
            this.frontDoor.DoorName = "Front Door";
            this.frontDoor.Location = new System.Drawing.Point(12, 12);
            this.frontDoor.Lock = true;
            this.frontDoor.MyProperty = 0;
            this.frontDoor.Name = "frontDoor";
            this.frontDoor.Runtime = null;
            this.frontDoor.Size = new System.Drawing.Size(283, 140);
            this.frontDoor.TabIndex = 0;
            this.frontDoor.WorkflowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            // 
            // backDoor
            // 
            this.backDoor.DoorName = "Back Door";
            this.backDoor.Location = new System.Drawing.Point(12, 158);
            this.backDoor.Lock = true;
            this.backDoor.MyProperty = 0;
            this.backDoor.Name = "backDoor";
            this.backDoor.Runtime = null;
            this.backDoor.Size = new System.Drawing.Size(283, 140);
            this.backDoor.TabIndex = 1;
            this.backDoor.WorkflowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            // 
            // fireButton
            // 
            this.fireButton.BackColor = System.Drawing.Color.Red;
            this.fireButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireButton.Location = new System.Drawing.Point(324, 13);
            this.fireButton.Name = "fireButton";
            this.fireButton.Size = new System.Drawing.Size(86, 36);
            this.fireButton.TabIndex = 2;
            this.fireButton.Text = "Fire!";
            this.fireButton.UseVisualStyleBackColor = false;
            this.fireButton.Click += new System.EventHandler(this.fireButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 317);
            this.Controls.Add(this.fireButton);
            this.Controls.Add(this.backDoor);
            this.Controls.Add(this.frontDoor);
            this.Name = "MainForm";
            this.Text = "The Doors";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private DoorControl frontDoor;
        private DoorControl backDoor;
        private System.Windows.Forms.Button fireButton;
    }
}

