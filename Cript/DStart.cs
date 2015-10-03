using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cript
{
	/// <summary>
	/// Summary description for DStart.
	/// </summary>
	public class DStart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.TextBox txtMsg;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label txtMode;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox pictureBoxDel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components;

		public DStart()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Text += " - " + Cript.APPNAME;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public void SetDeleteMode()
		{
			this.btnYes.BackColor = SystemColors.ControlDarkDark;
			this.btnYes.ForeColor = SystemColors.ControlLightLight;
			this.AcceptButton = this.btnNo;
			//this.CancelButton = this.btnYes;
			this.btnNo.TabIndex = 0;
			this.btnYes.TabIndex = 1;
			this.pictureBox1.Visible = false;
			this.pictureBoxDel.Visible = true;
		}

		public bool PleaseConfirm(IWin32Window w, Image m, string mode, string text)
		{
			if(m!= null) this.pictureBox.Image = m;
			if(text != null) this.txtMsg.Text = text;
			if(mode != null) this.txtMode.Text = mode;
			this.ShowDialog(w);
			return confirmed;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DStart));
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.txtMsg = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMode = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pictureBoxDel = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(8, 8);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 16);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// btnYes
			// 
			this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnYes.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnYes.Image")));
			this.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnYes.Location = new System.Drawing.Point(64, 152);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(88, 20);
			this.btnYes.TabIndex = 0;
			this.btnYes.Text = "Yes";
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnNo.Location = new System.Drawing.Point(184, 152);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(88, 20);
			this.btnNo.TabIndex = 1;
			this.btnNo.Text = "No";
			// 
			// txtMsg
			// 
			this.txtMsg.BackColor = System.Drawing.SystemColors.Control;
			this.txtMsg.Location = new System.Drawing.Point(64, 32);
			this.txtMsg.Multiline = true;
			this.txtMsg.Name = "txtMsg";
			this.txtMsg.ReadOnly = true;
			this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMsg.Size = new System.Drawing.Size(208, 88);
			this.txtMsg.TabIndex = 3;
			this.txtMsg.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Do you want to continue? ";
			// 
			// txtMode
			// 
			this.txtMode.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.txtMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.txtMode.Location = new System.Drawing.Point(64, 8);
			this.txtMode.Name = "txtMode";
			this.txtMode.Size = new System.Drawing.Size(208, 16);
			this.txtMode.TabIndex = 2;
			// 
			// pictureBoxDel
			// 
			this.pictureBoxDel.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBoxDel.Image")));
			this.pictureBoxDel.Location = new System.Drawing.Point(16, 64);
			this.pictureBoxDel.Name = "pictureBoxDel";
			this.pictureBoxDel.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxDel.TabIndex = 6;
			this.pictureBoxDel.TabStop = false;
			this.pictureBoxDel.Visible = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 64);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// DStart
			// 
			this.AcceptButton = this.btnYes;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnNo;
			this.ClientSize = new System.Drawing.Size(282, 184);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.pictureBoxDel,
																		  this.txtMode,
																		  this.label1,
																		  this.txtMsg,
																		  this.btnNo,
																		  this.btnYes,
																		  this.pictureBox});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DStart";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Confirm Start";
			this.ResumeLayout(false);

		}
		#endregion

		private bool confirmed = false;
		private void btnYes_Click(object sender, System.EventArgs e)
		{
			confirmed = true;
		}

		private void pictureBoxMB_Click(object sender, System.EventArgs e)
		{
			Cript.ShowMB();
		}
	}
}
