using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace Wrox.ProCSharp.WinServices
{
    public partial class QuoteService : ServiceBase
    {
        private QuoteServer quoteServer;

        public QuoteService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            quoteServer = new QuoteServer(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "quotes.txt"), 5678);
            quoteServer.Start();

        }

        protected override void OnStop()
        {
            quoteServer.Stop();
        }

        protected override void OnContinue()
        {
            base.OnContinue();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        public const int commandRefresh = 128;
        protected override void OnCustomCommand(int command)
        {
            switch (command)
            {
                case commandRefresh:
                    quoteServer.RefreshQuotes();
                    break;

                default:
                    break;
            }

        }
    }
}
