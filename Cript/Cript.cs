// Copyright (c) 2006 Vasian Cepa 
// GPL - GNU GENERAL PUBLIC LICENSE (Version 2 and newer)
// http://www.madebits.com
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using sc;

namespace Cript
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Cript : System.Windows.Forms.Form, StreamCipherMonitor
	{
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Panel panelMiddle;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.RichTextBox txtLog;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ProgressBar progressTotal;
		private System.Windows.Forms.ProgressBar progressCurrent;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.ComboBox cmbAlgo;
		private System.Windows.Forms.NumericUpDown numIC;
		private System.Windows.Forms.RadioButton radioDec;
		private System.Windows.Forms.RadioButton radioEnc;
		private System.Windows.Forms.RadioButton radioAuto;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Splitter splitter;
		private System.Windows.Forms.ColumnHeader columnFile;
		private System.Windows.Forms.ColumnHeader columnSize;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ColumnHeader columType;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckBox chkKeep;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.ImageList imageListTB;
		private System.Windows.Forms.ToolBarButton tbAdd;
		private System.Windows.Forms.ToolBarButton tbAddDir;
		private System.Windows.Forms.ToolBarButton tbRemove;
		private System.Windows.Forms.ToolBarButton tbInfo;
		private System.Windows.Forms.ToolBarButton tbPaste;
		private System.Windows.Forms.ToolBarButton tbCopy;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.Button btnClean;
		private System.Windows.Forms.CheckBox chkMask;
		private System.Windows.Forms.Button btnGen;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnIC;
		private System.Windows.Forms.Button btnAES;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton tbAbout;
		private System.Windows.Forms.ToolBarButton tbStart;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton tbGen;
		private System.Windows.Forms.RadioButton radioCRC;
		private System.Windows.Forms.RadioButton radioDel;
		private System.Windows.Forms.ToolBarButton toolBarButtonTG;
		private System.Windows.Forms.RadioButton radioScan;
		private System.Windows.Forms.ContextMenu contextMenuList;
		private System.Windows.Forms.MenuItem mnuAddFiles;
		private System.Windows.Forms.MenuItem mnuAddDir;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuRemSel;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mnuPaste;
		private System.Windows.Forms.MenuItem mnuCopy;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuSelect;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ToolBarButton tbMID;

		private string[] commandLine = null;
		public Cript(string[] args)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Text = APPNAME + " - " + Version + " - http://madebits.com";
			InitTB();
			commandLine = args;
			this.cmbAlgo.SelectedIndex = 0;
		}

		public static string Version
		{
			get 
			{ 
				//return "0.2.9";
				try
				{
					string name = System.Reflection.Assembly.GetExecutingAssembly().FullName;
					if(name == null) throw new Exception();
					string[] parts = name.Split(',');
					for(int i = 0; i < parts.Length; ++i)
					{
						string part = parts[i].Trim().ToUpper();
						if(part.StartsWith("VERSION"))
						{
							string[] ver = part.Split('=');
							int j = ver[1].LastIndexOf('.');
							if(j <= 0) return ver[1];
							return ver[1].Substring(0, j);
						}
					}
				}
				catch
				{}
				return "?.?.?";
			}
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Cript));
			this.panelTop = new System.Windows.Forms.Panel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.panelMiddle = new System.Windows.Forms.Panel();
			this.listView = new System.Windows.Forms.ListView();
			this.columnFile = new System.Windows.Forms.ColumnHeader();
			this.columnSize = new System.Windows.Forms.ColumnHeader();
			this.columType = new System.Windows.Forms.ColumnHeader();
			this.contextMenuList = new System.Windows.Forms.ContextMenu();
			this.mnuSelect = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuAddFiles = new System.Windows.Forms.MenuItem();
			this.mnuAddDir = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuCopy = new System.Windows.Forms.MenuItem();
			this.mnuPaste = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.mnuRemSel = new System.Windows.Forms.MenuItem();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.tbAdd = new System.Windows.Forms.ToolBarButton();
			this.tbAddDir = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbCopy = new System.Windows.Forms.ToolBarButton();
			this.tbPaste = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbRemove = new System.Windows.Forms.ToolBarButton();
			this.tbInfo = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.tbGen = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonTG = new System.Windows.Forms.ToolBarButton();
			this.tbStart = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.tbMID = new System.Windows.Forms.ToolBarButton();
			this.tbAbout = new System.Windows.Forms.ToolBarButton();
			this.imageListTB = new System.Windows.Forms.ImageList(this.components);
			this.panelBottom = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.radioScan = new System.Windows.Forms.RadioButton();
			this.radioDel = new System.Windows.Forms.RadioButton();
			this.radioCRC = new System.Windows.Forms.RadioButton();
			this.btnAES = new System.Windows.Forms.Button();
			this.btnIC = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnGen = new System.Windows.Forms.Button();
			this.btnClean = new System.Windows.Forms.Button();
			this.chkKeep = new System.Windows.Forms.CheckBox();
			this.chkMask = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.radioDec = new System.Windows.Forms.RadioButton();
			this.radioEnc = new System.Windows.Forms.RadioButton();
			this.radioAuto = new System.Windows.Forms.RadioButton();
			this.txtLog = new System.Windows.Forms.RichTextBox();
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.cmbAlgo = new System.Windows.Forms.ComboBox();
			this.numIC = new System.Windows.Forms.NumericUpDown();
			this.progressCurrent = new System.Windows.Forms.ProgressBar();
			this.progressTotal = new System.Windows.Forms.ProgressBar();
			this.splitter = new System.Windows.Forms.Splitter();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.panelTop.SuspendLayout();
			this.panelMiddle.SuspendLayout();
			this.panelBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numIC)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.pictureBox});
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(612, 50);
			this.panelTop.TabIndex = 0;
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.White;
			this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox.Image")));
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(612, 50);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBox, "Get help and the latest version!");
			this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			// 
			// panelMiddle
			// 
			this.panelMiddle.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.listView,
																					  this.toolBar});
			this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMiddle.Location = new System.Drawing.Point(0, 50);
			this.panelMiddle.Name = "panelMiddle";
			this.panelMiddle.Size = new System.Drawing.Size(612, 178);
			this.panelMiddle.TabIndex = 1;
			// 
			// listView
			// 
			this.listView.AllowDrop = true;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnFile,
																					   this.columnSize,
																					   this.columType});
			this.listView.ContextMenu = this.contextMenuList;
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.HideSelection = false;
			this.listView.LabelWrap = false;
			this.listView.Location = new System.Drawing.Point(0, 41);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(612, 137);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 1;
			this.toolTip.SetToolTip(this.listView, "Drag and drop files");
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
			this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
			this.listView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_MouseUp);
			this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
			this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
			this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
			this.listView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView_MouseMove);
			// 
			// columnFile
			// 
			this.columnFile.Text = "Path";
			this.columnFile.Width = 350;
			// 
			// columnSize
			// 
			this.columnSize.Text = "Size (KB)";
			this.columnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnSize.Width = 80;
			// 
			// columType
			// 
			this.columType.Text = "Type";
			this.columType.Width = 50;
			// 
			// contextMenuList
			// 
			this.contextMenuList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.mnuSelect,
																							this.menuItem1,
																							this.mnuAddFiles,
																							this.mnuAddDir,
																							this.menuItem3,
																							this.mnuCopy,
																							this.mnuPaste,
																							this.menuItem6,
																							this.mnuRemSel});
			this.contextMenuList.Popup += new System.EventHandler(this.contextMenuList_Popup);
			// 
			// mnuSelect
			// 
			this.mnuSelect.Index = 0;
			this.mnuSelect.Text = "Select All";
			this.mnuSelect.Click += new System.EventHandler(this.mnuSelect_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "-";
			// 
			// mnuAddFiles
			// 
			this.mnuAddFiles.Index = 2;
			this.mnuAddFiles.Text = "Add Files";
			this.mnuAddFiles.Click += new System.EventHandler(this.mnuAddFiles_Click);
			// 
			// mnuAddDir
			// 
			this.mnuAddDir.Index = 3;
			this.mnuAddDir.Text = "Add Folder";
			this.mnuAddDir.Click += new System.EventHandler(this.mnuAddDir_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 4;
			this.menuItem3.Text = "-";
			// 
			// mnuCopy
			// 
			this.mnuCopy.Index = 5;
			this.mnuCopy.Text = "Copy";
			this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
			// 
			// mnuPaste
			// 
			this.mnuPaste.Index = 6;
			this.mnuPaste.Text = "Paste";
			this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 7;
			this.menuItem6.Text = "-";
			// 
			// mnuRemSel
			// 
			this.mnuRemSel.Index = 8;
			this.mnuRemSel.Text = "Remove";
			this.mnuRemSel.Click += new System.EventHandler(this.mnuRemSel_Click);
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBar
			// 
			this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.tbAdd,
																					   this.tbAddDir,
																					   this.toolBarButton1,
																					   this.tbCopy,
																					   this.tbPaste,
																					   this.toolBarButton2,
																					   this.tbRemove,
																					   this.tbInfo,
																					   this.toolBarButton3,
																					   this.tbGen,
																					   this.toolBarButtonTG,
																					   this.tbStart,
																					   this.toolBarButton4,
																					   this.tbMID,
																					   this.tbAbout});
			this.toolBar.ButtonSize = new System.Drawing.Size(32, 32);
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imageListTB;
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(612, 41);
			this.toolBar.TabIndex = 0;
			this.toolBar.Wrappable = false;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// tbAdd
			// 
			this.tbAdd.ImageIndex = 0;
			this.tbAdd.ToolTipText = "Add files";
			// 
			// tbAddDir
			// 
			this.tbAddDir.ImageIndex = 1;
			this.tbAddDir.ToolTipText = "Add folder";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbCopy
			// 
			this.tbCopy.ImageIndex = 4;
			this.tbCopy.ToolTipText = "Copy selected items";
			// 
			// tbPaste
			// 
			this.tbPaste.ImageIndex = 5;
			this.tbPaste.ToolTipText = "Paste files / folders";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbRemove
			// 
			this.tbRemove.ImageIndex = 2;
			this.tbRemove.ToolTipText = "Remove selected items";
			// 
			// tbInfo
			// 
			this.tbInfo.ImageIndex = 3;
			this.tbInfo.ToolTipText = "Count items";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbGen
			// 
			this.tbGen.ImageIndex = 8;
			this.tbGen.ToolTipText = "Generate random password";
			// 
			// toolBarButtonTG
			// 
			this.toolBarButtonTG.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbStart
			// 
			this.tbStart.ImageIndex = 7;
			this.tbStart.ToolTipText = "Start / Stop";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbMID
			// 
			this.tbMID.ImageIndex = 9;
			this.tbMID.ToolTipText = "Show this machine\'s unique ID";
			// 
			// tbAbout
			// 
			this.tbAbout.ImageIndex = 6;
			this.tbAbout.ToolTipText = "http://www.madebits.com";
			// 
			// imageListTB
			// 
			this.imageListTB.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageListTB.ImageSize = new System.Drawing.Size(32, 32);
			this.imageListTB.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTB.ImageStream")));
			this.imageListTB.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.pictureBox2,
																					  this.pictureBox1,
																					  this.radioScan,
																					  this.radioDel,
																					  this.radioCRC,
																					  this.btnAES,
																					  this.btnIC,
																					  this.btnNext,
																					  this.btnCopy,
																					  this.btnGen,
																					  this.btnClean,
																					  this.chkKeep,
																					  this.chkMask,
																					  this.btnOK,
																					  this.radioDec,
																					  this.radioEnc,
																					  this.radioAuto,
																					  this.txtLog,
																					  this.txtStatus,
																					  this.txtPass,
																					  this.cmbAlgo,
																					  this.numIC,
																					  this.progressCurrent,
																					  this.progressTotal});
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(0, 236);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(612, 180);
			this.panelBottom.TabIndex = 2;
			this.panelBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBottom_MouseMove);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.pictureBox2.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 164);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(16, 16);
			this.pictureBox2.TabIndex = 25;
			this.pictureBox2.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBox2, "Total files");
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 146);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.TabIndex = 24;
			this.pictureBox1.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBox1, "Current file");
			// 
			// radioScan
			// 
			this.radioScan.Image = ((System.Drawing.Bitmap)(resources.GetObject("radioScan.Image")));
			this.radioScan.Location = new System.Drawing.Point(400, 8);
			this.radioScan.Name = "radioScan";
			this.radioScan.Size = new System.Drawing.Size(70, 24);
			this.radioScan.TabIndex = 5;
			this.toolTip.SetToolTip(this.radioScan, "Information about files");
			this.radioScan.CheckedChanged += new System.EventHandler(this.radioScan_CheckedChanged);
			// 
			// radioDel
			// 
			this.radioDel.Image = ((System.Drawing.Bitmap)(resources.GetObject("radioDel.Image")));
			this.radioDel.Location = new System.Drawing.Point(328, 8);
			this.radioDel.Name = "radioDel";
			this.radioDel.Size = new System.Drawing.Size(70, 24);
			this.radioDel.TabIndex = 4;
			this.toolTip.SetToolTip(this.radioDel, "Delete (wipe) all files");
			this.radioDel.CheckedChanged += new System.EventHandler(this.radioDel_CheckedChanged);
			// 
			// radioCRC
			// 
			this.radioCRC.Image = ((System.Drawing.Bitmap)(resources.GetObject("radioCRC.Image")));
			this.radioCRC.Location = new System.Drawing.Point(248, 8);
			this.radioCRC.Name = "radioCRC";
			this.radioCRC.Size = new System.Drawing.Size(70, 24);
			this.radioCRC.TabIndex = 3;
			this.toolTip.SetToolTip(this.radioCRC, "Finger print files");
			this.radioCRC.CheckedChanged += new System.EventHandler(this.radioCRC_CheckedChanged);
			// 
			// btnAES
			// 
			this.btnAES.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnAES.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAES.Image")));
			this.btnAES.Location = new System.Drawing.Point(452, 40);
			this.btnAES.Name = "btnAES";
			this.btnAES.Size = new System.Drawing.Size(24, 24);
			this.btnAES.TabIndex = 17;
			this.toolTip.SetToolTip(this.btnAES, "Default encryption type");
			this.btnAES.Click += new System.EventHandler(this.btnAES_Click);
			// 
			// btnIC
			// 
			this.btnIC.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnIC.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnIC.Image")));
			this.btnIC.Location = new System.Drawing.Point(372, 40);
			this.btnIC.Name = "btnIC";
			this.btnIC.Size = new System.Drawing.Size(24, 24);
			this.btnIC.TabIndex = 15;
			this.toolTip.SetToolTip(this.btnIC, "Iteration count (PKCS#5 SHA256)");
			this.btnIC.Click += new System.EventHandler(this.btnIC_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnNext.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnNext.Image")));
			this.btnNext.Location = new System.Drawing.Point(580, 40);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(24, 24);
			this.btnNext.TabIndex = 19;
			this.toolTip.SetToolTip(this.btnNext, "Next encryption type");
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCopy.Image")));
			this.btnCopy.Location = new System.Drawing.Point(32, 40);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(24, 24);
			this.btnCopy.TabIndex = 10;
			this.toolTip.SetToolTip(this.btnCopy, "Copy password to clipboard");
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnGen
			// 
			this.btnGen.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnGen.Image")));
			this.btnGen.Location = new System.Drawing.Point(8, 40);
			this.btnGen.Name = "btnGen";
			this.btnGen.Size = new System.Drawing.Size(24, 24);
			this.btnGen.TabIndex = 9;
			this.toolTip.SetToolTip(this.btnGen, "Generate random password");
			this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
			// 
			// btnClean
			// 
			this.btnClean.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnClean.Image")));
			this.btnClean.Location = new System.Drawing.Point(56, 40);
			this.btnClean.Name = "btnClean";
			this.btnClean.Size = new System.Drawing.Size(24, 24);
			this.btnClean.TabIndex = 11;
			this.toolTip.SetToolTip(this.btnClean, "Clean up the password text");
			this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
			// 
			// chkKeep
			// 
			this.chkKeep.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.chkKeep.Checked = true;
			this.chkKeep.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkKeep.Image = ((System.Drawing.Bitmap)(resources.GetObject("chkKeep.Image")));
			this.chkKeep.Location = new System.Drawing.Point(328, 40);
			this.chkKeep.Name = "chkKeep";
			this.chkKeep.Size = new System.Drawing.Size(40, 24);
			this.chkKeep.TabIndex = 14;
			this.toolTip.SetToolTip(this.chkKeep, "Keep password");
			this.chkKeep.CheckedChanged += new System.EventHandler(this.chkKeep_CheckedChanged);
			// 
			// chkMask
			// 
			this.chkMask.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.chkMask.Checked = true;
			this.chkMask.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMask.Image = ((System.Drawing.Bitmap)(resources.GetObject("chkMask.Image")));
			this.chkMask.Location = new System.Drawing.Point(280, 40);
			this.chkMask.Name = "chkMask";
			this.chkMask.Size = new System.Drawing.Size(40, 24);
			this.chkMask.TabIndex = 13;
			this.toolTip.SetToolTip(this.chkMask, "Mask password field");
			this.chkMask.CheckedChanged += new System.EventHandler(this.chkMask_CheckedChanged);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnOK.Image")));
			this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOK.Location = new System.Drawing.Point(476, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(128, 24);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "Cr!pt";
			this.toolTip.SetToolTip(this.btnOK, "Start / Stop processing files");
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// radioDec
			// 
			this.radioDec.Image = ((System.Drawing.Bitmap)(resources.GetObject("radioDec.Image")));
			this.radioDec.Location = new System.Drawing.Point(168, 8);
			this.radioDec.Name = "radioDec";
			this.radioDec.Size = new System.Drawing.Size(70, 24);
			this.radioDec.TabIndex = 2;
			this.toolTip.SetToolTip(this.radioDec, "Decrypt all files");
			this.radioDec.CheckedChanged += new System.EventHandler(this.radioDec_CheckedChanged);
			// 
			// radioEnc
			// 
			this.radioEnc.Image = ((System.Drawing.Bitmap)(resources.GetObject("radioEnc.Image")));
			this.radioEnc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.radioEnc.Location = new System.Drawing.Point(88, 8);
			this.radioEnc.Name = "radioEnc";
			this.radioEnc.Size = new System.Drawing.Size(70, 24);
			this.radioEnc.TabIndex = 1;
			this.toolTip.SetToolTip(this.radioEnc, "Encrypt all files");
			this.radioEnc.CheckedChanged += new System.EventHandler(this.radioEnc_CheckedChanged);
			// 
			// radioAuto
			// 
			this.radioAuto.Checked = true;
			this.radioAuto.Image = ((System.Drawing.Bitmap)(resources.GetObject("radioAuto.Image")));
			this.radioAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.radioAuto.Location = new System.Drawing.Point(8, 8);
			this.radioAuto.Name = "radioAuto";
			this.radioAuto.Size = new System.Drawing.Size(70, 24);
			this.radioAuto.TabIndex = 0;
			this.radioAuto.TabStop = true;
			this.toolTip.SetToolTip(this.radioAuto, "Auto: Find whether to encrypt / decrypt based on the file suffix");
			this.radioAuto.CheckedChanged += new System.EventHandler(this.radioAuto_CheckedChanged);
			// 
			// txtLog
			// 
			this.txtLog.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtLog.DetectUrls = false;
			this.txtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtLog.Location = new System.Drawing.Point(0, 96);
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size(610, 49);
			this.txtLog.TabIndex = 21;
			this.txtLog.Text = "";
			this.txtLog.WordWrap = false;
			this.txtLog.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtLog_MouseMove);
			// 
			// txtStatus
			// 
			this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
			this.txtStatus.Location = new System.Drawing.Point(0, 72);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.ReadOnly = true;
			this.txtStatus.Size = new System.Drawing.Size(612, 20);
			this.txtStatus.TabIndex = 20;
			this.txtStatus.Text = "";
			this.txtStatus.WordWrap = false;
			// 
			// txtPass
			// 
			this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtPass.Location = new System.Drawing.Point(80, 40);
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '*';
			this.txtPass.Size = new System.Drawing.Size(192, 20);
			this.txtPass.TabIndex = 12;
			this.txtPass.Text = "";
			// 
			// cmbAlgo
			// 
			this.cmbAlgo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.cmbAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAlgo.Items.AddRange(new object[] {
														 "AES 128 bit",
														 "AES 192 bit",
														 "AES 256 bit",
														 "Blowfish 128 bit",
														 "Blowfish 192 bit",
														 "Blowfish 256 bit",
														 "Blowfish 448 bit",
														 "Serpent 128 bit",
														 "Serpent 192 bit",
														 "Serpent 256 bit"});
			this.cmbAlgo.Location = new System.Drawing.Point(476, 40);
			this.cmbAlgo.Name = "cmbAlgo";
			this.cmbAlgo.Size = new System.Drawing.Size(104, 21);
			this.cmbAlgo.TabIndex = 18;
			// 
			// numIC
			// 
			this.numIC.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.numIC.Enabled = false;
			this.numIC.Location = new System.Drawing.Point(396, 40);
			this.numIC.Maximum = new System.Decimal(new int[] {
																  9999,
																  0,
																  0,
																  0});
			this.numIC.Minimum = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  0});
			this.numIC.Name = "numIC";
			this.numIC.Size = new System.Drawing.Size(48, 20);
			this.numIC.TabIndex = 16;
			this.numIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numIC.Value = new System.Decimal(new int[] {
																1024,
																0,
																0,
																0});
			// 
			// progressCurrent
			// 
			this.progressCurrent.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.progressCurrent.Location = new System.Drawing.Point(16, 146);
			this.progressCurrent.Name = "progressCurrent";
			this.progressCurrent.Size = new System.Drawing.Size(594, 16);
			this.progressCurrent.Step = 1;
			this.progressCurrent.TabIndex = 22;
			// 
			// progressTotal
			// 
			this.progressTotal.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.progressTotal.Location = new System.Drawing.Point(16, 164);
			this.progressTotal.Name = "progressTotal";
			this.progressTotal.Size = new System.Drawing.Size(594, 16);
			this.progressTotal.Step = 1;
			this.progressTotal.TabIndex = 23;
			// 
			// splitter
			// 
			this.splitter.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter.Location = new System.Drawing.Point(0, 228);
			this.splitter.MinSize = 150;
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(612, 8);
			this.splitter.TabIndex = 1;
			this.splitter.TabStop = false;
			// 
			// Cript
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(612, 416);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panelMiddle,
																		  this.splitter,
																		  this.panelBottom,
																		  this.panelTop});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(610, 350);
			this.Name = "Cript";
			this.Text = "Cr!ptAES - http://www.madebits.com";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cript_KeyDown);
			this.Resize += new System.EventHandler(this.Cript_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Cript_Closing);
			this.Load += new System.EventHandler(this.Cript_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cript_MouseMove);
			this.panelTop.ResumeLayout(false);
			this.panelMiddle.ResumeLayout(false);
			this.panelBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numIC)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			try
			{
				Application.Run(new Cript(args));
			}
			catch(Exception ex)
			{
				MessageBox.Show(null, ex.Message, APPNAME + " - Error");
			}
		}

		#region command

		private bool batchExit = false;
		private bool batchStart = false;
		private string coutDir = null;
		private static readonly string DEFAULT_SUFFIX = ".cript";
		private string criptFileSuffix = DEFAULT_SUFFIX;
		private bool ProcessCommandLine()
		{
			this.radioAuto_CheckedChanged(null, null);
			if(commandLine == null) return false;
			int count = 0;
			for(int i = 0; i < commandLine.Length; ++i)
			{
				if(commandLine[i].StartsWith("/"))
				{
					switch(commandLine[i].ToLower())
					{
						case "/?":
							ShowHelp();
							break;
						case "/p":
							i++;
							if(commandLine.Length <= i)
							{
								LogErr("/p password is missing");
							}
							else
							{
								this.txtPass.Text = commandLine[i].Trim();
							}
							break;
						case "/e":
							this.radioEnc.Checked = true;
							this.radioEnc_CheckedChanged(null, null);
							break;
						case "/d":
							this.radioDec.Checked = true;
							this.radioDec_CheckedChanged(null, null);
							break;
						case "/c":
							this.radioCRC.Checked = true;
							this.radioCRC_CheckedChanged(null, null);
							break;
						case "/w":
							this.radioDel.Checked = true;
							this.radioDel_CheckedChanged(null, null);
							break;
						case "/t":
							this.radioScan.Checked = true;
							this.radioScan_CheckedChanged(null, null);
							break;
						case "/a":
							i++;
							if(commandLine.Length <= i)
							{
								LogErr("/a method is missing");
							}
							else
							{
								this.cmbAlgo.SelectedIndex = EncryptionParams.EType2Index(
									EncryptionParams.String2EType(commandLine[i].Trim()));
							}
							break;
						case "/i":
							i++;
							if(commandLine.Length <= i)
							{
								LogErr("/i iterationCount is missing");
							}
							else
							{
								try
								{
									this.numIC.Value = Convert.ToInt32(commandLine[i]);
								}
								catch
								{
									this.numIC.Value = 1024;
								}
							}
							break;
						case "/f":
							i++;
							if(commandLine.Length <= i)
							{
								LogErr("/f inputFileList is missing");
							}
							else
							{
								try
								{
									using(StreamReader sr = new StreamReader(commandLine[i]))
									{
										for(string line = sr.ReadLine(); line != null; line = sr.ReadLine())
										{
											try
											{
												AddFile(line);
											}
											catch(Exception ex)
											{
												LogErr(line + " - " + ex.Message);
											}
										}
									}
								}
								catch(Exception ex)
								{
									LogErr(commandLine[i] + " - " + ex.Message);
								}
							}
							break;
						case "/s":
							batchStart = true;
							break;
						case "/x":
							batchExit = true;
							break;
						case "/k":
							this.chkKeep.Checked = false;
							break;
						case "/m":
							this.chkMask.Checked = false;
							break;
						case "/o":
							i++;
							if(commandLine.Length <= i)
							{
								LogErr("/o outDir is missing");
							}
							else
							{
								if(commandLine[i].Equals("*")) coutDir = commandLine[i];
								else coutDir = AddDirSep(Path.GetFullPath(commandLine[i]));
							}
							break;
						case "/u":
							i++;
							if(commandLine.Length <= i)
							{
								LogErr("/u suffix is missing");
							}
							else
							{
								SetSuffix(commandLine[i]);
							}
							this.radioAuto_CheckedChanged(null, null);
							break;
						default:
							LogErr("Unknow command " + commandLine[i]);
							break;
					}
				}
				else
				{
					try
					{
						if(!File.Exists(commandLine[i]) && (!Directory.Exists(commandLine[i])))
						{
							throw new Exception("not found!");
						}
						this.AddFile(commandLine[i]);
					}
					catch(Exception ex)
					{
						LogErr(commandLine[i] + " - " + ex.Message);
					}
				}
			}
			if(count > 0) LogAdded(count);
			commandLine = null;
			return batchStart;
		}		

		private void SetSuffix(string s)
		{
			if((s == null) || (s.Trim().Length <= 0) || (s.Trim().Equals(".")))
			{
				return;
			}
			s = s.Trim();
			if(!s.StartsWith("."))
			{
				s = "." + s;
			}
			if(s.IndexOfAny(new char[]{'*', '?', '<', '>', ':', '/', '\\', '|', '"'}) >= 0)
			{
				return;
			}
			criptFileSuffix = s;
			this.radioAuto_CheckedChanged(null, null);
		}

		private void ShowHelp()
		{
			string msg = "Cr!ptAES [/?] [/e | /d | /c | /w | /t]\n\t[/p password] [/m] [/k] [/i iterationCount] [/a aesKeySize] [/o outputDir]\n\t[/s] [/x] [/u suffix] [/f inputFileList] [files | folders]\n";
			msg +="Where:\n";
			msg +="\t/? - this help\n";
			msg +="\t/e - encryp, default auto\n";
			msg +="\t/d - decryp, default auto\n";
			msg +="\t/c - finger print, default auto\n";
			msg +="\t/w - wipe, default auto\n";
			msg +="\t/t - info, default auto\n";
			msg +="\t/p password\n";
			msg +="\t/m - don't mask password\n";
			msg +="\t/k - don't keep password\n";
			msg +="\t/i iterationCount - must be >=1, default 1024\n";
			msg +="\t/a aesKeySize - one of:\n";
			msg +="\t\tAES128, AES192, AES256\n";
			msg +="\t\tBWF128, BWF192, BWF256, BWF448\n";
			msg +="\t\tSER128, SER192, SER256\n";
			msg +="\t/o outputDir - * means same folder as input\n";
			msg +="\t/s - auto start\n";
			msg +="\t/x - auto stop\n";
			msg +="\t/u suffix - encrypted file suffix, default " + DEFAULT_SUFFIX + "\n";
			msg +="\t/f inputFileList - one path per line\n";
			msg +="\tfiles | folders - as many as you like, no wildcards";
			MessageBox.Show(this, msg, APPNAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}		

		#endregion command
		
		private void BAddDir()
		{
			if(this.IsWorking()) return;
			try
			{
				string s = OpenDirDialog.BrowseDialog(this, "Select an input folder.\nAll files in all subfolders will be processed!");
				if(s != null) this.AddFile(s);
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		int filterIndex = 0;
		private void BAddFiles()
		{
			if(this.IsWorking()) return;
			try
			{
				using(OpenFileDialog fd = new OpenFileDialog())
				{
					fd.Multiselect = true;
					fd.Filter = "All files (*.*)|*.*|Cr!ptAES files (*" + criptFileSuffix + ";*.cr!pt;*.cript)|*" + criptFileSuffix + "*.cr!pt;*.cript|Zip files (*.zip)|*.zip";
					fd.FilterIndex = filterIndex;
					if(fd.ShowDialog(this) == DialogResult.OK)
					{
						filterIndex = fd.FilterIndex;
						int count = AddFile(fd.FileNames);
						LogAdded(count);
					}
				}
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		#region add

		private int AddFile(string[] file)
		{
			if(this.IsWorking()) return 0;
			if(file == null) return 0;
			int count = 0;
			for(int i = 0; i < file.Length; ++i)
			{
				count += AddFile(file[i]);
			}
			return count;
		}		

		private static string AddDirSep(string file)
		{
			if(file == null) return null;
			if(!file.EndsWith(Path.DirectorySeparatorChar.ToString())) file+= Path.DirectorySeparatorChar.ToString();
			return file;
		}

		private int AddFile(string file)
		{
			if(this.IsWorking()) return 0;
			try
			{
				if(file == null) return 0;
				file = file.Trim();
				if(file.Length <= 0) return 0;
				bool isDir = false;
				if(Directory.Exists(file))
				{
					isDir = true;
				}
				else if(!File.Exists(file))
				{
					LogErr(file + " - not found");
					return 0;
				}
				file = Path.GetFullPath(file);
				if(isDir)
				{
					file = AddDirSep(file);
				}
				if(AlreadyAdded(file)) return 0;
				ListViewItem li = new ListViewItem(file);
				bool cript = IsEncrypted(file);
				li.ImageIndex = (cript ? 0 : (isDir ? 2 : 1));
				string size = "-";
				if(!isDir)
				{
					FileInfo fi = new FileInfo(file);
					if(fi == null) throw new Exception("cannot access " + file);
					long sizeKB = fi.Length / 1024;
					if((fi.Length % 1024) > 0) sizeKB++;
					size = sizeKB.ToString();
				}
				li.SubItems.Add(size);

				string ext = "<DIR>";
				if(!isDir)
				{
					ext = Path.GetExtension(file).ToUpper();
					//if(cript) ext = ext.Replace(CRIPT2.ToUpper(), CRIPT.ToUpper());
					if(ext.StartsWith("."))
					{
						ext = ext.Substring(1, ext.Length - 1);
					}
				}
				li.SubItems.Add(ext);
				this.listView.Items.Add(li);
			}
			catch(Exception ex)
			{
				LogErr(ex.Message);
				return 0;
			}
			return 1;
		}

		private bool AlreadyAdded(string file)
		{
			int c = listView.Items.Count;
			string f = file.ToUpper();
			for(int i = 0; i < c; ++i)
			{
				if(listView.Items[i].Text.ToUpper().Equals(f)) return true;
			}
			return false;
		}

		private bool IsEncrypted(string file)
		{
			if(file == null) return false;
			string temp = file.ToLower();
			return temp.EndsWith(criptFileSuffix) || temp.EndsWith(".cr!pt") || temp.EndsWith(".cript");
		}

		private void RemoveSel()
		{
			if(this.IsWorking()) return;
			try
			{
				int count = 0;
				ListView.SelectedListViewItemCollection c = listView.SelectedItems;
				if(c != null && c.Count > 0)
				{
					while(c.Count > 0)
					{
						listView.Items.Remove(c[0]);
						count++;
					}
				}
				else if(listView.Items.Count > 0)
				{
					if(MessageBox.Show(this, "Removel all items?", APPNAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						count = listView.Items.Count;
						listView.Items.Clear();
					}
				}
				ClearLog();
				if(count > 0) Log("Removed " + count + " item(s)!");
			}
			catch{}
		}

		private void CopySel()
		{
			if(this.IsWorking()) return;
			try
			{
				int count = 0;
				ListView.SelectedListViewItemCollection c = listView.SelectedItems;
				string[] files = null;
				if(c == null || c.Count <= 0)
				{
					if(this.listView.Items.Count > 0)
					{
						files = new string[this.listView.Items.Count];
						for(int i = 0; i < files.Length; ++i)
						{
							files[i] = listView.Items[i].Text;
						}
					}
					count = this.listView.Items.Count;
				}
				else
				{
					files = new string[c.Count];
					for(int i = 0; i < files.Length; ++i)
					{
						files[i] = c[i].Text;
					}
					count = c.Count;	
				}
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				if(files != null)
				{
					for(int i = 0; i < files.Length; ++i)
					{
						sb.Append(files[i]).Append(Environment.NewLine);
					}
					IDataObject iData = new DataObject();
					iData.SetData(DataFormats.FileDrop, files);
					iData.SetData(DataFormats.Text, sb.ToString());
					Clipboard.SetDataObject(iData, true);
				}
				ClearLog();
				if(count > 0) Log("Copied " + count + " item(s)!");
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		private static string[] String2Lines(string s)
		{
			if(s == null) return null;
			return s.Split('\n');
		}

		private void DoDrop(IDataObject iData)
		{
			try
			{
				if(IsWorking()) return;
				string[] ss = null;
				if(iData.GetDataPresent(DataFormats.FileDrop)) 
				{
					ss = (string[])iData.GetData(DataFormats.FileDrop);
				}
				else if(iData.GetDataPresent(DataFormats.Text))
				{
					string s = (string)iData.GetData(DataFormats.Text);
					ss = String2Lines(s);
				}
				else if(iData.GetDataPresent(DataFormats.UnicodeText))
				{
					string s = (string)iData.GetData(DataFormats.UnicodeText);
					ss = String2Lines(s);
				}
				if(ss != null && ss.Length > 0)
				{
					int count = AddFile(ss);
					LogAdded(count);
				}
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		#endregion add


		private void listView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			DoDrop(e.Data);
		}		

		private void listView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(IsWorking()) return;
			try
			{
				IDataObject iData = e.Data;
				if(CanPaste(iData)) 
				{
					e.Effect = DragDropEffects.Copy;
				}
			}
			catch{}
		}

		private bool CanPaste(IDataObject iData)
		{
			if(iData == null) return false;
			if(iData.GetDataPresent(DataFormats.FileDrop) || iData.GetDataPresent(DataFormats.Text) || iData.GetDataPresent(DataFormats.UnicodeText)) 
			{
				return true;
			}
			return false;
		}

		private bool CanPaste()
		{
			try
			{
				IDataObject iData = Clipboard.GetDataObject();
				return CanPaste(iData);
			}
			catch
			{
				return false;
			}
		}

		private void pictureBox_Click(object sender, System.EventArgs e)
		{
			ShowMB();
		}

		internal static void ShowMB()
		{
			try
			{
				System.Diagnostics.Process.Start("http://madebits.com/criptaes/index.php");
			}
			catch
			{
			}
		}
		
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DoStartStop();
		}

		#region log

		delegate void DLog(string s);

		private void Log(string s)
		{
			if(this.InvokeRequired)
			{
				this.Invoke(new DLog(_Log), new object[]{ s });
			}
			else
			{
				_Log(s);
			}
		}

		private void LogAdded(int count)
		{
			LogOne("Added " + count + " item(s)!");
		}

		private void _Log(string s)
		{
			if(s == null) return;
			int start = txtLog.Text.Length;
			if(start >= 2147482000)
			{
				try
				{
					int d = 10500;
					txtLog.Text = "..." + Environment.NewLine + txtLog.Text.Substring(d - 1, start - d);
				}
				catch{}
			}
			txtLog.AppendText(s + Environment.NewLine);
			if(s.StartsWith("#Error"))
			{
				txtLog.SelectionStart = start;
				txtLog.SelectionLength = s.Length;
				txtLog.SelectionColor = System.Drawing.Color.Red;
			}
			txtLog.SelectionStart = txtLog.Text.Length - 1;
			txtLog.SelectionLength = 0;
			txtLog.ScrollToCaret();
		}

		bool hasErrors = false;
		private void LogErr(string s)
		{
			if(s == null) return;
			hasErrors = true;
			Log("#Error: " + s);
		}

		private void ClearLog()
		{
			this.txtStatus.Clear();
			this.txtLog.Clear();
			SetProgress(0, 0);
			totalFilesSize = 0;
			currentFilesSize = 0;
			totalFiles = 0;
			if(crc != null) crc.Clear();
			crc = null;
			hasRep = false;
			hasErrors = false;
		}

		private void LogErrOne(string s)
		{
			ClearLog();
			LogErr(s);
		}

		private void LogOne(string s)
		{
			ClearLog();
			Log(s);
		}

		private void LogCurrent(string f)
		{
			if(f == null) f = string.Empty;
			this.txtStatus.Text = f;
		}

		#endregion log

			
		#region startstop

		private bool IsEncMode()
		{
			return (this.radioAuto.Checked || this.radioEnc.Checked || this.radioDec.Checked);
		}

		private Image GetStartMsg(ref string outMode, ref string outMsg)
		{
			Image m = null;
			outMode = "Mode: ";
			if(this.radioAuto.Checked)
			{
				outMode += "Auto (Encrypt / Decrypt)";
				m = this.radioAuto.Image;
			}
			else if(this.radioEnc.Checked)
			{
				outMode += "Encrypt";
				m = this.radioEnc.Image;
			}
			else if(this.radioDec.Checked)
			{
				outMode += "Decrypt";
				m = this.radioDec.Image;
			}
			else if(this.radioCRC.Checked)
			{
				outMode += "Finger print";
				m = this.radioCRC.Image;
			}
			else if(this.radioDel.Checked)
			{
				outMode += "Delete (wipe with random data)";
				m = this.radioDel.Image;
			}
			else if(this.radioScan.Checked)
			{
				outMode += "Information about files";
				m = this.radioScan.Image;
			}
			string msg = "Items: " + this.listView.Items.Count + Environment.NewLine;
			if(IsEncMode())
			{
				msg += "Encryption type : ";
				EType etype = EncryptionParams.Index2EType(this.cmbAlgo.SelectedIndex);
				int ks = 16; int ivs = 16; int ss = 16;
				EncryptionParams.EType2KeyData(etype, ref ks, ref ivs, ref ss);
				msg += EncryptionParams.EType2String(etype);
				msg +=  Environment.NewLine;
				msg += "IV: " + ivs + " bytes, Salt: " + ss + " bytes" + Environment.NewLine;
				if(this.numIC.Value != 1024)
				{
					msg += "Iteration count: " + this.numIC.Value + Environment.NewLine;
				}
				msg += "Password length: " + this.txtPass.Text.Trim().Length  + Environment.NewLine;
				msg += "Keep password: " + (this.chkKeep.Checked ? "Yes" : "No") + Environment.NewLine;
				msg += "Encrypted files suffix: *" + this.criptFileSuffix + Environment.NewLine;
			}
			else if(this.radioDel.Checked)
			{
				msg += Environment.NewLine;
				msg += "Deleted files and folders cannot be recovered!" + Environment.NewLine;
			}
			outMsg = msg.TrimEnd(new char[]{'\n', '\r'});
			return m;
		}

		private void DoStartStop()
		{
			try
			{
				if(IsWorking())
				{
					Stop();
					return;
				}
				ClearLog();
				//SetSuffix(this.txtSuffix.Text);
				if(this.listView.Items.Count <= 0)
				{
					throw new Exception("select some files!");
				}
				if(IsEncMode())
				{
					SetEncryptionParams();
				}
				else if(this.radioCRC.Checked || this.radioScan.Checked)
				{
					this.batchExit = false;
				}
				if(!this.batchStart)
				{
					string msg = string.Empty;
					string mode = string.Empty;
					Image m = GetStartMsg(ref mode, ref msg);
					/*
					MessageBoxIcon ic = MessageBoxIcon.Question;
					if(this.radioDel.Checked)
					{
						ic = MessageBoxIcon.Warning;
						msg += "\n\n!!! Warning: Deleted files and folders cannot be recovered !!!";
					}
					if(MessageBox.Show(this, msg, APPNAME, MessageBoxButtons.YesNo, ic) == DialogResult.No)
					{
						return;
					}
					*/
					DStart ds = new DStart();
					if(this.radioDel.Checked) ds.SetDeleteMode();
					if(!ds.PleaseConfirm(this, m, mode, msg))
					{
						return;
					}
				}
				if(IsEncMode())
				{
					if((coutDir != null))
					{
						if(!coutDir.Equals("*"))
						{
							this.encParams.OutDir = coutDir;
						}
						else
						{
							this.encParams.OutDir = null;
						}
					}
					else
					{
						this.encParams.OutDir = OpenDirDialog.BrowseDialog(this, "Select output folder.\nSelect cancel to put the output files in the same folder as the originals!");
					}
					CheckSubDir(this.encParams.OutDir);
					if(!this.chkKeep.Checked)
					{
						this.txtPass.Clear();
					}
				}
				Start();
			}
			catch(Exception ex)
			{
				this.encParams.Password = null;
				this.encParams.OutDir = null;
				LogErrOne(ex.Message);
				EnableAll();
			}
		}

		private void CheckSubDir(string outDir)
		{
			if(outDir == null) return;
			string temp = outDir.ToUpper();
			for(int i = 0; i < this.listView.Items.Count; ++i)
			{
				string file = this.listView.Items[i].Text;
				string dir = null;
				if(Directory.Exists(file))
				{
					dir = file;
				}
				//else if(File.Exists(file))
				//{
				//	dir = AddDirSep(Path.GetDirectoryName(file));
				//}
				if(dir == null) continue;
				if(temp.StartsWith(dir.ToUpper()))
				{
					throw new Exception("Output folder cannot be a subfolder of an input folder: " + outDir + " -> " + dir);
				}
			}
		}

		private void EnableAll()
		{
			EnableAll(true);
		}

		private void EnableAll(bool on)
		{
			EnableTB(on);
			if(!on) this.chkMask.Checked = true;
			this.chkMask.Enabled = on;
			this.txtPass.Enabled = on;
			this.cmbAlgo.Enabled = on;
			this.numIC.Enabled = on && numICEnabled;
			this.radioAuto.Enabled = on;
			this.radioEnc.Enabled = on;
			this.radioDec.Enabled = on;
			this.radioCRC.Enabled = on;
			this.radioDel.Enabled = on;
			this.radioScan.Enabled = on;
			this.chkKeep.Enabled = on;
			this.btnClean.Enabled = on;
			this.btnGen.Enabled = on;
			this.btnCopy.Enabled = on;
			this.btnNext.Enabled = on;
			this.btnAES.Enabled = on;
            this.btnIC.Enabled = on;
			this.btnOK.Enabled = true;
			this.btnOK.Text = on ? "Cr!pt" : "Stop";
		}

		#endregion startstop
		
		#region random
		
		private static readonly string alpha =
			"!\"$%&/(}abcdefghijklmn)=?\\@*+^opqrstuvwxyz0123456789ABCDEFGH<~#;,[:.IJKLMNOPQRSTUVWXYZ]-_>|{";
		private static readonly string alpha2 =
			"abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private void BGenPass()
		{
			if(this.IsWorking()) return;
			try
			{
				EType t = EncryptionParams.Index2EType(cmbAlgo.SelectedIndex);
				int keyLen = 16; int ivSize = 16; int saltSize = 16;
				EncryptionParams.EType2KeyData(t, ref keyLen, ref ivSize, ref saltSize);
				keyLen = keyLen * 8;
				int length = keyLen / 6;
				if((keyLen % 6) > 0) length++;
				txtPass.Text = GetRandString(alpha, length);
				this.txtPass.Focus();
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		private string GetRandString(string alpha, int length)
		{
			if((alpha == null) || (length <=0)) return string.Empty;
			byte[] buff = new byte[length];
			GetRandom().NextBytes(buff);
			StringBuilder sb = new StringBuilder(length);
			for(int i = 0; i < length; i++)
			{
				int r = (int)buff[i] % alpha.Length; 
				sb.Append(alpha[r]);
			}
			return sb.ToString();
		}

		#endregion random

		private void chkMask_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			txtPass.PasswordChar = (chkMask.Checked) ? '*' : (char)0;
			ClearLog();
			string t = chkMask.Checked ? "ON" : "OFF";
			Log("Mask password: " + t);
			txtPass.Focus();
		}

		private void Cript_Load(object sender, System.EventArgs e)
		{
			this.txtLog.BackColor = SystemColors.Window;
			try
			{
				bool start = ProcessCommandLine();
				if(start)
				{
				
					DoStartStop();
				}
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		private void Cript_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.Stop())
			{
				e.Cancel = true;
			}
		}

		private void Cript_Resize(object sender, System.EventArgs e)
		{
			AS();
		}

		private void AS()
		{
			if((this.splitter.Location.Y <= 55)
				&& (this.WindowState != FormWindowState.Minimized))
			{
				int temp = this.ClientRectangle.Height - 150;
				if(temp < 100) temp = 100;
				this.splitter.SplitPosition = temp;
			}
		}

		private void BItemInfo()
		{
			if(this.IsWorking()) return;
			string msg = "Items: " + this.listView.Items.Count;
			int dirs = 0;
			for(int i = 0; i < listView.Items.Count; ++i)
			{
				if(listView.Items[i].SubItems[1].Text.Equals("-")) dirs++;
			}
			if(dirs > 0) msg += " Folders: " + dirs;
			msg += " Selected: " + this.listView.SelectedItems.Count;
			LogOne(msg);
		}

		private void listView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.Equals(Keys.Delete) && !this.IsWorking())
			{
				RemoveSel();
			}
			else if(e.Control && e.KeyCode.Equals(Keys.A))
			{
				e.Handled = true;
				SelectAll();
			}
			else if(e.Control && e.KeyCode.Equals(Keys.V))
			{
				PasteFiles();
			}
			else if(e.Control && e.KeyCode.Equals(Keys.C))
			{
				CopySel();
			}
		}

		private void SelectAll()
		{
			if(this.IsWorking()) return;
			if(listView.Items.Count <= 0) return;
			for(int i = 0; i < listView.Items.Count; i++)
			{
				listView.Items[i].Selected = true;
			}
		}

		private void PasteFiles()
		{
			if(IsWorking()) return;
			try
			{
				DoDrop(Clipboard.GetDataObject());
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		private void listView_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if(this.IsWorking()) return;
				if(listLast.X < 0 || listLast.Y < 0) return;
				ListViewItem item = listView.GetItemAt(listLast.X, listLast.Y);
				if(item == null) return;
				string file = item.Text;
				if(file == null) return;
				bool isDir = Directory.Exists(file);
				System.Diagnostics.Process p = System.Diagnostics.Process.Start("explorer.exe", "/e," + (isDir ? string.Empty : "/select,") + "\"" + file + "\"");
				if(p != null) p.Close();
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		private Point listLast = new Point(-1, -1);
		private void listView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			listLast.X = e.X;
			listLast.Y = e.Y;
		}

		private void Cript_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Alt && e.KeyCode.Equals(Keys.X))
			{
				e.Handled = true;
				Close();
			}
			else if(e.KeyCode.Equals(Keys.Enter))
			{
				DoStartStop();
			}
		}

		#region process

		private enum EType { AES128, AES192, AES256, BWF128, BWF192, BWF256, BWF448, SER128, SER192, SER256 };

		private class EncryptionParams
		{
			public enum EMode{Auto, Enc, Dec}
			
			private string password = null;
			private string outDir = null;
			public EType keyType = EType.AES128;
			public int icount = 1024;
			public EMode mode = EMode.Auto;
			
			public string OutDir
			{
				get{ return outDir; }
				set
				{ 
					outDir = value;
					outDir = AddDirSep(outDir);
				}
			}

			public string Password
			{
				get{ return password; }
				set{ password = value; }
			}

			public static string EType2String(EType t)
			{
				switch(t)
				{
					case EType.AES128: return "AES128";
					case EType.AES192: return "AES192";
					case EType.AES256: return "AES256";
					case EType.BWF128: return "BWF128";
					case EType.BWF192: return "BWF192";
					case EType.BWF256: return "BWF256";
					case EType.BWF448: return "BWF448";
					case EType.SER128: return "SER128";
					case EType.SER192: return "SER192";
					case EType.SER256: return "SER256";
				}
				return "?";
			}

			public static EType String2EType(string s)
			{
				if(s == null) return EType.AES128;
				switch(s.ToUpper())
				{
					case "AES128": return EType.AES128;
					case "AES192": return EType.AES192;
					case "AES256": return EType.AES256;
					case "BWF128": return EType.BWF128;
					case "BWF192": return EType.BWF192;
					case "BWF256": return EType.BWF256;
					case "BWF448": return EType.BWF448;
					case "SER128": return EType.SER128;
					case "SER192": return EType.SER192;
					case "SER256": return EType.SER256;
					default:
						throw new Exception("unknown key type: " + s);
				}
			}

			public static int EType2Index(EType t)
			{
				switch(t)
				{
					case EType.AES128: return 0;
					case EType.AES192: return 1;
					case EType.AES256: return 2;
					case EType.BWF128: return 3;
					case EType.BWF192: return 4;
					case EType.BWF256: return 5;
					case EType.BWF448: return 6;
					case EType.SER128: return 7;
					case EType.SER192: return 8;
					case EType.SER256: return 9;
				}
				return 0;
			}

			public static EType Index2EType(int t)
			{
				switch(t)
				{
					case 0: return EType.AES128;
					case 1: return EType.AES192;
					case 2: return EType.AES256;
					case 3: return EType.BWF128;
					case 4: return EType.BWF192;
					case 5: return EType.BWF256;
					case 6: return EType.BWF448;
					case 7: return EType.SER128;
					case 8: return EType.SER192;
					case 9: return EType.SER256;
				}
				return EType.AES128;
			}

			public static void EType2KeyData(EType t, ref int keySize, ref int ivSize, ref int saltSize)
			{
				keySize = 16; ivSize = 16; saltSize = 16;
				switch(t)
				{
					case EType.AES128: keySize = 16; ivSize = 16; break;
					case EType.AES192: keySize = 24; ivSize = 16; break;
					case EType.AES256: keySize = 32; ivSize = 16; break;
					case EType.BWF128: keySize = 16; ivSize = 8; break;
					case EType.BWF192: keySize = 24; ivSize = 8; break;
					case EType.BWF256: keySize = 32; ivSize = 8; break;
					case EType.BWF448: keySize = 56; ivSize = 8; break;
					case EType.SER128: keySize = 16; ivSize = 16; break;
					case EType.SER192: keySize = 24; ivSize = 16; break;
					case EType.SER256: keySize = 32; ivSize = 16; break;
					default: throw new Exception("unknown encryption type");
				}
				saltSize = keySize;
			}

			public static IBlockCipher EType2IBC(EType t)
			{
				IBlockCipher bc = null;
				switch(t)
				{
					case EType.AES128: bc = new aes.AESFast(); break;
					case EType.AES192: bc = new aes.AESFast(); break;
					case EType.AES256: bc = new aes.AESFast(); break;
					case EType.BWF128: bc = new aes.BFW(); break;
					case EType.BWF192: bc = new aes.BFW(); break;
					case EType.BWF256: bc = new aes.BFW(); break;
					case EType.BWF448: bc = new aes.BFW(); break;
					case EType.SER128: bc = new aes.Ser(); break;
					case EType.SER192: bc = new aes.Ser(); break;
					case EType.SER256: bc = new aes.Ser(); break;
				}
				return bc;
			}
		}

		private EncryptionParams encParams = new EncryptionParams();
		private void SetEncryptionParams()
		{
			this.encParams.Password = this.txtPass.Text.Trim();
			this.txtPass.Text = this.encParams.Password;
			if(this.encParams.Password.Length <= 0)
			{
				throw new Exception("password is required!");
			}
			this.encParams.keyType = EncryptionParams.Index2EType(this.cmbAlgo.SelectedIndex);
			this.encParams.icount =(int)this.numIC.Value;
			if(this.radioEnc.Checked) this.encParams.mode = EncryptionParams.EMode.Enc;
			else if(this.radioDec.Checked) this.encParams.mode = EncryptionParams.EMode.Dec;
			else
			{ 
				this.encParams.mode = EncryptionParams.EMode.Auto;
			}
		}
		
		private void ProcessItems()
		{
			int total = this.listView.Items.Count;
			int processed = 0;
			for(int i = 0; i < total; ++i)
			{
				string file = this.listView.Items[i].Text;
				try
				{
					if(ShouldStop()) return;
					ProcessItem(file, ref processed);
				}
				catch(Exception ex)
				{
					if(ShouldStop()) return;
					LogErr(file + " - " + ex.Message);
				}
			}
		}

		private string inDir = null;
		private void ProcessItem(string file, ref int processed)
		{
			inDir = null;
			if(Directory.Exists(file))
			{
				inDir = file;
				ProcessDir(file, ref processed);
			}
			else if(File.Exists(file))
			{
				ProcessFile(file, ref processed);
			}
			else
			{
				LogErr(file + " - not found");
			}
		}

		private void ProcessDir(string dir, ref int processed)
		{
			if(dir == null) return;
			string[] files = Directory.GetFiles(dir);
			if((files != null) && files.Length > 0)
			{
				for(int i = 0; i < files.Length; ++i)
				{
					if(ShouldStop()) return;
					ProcessFile(files[i], ref processed);
				}
			}
			files = Directory.GetDirectories(dir);
			if((files != null) && files.Length > 0)
			{
				for(int i = 0; i < files.Length; ++i)
				{
					if(ShouldStop()) return;
					ProcessDir(files[i], ref processed);
				}
			}
		}

		private void ProcessFile(string file, ref int processed)
		{
			processed++;
			string sprocessed = "[" + processed + " of " + totalFiles + "] ";
			try
			{		
				if(file == null) return;
				FileInfo fi = new FileInfo(file);
				string slen = string.Empty;
				if(fi != null) slen = " [" + fi.Length.ToString() + " bytes]";
				fi = null;

				bool encrypt = IsEcryptAction(file);
				string outFile = GetDirOutFileName(file, inDir, this.encParams.OutDir);
				Directory.CreateDirectory(Path.GetDirectoryName(outFile));
				outFile = GetOutFileName(outFile, encrypt);

				string mode = encrypt ? "Encrypt " : "Decrypt ";
				this.LogCurrent(sprocessed + mode + file + slen + " -> " + Path.GetFileName(outFile));
				EncryptFile(file, outFile, encrypt);
			}
			catch(Exception ex)
			{
				if(ShouldStop()) return;
				LogErr(sprocessed + file + " - " + ex.Message);
			}
		}

		private bool IsEcryptAction(string file)
		{
			if(this.encParams.mode.Equals(EncryptionParams.EMode.Enc)) return true;
			else if(this.encParams.mode.Equals(EncryptionParams.EMode.Dec)) return false;
			else // auto
			{ 
				return !IsEncrypted(file);
			}
		}

		private static string GetDirOutFileName(string file, string inDir, string outDir)
		{
			if(outDir == null)
			{
				return file;
			}
			bool appendInDir = true;
			if((inDir == null) || !file.ToUpper().StartsWith(inDir.ToUpper()) || !Directory.Exists(inDir))
			{
				appendInDir = false;
				inDir = Path.GetDirectoryName(file);
			}
			inDir = Path.GetFullPath(inDir);
			inDir = AddDirSep(inDir);
			string pathDiference = file.Substring(inDir.Length, file.Length - inDir.Length);
			string path = outDir;
			if(appendInDir)
			{
				int k = 0;
				try
				{
					k = inDir.LastIndexOf(Path.DirectorySeparatorChar, inDir.Length - 2);
				}
				catch{}
				if(k < 0) k = 0;
				string t = inDir.Substring(k, inDir.Length - k);
				if(t.StartsWith(Path.DirectorySeparatorChar.ToString()))
				{
					t = t.Substring(1, t.Length - 1);
				}
				t = t.Replace(":", "_");
				path += t;
			}
			path += pathDiference;
			return path;
		}

		private string GetOutFileName(string file, bool encrypt)
		{
			int count = 0;
			string outFile = _GetOutFileName(file, encrypt);
			string fn = Path.Combine(Path.GetDirectoryName(outFile), Path.GetFileNameWithoutExtension(outFile));
			string fe = Path.GetExtension(outFile);
			string temp = outFile;
			while(File.Exists(temp))
			{
				count++;
				temp = fn + "-" + count + fe;
			}
			return temp;
		}

		private string _GetOutFileName(string file, bool encrypt)
		{
			if(encrypt)
			{
				return file + criptFileSuffix;
			}
			else
			{
				if(IsEncrypted(file))
				{
					return Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file));
				}
				else
				{
					return file + ".plain";
				}
			}
		}

		private StrongRandomGenerator rndgen = null;
		private StrongRandomGenerator GetRandom()
		{
			if(rndgen == null)
			{
				byte[] seed = StrongRandomGenerator.GetDefaultSeed();
				if((mouseMoveData != null) && mouseMoveData.Count > 0)
				{
					ArrayList temp = mouseMoveData;
					mouseMoveData = null;
					try
					{
						byte[] buff = new byte[seed.Length + temp.Count];
						Array.Copy(seed, 0, buff, 0, seed.Length);
						temp.CopyTo(buff, seed.Length);
						seed = buff;
					}
					catch{}
				}
				mouseMoveData = null;
				rndgen = new StrongRandomGenerator(seed);
			}
			return rndgen;
		}

		private void EncryptFile(string file, string outFile, bool encrypt)
		{
			
			FileStream fin = null;
			FileStream fout = null;
			try
			{
				fin = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 5 * 1024 * 1024);
				if(fin == null) throw new Exception("cannot read");
				if(fin.Length <= 0) throw new Exception("empty file");
				fout = new FileStream(outFile, FileMode.Create, FileAccess.Write, FileShare.Read, 5 * 1024 * 1024);
				if(fout == null) throw new Exception("cannot write");
				byte[] iv = new byte[1];
				byte[] salt = new byte[1];
				if(encrypt)
				{
					StreamCtx ctx = MakeEncryptStreamCtx(this.encParams.Password, this.encParams.keyType, ref iv, ref salt, this.encParams.icount);
					if(ctx == null)
					{
						if(this.ShouldStop()) return;
						else throw new Exception("internal encryption error");
					}
					fout.Write(iv, 0, iv.Length);
					fout.Write(salt, 0, salt.Length);
					StreamCipher.Encrypt(ctx, fin, fout, this);
				}
				else
				{
					int keySize = 16; int ivSize = 16; int saltSize = 16;
                    EncryptionParams.EType2KeyData(this.encParams.keyType, ref keySize, ref ivSize, ref saltSize);
					iv = new byte[ivSize];
					salt = new byte[saltSize];
					if(fin.Length <= (iv.Length + salt.Length))
					{
						throw new Exception("no data");
					}
					if(fin.Read(iv, 0, iv.Length) != iv.Length)
					{
						throw new Exception("no data");
					}
					if(fin.Read(salt, 0, salt.Length) != salt.Length)
					{
						throw new Exception("no data");
					}
					StreamCtx ctx = MakeDecryptStreamCtx(this.encParams.Password, this.encParams.keyType, keySize, iv, salt, this.encParams.icount);
					if(ctx == null)
					{
						if(this.ShouldStop()) return;
						else throw new Exception("internal encryption error");
					}
					StreamCipher.Decrypt(ctx, fin, fout, this);
				}				
			}
			finally
			{
				try{ if(fin != null) fin.Close(); } 
				catch{}
				finally{fin = null; }
				try{ if(fout != null) fout.Close(); } 
				catch{}
				finally{fout = null; }
			}
		}

		private StreamCtx MakeEncryptStreamCtx(string password, EType keyType, ref byte[]iv, ref byte[] salt, int icount)
		{
			sc.IBlockCipher bc = null;
			StreamCtx ctx = null;
			int count = 0;
			
			int keySize = 16; int ivSize = 16; int saltSize = 16;
			EncryptionParams.EType2KeyData(keyType, ref keySize, ref ivSize, ref saltSize);
			iv = new byte[ivSize];
			salt = new byte[saltSize];
			this.GetRandom().NextBytes(iv);

			while(ctx == null)
			{
				if(this.ShouldStop()) return null;
				count++;
				if(count > 128) return null;

				bc = EncryptionParams.EType2IBC(keyType);
				if(bc == null) return null;
				this.GetRandom().NextBytes(salt);
				byte[] key = KeyGen.DeriveKey(password, keySize, salt, icount);
				ctx = StreamCipher.MakeStreamCtx(bc, key, iv);
			}
			return ctx;
		}

		private StreamCtx MakeDecryptStreamCtx(string password, EType keyType, int keySize, byte[]iv, byte[] salt, int icount)
		{
			sc.IBlockCipher bc = EncryptionParams.EType2IBC(keyType);
			if(bc == null) return null;
			byte[] key = KeyGen.DeriveKey(password, keySize, salt, icount);
			return StreamCipher.MakeStreamCtx(bc, key, iv);
		}

		#endregion process

		#region thread

		internal static readonly string APPNAME = "Cr!ptAES";
		private Thread thread = null;
		private bool shouldStop = false;
		private delegate bool DStop();

		private bool IsWorking()
		{
			return thread != null;
		}

		private void Start()
		{
			Stop();
			EnableAll(false);
			thread = new Thread(new ThreadStart(DoWork));
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			shouldStop = false;
			this.txtLog.Focus();
			thread.Start();
		}

		private bool Stop()
		{
			try
			{
				if(!IsWorking()) return false;
				thread.Suspend();
				if(MessageBox.Show(this, "Do you really want to stop processing?", APPNAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					thread.Resume();
					this.txtLog.Focus();
					return true;
				}
				btnOK.Enabled = false;
				shouldStop = true;
				thread.Resume();
				this.txtLog.Focus();
				Log("Stopping please wait ...");
			}
			catch
			{
				btnOK.Enabled = true;
			}
			return false;
		}

		public bool ShouldStop()
		{
			return shouldStop;
		}

		private void DoWork()
		{
			try
			{
				if(IsEncMode())
				{
					if(this.encParams.OutDir != null)
					{
						this.encParams.OutDir = AddDirSep(Path.GetFullPath(this.encParams.OutDir));
						Log("Output directory: " + this.encParams.OutDir);
						Directory.CreateDirectory(this.encParams.OutDir);
					}
				}
				this.totalFilesSize = ScanFiles(this.radioScan.Checked);
				if(this.radioScan.Checked || ((totalFilesSize <= 0) || (this.totalFiles <=0)) && !this.radioDel.Checked)
				{
					return;
				}
				if(this.radioCRC.Checked)
				{
					ProcessCRC();
				}
				else if(this.radioDel.Checked)
				{
					ProcessDelete();
				}
				else
				{
					ProcessItems();
				}
			}
			catch(Exception ex)
			{
				LogErr(ex.Message);
			}
			catch
			{}
			finally
			{
				thread = null;
				if(IsEncMode())
				{
					this.encParams.Password = null;
					coutDir = null;
					if(this.encParams.OutDir != null)
					{
						Log("Output directory: " + this.encParams.OutDir);
					}
					this.encParams.OutDir = null;
				}
				try
				{
					EnableAll();
					SetProgress(0, 0);
					if(!this.ShouldStop())
					{
						this.LogCurrent(null);
						Log("Done!");
					}
					else
					{
						Log("Stopped!");
					}
					if(this.batchExit && !hasErrors)
					{
						Close();
					}
				}
				catch{}
			}
		}

		#endregion thread

		#region scan

		private ulong ScanFiles(bool scanMode)
		{
			string file = null;
			this.scanData = new ScanData();
			try
			{
				int total = this.listView.Items.Count;
				Log("Scanning " + total + " item(s) ...");
				for(int i = 0; i < total; ++i)
				{
					if(ShouldStop()) return 0;
					file = this.listView.Items[i].Text;
					if(Directory.Exists(file))
					{
						if(this.radioDel.Checked)
						{
							CheckForVolume(file);
						}
						ScanDir(file, scanMode);
					}
					else if(File.Exists(file))
					{
						ScanFile(file, scanMode);
					}
				}
				if(ShouldStop()) return 0;
				string msg = "Processing: " + this.totalFiles + " file(s)";
				msg += ", " + totalDirs + " folder(s)";
				Log(msg + ". Total size: " + FileSize2String(this.totalFilesSize) + "...");
				Log(scanData.SizesPerVolume(new DStop(this.ShouldStop), this.IsEncMode()));
				if(scanMode)
				{
					if(ShouldStop()) return 0;
					Log(string.Empty);
					Log(this.scanData.ToString(new DStop(this.ShouldStop), totalFiles));
				}
				Log(string.Empty);
			}
			catch(Exception ex)
			{
				this.totalFilesSize = 0;
				if(!ShouldStop())
				{
					string t = ((file ==  null) ? string.Empty : (file + " - "));
					throw new Exception(t + ex.Message);
				}
			}
			finally
			{
				if(scanData != null) scanData.Clear();
				scanData = null;
			}
			return this.totalFilesSize;
		}

		private static string FileSize2String(ulong size)
		{
			string s = size + " byte(s)";
			ulong kb = size / 1024;
			if((size % 1024) >= 512) kb++;
			if(kb > 0)
			{
				s += " ~ " + kb + " KB";
				ulong mb = kb / 1024;
				if((kb % 1024) >= 512) mb++;
				if(mb > 0) s += " ~ " + mb + " MB";
			}
			return s;
		}

		private void ScanDir(string dir, bool scanMode)
		{
			if(dir == null) return;
			totalDirs++;
			try
			{
				string[] files = Directory.GetFiles(dir);
				if((files != null) && files.Length > 0)
				{
					for(int i = 0; i < files.Length; ++i)
					{
						if(ShouldStop()) return;
						ScanFile(files[i], scanMode);
					}
				}
				files = Directory.GetDirectories(dir);
				if((files != null) && files.Length > 0)
				{
					for(int i = 0; i < files.Length; ++i)
					{
						if(ShouldStop()) return;
						ScanDir(files[i], scanMode);
					}
				}
			}
			catch{}
		}

		private class ScanData
		{
			public Hashtable suffixes = null;
			public ArrayList emptyFiles = null;
			public long smallestFile = Int64.MaxValue;
			public string smallestFileName = null;
			public long biggestFile = 0;
			public string biggestFileName = null;
			public Hashtable fileSizePerVolume = null;

			public void Clear()
			{
				if(suffixes != null) suffixes.Clear();
				suffixes = null;
				if(emptyFiles != null) emptyFiles.Clear();
				emptyFiles = null;
				if(fileSizePerVolume != null) fileSizePerVolume.Clear();
				fileSizePerVolume = null;
			}

			public string SizesPerVolume(DStop shouldStop, bool inEncMode)
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				if((fileSizePerVolume != null) && (fileSizePerVolume.Keys.Count > 0))
				{
					//sb.Append(Environment.NewLine);
					SortedList sorted = new SortedList(fileSizePerVolume);
					foreach(string ext in sorted.Keys)
					{
						if(shouldStop()) return string.Empty;
						ulong sizeVolume = (ulong)sorted[ext];
						ulong total = 0;
						ulong free = DiskInfo.FreeDiskSpace(ext, ref total);
						int freePercent = 0;
						if(total != 0) freePercent = (int)((free * 100) / total);
						sb.Append("@ ").Append(ext);
						sb.Append(Environment.NewLine);
						sb.Append("  | Input: ").Append(" ").Append(FileSize2String(sizeVolume)).Append(Environment.NewLine);
						sb.Append("  | Free : ").Append(FileSize2String(free)).Append(" => ").Append(freePercent).Append("%").Append(Environment.NewLine);
						sb.Append("  | Total: ").Append(FileSize2String(total)).Append(Environment.NewLine);
						if(inEncMode && (free <= (sizeVolume + 1024*1024))) sb.Append("  ! There may not be enough free space of this volume !!!").Append(Environment.NewLine);
						//sb.Append(Environment.NewLine);
					}
				}
				return sb.ToString();
			}

			public string ToString(DStop shouldStop, int totalFiles)
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				bool hasEmpty = ((emptyFiles != null) && (emptyFiles.Count > 0));
				//sb.Append(SizesPerVolume());
				if(totalFiles > 1)
				{
					if(smallestFileName != null)
					{
						sb.Append("Smallest " + (hasEmpty ? "(not-empty) ": string.Empty) + "file:\n" + smallestFileName + "  [" + FileSize2String((ulong)smallestFile) + "]").Append(Environment.NewLine);
						sb.Append(Environment.NewLine);
					}
					if(biggestFileName != null)
					{
						sb.Append("Biggest file:\n" + biggestFileName + "  [" + FileSize2String((ulong)biggestFile) + "]").Append(Environment.NewLine);
						sb.Append(Environment.NewLine);
					}
				}
				if((suffixes != null) && (suffixes.Keys.Count > 0))
				{
					sb.Append(Environment.NewLine);
					sb.Append("--- " + suffixes.Keys.Count.ToString() +  " file type(s) ---").Append(Environment.NewLine);
					SortedList sorted = new SortedList(suffixes);
					sb.Append("No. of files - Type");
					sb.Append(Environment.NewLine);
					sb.Append(Environment.NewLine);
					foreach(string ext in sorted.Keys)
					{
						if(shouldStop()) return string.Empty;
						string sext = (ext.Length <= 0 ? "?" : ext);
						string num = String.Format("{0,5}", (int)sorted[ext]);
						sb.Append(num).Append(" ").Append(sext).Append(Environment.NewLine);
					}
				}
				if(hasEmpty)
				{
					sb.Append(Environment.NewLine);
					sb.Append("--- " + emptyFiles.Count +  " empty file(s) ---").Append(Environment.NewLine);
					sb.Append(Environment.NewLine);
					for(int i = 0; i < emptyFiles.Count; ++i)
					{
						if(shouldStop()) return string.Empty;
						sb.Append((string)emptyFiles[i]).Append(Environment.NewLine);
					}
				}
				return sb.ToString();
			}
		}

		private ScanData scanData = null;
		private void ScanFile(string file, bool scanMode)
		{
			if(file == null) return;
			if(scanMode && (scanData.suffixes == null)) scanData.suffixes = new Hashtable();
			if(scanData.fileSizePerVolume == null) scanData.fileSizePerVolume = new Hashtable();
			try
			{
				if(scanMode)
				{
					string ext = Path.GetExtension(file).ToUpper();
					if(scanData.suffixes[ext] == null) scanData.suffixes[ext] = 1;
					else
					{
						int i = (int)scanData.suffixes[ext];
						scanData.suffixes[ext] = i + 1;
					}
				}
				FileInfo fi = new FileInfo(file);
				if(fi != null)
				{
					string root = Path.GetPathRoot(fi.FullName);
					if(scanData.fileSizePerVolume[root] == null)
					{
						scanData.fileSizePerVolume[root] = (ulong)fi.Length;
					}
					else
					{
						ulong usize = (ulong)scanData.fileSizePerVolume[root];
						usize += (ulong)fi.Length;
						scanData.fileSizePerVolume[root] = usize;
					}
					
					if(scanMode)
					{
						if(fi.Length <= 0)
						{
							if(this.scanData.emptyFiles == null) this.scanData.emptyFiles = new ArrayList();
							if(!this.scanData.emptyFiles.Contains(file.ToLower()))
							{
								this.scanData.emptyFiles.Add(file.ToLower());
							}
						}
						else
						{
							if(fi.Length > this.scanData.biggestFile)
							{
								this.scanData.biggestFile = fi.Length;
								this.scanData.biggestFileName = file;
							}
							if(fi.Length < this.scanData.smallestFile)
							{
								this.scanData.smallestFile = fi.Length;
								this.scanData.smallestFileName = file;
							}
						}
					}
					this.totalFiles++;
					this.totalFilesSize = this.totalFilesSize + (ulong)fi.Length;
				}
			}
			catch{}
		}

		#endregion scan


		#region progress

		private int totalFiles = 0;
		private int totalDirs = 0;
		private ulong totalFilesSize = 0;
		private ulong currentFilesSize = 0;
		private bool currentFilesSizeSet = false;

		public void Progress(long progress, long length)
		{
			try
			{
				if(length <= 0) return;
				int current = (int)((progress * 100) / length);
				ulong delta = (ulong)progress;
				if(progress == 0) currentFilesSizeSet = false;
				if((progress == length) && !currentFilesSizeSet)
				{
					currentFilesSizeSet = true;
					currentFilesSize = currentFilesSize + (ulong)length;
					delta = 0;
				}
				ulong temp = currentFilesSize + delta;
				int total = 0;
				if(totalFilesSize != 0)
				{
					total = (int)((temp * 100) / totalFilesSize);
				}
				SetProgress(current, total);
			}
			catch{}
		}

		private delegate void DSetProgress(int current, int total);
		private int lastPC = -1;
		private int lastPT = -1;
		private void SetProgress(int current, int total)
		{
			if((current == lastPC) && (total == lastPT)) return;
			lastPC = current;
			lastPT = total;
			if(this.InvokeRequired)
			{
				this.Invoke(new DSetProgress(_SetProgress), new object[]{current, total});
			}
			else
			{
				_SetProgress(current, total);
			}
		}

		private void _SetProgress(int current, int total)
		{
			try
			{
				this.progressCurrent.Value = current;
				this.progressTotal.Value = total;
			}
			catch{}
		}

		#endregion progress

		private int lastColClicked = 0;
		private bool lastColDesc = false;
		private void listView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			if(this.IsWorking()) return;
			try
			{
				if(this.listView.Items.Count <= 0) return;
				if(lastColClicked == e.Column)
				{
					lastColDesc = !lastColDesc;
				}
				else
				{
					lastColDesc = false;
				}
				ListComparator lc = new ListComparator(e.Column, lastColDesc);
				this.listView.ListViewItemSorter = lc;
				lastColClicked = e.Column;
			}
			catch{}
		}

		private void btnClean_Click(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			ClearLog();
			this.txtPass.Clear();
			this.txtPass.Focus();
		}

		private ArrayList mouseMoveData = new ArrayList();
		private void ProcessMouseMoveData(int X, int Y)
		{
			try
			{
				if((mouseMoveData == null) || (mouseMoveData.Count > 4096)) return;
				int point = X * Y;
				//System.Diagnostics.Debug.WriteLine("(" + X + ","+ Y + ") " + point +  " B1 " + (byte)point + " B2 " + (byte)(point >> 8));
				mouseMoveData.Add((byte)point);
				mouseMoveData.Add((byte)(point >> 8));
			}
			catch{}
		}
		
		private void Cript_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ProcessMouseMoveData(e.X, e.Y);
		}		

		private void listView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ProcessMouseMoveData(e.X, e.Y);
		}

		private void panelBottom_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ProcessMouseMoveData(e.X, e.Y);
		}

		private void txtLog_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ProcessMouseMoveData(e.X, e.Y);
		}

		private void pictureBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ProcessMouseMoveData(e.X, e.Y);
		}

		private bool numICEnabled = false;
		private void EnableIC()
		{
			if(this.IsWorking()) return;
			numICEnabled = !numICEnabled;
			this.numIC.Enabled = numICEnabled;
			if(!this.numIC.Enabled) numIC.Value = 1024;
		}		

		private void AES128()
		{
			if(this.IsWorking()) return;
			this.cmbAlgo.SelectedIndex = 0;
		}

		#region tb

		private void ShowMID()
		{
			string mid = MID.GetMID();
			byte[] b = SHA256.MessageSHA256(System.Text.Encoding.ASCII.GetBytes(mid));
			if((b == null) || b.Length <= 0) mid = "<???>";
			else
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				for(int i = 0; i < b.Length; ++i)
				{
					if(b[i] < 16) sb.Append('0');
					sb.Append(b[i].ToString("X"));
				}
				mid = sb.ToString();
			}
			//MessageBox.Show(this, mid , "Unique Machine ID - " + APPNAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
			LogOne("Your machine ID: " + mid);
		}

		private delegate void TBAction(); 

		private void InitTB()
		{
			this.tbAdd.Tag = new TBAction(BAddFiles);
			this.tbRemove.Tag = new TBAction(RemoveSel);
			this.tbAddDir.Tag = new TBAction(BAddDir);
			this.tbInfo.Tag = new TBAction(BItemInfo);
			this.tbPaste.Tag = new TBAction(PasteFiles);
			this.tbCopy.Tag = new TBAction(CopySel);
			this.tbGen.Tag = new TBAction(BGenPass);
			this.tbStart.Tag = new TBAction(DoStartStop);
			this.tbAbout.Tag = new TBAction(ShowMB);
			this.tbMID.Tag = new TBAction(ShowMID);
		}

		private void EnableTB(bool on)
		{
			foreach(ToolBarButton b in this.toolBar.Buttons)
			{
				b.Enabled = on;
			}
			this.tbStart.Pushed = !on;
			this.tbStart.Enabled = true;
			this.tbAbout.Enabled = true;
		}

		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button.Tag == null) return;
			try
			{
				TBAction tba = (TBAction)e.Button.Tag;
				tba();
			}
			catch{}
		}

		#endregion tb

		private void btnGen_Click(object sender, System.EventArgs e)
		{
			this.BGenPass();
		}

		private void radioDec_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			if(radioDec.Checked) LogOne("Mode: Decrypt all files!");
		}

		private void radioEnc_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			if(radioEnc.Checked) LogOne("Mode: Encrypt all files!");
		}

		
		private void radioCRC_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			if(radioCRC.Checked) LogOne("Mode: Calculate SHA256 finger print of all files!");
			SetOtherMode(IsEncMode());
		}

		private void radioAuto_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			if(radioAuto.Checked) LogOne("Mode: Auto - decrypt *" + this.criptFileSuffix + " files, encrypt all other files!");
		}

		private void radioDel_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			if(radioDel.Checked) LogOne("Mode: Delete, wipe all files with random data!");
			if(radioDel.Checked)
			{
				this.btnOK.BackColor = SystemColors.ControlDarkDark;
				this.btnOK.ForeColor = SystemColors.ControlLightLight;
			}
			else
			{
				this.btnOK.BackColor = SystemColors.Control;
				this.btnOK.ForeColor = SystemColors.ControlText;
			}
			SetOtherMode(IsEncMode());
		}

		private void radioScan_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			if(radioScan.Checked) LogOne("Mode: Information about files!");
			SetOtherMode(IsEncMode());
		}

		private void SetOtherMode(bool on)
		{
			this.btnGen.Visible = on;
			this.btnClean.Visible = on;
			this.btnCopy.Visible = on;
			this.txtPass.Visible = on;
			this.chkMask.Visible = on;
			this.chkKeep.Visible = on;
			this.btnIC.Visible = on;
			this.numIC.Visible = on;
			this.btnAES.Visible = on;
			this.cmbAlgo.Visible = on;
			this.btnNext.Visible = on;
			this.tbGen.Visible = on;
			this.toolBarButtonTG.Visible = on;
		}

		private void NextKeySize()
		{
			if(this.IsWorking()) return;
			int i = this.cmbAlgo.SelectedIndex;
			i++;
			if(i >= this.cmbAlgo.Items.Count) i = 0;
			this.cmbAlgo.SelectedIndex = i;
		}

		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.IsWorking()) return;
				Clipboard.SetDataObject(this.txtPass.Text, true);
				ClearLog();
				Log("Password copied to clipboard!");
				this.txtPass.Focus();
			}
			catch(Exception ex)
			{
				LogErrOne(ex.Message);
			}
		}

		private void chkKeep_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.IsWorking()) return;
			ClearLog();
			string t = chkKeep.Checked ? "ON" : "OFF";
			Log("Keep password: " + t);
			this.txtPass.Focus();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			this.NextKeySize();
		}

		private void btnIC_Click(object sender, System.EventArgs e)
		{
			EnableIC();
		}

		private void btnAES_Click(object sender, System.EventArgs e)
		{
			AES128();
		}

		#region crc

		private void ProcessCRC()
		{
			int total = this.listView.Items.Count;
			int processed = 0;
			for(int i = 0; i < total; ++i)
			{
				string file = this.listView.Items[i].Text;
				try
				{
					if(ShouldStop()) return;
					if(Directory.Exists(file))
					{
						CalcDirCRC(file, ref processed);
					}
					else if(File.Exists(file))
					{
						CalcCRC(file, ref processed, this);
					}
					else
					{
						LogErr(file + " - not found");
					}
				}
				catch(Exception ex)
				{
					if(ShouldStop()) return;
					LogErr(file + " - " + ex.Message);
				}
			}
			try
			{
				if(this.hasRep)
				{
					Log("--- Equal (repeated) files ---");
					foreach(string c in crc.Keys)
					{
						if(ShouldStop()) return;
						ArrayList f = (ArrayList)crc[c];
						if((f == null) || (f.Count < 2)) continue;
						Log(string.Empty);
						for(int i = 0; i < f.Count; ++i)
						{
							if(ShouldStop()) return;
							Log((string)f[i]);
						}
					}
					Log(string.Empty);
				}
				else
				{
					Log(string.Empty);
				}
				crc.Clear();
				crc = null;
			}
			catch{}
		}

		private void CalcDirCRC(string dir, ref int processed)
		{
			if(dir == null) return;
			string[] files = Directory.GetFiles(dir);
			if((files != null) && files.Length > 0)
			{
				for(int i = 0; i < files.Length; ++i)
				{
					if(ShouldStop()) return;
					try
					{
						CalcCRC(files[i], ref processed, this);
					}
					catch(Exception ex)
					{
						if(ShouldStop()) return;
						LogErr(files[i] + " - " + ex.Message);
					}
				}
			}
			files = Directory.GetDirectories(dir);
			if((files != null) && files.Length > 0)
			{
				for(int i = 0; i < files.Length; ++i)
				{
					if(ShouldStop()) return;
					try
					{
						CalcDirCRC(files[i], ref processed);
					}
					catch(Exception ex)
					{
						if(ShouldStop()) return;
						LogErr(files[i] + " - " + ex.Message);
					}
				}
			}
		}

		private void CalcCRC(string file, ref int processed, StreamCipherMonitor monitor)
		{
			processed++;
			string sprocessed = "[" + processed + " of " + totalFiles + "] ";
			FileStream fin = null;
			System.Security.Cryptography.HashAlgorithm hash = null;
			try
			{
				if(file == null) return;
				FileInfo fi = new FileInfo(file);
				string slen = string.Empty;
				if(fi != null) slen = " [" + fi.Length.ToString() + " bytes]";
				fi = null;
				string t = sprocessed + file + slen;
				LogCurrent(t);
				Log(t);
				fin = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 5 * 1024 * 1024);
				if(fin == null) throw new Exception("cannot read");
				if(monitor != null) monitor.Progress(0, fin.Length);
				hash = new System.Security.Cryptography.SHA256Managed();
				byte[] buffer = new byte[0x1000];
				while(true)
				{
					if(monitor != null)
					{
						if(monitor.ShouldStop()) return;
						monitor.Progress(fin.Position, fin.Length);
					}
					int n = fin.Read(buffer, 0, 0x1000);
					if(n == 0x1000)
					{
						hash.TransformBlock(buffer, 0, 0x1000, buffer, 0);
					}
					else
					{
						hash.TransformFinalBlock(buffer, 0, n);
						break;
					}
				}
				ProcessBytes(file, hash.Hash);
				if(monitor != null)
				{
					if(!monitor.ShouldStop())
					{
						monitor.Progress(fin.Length, fin.Length);
					}
				}
			}
			finally
			{
				if(fin != null) fin.Close();
			}
		}

		private Hashtable crc = null;
		private bool hasRep = false;
		private void ProcessBytes(string file, byte[] b)
		{
			if((b == null) || b.Length <= 0) return;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for(int i = 0; i < b.Length; ++i)
			{
				if(b[i] < 16) sb.Append('0');
				sb.Append(b[i].ToString("X"));
			}
			if(crc == null) crc = new Hashtable();
			string t = sb.ToString();
			if(crc[t] == null)
			{
				ArrayList f = new ArrayList();
				f.Add(file.ToLower());
				crc[t] = f;
			}
			else
			{
				ArrayList f = (ArrayList)crc[t];
				string fl = file.ToLower();
				if(!f.Contains(fl))
				{
					f.Add(fl);
					crc[t] = f;
				}
				if(f.Count > 1) hasRep = true; 
			}
			Log("SHA256: " + t);
			Log(string.Empty);
		}

		#endregion crc

		#region delete

		private void ProcessDelete()
		{
			int total = this.listView.Items.Count;
			int processed = 0;
			for(int i = 0; i < total; ++i)
			{
				string file = this.listView.Items[i].Text;
				try
				{
					if(ShouldStop()) return;
					if(Directory.Exists(file))
					{
						DeleteDir(file, ref processed);
					}
					else if(File.Exists(file))
					{
						Delete(file, ref processed, this);
					}
					else
					{
						LogErr(file + " - not found");
					}
				}
				catch(Exception ex)
				{
					if(ShouldStop()) return;
					LogErr(file + " - " + ex.Message);
				}
			}
			Log(string.Empty);
		}

		private void CheckForVolume(string dir)
		{
			if(dir == null) return;
			dir = AddDirSep(dir);
			if((dir.Length == 3) && dir[1] == ':')
			{
				throw new Exception("cannot delete an entire volume!");
			}
		}

		private void DeleteDir(string dir, ref int processed)
		{
			if(dir == null) return;
			dir = AddDirSep(dir);
			CheckForVolume(dir);
			string[] files = Directory.GetFiles(dir);
			if((files != null) && files.Length > 0)
			{
				for(int i = 0; i < files.Length; ++i)
				{
					if(ShouldStop()) return;
					try
					{
						Delete(files[i], ref processed, this);
					}
					catch(Exception ex)
					{
						if(ShouldStop()) return;
						LogErr(files[i] + " - " + ex.Message);
					}
				}
			}
			files = Directory.GetDirectories(dir);
			if((files != null) && files.Length > 0)
			{
				for(int i = 0; i < files.Length; ++i)
				{
					if(ShouldStop()) return;
					try
					{
						DeleteDir(files[i], ref processed);
					}
					catch(Exception ex)
					{
						if(ShouldStop()) return;
						LogErr(files[i] + " - " + ex.Message);
					}
				}
			}
			files = Directory.GetFiles(dir);
			if((files != null) && files.Length > 0)
			{
				return;
			}
			files = Directory.GetDirectories(dir);
			if((files != null) && files.Length > 0)
			{
				return;
			}
			string dirName = dir;
			while(Directory.Exists(dirName) || File.Exists(dirName))
			{
				string name = GetRandString(alpha2, 64);
				dirName = AddDirSep(Path.Combine(GetParentDir(dir), name));
			}
			DirectoryInfo fi = new DirectoryInfo(dir);
			SetTime(fi);
			fi = null;
			Directory.Move(dir, dirName);
			fi = new DirectoryInfo(dirName);
			SetTime(fi);
			fi = null;
			Directory.Delete(dirName, false);
		}

		private string GetParentDir(string dir)
		{
			string t = dir;
			if(t.EndsWith(Path.DirectorySeparatorChar.ToString()))
			{
				t = t.Substring(0, t.Length - 1); 
			}
			int i = t.LastIndexOfAny(new char[]{Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar});
			if(i <= 0) return null;
			return t.Substring(0, i);
		}

		private void Delete(string file, ref int processed, StreamCipherMonitor monitor)
		{
			processed++;
			string sprocessed = "[" + processed + " of " + totalFiles + "] Deleting: ";
			
			FileStream fs = null;
			try
			{
				if(file == null) return;
				string slen = string.Empty;
				FileInfo fi = new FileInfo(file);
				if(fi == null)
				{
					LogCurrent(sprocessed);
					throw new Exception("cannot access");
				}
				slen = " [" + fi.Length.ToString() + " bytes]";
				long length = fi.Length;
				if((fi.Attributes | FileAttributes.ReadOnly) == fi.Attributes)
				{
					fi.Attributes = FileAttributes.Normal;
				}
				fi = null;
				string t = sprocessed + file + slen;
				LogCurrent(t);
				if(monitor != null) monitor.Progress(0, length);
				if(length > 0)
				{
					fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 0x1000);
					if(fs == null) throw new Exception("cannot access");
					long remained = length;
					byte[] buff = new byte[0x1000];
					while(remained > 0)
					{
						if(monitor != null)
						{
							if(monitor.ShouldStop()) return;
							monitor.Progress(fs.Position, length);
						}
						long count = System.Math.Min(0x1000, remained);
						if(count != 0x1000)
						{
							buff = new byte[count];
						}
						GetRandom().NextBytes(buff);
						fs.Write(buff, 0, (int)count);
						remained -= count;
					}
					fs.Flush();
					fs.Close();
					fs = null;
				}
				fs = File.Open(file, FileMode.Truncate, FileAccess.Write);
				fs.Close();
				fs = null;
				fi = new FileInfo(file);
				SetTime(fi);
				fi = null;
				string fileName = file;
				try
				{
					string fileFolder = Path.GetDirectoryName(file);
					for(int i = 0; i < 3; ++i)
					{
						if(monitor != null)
						{
							if(monitor.ShouldStop()) return;
						}
						string newFileName = fileName;
						while(File.Exists(newFileName))
						{
							string name = this.GetRandString(alpha2, 64);
							newFileName = Path.Combine(fileFolder, name);
						}
						File.Move(fileName, newFileName);
						fileName = newFileName;
					}
				}
				finally
				{
					fi = new FileInfo(fileName);
					SetTime(fi);
					fi.Delete();
					fi = null;
				}
				if(monitor != null)
				{
					if(!monitor.ShouldStop())
					{
						monitor.Progress(length, length);
					}
				}
			}
			finally
			{
				try{ if(fs != null) fs.Close(); }
				catch{}
				fs = null;
			}

		}

		internal static void SetTime(FileSystemInfo fi)
		{
			if(fi == null) return;
			try
			{
				DateTime dt = NextDate();
				fi.CreationTime = dt;
				fi.LastWriteTime = dt;
				fi.LastAccessTime = dt;
			}
			catch{}
		}

		private static System.Random trnd = new System.Random((int)(DateTime.Now.Ticks + Environment.WorkingSet));
		internal static DateTime NextDate()
		{
			int maxYear = DateTime.Now.Year;
			return new DateTime(trnd.Next(maxYear - 5, maxYear), trnd.Next(1, 12),
				trnd.Next(1, 28), trnd.Next(0, 23), trnd.Next(0, 59),
				trnd.Next(0, 59), trnd.Next(0, 999));
		}

		#endregion delete

		private void mnuAddFiles_Click(object sender, System.EventArgs e)
		{
			this.BAddFiles();
		}

		private void mnuAddDir_Click(object sender, System.EventArgs e)
		{
			this.BAddDir();
		}

		private void mnuPaste_Click(object sender, System.EventArgs e)
		{
			this.PasteFiles();
		}

		private void mnuSelect_Click(object sender, System.EventArgs e)
		{
			this.SelectAll();
		}

		private void mnuCopy_Click(object sender, System.EventArgs e)
		{
			this.CopySel();
		}

		private void mnuRemSel_Click(object sender, System.EventArgs e)
		{
			this.RemoveSel();
		}

		private void contextMenuList_Popup(object sender, System.EventArgs e)
		{
			bool on = !this.IsWorking();
			bool hasItems = (this.listView.Items.Count > 0);
			mnuAddFiles.Enabled = on;
			mnuAddDir.Enabled = on;
			mnuCopy.Enabled = (on && hasItems);
			mnuRemSel.Enabled = (on && hasItems);
			mnuPaste.Enabled = on && CanPaste();
			mnuSelect.Enabled = (on && hasItems && (this.listView.Items.Count != this.listView.SelectedItems.Count));
		}

		#region shbf

		private class OpenDirDialog : FolderNameEditor
		{

			private OpenDirDialog()
			{
			}

			public static string BrowseDialog(IWin32Window w, string text)
			{
				FolderNameEditor.FolderBrowser d = new FolderNameEditor.FolderBrowser();
				if(text != null) d.Description = text;
				d.StartLocation = FolderNameEditor.FolderBrowserFolder.Desktop;
				d.Style = FolderNameEditor.FolderBrowserStyles.RestrictToFilesystem | FolderNameEditor.FolderBrowserStyles.ShowTextBox;
				if(d.ShowDialog(w) == DialogResult.Cancel) return null;
				string t = d.DirectoryPath;
				d.Dispose();
				return t;
			}
		} //EOC

		#endregion shbf

		#region sort

		private class ListComparator : IComparer
		{
			private int colNum = 0;
			private bool desc = false;

			internal ListComparator(int colNum, bool desc)
			{
				this.colNum = colNum;
				this.desc = desc;
			}

			public int Compare(object x, object y)
			{
				if(x == null) return -1;
				if(y == null) return 1;
				int result = 0;
				try
				{
					ListViewItem lx = (ListViewItem)x;
					ListViewItem ly = (ListViewItem)y;
					switch(colNum)
					{
						case 0:
							if((lx.SubItems[1].Text.Equals("-")) && (ly.SubItems[1].Text.Equals("-")))
							{
								result = lx.SubItems[colNum].Text.CompareTo(ly.SubItems[colNum].Text);
							}
							else if(lx.SubItems[1].Text.Equals("-"))
							{
								result = -1;
							}
							else if(ly.SubItems[1].Text.Equals("-"))
							{
								result = 1;
							}
							else
							{
								result = lx.SubItems[colNum].Text.CompareTo(ly.SubItems[colNum].Text);
							}
							break;
						case 1:
							if((lx.SubItems[colNum].Text.Equals("-")) && (ly.SubItems[colNum].Text.Equals("-")))
							{
								result = lx.SubItems[colNum].Text.CompareTo(ly.SubItems[colNum].Text);
							}
							else if(lx.SubItems[colNum].Text.Equals("-"))
							{
								result = 1;
							}
							else if(ly.SubItems[colNum].Text.Equals("-"))
							{
								result = -1;
							}
							else
							{
								int ix = Convert.ToInt32(lx.SubItems[colNum].Text);
								int iy = Convert.ToInt32(ly.SubItems[colNum].Text);
								result = ix.CompareTo(iy);
								if(result == 0)
								{
									result = lx.SubItems[colNum].Text.CompareTo(ly.SubItems[colNum].Text);
								}
							}
							break;
						default:
							goto case 0;
					}
				}
				catch
				{
					return 0;
				}
				if(result == 0) return 0;
				if(desc) return -result;
				return result;
			}
		}//EOC

		#endregion sort

	}//EOC
}
