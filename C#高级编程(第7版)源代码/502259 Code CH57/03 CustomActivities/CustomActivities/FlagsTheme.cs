using System;
using System.Workflow.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CustomActivities
{
    /// <summary>
    /// Defines the theme for the Flags designer
    /// </summary>
    public class FlagsTheme : CompositeDesignerTheme
    {
        /// <summary>
        /// Define the properties of the theme
        /// </summary>
        /// <param name="theme"></param>
        public FlagsTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.ShowDropShadow = false;
            this.ConnectorStartCap = LineAnchor.None;
            this.ConnectorEndCap = LineAnchor.None;
            this.ForeColor = Color.FromArgb(0xff, 0x80, 0, 0x80);
            this.BorderColor = Color.FromArgb(0xff, 0xe0, 0xe0, 0xe0);
            this.BorderStyle = DashStyle.Dash;
        }
    }
}
