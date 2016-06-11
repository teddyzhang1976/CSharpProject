using System;

namespace Wrox.ProCSharp.Remoting
{
    [Serializable]
    public class StatusEventArgs : EventArgs
    {
        public StatusEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }

    }

    public class RemoteObject : MarshalByRefObject
    {
        public RemoteObject()
        {
            Console.WriteLine("RemoteObject constructor called");
        }
        public event EventHandler<StatusEventArgs> Status;

        public void LongWorking(int ms)
        {
            Console.WriteLine("RemoteObject: LongWorking() Started");
            StatusEventArgs e = new StatusEventArgs("Message for Client: LongWorking() Started");
            // fire event
            if (Status != null)
            {
                Console.WriteLine("RemoteObject: Firing Starting Event");
                Status(this, e);
            }
            System.Threading.Thread.Sleep(ms);
            e.Message = "Message for Client: LongWorking() Ending";
            // fire ending event
            if (Status != null)
            {
                Console.WriteLine("RemoteObject: Firing Ending Event");
                Status(this, e);
            }
            Console.WriteLine("RemoteObject: LongWorking() Ending");
        }

    }
}
