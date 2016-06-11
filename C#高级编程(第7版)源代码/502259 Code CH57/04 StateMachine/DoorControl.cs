using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Runtime;

namespace Doors
{
    [Serializable]
    public partial class DoorControl : UserControl
    {
        public DoorControl()
        {
            InitializeComponent();

            _pin = new StringBuilder();
        }

        private StringBuilder _pin;

        public string PIN
        {
            get { return _pin.ToString(); }
        }
	
        public void KeypadClicked(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (null != b)
                _pin.Append(b.Text);
        }

        private void EnterClicked(object sender, EventArgs e)
        {
            Runtime.GetService<DoorsWorkflow.IDoorService>().OnRequestEntry(WorkflowID);
        }

        private void OpenDoor(object sender, EventArgs e)
        {
            Runtime.GetService<DoorsWorkflow.IDoorService>().OnOpenDoor(WorkflowID);
            openDoor.Enabled = false;
            closeDoor.Enabled = true;
        }

        private void CloseDoor(object sender, EventArgs e)
        {
            Runtime.GetService<DoorsWorkflow.IDoorService>().OnCloseDoor(WorkflowID);
            openDoor.Enabled = true;
            closeDoor.Enabled = false;
        }

        private Guid _workflowID;

        public Guid WorkflowID
        {
            get { return _workflowID; }
            set { _workflowID = value; }
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private WorkflowRuntime _runtime;

        public WorkflowRuntime Runtime
        {
            get { return _runtime; }
            set { _runtime = value; }
        }

        public bool Lock
        {
            get
            {
                return lockedButton.Checked;
            }
            set
            {
                lockedButton.Checked = value ? true : false;
                unlockedButton.Checked = value ? false : true;
                button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled
                 = button8.Enabled = button9.Enabled = button10.Enabled = button11.Enabled = value;

                if (value)
                    closeDoor.Enabled = openDoor.Enabled = false;
                else
                {
                    openDoor.Enabled = true;
                    closeDoor.Enabled = false;
                }

            }
        }

        [Description("The name of the door")]
        [Category("Appearance")]
        public string DoorName
        {
            get { return doorName.Text; }
            set { doorName.Text = value; }
        }
		
    }
}
