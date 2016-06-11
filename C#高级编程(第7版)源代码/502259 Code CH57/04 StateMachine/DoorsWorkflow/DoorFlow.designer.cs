using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace DoorsWorkflow
{
    partial class DoorFlow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.UnlockDoor = new System.Workflow.Activities.SetStateActivity();
            this.PINInvalid = new System.Workflow.Activities.IfElseBranchActivity();
            this.PINValid = new System.Workflow.Activities.IfElseBranchActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.StateClosed = new System.Workflow.Activities.SetStateActivity();
            this.CloseBeep = new System.Workflow.Activities.CodeActivity();
            this.CloseDoor = new System.Workflow.Activities.HandleExternalEventActivity();
            this.LockDoor = new System.Workflow.Activities.CallExternalMethodActivity();
            this.CheckPINValidity = new System.Workflow.Activities.IfElseActivity();
            this.ValidatePIN = new System.Workflow.Activities.CodeActivity();
            this.EnterPIN = new System.Workflow.Activities.HandleExternalEventActivity();
            this.CU_UnlockDoor = new System.Workflow.Activities.CallExternalMethodActivity();
            this.Opened = new System.Workflow.Activities.SetStateActivity();
            this.OpenBeep = new System.Workflow.Activities.CodeActivity();
            this.OpenDoor = new System.Workflow.Activities.HandleExternalEventActivity();
            this.LockUp = new System.Workflow.Activities.SetStateActivity();
            this.LockWait = new System.Workflow.Activities.DelayActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.Unlock = new System.Workflow.Activities.CallExternalMethodActivity();
            this.FireAlarmRaised = new System.Workflow.Activities.HandleExternalEventActivity();
            this.DoorClosed = new System.Workflow.Activities.EventDrivenActivity();
            this.CLInitialize = new System.Workflow.Activities.StateInitializationActivity();
            this.RequestEntry = new System.Workflow.Activities.EventDrivenActivity();
            this.CUInitialize = new System.Workflow.Activities.StateInitializationActivity();
            this.DoorOpened = new System.Workflow.Activities.EventDrivenActivity();
            this.FireLock = new System.Workflow.Activities.EventDrivenActivity();
            this.OnFireAlarm = new System.Workflow.Activities.EventDrivenActivity();
            this.FireAlarm = new System.Workflow.Activities.StateActivity();
            this.OpenUnlocked = new System.Workflow.Activities.StateActivity();
            this.ClosedLocked = new System.Workflow.Activities.StateActivity();
            this.ClosedUnlocked = new System.Workflow.Activities.StateActivity();
            // 
            // UnlockDoor
            // 
            this.UnlockDoor.Name = "UnlockDoor";
            this.UnlockDoor.TargetStateName = "ClosedUnlocked";
            // 
            // PINInvalid
            // 
            this.PINInvalid.Name = "PINInvalid";
            // 
            // PINValid
            // 
            this.PINValid.Activities.Add(this.UnlockDoor);
            ruleconditionreference1.ConditionName = "PinValid";
            this.PINValid.Condition = ruleconditionreference1;
            this.PINValid.Name = "PINValid";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // StateClosed
            // 
            this.StateClosed.Name = "StateClosed";
            this.StateClosed.TargetStateName = "ClosedUnlocked";
            // 
            // CloseBeep
            // 
            this.CloseBeep.Name = "CloseBeep";
            this.CloseBeep.ExecuteCode += new System.EventHandler(this.CloseBeep_ExecuteCode);
            // 
            // CloseDoor
            // 
            this.CloseDoor.EventName = "CloseDoor";
            this.CloseDoor.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.CloseDoor.Name = "CloseDoor";
            // 
            // LockDoor
            // 
            this.LockDoor.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.LockDoor.MethodName = "LockDoor";
            this.LockDoor.Name = "LockDoor";
            // 
            // CheckPINValidity
            // 
            this.CheckPINValidity.Activities.Add(this.PINValid);
            this.CheckPINValidity.Activities.Add(this.PINInvalid);
            this.CheckPINValidity.Name = "CheckPINValidity";
            // 
            // ValidatePIN
            // 
            this.ValidatePIN.Name = "ValidatePIN";
            this.ValidatePIN.ExecuteCode += new System.EventHandler(this.ValidatePIN_ExecuteCode);
            // 
            // EnterPIN
            // 
            this.EnterPIN.EventName = "RequestEntry";
            this.EnterPIN.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.EnterPIN.Name = "EnterPIN";
            // 
            // CU_UnlockDoor
            // 
            this.CU_UnlockDoor.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.CU_UnlockDoor.MethodName = "UnlockDoor";
            this.CU_UnlockDoor.Name = "CU_UnlockDoor";
            // 
            // Opened
            // 
            this.Opened.Name = "Opened";
            this.Opened.TargetStateName = "OpenUnlocked";
            // 
            // OpenBeep
            // 
            this.OpenBeep.Name = "OpenBeep";
            this.OpenBeep.ExecuteCode += new System.EventHandler(this.Beep_ExecuteCode);
            // 
            // OpenDoor
            // 
            this.OpenDoor.EventName = "OpenDoor";
            this.OpenDoor.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.OpenDoor.Name = "OpenDoor";
            // 
            // LockUp
            // 
            this.LockUp.Name = "LockUp";
            this.LockUp.TargetStateName = "ClosedLocked";
            // 
            // LockWait
            // 
            this.LockWait.Name = "LockWait";
            this.LockWait.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "FireAlarm";
            // 
            // Unlock
            // 
            this.Unlock.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.Unlock.MethodName = "UnlockDoor";
            this.Unlock.Name = "Unlock";
            // 
            // FireAlarmRaised
            // 
            this.FireAlarmRaised.EventName = "FireAlarm";
            this.FireAlarmRaised.InterfaceType = typeof(DoorsWorkflow.IDoorService);
            this.FireAlarmRaised.Name = "FireAlarmRaised";
            // 
            // DoorClosed
            // 
            this.DoorClosed.Activities.Add(this.CloseDoor);
            this.DoorClosed.Activities.Add(this.CloseBeep);
            this.DoorClosed.Activities.Add(this.StateClosed);
            this.DoorClosed.Activities.Add(this.faultHandlersActivity1);
            this.DoorClosed.Name = "DoorClosed";
            // 
            // CLInitialize
            // 
            this.CLInitialize.Activities.Add(this.LockDoor);
            this.CLInitialize.Name = "CLInitialize";
            // 
            // RequestEntry
            // 
            this.RequestEntry.Activities.Add(this.EnterPIN);
            this.RequestEntry.Activities.Add(this.ValidatePIN);
            this.RequestEntry.Activities.Add(this.CheckPINValidity);
            this.RequestEntry.Name = "RequestEntry";
            // 
            // CUInitialize
            // 
            this.CUInitialize.Activities.Add(this.CU_UnlockDoor);
            this.CUInitialize.Name = "CUInitialize";
            // 
            // DoorOpened
            // 
            this.DoorOpened.Activities.Add(this.OpenDoor);
            this.DoorOpened.Activities.Add(this.OpenBeep);
            this.DoorOpened.Activities.Add(this.Opened);
            this.DoorOpened.Name = "DoorOpened";
            // 
            // FireLock
            // 
            this.FireLock.Activities.Add(this.LockWait);
            this.FireLock.Activities.Add(this.LockUp);
            this.FireLock.Name = "FireLock";
            // 
            // OnFireAlarm
            // 
            this.OnFireAlarm.Activities.Add(this.FireAlarmRaised);
            this.OnFireAlarm.Activities.Add(this.Unlock);
            this.OnFireAlarm.Activities.Add(this.setStateActivity1);
            this.OnFireAlarm.Name = "OnFireAlarm";
            // 
            // FireAlarm
            // 
            this.FireAlarm.Name = "FireAlarm";
            // 
            // OpenUnlocked
            // 
            this.OpenUnlocked.Activities.Add(this.DoorClosed);
            this.OpenUnlocked.Name = "OpenUnlocked";
            // 
            // ClosedLocked
            // 
            this.ClosedLocked.Activities.Add(this.RequestEntry);
            this.ClosedLocked.Activities.Add(this.CLInitialize);
            this.ClosedLocked.Name = "ClosedLocked";
            // 
            // ClosedUnlocked
            // 
            this.ClosedUnlocked.Activities.Add(this.FireLock);
            this.ClosedUnlocked.Activities.Add(this.DoorOpened);
            this.ClosedUnlocked.Activities.Add(this.CUInitialize);
            this.ClosedUnlocked.Name = "ClosedUnlocked";
            // 
            // DoorFlow
            // 
            this.Activities.Add(this.ClosedUnlocked);
            this.Activities.Add(this.ClosedLocked);
            this.Activities.Add(this.OpenUnlocked);
            this.Activities.Add(this.FireAlarm);
            this.Activities.Add(this.OnFireAlarm);
            this.CompletedStateName = "FireAlarm";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "ClosedLocked";
            this.Name = "DoorFlow";
            this.CanModifyActivities = false;

        }

        #endregion

        private CallExternalMethodActivity Unlock;
        private HandleExternalEventActivity FireAlarmRaised;
        private EventDrivenActivity OnFireAlarm;
        private StateActivity FireAlarm;
        private SetStateActivity setStateActivity1;
        private FaultHandlersActivity faultHandlersActivity1;
        private CallExternalMethodActivity CU_UnlockDoor;
        private StateInitializationActivity CUInitialize;
        private SetStateActivity LockUp;
        private DelayActivity LockWait;
        private CallExternalMethodActivity LockDoor;
        private EventDrivenActivity FireLock;
        private StateInitializationActivity CLInitialize;
        private SetStateActivity StateClosed;
        private CodeActivity CloseBeep;
        private HandleExternalEventActivity CloseDoor;
        private SetStateActivity Opened;
        private EventDrivenActivity DoorClosed;
        private StateActivity OpenUnlocked;
        private SetStateActivity UnlockDoor;
        private StateActivity ClosedUnlocked;
        private EventDrivenActivity DoorOpened;
        private CodeActivity OpenBeep;
        private HandleExternalEventActivity OpenDoor;
        private IfElseBranchActivity PINInvalid;
        private IfElseBranchActivity PINValid;
        private IfElseActivity CheckPINValidity;
        private EventDrivenActivity RequestEntry;
        private HandleExternalEventActivity EnterPIN;
        private CodeActivity ValidatePIN;
        private StateActivity ClosedLocked;







































































    }
}
