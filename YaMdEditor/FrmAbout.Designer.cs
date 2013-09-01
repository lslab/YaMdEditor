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
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.labelAppName = new System.Windows.Forms.Label();
        this.labelVersion = new System.Windows.Forms.Label();
        this.labelCopyright = new System.Windows.Forms.Label();
        this.labelSpecialThanks = new System.Windows.Forms.Label();
        this.linkLabel2 = new System.Windows.Forms.LinkLabel();
        this.label1 = new System.Windows.Forms.Label();
        this.linkLabel3 = new System.Windows.Forms.LinkLabel();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.linkLabel1 = new System.Windows.Forms.LinkLabel();
        this.label4 = new System.Windows.Forms.Label();
        this.linkLabel4 = new System.Windows.Forms.LinkLabel();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // cmdOK
        // 
        this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdOK.Location = new System.Drawing.Point(340, 420);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(75, 23);
        this.cmdOK.TabIndex = 0;
        this.cmdOK.Text = "&OK";
        this.cmdOK.UseVisualStyleBackColor = true;
        this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
        // 
        // pictureBox1
        // 
        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        this.pictureBox1.InitialImage = null;
        this.pictureBox1.Location = new System.Drawing.Point(17, 11);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(48, 48);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        this.pictureBox1.TabIndex = 1;
        this.pictureBox1.TabStop = false;
        // 
        // labelAppName
        // 
        this.labelAppName.AutoSize = true;
        this.labelAppName.Location = new System.Drawing.Point(79, 11);
        this.labelAppName.Name = "labelAppName";
        this.labelAppName.Size = new System.Drawing.Size(77, 12);
        this.labelAppName.TabIndex = 2;
        this.labelAppName.Text = "labelAppName";
        // 
        // labelVersion
        // 
        this.labelVersion.AutoSize = true;
        this.labelVersion.Location = new System.Drawing.Point(79, 29);
        this.labelVersion.Name = "labelVersion";
        this.labelVersion.Size = new System.Drawing.Size(77, 12);
        this.labelVersion.TabIndex = 3;
        this.labelVersion.Text = "labelVersion";
        // 
        // labelCopyright
        // 
        this.labelCopyright.AutoSize = true;
        this.labelCopyright.Location = new System.Drawing.Point(79, 47);
        this.labelCopyright.Name = "labelCopyright";
        this.labelCopyright.Size = new System.Drawing.Size(89, 12);
        this.labelCopyright.TabIndex = 4;
        this.labelCopyright.Text = "labelCopyright";
        // 
        // labelSpecialThanks
        // 
        this.labelSpecialThanks.Location = new System.Drawing.Point(15, 185);
        this.labelSpecialThanks.Name = "labelSpecialThanks";
        this.labelSpecialThanks.Size = new System.Drawing.Size(368, 28);
        this.labelSpecialThanks.TabIndex = 6;
        this.labelSpecialThanks.Text = "Markdown  -  A text-to-HTML conversion tool for web writers\r\nCopyright (c) 2004 J" +
            "ohn Gruber\r\n";
        // 
        // linkLabel2
        // 
        this.linkLabel2.AutoSize = true;
        this.linkLabel2.Location = new System.Drawing.Point(15, 213);
        this.linkLabel2.Name = "linkLabel2";
        this.linkLabel2.Size = new System.Drawing.Size(269, 12);
        this.linkLabel2.TabIndex = 7;
        this.linkLabel2.TabStop = true;
        this.linkLabel2.Text = "http://daringfireball.net/projects/markdown/";
        this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(15, 236);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(335, 24);
        this.label1.TabIndex = 8;
        this.label1.Text = "MarkdownDeep\r\nCopyright 2010-2011 Topten Software";
        // 
        // linkLabel3
        // 
        this.linkLabel3.AutoSize = true;
        this.linkLabel3.Location = new System.Drawing.Point(15, 261);
        this.linkLabel3.Name = "linkLabel3";
        this.linkLabel3.Size = new System.Drawing.Size(263, 12);
        this.linkLabel3.TabIndex = 9;
        this.linkLabel3.TabStop = true;
        this.linkLabel3.Text = "http://www.toptensoftware.com/markdowndeep/";
        this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(13, 282);
        this.textBox1.Margin = new System.Windows.Forms.Padding(4);
        this.textBox1.Multiline = true;
        this.textBox1.Name = "textBox1";
        this.textBox1.ReadOnly = true;
        this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.textBox1.Size = new System.Drawing.Size(401, 131);
        this.textBox1.TabIndex = 10;
        this.textBox1.Text = resources.GetString("textBox1.Text");
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(15, 71);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(167, 12);
        this.label2.TabIndex = 11;
        this.label2.Text = "Yet another Markdown Editor";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(15, 113);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(41, 12);
        this.label3.TabIndex = 12;
        this.label3.Text = "Thanks";
        // 
        // linkLabel1
        // 
        this.linkLabel1.AutoSize = true;
        this.linkLabel1.Location = new System.Drawing.Point(15, 157);
        this.linkLabel1.Name = "linkLabel1";
        this.linkLabel1.Size = new System.Drawing.Size(275, 12);
        this.linkLabel1.TabIndex = 14;
        this.linkLabel1.TabStop = true;
        this.linkLabel1.Text = "https://github.com/hibara/MarkDownSharpEditor";
        this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
        // 
        // label4
        // 
        this.label4.Location = new System.Drawing.Point(15, 132);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(335, 24);
        this.label4.TabIndex = 13;
        this.label4.Text = "MarkDown#Editor\nCopyright (C) 2012-2013 M.Hibara, All rights reserved.";
        // 
        // linkLabel4
        // 
        this.linkLabel4.AutoSize = true;
        this.linkLabel4.Location = new System.Drawing.Point(15, 88);
        this.linkLabel4.Name = "linkLabel4";
        this.linkLabel4.Size = new System.Drawing.Size(215, 12);
        this.linkLabel4.TabIndex = 15;
        this.linkLabel4.TabStop = true;
        this.linkLabel4.Text = "https://github.com/lslab/YaMdEditor";
        this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
        // 
        // FormAbout
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.cmdOK;
        this.ClientSize = new System.Drawing.Size(427, 454);
        this.Controls.Add(this.linkLabel4);
        this.Controls.Add(this.linkLabel1);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.linkLabel3);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.linkLabel2);
        this.Controls.Add(this.labelSpecialThanks);
        this.Controls.Add(this.labelCopyright);
        this.Controls.Add(this.labelVersion);
        this.Controls.Add(this.labelAppName);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.cmdOK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FormAbout";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "YaMdEditor";
        this.Load += new System.EventHandler(this.FormAbout_Load);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdOK;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label labelAppName;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.Label labelCopyright;
    private System.Windows.Forms.Label labelSpecialThanks;
    private System.Windows.Forms.LinkLabel linkLabel2;
    private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel4;
  }
}