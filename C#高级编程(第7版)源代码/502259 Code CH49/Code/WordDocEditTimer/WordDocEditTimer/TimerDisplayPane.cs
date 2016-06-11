using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace WordDocEditTimer
{
    public partial class TimerDisplayPane : UserControl
    {
        private Dictionary<string, DocumentTimer> documentEditTimes;

        public TimerDisplayPane()
        {
            InitializeComponent();
        }

        public TimerDisplayPane(Dictionary<string, DocumentTimer> documentEditTimes)
            : this()
        {
            // Store reference to edit times
            this.documentEditTimes = documentEditTimes;
        }

        internal void RefreshDisplay()
        {
            // Clear existing list
            this.timerList.Items.Clear();

            // Ensure all docs are monitored
            foreach (Word.Document doc in Globals.ThisAddIn.Application.Documents)
            {
                bool isMonitored = false;
                bool requiresNameChange = false;
                DocumentTimer oldNameTimer = null;
                string oldName = null;
                foreach (string documentName in documentEditTimes.Keys)
                {
                    if (doc.Name == documentName)
                    {
                        isMonitored = true;
                        break;
                    }
                    else
                    {
                        if (documentEditTimes[documentName].Document == doc)
                        {
                            // Monitored, but name changed!
                            oldName = documentName;
                            oldNameTimer = documentEditTimes[documentName];
                            isMonitored = true;
                            requiresNameChange = true;
                            break;
                        }
                    }
                }

                // Add monitor if not monitored
                if (!isMonitored)
                {
                    Globals.ThisAddIn.MonitorDocument(doc);
                }

                // Rename if necessary
                if (requiresNameChange)
                {
                    documentEditTimes.Remove(oldName);
                    documentEditTimes.Add(doc.Name, oldNameTimer);
                }
            }

            // Create new list
            foreach (string documentName in documentEditTimes.Keys)
            {
                // Check to see if doc is still loaded
                bool isLoaded = false;
                foreach (Word.Document doc in Globals.ThisAddIn.Application.Documents)
                {
                    if (doc.Name == documentName)
                    {
                        isLoaded = true;
                        break;
                    }
                }
                if (!isLoaded)
                {
                    documentEditTimes[documentName].IsActive = false;
                    documentEditTimes[documentName].Document = null;
                }

                // Add item
                this.timerList.Items.Add(string.Format("{0}: {1}", documentName,
                   documentEditTimes[documentName].EditTime +
                   (documentEditTimes[documentName].IsActive ?
                   (DateTime.Now - documentEditTimes[documentName].LastActive) : new TimeSpan(0))));
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshDisplay();
        }
    }
}