using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace WordDocEditTimer
{
    public partial class TimerRibbon
    {
        private void TimerRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void group1_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            // Show or hide task pane
            Globals.ThisAddIn.ToggleTaskPaneDisplay();
        }

        private void toggleDisplayButton_Click(object sender, RibbonControlEventArgs e)
        {
            // Show or hide task pane
            Globals.ThisAddIn.ToggleTaskPaneDisplay();
        }

        private void pauseCheckBox_Click(object sender, RibbonControlEventArgs e)
        {
            // Pause timer
            Globals.ThisAddIn.PauseOrResumeTimer(pauseCheckBox.Checked);
        }

        internal void SetPauseStatus(bool isPaused)
        {
            // Ensure checkbox is accurate
            pauseCheckBox.Checked = isPaused;
        }
    }
}
