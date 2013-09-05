namespace YaMdEditor
{
    partial class FrmOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tabOption = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tpMarkdown = new System.Windows.Forms.TabPage();
            this.tabOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOption
            // 
            this.tabOption.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabOption.Controls.Add(this.tpGeneral);
            this.tabOption.Controls.Add(this.tpMarkdown);
            this.tabOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOption.Location = new System.Drawing.Point(0, 0);
            this.tabOption.Multiline = true;
            this.tabOption.Name = "tabOption";
            this.tabOption.SelectedIndex = 0;
            this.tabOption.Size = new System.Drawing.Size(618, 395);
            this.tabOption.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Location = new System.Drawing.Point(22, 4);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(592, 387);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "general";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tpMarkdown
            // 
            this.tpMarkdown.Location = new System.Drawing.Point(22, 4);
            this.tpMarkdown.Name = "tpMarkdown";
            this.tpMarkdown.Padding = new System.Windows.Forms.Padding(3);
            this.tpMarkdown.Size = new System.Drawing.Size(592, 387);
            this.tpMarkdown.TabIndex = 1;
            this.tpMarkdown.Text = "markdown";
            this.tpMarkdown.UseVisualStyleBackColor = true;
            // 
            // FrmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 395);
            this.Controls.Add(this.tabOption);
            this.Name = "FrmOption";
            this.Text = "Option";
            this.tabOption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOption;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpMarkdown;
    }
}