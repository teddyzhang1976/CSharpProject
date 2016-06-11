using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;

namespace DoorsWorkflow
{
    [ExternalDataExchange]
	public interface IDoorService
	{
        void LockDoor();
        void UnlockDoor();

        event EventHandler<ExternalDataEventArgs> RequestEntry;
        event EventHandler<ExternalDataEventArgs> OpenDoor;
        event EventHandler<ExternalDataEventArgs> CloseDoor;
        event EventHandler<ExternalDataEventArgs> FireAlarm;

        void OnRequestEntry(Guid id);
        void OnOpenDoor(Guid id);
        void OnCloseDoor(Guid id);
        void OnFireAlarm();
    }
}
