using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Runtime;
using System.Workflow.Activities;

namespace Doors
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            _runtime = new WorkflowRuntime();

            ExternalDataExchangeService edes = new ExternalDataExchangeService();

            _runtime.AddService(edes);

            _service = new DoorService();

            edes.AddService(_service);

            _runtime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(OnWorkflowCompleted);
            _runtime.StartRuntime();

            AddDoor(_service, frontDoor);
            AddDoor(_service, backDoor);
        }

        void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            MessageBox.Show(string.Format("Workflow completed: {0}", e.WorkflowInstance.InstanceId));
        }

        private void AddDoor(DoorService service, DoorControl door)
        {
            Guid id = Guid.NewGuid();

            service.AddDoor(id, door);

            // Now add in a workflow for the door
            WorkflowInstance instance = _runtime.CreateWorkflow(typeof(DoorsWorkflow.DoorFlow), null, id);

            door.WorkflowID = id;
            door.Runtime = _runtime;

            instance.Start();
        }

        private WorkflowRuntime _runtime;
        private DoorService _service;

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _runtime.StopRuntime();
        }

        private void fireButton_Click(object sender, EventArgs e)
        {
            frontDoor.Enabled = false;
            backDoor.Enabled = false;
            fireButton.Enabled = false;
            fireButton.BackColor = SystemColors.Control;
            _service.OnFireAlarm();
        }
    }


}