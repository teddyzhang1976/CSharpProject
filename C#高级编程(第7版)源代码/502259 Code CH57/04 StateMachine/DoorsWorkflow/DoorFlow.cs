using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Media;
using System.IO;
using System.Reflection;

namespace DoorsWorkflow
{
    public sealed partial class DoorFlow : StateMachineWorkflowActivity
    {
        public DoorFlow()
        {
            InitializeComponent();
        }

        private bool _validPin;

        public bool ValidPIN
        {
            get { return _validPin; }
            set { _validPin = value; }
        }

        private void ValidatePIN_ExecuteCode(object sender, EventArgs e)
        {
            // Code to check that the PIN entered is valid

            ValidPIN = true;
        }

        private void Beep_ExecuteCode(object sender, EventArgs e)
        {
            Play("DoorsWorkflow.WindowsHardwareInsert.wav");
        }

        private void CloseBeep_ExecuteCode(object sender, EventArgs e)
        {
            Play("DoorsWorkflow.WindowsHardwareRemove.wav");
        }

        private void Play(string sound)
        {
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(sound))
            {
                SoundPlayer player = new SoundPlayer(s);
                player.Play();
            }
        }
    }
}
