namespace YaMdEditor
{
  partial class FormAbout
  {
    /// <summary>
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows

    /// <summary>
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
        this.cmdOK = new System.Windows.Forms.Button();
        this.labelAppName = new System.Windows.Forms.Label();
        this.labelVersion = new System.Windows.Forms.Label();
        this.labelCopyright = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.lblAppName = new System.Windows.Forms.Label();
        this.llbAppUrl = new System.Windows.Forms.LinkLabel();
        this.SuspendLayout();
        // 
        // cmdOK
        // 
        this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdOK.Location = new System.Drawing.Point(343, 261);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(75, 23);
        this.cmdOK.TabIndex = 0;
        this.cmdOK.Text = "&OK";
        this.cmdOK.UseVisualStyleBackColor = true;
        this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
        // 
        // labelAppName
        // 
        this.labelAppName.AutoSize = true;
        this.labelAppName.Location = new System.Drawing.Point(15, 9);
        this.labelAppName.Name = "labelAppName";
        this.labelAppName.Size = new System.Drawing.Size(77, 12);
        this.labelAppName.TabIndex = 2;
        this.labelAppName.Text = "labelAppName";
        // 
        // labelVersion
        // 
        this.labelVersion.AutoSize = true;
        this.labelVersion.Location = new System.Drawing.Point(15, 28);
        this.labelVersion.Name = "labelVersion";
        this.labelVersion.Size = new System.Drawing.Size(77, 12);
        this.labelVersion.TabIndex = 3;
        this.labelVersion.Text = "labelVersion";
        // 
        // labelCopyright
        // 
        this.labelCopyright.AutoSize = true;
        this.labelCopyright.Location = new System.Drawing.Point(15, 47);
        this.labelCopyright.Name = "labelCopyright";
        this.labelCopyright.Size = new System.Drawing.Size(89, 12);
        this.labelCopyright.TabIndex = 4;
        this.labelCopyright.Text = "labelCopyright";
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(17, 110);
        this.textBox1.Margin = new System.Windows.Forms.Padding(4);
        this.textBox1.Multiline = true;
        this.textBox1.Name = "textBox1";
        this.textBox1.ReadOnly = true;
        this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.textBox1.Size = new System.Drawing.Size(401, 131);
        this.textBox1.TabIndex = 10;
        this.textBox1.Text = resources.GetString("textBox1.Text");
        // 
        // lblAppName
        // 
        this.lblAppName.AutoSize = true;
        this.lblAppName.Location = new System.Drawing.Point(15, 66);
        this.lblAppName.Name = "lblAppName";
        this.lblAppName.Size = new System.Drawing.Size(167, 12);
        this.lblAppName.TabIndex = 11;
        this.lblAppName.Text = "Yet another Markdown Editor";
        // 
        // llbAppUrl
        // 
        this.llbAppUrl.AutoSize = true;
        this.llbAppUrl.Location = new System.Drawing.Point(15, 85);
        this.llbAppUrl.Name = "llbAppUrl";
        this.llbAppUrl.Size = new System.Drawing.Size(215, 12);
        this.llbAppUrl.TabIndex = 15;
        this.llbAppUrl.TabStop = true;
        this.llbAppUrl.Text = "https://github.com/lslab/YaMdEditor";
        this.llbAppUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbAppUrl_LinkClicked);
        // 
        // FormAbout
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.cmdOK;
        this.ClientSize = new System.Drawing.Size(432, 299);
        this.Controls.Add(this.llbAppUrl);
        this.Controls.Add(this.lblAppName);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.labelCopyright);
        this.Controls.Add(this.labelVersion);
        this.Controls.Add(this.labelAppName);
        this.Controls.Add(this.cmdOK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FormAbout";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "YaMdEditor";
        this.Load += new System.EventHandler(this.FormAbout_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdOK;
    private System.Windows.Forms.Label labelAppName;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.LinkLabel llbAppUrl;
  }
}