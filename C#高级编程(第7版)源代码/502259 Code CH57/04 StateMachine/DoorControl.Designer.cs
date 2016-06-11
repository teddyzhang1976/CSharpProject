namespace Doors
{
    partial class DoorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.lockState = new System.Windows.Forms.GroupBox();
            this.unlockedButton = new System.Windows.Forms.RadioButton();
            this.lockedButton = new System.Windows.Forms.RadioButton();
            this.openDoor = new System.Windows.Forms.Button();
            this.closeDoor = new System.Windows.Forms.Button();
            this.doorName = new System.Windows.Forms.Label();
            this.lockState.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(63, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 52);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(33, 52);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(63, 52);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 81);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(24, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(33, 81);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(24, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(63, 81);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(24, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(3, 110);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(24, 23);
            this.button10.TabIndex = 9;
            this.button10.Text = "0";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.KeypadClicked);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(33, 110);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(54, 23);
            this.button11.TabIndex = 10;
            this.button11.Text = "Enter";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.EnterClicked);
            // 
            // lockState
            // 
            this.lockState.Controls.Add(this.unlockedButton);
            this.lockState.Controls.Add(this.lockedButton);
            this.lockState.Location = new System.Drawing.Point(102, 23);
            this.lockState.Name = "lockState";
            this.lockState.Size = new System.Drawing.Size(92, 110);
            this.lockState.TabIndex = 11;
            this.lockState.TabStop = false;
            this.lockState.Text = "Lock State";
            // 
            // unlockedButton
            // 
            this.unlockedButton.AutoSize = true;
            this.unlockedButton.Enabled = false;
            this.unlockedButton.Location = new System.Drawing.Point(6, 42);
            this.unlockedButton.Name = "unlockedButton";
            this.unlockedButton.Size = new System.Drawing.Size(71, 17);
            this.unlockedButton.TabIndex = 1;
            this.unlockedButton.Text = "Unlocked";
            this.unlockedButton.UseVisualStyleBackColor = true;
            // 
            // lockedButton
            // 
            this.lockedButton.AutoSize = true;
            this.lockedButton.Checked = true;
            this.lockedButton.Enabled = false;
            this.lockedButton.Location = new System.Drawing.Point(6, 19);
            this.lockedButton.Name = "lockedButton";
            this.lockedButton.Size = new System.Drawing.Size(61, 17);
            this.lockedButton.TabIndex = 0;
            this.lockedButton.TabStop = true;
            this.lockedButton.Text = "Locked";
            this.lockedButton.UseVisualStyleBackColor = true;
            // 
            // openDoor
            // 
            this.openDoor.Enabled = false;
            this.openDoor.Location = new System.Drawing.Point(200, 23);
            this.openDoor.Name = "openDoor";
            this.openDoor.Size = new System.Drawing.Size(75, 23);
            this.openDoor.TabIndex = 12;
            this.openDoor.Text = "&Open";
            this.openDoor.UseVisualStyleBackColor = true;
            this.openDoor.Click += new System.EventHandler(this.OpenDoor);
            // 
            // closeDoor
            // 
            this.closeDoor.Enabled = false;
            this.closeDoor.Location = new System.Drawing.Point(200, 52);
            this.closeDoor.Name = "closeDoor";
            this.closeDoor.Size = new System.Drawing.Size(75, 23);
            this.closeDoor.TabIndex = 13;
            this.closeDoor.Text = "&Close";
            this.closeDoor.UseVisualStyleBackColor = true;
            this.closeDoor.Click += new System.EventHandler(this.CloseDoor);
            // 
            // doorName
            // 
            this.doorName.BackColor = System.Drawing.SystemColors.Desktop;
            this.doorName.Dock = System.Windows.Forms.DockStyle.Top;
            this.doorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doorName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.doorName.Location = new System.Drawing.Point(0, 0);
            this.doorName.Name = "doorName";
            this.doorName.Size = new System.Drawing.Size(283, 20);
            this.doorName.TabIndex = 14;
            this.doorName.Text = "Door Name";
            // 
            // DoorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.doorName);
            this.Controls.Add(this.closeDoor);
            this.Controls.Add(this.openDoor);
            this.Controls.Add(this.lockState);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DoorControl";
            this.Size = new System.Drawing.Size(283, 140);
            this.lockState.ResumeLayout(false);
            this.lockState.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox lockState;
        private System.Windows.Forms.RadioButton unlockedButton;
        private System.Windows.Forms.RadioButton lockedButton;
        private System.Windows.Forms.Button openDoor;
        private System.Windows.Forms.Button closeDoor;
        private System.Windows.Forms.Label doorName;
    }
}
