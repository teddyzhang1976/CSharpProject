using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Tools = Microsoft.Office.Tools;

namespace WordDocEditTimer
{
    public partial class ThisAddIn
    {
        private Dictionary<string, DocumentTimer> documentEditTimes;
        private List<Tools.CustomTaskPane> timerDisplayPanes;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Initialize timers and display panels
            documentEditTimes = new Dictionary<string, DocumentTimer>();
            timerDisplayPanes = new List<Microsoft.Office.Tools.CustomTaskPane>();

            // Add event handlers
            Word.ApplicationEvents4_Event eventInterface = this.Application;
            eventInterface.DocumentOpen += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentOpenEventHandler(eventInterface_DocumentOpen);
            eventInterface.NewDocument += new Microsoft.Office.Interop.Word.ApplicationEvents4_NewDocumentEventHandler(eventInterface_NewDocument);
            eventInterface.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(eventInterface_DocumentBeforeClose);
            eventInterface.WindowActivate += new Microsoft.Office.Interop.Word.ApplicationEvents4_WindowActivateEventHandler(eventInterface_WindowActivate);

            // Start monitoring active document
            MonitorDocument(this.Application.ActiveDocument);
            AddTaskPaneToWindow(this.Application.ActiveDocument.ActiveWindow);
        }

        private void timerDisplayPane_VisibleChanged(object sender, EventArgs e)
        {
            // Get task pane and toggle visibility
            Tools.CustomTaskPane taskPane = (Tools.CustomTaskPane)sender;
            if (taskPane.Visible)
            {
                TimerDisplayPane timerControl = (TimerDisplayPane)taskPane.Control;
                timerControl.RefreshDisplay();
            }
        }

        private void eventInterface_DocumentBeforeClose(Word.Document Doc, ref bool Cancel)
        {
            // Freeze timer
            documentEditTimes[Doc.Name].EditTime += DateTime.Now - documentEditTimes[Doc.Name].LastActive;
            documentEditTimes[Doc.Name].IsActive = false;
            documentEditTimes[Doc.Name].Document = null;

            // Remove task pane
            RemoveTaskPaneFromWindow(Doc.ActiveWindow);
        }

        private void eventInterface_NewDocument(Word.Document Doc)
        {
            // Monitor new doc
            MonitorDocument(Doc);
            AddTaskPaneToWindow(Doc.ActiveWindow);

            // Set checkbox
            Globals.Ribbons.TimerRibbon.SetPauseStatus(false);
        }

        private void eventInterface_DocumentOpen(Word.Document Doc)
        {
            if (documentEditTimes.ContainsKey(Doc.Name))
            {
                // Monitor old doc
                documentEditTimes[Doc.Name].LastActive = DateTime.Now;
                documentEditTimes[Doc.Name].IsActive = true;
                documentEditTimes[Doc.Name].Document = Doc;
                AddTaskPaneToWindow(Doc.ActiveWindow);
            }
            else
            {
                // Monitor new doc
                MonitorDocument(Doc);
                AddTaskPaneToWindow(Doc.ActiveWindow);
            }
        }

        internal void MonitorDocument(Word.Document Doc)
        {
            // Monitor doc
            documentEditTimes.Add(Doc.Name, new DocumentTimer
            {
                Document = Doc,
                EditTime = new TimeSpan(0),
                IsActive = true,
                LastActive = DateTime.Now
            });
        }

        private void AddTaskPaneToWindow(Word.Window Wn)
        {
            // Check for task pane in window
            Tools.CustomTaskPane docPane = null;
            Tools.CustomTaskPane paneToRemove = null;
            foreach (Tools.CustomTaskPane pane in timerDisplayPanes)
            {
                try
                {
                    if (pane.Window == Wn)
                    {
                        docPane = pane;
                        break;
                    }
                }
                catch (ArgumentNullException)
                {
                    // pane.Window is null, so document1 has been unloaded.
                    paneToRemove = pane;
                }
            }

            // Remove pane if necessary
            timerDisplayPanes.Remove(paneToRemove);

            // Add task pane to doc
            if (docPane == null)
            {
                Tools.CustomTaskPane pane = this.CustomTaskPanes.Add(
                   new TimerDisplayPane(documentEditTimes),
                   "Document Edit Timer",
                   Wn);
                timerDisplayPanes.Add(pane);
                pane.VisibleChanged += new EventHandler(timerDisplayPane_VisibleChanged);
            }
        }

        private void RemoveTaskPaneFromWindow(Word.Window Wn)
        {
            // Check for task pane in window
            Tools.CustomTaskPane docPane = null;
            foreach (Tools.CustomTaskPane pane in timerDisplayPanes)
            {
                if (pane.Window == Wn)
                {
                    docPane = pane;
                    break;
                }
            }

            // Remove document task pane
            if (docPane != null)
            {
                this.CustomTaskPanes.Remove(docPane);
                timerDisplayPanes.Remove(docPane);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Allow disposal to clean up.
        }

        internal void ToggleTaskPaneDisplay()
        {
            // Ensure window has task window
            AddTaskPaneToWindow(this.Application.ActiveDocument.ActiveWindow);

            // toggle document task pane
            Tools.CustomTaskPane docPane = null;
            foreach (Tools.CustomTaskPane pane in timerDisplayPanes)
            {
                if (pane.Window == this.Application.ActiveDocument.ActiveWindow)
                {
                    docPane = pane;
                    break;
                }
            }
            docPane.Visible = !docPane.Visible;
        }

        internal void PauseOrResumeTimer(bool pause)
        {
            // Get timer
            DocumentTimer documentTimer = documentEditTimes[this.Application.ActiveDocument.Name];

            if (pause && documentTimer.IsActive)
            {
                // Freeze timer
                documentTimer.EditTime += DateTime.Now - documentTimer.LastActive;
                documentTimer.IsActive = false;
            }
            else if (!pause && !documentTimer.IsActive)
            {
                // Resume timer
                documentTimer.IsActive = true;
                documentTimer.LastActive = DateTime.Now;
            }
        }

        private void eventInterface_WindowActivate(Word.Document Doc, Word.Window Wn)
        {
            if (documentEditTimes.ContainsKey(this.Application.ActiveDocument.Name))
            {
                // Ensure pause checkbox in ribbon is accurate, start by getting timer
                DocumentTimer documentTimer = documentEditTimes[this.Application.ActiveDocument.Name];

                // Set checkbox
                Globals.Ribbons.TimerRibbon.SetPauseStatus(!documentTimer.IsActive);
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
