namespace Wrox.ProCSharp.Localization
{
  partial class BookOfTheDayForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookOfTheDayForm));
      this.pictureFlag = new System.Windows.Forms.PictureBox();
      this.labelBookOfTheDay = new System.Windows.Forms.Label();
      this.labelItemsSold = new System.Windows.Forms.Label();
      this.textTitle = new System.Windows.Forms.TextBox();
      this.textDate = new System.Windows.Forms.TextBox();
      this.textItemsSold = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureFlag)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureFlag
      // 
      resources.ApplyResources(this.pictureFlag, "pictureFlag");
      this.pictureFlag.Image = global::Wrox.ProCSharp.Localization.Properties.Resources.Flag;
      this.pictureFlag.Name = "pictureFlag";
      this.pictureFlag.TabStop = false;
      // 
      // labelBookOfTheDay
      // 
      resources.ApplyResources(this.labelBookOfTheDay, "labelBookOfTheDay");
      this.labelBookOfTheDay.Name = "labelBookOfTheDay";
      // 
      // labelItemsSold
      // 
      resources.ApplyResources(this.labelItemsSold, "labelItemsSold");
      this.labelItemsSold.Name = "labelItemsSold";
      // 
      // textTitle
      // 
      resources.ApplyResources(this.textTitle, "textTitle");
      this.textTitle.Name = "textTitle";
      // 
      // textDate
      // 
      resources.ApplyResources(this.textDate, "textDate");
      this.textDate.Name = "textDate";
      // 
      // textItemsSold
      // 
      resources.ApplyResources(this.textItemsSold, "textItemsSold");
      this.textItemsSold.Name = "textItemsSold";
      // 
      // BookOfTheDayForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.textItemsSold);
      this.Controls.Add(this.textDate);
      this.Controls.Add(this.textTitle);
      this.Controls.Add(this.labelItemsSold);
      this.Controls.Add(this.labelBookOfTheDay);
      this.Controls.Add(this.pictureFlag);
      this.Name = "BookOfTheDayForm";
      ((System.ComponentModel.ISupportInitialize)(this.pictureFlag)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureFlag;
    private System.Windows.Forms.Label labelBookOfTheDay;
    private System.Windows.Forms.Label labelItemsSold;
    private System.Windows.Forms.TextBox textTitle;
    private System.Windows.Forms.TextBox textDate;
    private System.Windows.Forms.TextBox textItemsSold;
  }
}

