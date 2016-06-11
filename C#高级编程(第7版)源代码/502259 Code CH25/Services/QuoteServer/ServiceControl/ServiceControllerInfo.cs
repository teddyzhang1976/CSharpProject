using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace Wrox.ProCSharp.WinServices
{
    public class ServiceControllerInfo
    {
        private readonly ServiceController controller;

        public ServiceControllerInfo(ServiceController controller)
        {
            this.controller = controller;
        }

        public ServiceController Controller
        {
            get { return controller; }
        }

        public string ServiceTypeName
        {
            get
            {
                ServiceType type = controller.ServiceType;
                string serviceTypeName = String.Empty;
                if ((type & ServiceType.InteractiveProcess) != 0)
                {
                    serviceTypeName = "Interactive ";
                    type -= ServiceType.InteractiveProcess;
                }
                switch (type)
                {
                    case ServiceType.Adapter:
                        serviceTypeName += "Adapter";
                        break;

                    case ServiceType.FileSystemDriver:
                    case ServiceType.KernelDriver:
                    case ServiceType.RecognizerDriver:
                        serviceTypeName += "Driver";
                        break;

                    case ServiceType.Win32OwnProcess:
                        serviceTypeName += "Win32 Service Process";
                        break;

                    case ServiceType.Win32ShareProcess:
                        serviceTypeName += "Win32 Shared Process";
                        break;

                    default:
                        serviceTypeName += "unknown type " + type.ToString();
                        break;
                }
                return serviceTypeName;
            }
        }

        public string ServiceStatusName
        {
            get
            {
                switch (controller.Status)
                {
                    case ServiceControllerStatus.ContinuePending:
                        return "Continue Pending";
                    case ServiceControllerStatus.Paused:
                        return "Paused";
                    case ServiceControllerStatus.PausePending:
                        return "Pause Pending";
                    case ServiceControllerStatus.StartPending:
                        return "Start Pending";
                    case ServiceControllerStatus.Running:
                        return "Running";
                    case ServiceControllerStatus.Stopped:
                        return "Stopped";
                    case ServiceControllerStatus.StopPending:
                        return "Stop Pending";
                    default:
                        return "Unknown status";
                }
            }
        }

        public string DisplayName
        {
            get { return controller.DisplayName; }
        }

        public string ServiceName
        {
            get { return controller.ServiceName; }
        }

        public bool EnableStart
        {
            get
            {
                return controller.Status == ServiceControllerStatus.Stopped;
            }
        }

        public bool EnableStop
        {
            get
            {
                return controller.Status == ServiceControllerStatus.Running;
            }
        }

        public bool EnablePause
        {
            get
            {
                return controller.Status == ServiceControllerStatus.Running &&
                      controller.CanPauseAndContinue;
            }
        }

        public bool EnableContinue
        {
            get
            {
                return controller.Status == ServiceControllerStatus.Paused;
            }
        }

    }
}
