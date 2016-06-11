using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;
using System.Media;
using System.Workflow.Runtime;
using System.IO;
using System.Reflection;

namespace Doors
{
    [Serializable]
    public class DoorService : DoorsWorkflow.IDoorService
    {
        public DoorService()
        {
            _doorControls = new Dictionary<Guid, DoorControl>();
        }

        public void AddDoor(Guid id, DoorControl control)
        {
            _doorControls.Add(id, control);
        }

        public void LockDoor()
        {
            bool locked = _doorControls[WorkflowEnvironment.WorkflowInstanceId].Lock;

            if (!locked)
            {
                _doorControls[WorkflowEnvironment.WorkflowInstanceId].Lock = true;
                Play("Doors.Windows Logoff Sound.wav");
            }
        }

        public void UnlockDoor()
        {
            bool locked = _doorControls[WorkflowEnvironment.WorkflowInstanceId].Lock;

            if (locked)
            {
                _doorControls[WorkflowEnvironment.WorkflowInstanceId].Lock = false;
                Play("Doors.Windows Logon Sound.wav");
            }
        }

        public event EventHandler<ExternalDataEventArgs> RequestEntry;
        public event EventHandler<ExternalDataEventArgs> OpenDoor;
        public event EventHandler<ExternalDataEventArgs> CloseDoor;
        public event EventHandler<ExternalDataEventArgs> FireAlarm;

        public void OnRequestEntry(Guid id)
        {
            if (null != RequestEntry)
                RequestEntry(this, new ExternalDataEventArgs(id));
        }

        public void OnOpenDoor(Guid id)
        {
            if (null != OpenDoor)
                OpenDoor(this, new ExternalDataEventArgs(id));
        }

        public void OnCloseDoor(Guid id)
        {
            if (null != CloseDoor)
                CloseDoor(this, new ExternalDataEventArgs(id));
        }

        public void OnFireAlarm()
        {
            foreach (KeyValuePair<Guid, DoorControl> kvp in _doorControls)
            {
                if (null != FireAlarm)
                    FireAlarm(this, new ExternalDataEventArgs(kvp.Key));
            }
        }

        [NonSerialized]
        private Dictionary<Guid, DoorControl> _doorControls;

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
