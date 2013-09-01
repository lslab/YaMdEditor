using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace YaMdEditor
{
	public partial class FormAbout : Form
	{
		public FormAbout()
		{
			InitializeComponent();
		}

		private void FormAbout_Load(object sender, EventArgs e)
		{


			Assembly assembly = Assembly.GetEntryAssembly();
			AssemblyCopyrightAttribute[] CopyrightAttribute =
					(AssemblyCopyrightAttribute[])assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
			String CopyrightString = CopyrightAttribute[0].Copyright;

			labelAppName.Text = Application.ProductName;
			labelVersion.Text = "Version." + Application.ProductVersion;
			labelCopyright.Text = CopyrightString;

		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			linkLabel2.LinkVisited = true;
			System.Diagnostics.Process.Start(linkLabel2.Text);
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			linkLabel3.LinkVisited = true;
			System.Diagnostics.Process.Start(linkLabel3.Text);
		}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel4.LinkVisited = true;
            System.Diagnostics.Process.Start(linkLabel4.Text);
        }


	}
}
