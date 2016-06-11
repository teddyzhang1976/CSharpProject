using System;
using System.Workflow.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CustomActivities
{
    /// <summary>
    /// Define a theme for the WriteLineActivity
    /// </summary>
	public class WriteLineTheme : ActivityDesignerTheme
	{
        /// <summary>
        /// Construct the theme and set some defaults
        /// </summary>
        /// <param name="theme"></param>
        public WriteLineTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BackColorStart = Color.Yellow;
            this.BackColorEnd = Color.Orange;
            this.BackgroundStyle = LinearGradientMode.ForwardDiagonal;
        }
	}
}
