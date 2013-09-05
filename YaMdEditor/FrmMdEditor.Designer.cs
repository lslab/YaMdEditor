namespace YaMdEditor
{
    partial class FormMdEditor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMdEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtMarkdown = new RichTextBoxEx();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPreview = new System.Windows.Forms.TabPage();
            this.webPreview = new System.Windows.Forms.WebBrowser();
            this.tpSource = new System.Windows.Forms.TabPage();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistoryFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOutputHtmlFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOutputHtmlToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearchNext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearchPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAutoPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuViewPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFont = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOutputHtmlToClipBoard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripcbMarkdownParser = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTextEncoding = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFontInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCssFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelHtmlEncoding = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.contextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bgWorker_Preview = new System.ComponentModel.BackgroundWorker();
            this.tm_preview = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpPreview.SuspendLayout();
            this.tpSource.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtMarkdown);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            // 
            // txtMarkdown
            // 
            this.txtMarkdown.AcceptsTab = true;
            resources.ApplyResources(this.txtMarkdown, "txtMarkdown");
            this.txtMarkdown.HorizontalPosition = 0;
            this.txtMarkdown.Name = "txtMarkdown";
            this.txtMarkdown.VerticalPosition = 0;
            this.txtMarkdown.VScroll += new System.EventHandler(this.txtMarkdown_VScroll);
            this.txtMarkdown.TextChanged += new System.EventHandler(this.txtMarkdown_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPreview);
            this.tabControl1.Controls.Add(this.tpSource);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpPreview
            // 
            this.tpPreview.Controls.Add(this.webPreview);
            resources.ApplyResources(this.tpPreview, "tpPreview");
            this.tpPreview.Name = "tpPreview";
            this.tpPreview.UseVisualStyleBackColor = true;
            // 
            // webPreview
            // 
            resources.ApplyResources(this.webPreview, "webPreview");
            this.webPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.webPreview.Name = "webPreview";
            this.webPreview.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webPreview_DocumentCompleted);
            // 
            // tpSource
            // 
            this.tpSource.Controls.Add(this.txtSource);
            resources.ApplyResources(this.tpSource, "tpSource");
            this.tpSource.Name = "tpSource";
            this.tpSource.UseVisualStyleBackColor = true;
            // 
            // txtSource
            // 
            resources.ApplyResources(this.txtSource, "txtSource");
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView,
            this.menuTool,
            this.menuHelp});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewFile,
            this.menuOpenFile,
            this.menuHistoryFiles,
            this.toolStripMenuItem1,
            this.menuSaveFile,
            this.menuSaveAsFile,
            this.toolStripMenuItem5,
            this.menuOutputHtmlFile,
            this.menuOutputHtmlToClipboard,
            this.toolStripMenuItem7,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            resources.ApplyResources(this.menuFile, "menuFile");
            this.menuFile.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // menuNewFile
            // 
            resources.ApplyResources(this.menuNewFile, "menuNewFile");
            this.menuNewFile.Name = "menuNewFile";
            this.menuNewFile.Click += new System.EventHandler(this.menuNewFile_Click);
            // 
            // menuOpenFile
            // 
            resources.ApplyResources(this.menuOpenFile, "menuOpenFile");
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
            // 
            // menuHistoryFiles
            // 
            this.menuHistoryFiles.Name = "menuHistoryFiles";
            resources.ApplyResources(this.menuHistoryFiles, "menuHistoryFiles");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // menuSaveFile
            // 
            resources.ApplyResources(this.menuSaveFile, "menuSaveFile");
            this.menuSaveFile.Name = "menuSaveFile";
            this.menuSaveFile.Click += new System.EventHandler(this.menuSaveFile_Click);
            // 
            // menuSaveAsFile
            // 
            this.menuSaveAsFile.Name = "menuSaveAsFile";
            resources.ApplyResources(this.menuSaveAsFile, "menuSaveAsFile");
            this.menuSaveAsFile.Click += new System.EventHandler(this.menuSaveAsFile_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // menuOutputHtmlFile
            // 
            resources.ApplyResources(this.menuOutputHtmlFile, "menuOutputHtmlFile");
            this.menuOutputHtmlFile.Name = "menuOutputHtmlFile";
            this.menuOutputHtmlFile.Click += new System.EventHandler(this.menuOutputHtmlFile_Click);
            // 
            // menuOutputHtmlToClipboard
            // 
            resources.ApplyResources(this.menuOutputHtmlToClipboard, "menuOutputHtmlToClipboard");
            this.menuOutputHtmlToClipboard.Name = "menuOutputHtmlToClipboard";
            this.menuOutputHtmlToClipboard.Click += new System.EventHandler(this.menuOutputHtmlToClipboard_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            resources.ApplyResources(this.menuExit, "menuExit");
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUndo,
            this.menuRedo,
            this.toolStripMenuItem2,
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.toolStripMenuItem3,
            this.menuSelectAll,
            this.toolStripMenuItem10,
            this.menuSearch,
            this.menuReplace,
            this.menuSearchNext,
            this.menuSearchPrev});
            this.menuEdit.Name = "menuEdit";
            resources.ApplyResources(this.menuEdit, "menuEdit");
            // 
            // menuUndo
            // 
            resources.ApplyResources(this.menuUndo, "menuUndo");
            this.menuUndo.Name = "menuUndo";
            this.menuUndo.Click += new System.EventHandler(this.menuUndo_Click);
            // 
            // menuRedo
            // 
            this.menuRedo.Name = "menuRedo";
            resources.ApplyResources(this.menuRedo, "menuRedo");
            this.menuRedo.Click += new System.EventHandler(this.menuRedo_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // menuCut
            // 
            resources.ApplyResources(this.menuCut, "menuCut");
            this.menuCut.Name = "menuCut";
            this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
            // 
            // menuCopy
            // 
            resources.ApplyResources(this.menuCopy, "menuCopy");
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuPaste
            // 
            resources.ApplyResources(this.menuPaste, "menuPaste");
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Name = "menuSelectAll";
            resources.ApplyResources(this.menuSelectAll, "menuSelectAll");
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            // 
            // menuSearch
            // 
            this.menuSearch.Name = "menuSearch";
            resources.ApplyResources(this.menuSearch, "menuSearch");
            this.menuSearch.Click += new System.EventHandler(this.menuSearch_Click);
            // 
            // menuReplace
            // 
            this.menuReplace.Name = "menuReplace";
            resources.ApplyResources(this.menuReplace, "menuReplace");
            this.menuReplace.Click += new System.EventHandler(this.menuReplace_Click);
            // 
            // menuSearchNext
            // 
            this.menuSearchNext.Name = "menuSearchNext";
            resources.ApplyResources(this.menuSearchNext, "menuSearchNext");
            this.menuSearchNext.Click += new System.EventHandler(this.menuSearchNext_Click);
            // 
            // menuSearchPrev
            // 
            this.menuSearchPrev.Name = "menuSearchPrev";
            resources.ApplyResources(this.menuSearchPrev, "menuSearchPrev");
            this.menuSearchPrev.Click += new System.EventHandler(this.menuSearchPrev_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewAutoPreview,
            this.toolStripMenuItem8,
            this.menuViewPreview,
            this.menuViewVertical,
            this.menuViewToolBar,
            this.menuViewStatusBar});
            this.menuView.Name = "menuView";
            resources.ApplyResources(this.menuView, "menuView");
            // 
            // menuViewAutoPreview
            // 
            this.menuViewAutoPreview.Checked = true;
            this.menuViewAutoPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewAutoPreview.Name = "menuViewAutoPreview";
            resources.ApplyResources(this.menuViewAutoPreview, "menuViewAutoPreview");
            this.menuViewAutoPreview.Click += new System.EventHandler(this.menuViewAutoPreview_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            // 
            // menuViewPreview
            // 
            this.menuViewPreview.Checked = true;
            this.menuViewPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewPreview.Name = "menuViewPreview";
            resources.ApplyResources(this.menuViewPreview, "menuViewPreview");
            this.menuViewPreview.Click += new System.EventHandler(this.menuViewPreview_Click);
            // 
            // menuViewVertical
            // 
            this.menuViewVertical.Checked = true;
            this.menuViewVertical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewVertical.Name = "menuViewVertical";
            resources.ApplyResources(this.menuViewVertical, "menuViewVertical");
            this.menuViewVertical.Click += new System.EventHandler(this.menuViewVertical_Click);
            // 
            // menuViewToolBar
            // 
            this.menuViewToolBar.Checked = true;
            this.menuViewToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewToolBar.Name = "menuViewToolBar";
            resources.ApplyResources(this.menuViewToolBar, "menuViewToolBar");
            this.menuViewToolBar.Click += new System.EventHandler(this.menuViewToolBar_Click);
            // 
            // menuViewStatusBar
            // 
            this.menuViewStatusBar.Checked = true;
            this.menuViewStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewStatusBar.Name = "menuViewStatusBar";
            resources.ApplyResources(this.menuViewStatusBar, "menuViewStatusBar");
            this.menuViewStatusBar.Click += new System.EventHandler(this.menuViewStatusBar_Click);
            // 
            // menuTool
            // 
            this.menuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewRefresh,
            this.toolStripMenuItem6,
            this.menuFont,
            this.menuViewLanguage});
            this.menuTool.Name = "menuTool";
            resources.ApplyResources(this.menuTool, "menuTool");
            // 
            // menuViewRefresh
            // 
            resources.ApplyResources(this.menuViewRefresh, "menuViewRefresh");
            this.menuViewRefresh.Name = "menuViewRefresh";
            this.menuViewRefresh.Click += new System.EventHandler(this.menuViewRefresh_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // menuFont
            // 
            resources.ApplyResources(this.menuFont, "menuFont");
            this.menuFont.Name = "menuFont";
            this.menuFont.Click += new System.EventHandler(this.menuFont_Click);
            // 
            // menuViewLanguage
            // 
            this.menuViewLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewChinese,
            this.menuViewEnglish});
            this.menuViewLanguage.Name = "menuViewLanguage";
            resources.ApplyResources(this.menuViewLanguage, "menuViewLanguage");
            // 
            // menuViewChinese
            // 
            this.menuViewChinese.Checked = true;
            this.menuViewChinese.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewChinese.Name = "menuViewChinese";
            resources.ApplyResources(this.menuViewChinese, "menuViewChinese");
            this.menuViewChinese.Click += new System.EventHandler(this.menuViewChinese_Click);
            // 
            // menuViewEnglish
            // 
            this.menuViewEnglish.Name = "menuViewEnglish";
            resources.ApplyResources(this.menuViewEnglish, "menuViewEnglish");
            this.menuViewEnglish.Click += new System.EventHandler(this.menuViewEnglish_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            resources.ApplyResources(this.menuHelp, "menuHelp");
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            resources.ApplyResources(this.menuAbout, "menuAbout");
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewFile,
            this.toolStripButtonOpenFile,
            this.toolStripButtonSaveFile,
            this.toolStripSeparator2,
            this.toolStripButtonUndo,
            this.toolStripSeparator1,
            this.toolStripButtonCut,
            this.toolStripButtonCopy,
            this.toolStripButtonPaste,
            this.toolStripSeparator3,
            this.toolStripButtonFont,
            this.toolStripSeparator7,
            this.toolStripButtonRefresh,
            this.toolStripSeparator6,
            this.toolButtonOutput,
            this.toolStripButtonOutputHtmlToClipBoard,
            this.toolStripSeparator5,
            this.toolStripcbMarkdownParser});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonNewFile
            // 
            this.toolStripButtonNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonNewFile, "toolStripButtonNewFile");
            this.toolStripButtonNewFile.Name = "toolStripButtonNewFile";
            this.toolStripButtonNewFile.Click += new System.EventHandler(this.menuNewFile_Click);
            // 
            // toolStripButtonOpenFile
            // 
            this.toolStripButtonOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonOpenFile, "toolStripButtonOpenFile");
            this.toolStripButtonOpenFile.Name = "toolStripButtonOpenFile";
            this.toolStripButtonOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
            // 
            // toolStripButtonSaveFile
            // 
            this.toolStripButtonSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonSaveFile, "toolStripButtonSaveFile");
            this.toolStripButtonSaveFile.Name = "toolStripButtonSaveFile";
            this.toolStripButtonSaveFile.Click += new System.EventHandler(this.menuSaveFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonUndo, "toolStripButtonUndo");
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.menuUndo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButtonCut
            // 
            this.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonCut, "toolStripButtonCut");
            this.toolStripButtonCut.Name = "toolStripButtonCut";
            this.toolStripButtonCut.Click += new System.EventHandler(this.menuCut_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonCopy, "toolStripButtonCopy");
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // toolStripButtonPaste
            // 
            this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonPaste, "toolStripButtonPaste");
            this.toolStripButtonPaste.Name = "toolStripButtonPaste";
            this.toolStripButtonPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButtonFont
            // 
            this.toolStripButtonFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonFont, "toolStripButtonFont");
            this.toolStripButtonFont.Name = "toolStripButtonFont";
            this.toolStripButtonFont.Click += new System.EventHandler(this.menuFont_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonRefresh, "toolStripButtonRefresh");
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.menuViewRefresh_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // toolButtonOutput
            // 
            this.toolButtonOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolButtonOutput, "toolButtonOutput");
            this.toolButtonOutput.Name = "toolButtonOutput";
            this.toolButtonOutput.Click += new System.EventHandler(this.menuOutputHtmlFile_Click);
            // 
            // toolStripButtonOutputHtmlToClipBoard
            // 
            this.toolStripButtonOutputHtmlToClipBoard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonOutputHtmlToClipBoard, "toolStripButtonOutputHtmlToClipBoard");
            this.toolStripButtonOutputHtmlToClipBoard.Name = "toolStripButtonOutputHtmlToClipBoard";
            this.toolStripButtonOutputHtmlToClipBoard.Click += new System.EventHandler(this.menuOutputHtmlToClipboard_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripcbMarkdownParser
            // 
            this.toolStripcbMarkdownParser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripcbMarkdownParser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripcbMarkdownParser.DropDownWidth = 350;
            resources.ApplyResources(this.toolStripcbMarkdownParser, "toolStripcbMarkdownParser");
            this.toolStripcbMarkdownParser.Items.AddRange(new object[] {
            resources.GetString("toolStripcbMarkdownParser.Items"),
            resources.GetString("toolStripcbMarkdownParser.Items1"),
            resources.GetString("toolStripcbMarkdownParser.Items2"),
            resources.GetString("toolStripcbMarkdownParser.Items3"),
            resources.GetString("toolStripcbMarkdownParser.Items4"),
            resources.GetString("toolStripcbMarkdownParser.Items5"),
            resources.GetString("toolStripcbMarkdownParser.Items6")});
            this.toolStripcbMarkdownParser.Name = "toolStripcbMarkdownParser";
            this.toolStripcbMarkdownParser.SelectedIndexChanged += new System.EventHandler(this.toolStripcbMarkdownParser_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTextEncoding,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelFontInfo,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelCssFileName,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelHtmlEncoding});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabelTextEncoding
            // 
            this.toolStripStatusLabelTextEncoding.Name = "toolStripStatusLabelTextEncoding";
            this.toolStripStatusLabelTextEncoding.Padding = new System.Windows.Forms.Padding(0, 0, 32, 0);
            resources.ApplyResources(this.toolStripStatusLabelTextEncoding, "toolStripStatusLabelTextEncoding");
            // 
            // toolStripStatusLabel2
            // 
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabelFontInfo
            // 
            this.toolStripStatusLabelFontInfo.Name = "toolStripStatusLabelFontInfo";
            this.toolStripStatusLabelFontInfo.Padding = new System.Windows.Forms.Padding(0, 0, 32, 0);
            resources.ApplyResources(this.toolStripStatusLabelFontInfo, "toolStripStatusLabelFontInfo");
            this.toolStripStatusLabelFontInfo.Click += new System.EventHandler(this.menuFont_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabelCssFileName
            // 
            this.toolStripStatusLabelCssFileName.Name = "toolStripStatusLabelCssFileName";
            this.toolStripStatusLabelCssFileName.Padding = new System.Windows.Forms.Padding(0, 0, 32, 0);
            resources.ApplyResources(this.toolStripStatusLabelCssFileName, "toolStripStatusLabelCssFileName");
            this.toolStripStatusLabelCssFileName.Click += new System.EventHandler(this.toolStripStatusLabelCssFileName_Click);
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelHtmlEncoding
            // 
            this.toolStripStatusLabelHtmlEncoding.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripStatusLabelHtmlEncoding.Name = "toolStripStatusLabelHtmlEncoding";
            this.toolStripStatusLabelHtmlEncoding.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
            resources.ApplyResources(this.toolStripStatusLabelHtmlEncoding, "toolStripStatusLabelHtmlEncoding");
            this.toolStripStatusLabelHtmlEncoding.Click += new System.EventHandler(this.toolStripStatusLabelHtmlEncoding_Click);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // contextMenu1
            // 
            this.contextMenu1.Name = "contextMenu1";
            resources.ApplyResources(this.contextMenu1, "contextMenu1");
            this.contextMenu1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu1_ItemClicked);
            // 
            // bgWorker_Preview
            // 
            this.bgWorker_Preview.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_Preview_DoWork);
            this.bgWorker_Preview.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_Preview_ProgressChanged);
            this.bgWorker_Preview.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_Preview_RunWorkerCompleted);
            // 
            // tm_preview
            // 
            this.tm_preview.Tick += new System.EventHandler(this.tm_preview_Tick);
            // 
            // FormMdEditor
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMdEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMdEditor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMdEditor_FormClosed);
            this.Load += new System.EventHandler(this.frmMdEditor_Load);
            this.Shown += new System.EventHandler(this.frmMdEditor_Shown);
            this.ResizeBegin += new System.EventHandler(this.frmMdEditor_ResizeBegin);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpPreview.ResumeLayout(false);
            this.tpSource.ResumeLayout(false);
            this.tpSource.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPreview;
        private System.Windows.Forms.WebBrowser webPreview;
        private System.Windows.Forms.TabPage tpSource;
        private System.Windows.Forms.TextBox txtSource;
        private RichTextBoxEx txtMarkdown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewFile;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuHistoryFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuSaveFile;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAsFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuOutputHtmlFile;
        private System.Windows.Forms.ToolStripMenuItem menuOutputHtmlToClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuUndo;
        private System.Windows.Forms.ToolStripMenuItem menuRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem menuSearch;
        private System.Windows.Forms.ToolStripMenuItem menuReplace;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem menuViewToolBar;
        private System.Windows.Forms.ToolStripMenuItem menuViewStatusBar;
        private System.Windows.Forms.ToolStripMenuItem menuTool;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem menuFont;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveFile;
        private System.Windows.Forms.ToolStripButton toolButtonOutput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCut;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonFont;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutputHtmlToClipBoard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTextEncoding;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFontInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCssFileName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHtmlEncoding;
        private System.Windows.Forms.ToolStripMenuItem menuViewVertical;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenu1;
        private System.Windows.Forms.ToolStripMenuItem menuViewPreview;
        private System.ComponentModel.BackgroundWorker bgWorker_Preview;
        private System.Windows.Forms.ToolStripMenuItem menuViewAutoPreview;
        private System.Windows.Forms.Timer tm_preview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuSearchNext;
        private System.Windows.Forms.ToolStripMenuItem menuSearchPrev;
        private System.Windows.Forms.ToolStripMenuItem menuViewRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuViewLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuViewChinese;
        private System.Windows.Forms.ToolStripMenuItem menuViewEnglish;
        private System.Windows.Forms.ToolStripComboBox toolStripcbMarkdownParser;
        

    }
}

