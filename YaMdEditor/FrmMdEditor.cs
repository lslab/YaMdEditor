using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using YaMdEditor.Properties;
using System.Collections;
using System.Web;

namespace YaMdEditor
{
    public partial class FormMdEditor : Form
    {

        Encoding _EditingFileEncoding = Encoding.UTF8;
        string _MarkDownTextFilePath = "";

        string _SelectedCssFilePath = "";
        string _cssContent = "";
        string _htmlHeader = "";
        string _htmlFooter = "</body>\n</html>";

        private bool _fNoTitle = true;
        private bool _fConstraintChange = true;

        private Point _preFormPos;
        private Size _preFormSize;

        private int _richEditBoxInternalHeight;

        private int _markdownParserIndex = 0;


        public FormMdEditor()
        {
            InitializeComponent();
        }


        private void frmMdEditor_Load(object sender, EventArgs e)
        {
            //ignore script errors in Webbrowser
            webPreview.ScriptErrorsSuppressed = true;

            var obj = AppSettings.Instance;


            this._markdownParserIndex = obj.MarkdownParserIndex;
            this.toolStripcbMarkdownParser.SelectedIndex = _markdownParserIndex;
            this.Location = obj.FormPos;
            this.Size = obj.FormSize;
            this.txtMarkdown.Width = obj.richEditWidth;

            // Ajust window position ( Set position into Desktop range )
            if (this.Left < 0 || this.Left > Screen.PrimaryScreen.Bounds.Width)
            {
                this.Left = 0;
            }
            if (this.Top < 0 || this.Top > Screen.PrimaryScreen.Bounds.Height)
            {
                this.Top = 0;
            }

            if (obj.FormState == 1)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (obj.FormState == 2)
            {

                this.WindowState = FormWindowState.Maximized;
            }

            //View main menu
            this.menuViewToolBar.Checked = obj.fViewToolBar;
            this.toolStrip1.Visible = obj.fViewToolBar;
            this.menuViewStatusBar.Checked = obj.fViewStatusBar;
            this.statusStrip1.Visible = obj.fViewStatusBar;


            this.menuViewAutoPreview.Checked = obj.fAutoBrowserPreview;

            if (obj.Lang == "zh")
            {
                menuViewChinese.Checked = true;
                menuViewEnglish.Checked = false;
            }
            else
            {
                menuViewChinese.Checked = false;
                menuViewEnglish.Checked = true;
            }

            //Interval time of browser preview

            if (obj.AutoBrowserPreviewInterval > 0)
            {
                this.tm_preview.Interval = obj.AutoBrowserPreviewInterval;
            }



            //-----------------------------------
            //RichEditBox font
            FontConverter fc = new FontConverter();
            try
            {
                txtMarkdown.Font = (Font)fc.ConvertFromString(obj.FontFormat);
            }
            catch { }
            //RichEditBox font color
            txtMarkdown.ForeColor = Color.FromArgb(obj.richEditForeColor);
            //View in statusbar
            toolStripStatusLabelFontInfo.Text =
                txtMarkdown.Font.Name + "," + txtMarkdown.Font.Size.ToString() + "pt";

            //-----------------------------------
            //View selected character encoding name
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                if (ei.GetEncoding().IsBrowserDisplay == true)
                {
                    if (ei.CodePage == obj.CodePageNumber)
                    {
                        toolStripStatusLabelHtmlEncoding.Text = ei.DisplayName;
                        break;
                    }
                }
            }

            //-----------------------------------
            //View selected CSS file name
            toolStripStatusLabelCssFileName.Text = Resources.toolTipCssFileName;

            if (obj.ArrayCssFileList.Count > 0)
            {
                string FilePath = (string)obj.ArrayCssFileList[0];
                if (File.Exists(FilePath) == true)
                {
                    toolStripStatusLabelCssFileName.Text = Path.GetFileName(FilePath);
                    _SelectedCssFilePath = FilePath;
                }
            }

            //-----------------------------------
            //View HTML charcter encoding name for output
            if (obj.HtmlEncodingOption == 0)
            {
                // View encoding name of editor window
                toolStripStatusLabelHtmlEncoding.Text = _EditingFileEncoding.EncodingName;
            }
            else
            {
                //Select encoding
                Encoding enc = Encoding.GetEncoding(obj.CodePageNumber);
                toolStripStatusLabelHtmlEncoding.Text = enc.EncodingName;
            }

            //-----------------------------------
            //Search form options
            //chkOptionCase.Checked = obj.fSearchOptionIgnoreCase ? false : true;

            _fConstraintChange = false;

        }



        private void txtMarkdown_TextChanged(object sender, EventArgs e)
        {
            if (_fConstraintChange == true)
            {
                return;
            }

            //-----------------------------------
            FormTextChange();

            //-----------------------------------
            if (this.menuViewAutoPreview.Checked == true && this.menuViewPreview.Checked == true)
            {
                tm_preview.Enabled = true;
            }
        }



        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile("", true);
        }

        private void menuSaveFile_Click(object sender, EventArgs e)
        {
            SaveToEditingFile(false);
        }



        private bool OpenFile(string FilePath, bool fOpenDialog = false)
        {
            if (FilePath == "")
            {
                _fNoTitle = true;  // No title flag
            }
            else
            {
                _fNoTitle = false;
            }

            if (txtMarkdown.Modified == true)
            {
                //"Question"
                //"This file being edited. Do you wish to save before opening file?"
                DialogResult ret = MessageBox.Show(Resources.MsgSaveFileToOpenFile,
                Resources.DialogTitleQuestion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    if (SaveToEditingFile() == false)
                    {
                        //Cancel
                        return false;
                    }
                }
                else if (ret == DialogResult.Cancel)
                {
                    return false;
                }

                //Save file path to editing history
                foreach (AppHistory data in AppSettings.Instance.ArrayHistoryEditedFiles)
                {
                    if (data.md == _MarkDownTextFilePath)
                    {
                        AppSettings.Instance.ArrayHistoryEditedFiles.Remove(data);
                        break;
                    }
                }
                AppHistory HistroyData = new AppHistory();
                HistroyData.md = _MarkDownTextFilePath;
                HistroyData.css = _SelectedCssFilePath;
                AppSettings.Instance.ArrayHistoryEditedFiles.Insert(0, HistroyData);
            }

            //-----------------------------------
            //View open file dialog
            if (fOpenDialog == true)
            {
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FilePath = openFileDialog1.FileName;
                    _fNoTitle = false;
                }
                else
                {
                    return false;
                }
            }

            //Set this file to 'editing file' path
            _MarkDownTextFilePath = FilePath;

            //-----------------------------------
            //Detect encoding
            if (_fNoTitle == false)
            {
                _EditingFileEncoding = TextFileEncodingDetector.GetEncoding(FilePath);

            }
            else
            {
                // Set this file to default encoding in 'No title'
                _EditingFileEncoding = Encoding.UTF8;
            }

            //View in statusbar
            toolStripStatusLabelTextEncoding.Text = _EditingFileEncoding.EncodingName;
            //Use encoding of editing file
            if (AppSettings.Instance.HtmlEncodingOption == 0)
            {
                toolStripStatusLabelHtmlEncoding.Text = _EditingFileEncoding.EncodingName;
            }

            //-----------------------------------
            //Apply that the pair CSS file to this file exists  
            foreach (AppHistory data in AppSettings.Instance.ArrayHistoryEditedFiles)
            {
                if (data.md == _MarkDownTextFilePath)
                {
                    if (File.Exists(data.css) == true)
                    {
                        _SelectedCssFilePath = data.css;
                        break;
                    }
                }
            }

            //View selected CSS file name to stausbar
            if (File.Exists(_SelectedCssFilePath) == true)
            {
                toolStripStatusLabelCssFileName.Text = Path.GetFileName(_SelectedCssFilePath);
            }
            else
            {
                toolStripStatusLabelCssFileName.Text = Resources.toolTipCssFileName;
            }

            _fConstraintChange = true;
            txtMarkdown.Clear();


            // richTextBox1 font name setting
            var obj = AppSettings.Instance;
            FontConverter fc = new FontConverter();
            try
            {
                txtMarkdown.Font = (Font)fc.ConvertFromString(obj.FontFormat);
            }
            catch { }
            // richTextBox1 font color setting
            txtMarkdown.ForeColor = Color.FromArgb(obj.richEditForeColor);
            //View them in statusbar
            toolStripStatusLabelFontInfo.Text = txtMarkdown.Font.Name + "," + txtMarkdown.Font.Size.ToString() + "pt";

            //-----------------------------------
            //Read text file
            if (File.Exists(FilePath) == true)
            {
                txtMarkdown.Text = File.ReadAllText(FilePath, _EditingFileEncoding);
            }

            txtMarkdown.BeginUpdate();
            txtMarkdown.SelectionStart = txtMarkdown.Text.Length;
            txtMarkdown.ScrollToCaret();

            //Get height of richTextBox1 ( for webBrowser sync )
            _richEditBoxInternalHeight = txtMarkdown.VerticalPosition;
            //Restore cursor position
            txtMarkdown.SelectionStart = 0;
            txtMarkdown.EndUpdate();

            txtMarkdown.Modified = false;

            _fConstraintChange = false;
            PreviewToBrowser();

            FormTextChange();
            return true;

        }



        private void PreviewToBrowser()
        {
            //Do not preview in constraint to change
            if (_fConstraintChange == true)
            {
                return;
            }
            if (bgWorker_Preview.IsBusy == true)
            {
                return;
            }

            if (txtMarkdown.Text == "")
                return;

            string ResultText = "";
            bgWorker_Preview.WorkerReportsProgress = true;

            ResultText = txtMarkdown.Text;

            bgWorker_Preview.RunWorkerAsync(ResultText);

        }


        private void FormTextChange()
        {
            string FileName;
            if (_fNoTitle == true)
            {
                FileName = Resources.NoFileName;
            }
            else
            {
                //FileName = System.IO.Path.GetFileName(_MarkDownTextFilePath);
                FileName = _MarkDownTextFilePath;
            }

            if (txtMarkdown.Modified == true)
            {
                FileName = FileName + Resources.FlagChanged;
            }
            this.Text = FileName + " - " + Application.ProductName;
        }


        private bool SaveToEditingFile(bool fSaveAs = false)
        {
            if (_fNoTitle == true || fSaveAs == true)
            {
                saveFileDialog1.Filter = "Markdown(*.md)|*.md|Markdown(*.markdown)|*.markdown|Text file(*.txt)|*.txt|All files(*.*)|*.*";
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, _EditingFileEncoding))
                    {
                        sw.Write(txtMarkdown.Text);
                        _MarkDownTextFilePath = saveFileDialog1.FileName;

                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(
                    _MarkDownTextFilePath,
                    false,
                    _EditingFileEncoding))
                {
                    sw.Write(txtMarkdown.Text);
                }

            }

            _fNoTitle = false;
            txtMarkdown.Modified = false;
            FormTextChange();
            return true;
        }


        private void menuViewRefresh_Click(object sender, EventArgs e)
        {
            if (menuViewPreview.Checked == true)
            {
                PreviewToBrowser();
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewToBrowser();

        }

        private void menuFont_Click(object sender, EventArgs e)
        {
            bool fModify = txtMarkdown.Modified;
            fontDialog1.Font = txtMarkdown.Font;
            fontDialog1.Color = txtMarkdown.ForeColor;

            fontDialog1.MinSize = 6;
            fontDialog1.MaxSize = 72;
            fontDialog1.FontMustExist = true;

            fontDialog1.AllowVerticalFonts = false;

            fontDialog1.ShowColor = true;

            fontDialog1.ShowEffects = false;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {

                this.txtMarkdown.TextChanged -= new System.EventHandler(this.txtMarkdown_TextChanged);
                txtMarkdown.Font = fontDialog1.Font;
                txtMarkdown.ForeColor = fontDialog1.Color;

                toolStripStatusLabelFontInfo.Text =
                    fontDialog1.Font.Name + "," + fontDialog1.Font.Size.ToString() + "pt";
                this.txtMarkdown.TextChanged += new System.EventHandler(this.txtMarkdown_TextChanged);
            }

            txtMarkdown.Modified = fModify;
        }

        private void toolStripStatusLabelCssFileName_Click(object sender, EventArgs e)
        {

            //Regist item to popup menus
            contextMenu1.Items.Clear();

            foreach (string FilePath in AppSettings.Instance.ArrayCssFileList)
            {
                if (File.Exists(FilePath) == true)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(Path.GetFileName(FilePath));
                    item.Tag = FilePath;
                    if (_SelectedCssFilePath == FilePath)
                    {
                        item.Checked = true;
                    }
                    contextMenu1.Items.Add(item);
                }
            }
            if (contextMenu1.Items.Count > 0)
            {
                contextMenu1.Tag = "css";
                contextMenu1.Show(Control.MousePosition);
            }
        }

        private void contextMenu1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //-----------------------------------
            // Change selected CSS file
            //-----------------------------------
            if ((string)contextMenu1.Tag == "css")
            {
                _SelectedCssFilePath = (string)e.ClickedItem.Tag;
                toolStripStatusLabelCssFileName.Text = Path.GetFileName(_SelectedCssFilePath);
                _cssContent = "";
                _htmlHeader = "";
                PreviewToBrowser();

            }
            //-----------------------------------
            // Change encoding to output HTML file
            //-----------------------------------
            else if ((string)contextMenu1.Tag == "encoding")
            {
                AppSettings.Instance.CodePageNumber = (int)e.ClickedItem.Tag;
                //Refresh previewing, too
                toolStripStatusLabelHtmlEncoding.Text = e.ClickedItem.Text;
                PreviewToBrowser();
            }
        }

        private void toolStripStatusLabelHtmlEncoding_Click(object sender, EventArgs e)
        {
            //Regist item to popup menus
            contextMenu1.Items.Clear();
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                if (ei.GetEncoding().IsBrowserDisplay == true)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(ei.DisplayName);
                    item.Tag = ei.CodePage;
                    if (ei.CodePage == AppSettings.Instance.CodePageNumber)
                    {
                        item.Checked = true;
                    }
                    contextMenu1.Items.Add(item);
                }
            }
            contextMenu1.Tag = "encoding";
            contextMenu1.Show(Control.MousePosition);
        }


        private void menuViewPreview_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                menuViewPreview.Checked = true;
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                menuViewPreview.Checked = false;
                splitContainer1.Panel2Collapsed = true;
                menuViewAutoPreview.Checked = false;
                AppSettings.Instance.fAutoBrowserPreview = false;
            }
        }

        private void menuViewToolBar_Click(object sender, EventArgs e)
        {
            if (toolStrip1.Visible == false)
            {
                menuViewToolBar.Checked = true;
                toolStrip1.Visible = true;
            }
            else
            {
                menuViewToolBar.Checked = false;
                toolStrip1.Visible = false;
            }
        }

        private void menuViewStatusBar_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == false)
            {
                menuViewStatusBar.Checked = true;
                statusStrip1.Visible = true;
            }
            else
            {
                menuViewStatusBar.Checked = false;
                statusStrip1.Visible = false;

            }

        }


        private void menuViewVertical_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Orientation == Orientation.Vertical)
            {
                menuViewVertical.Checked = false;
                splitContainer1.Orientation = Orientation.Horizontal;
                splitContainer1.SplitterDistance = splitContainer1.Size.Height / 2;
            }
            else
            {
                menuViewVertical.Checked = true;
                splitContainer1.Orientation = Orientation.Vertical;
                splitContainer1.SplitterDistance = splitContainer1.Size.Width / 2;
            }
        }

        private void menuSaveAsFile_Click(object sender, EventArgs e)
        {
            SaveToEditingFile(true);
        }



        //----------------------------------------------------------------------
        // BackgroundWorker ProgressChanged
        //----------------------------------------------------------------------
        private void bgWorker_Preview_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        //----------------------------------------------------------------------
        // BackgroundWorker browser preview
        //----------------------------------------------------------------------
        private void bgWorker_Preview_DoWork(object sender, DoWorkEventArgs e)
        {
            string ResultText = (string)e.Argument;
            string MkResultText = "";

            string BackgroundColorString;
            string EncodingName;

            //Editing file name
            string FileName = (_MarkDownTextFilePath == "" ? "" : Path.GetFileName(_MarkDownTextFilePath));
            //DOCTYPE
            HtmlHeader htmlHeader = new HtmlHeader();
            string DocType = htmlHeader.GetHtmlHeader(AppSettings.Instance.HtmlDocType);

            //Marker's color
            if (AppSettings.Instance.fHtmlHighLightColor == true)
            {
                Color ColorBackground = Color.FromArgb(AppSettings.Instance.HtmlHighLightColor);
                BackgroundColorString = ColorTranslator.ToHtml(ColorBackground);
            }
            else
            {
                BackgroundColorString = "none";
            }

            //Codepage
            int CodePageNum = AppSettings.Instance.CodePageNumber;
            try
            {
                Encoding enc = Encoding.GetEncoding(CodePageNum);
                //Is the encoding supported browser?
                if (enc.IsBrowserDisplay == true)
                {
                    EncodingName = enc.WebName;
                }
                else
                {
                    EncodingName = "UTF-8";
                }
            }
            catch
            {
                //Default encoding if failing to get encoding
                EncodingName = "UTF-8";
            }
            if (_cssContent == "")
            {
                if (File.Exists(_SelectedCssFilePath))
                {
                    using (StreamReader reader = new StreamReader(_SelectedCssFilePath, Encoding.UTF8))
                    {
                        _cssContent = reader.ReadToEnd();
                    }
                }
            }
            //Header
            if (_htmlHeader == "")
            {
                _htmlHeader = string.Format(
    @"{0}
<html>
<head>
<meta http-equiv='Content-Type' content='text/html; charset={1}' />
<style type='text/css'>
        {2}
	 ._mk {{background-color:{3}}}
</style>
<title>{4}</title>
</head>
<body>
",
                DocType,               //DOCTYPE
                EncodingName,          //( encoding )
                _cssContent,           //_SelectedCssFilePath,  
                BackgroundColorString, //background color in Editing )
                FileName);             // ( title = file name )
            }

            //-----------------------------------
            // MarkdownDeep
            // Create an instance of Markdown
            //-----------------------------------

            if (_markdownParserIndex == 0)  //SundownNet - Github Flovored Markdown With TOC
            {
                var mode = new Sundown.HtmlRenderMode();
                mode.TOC = true;
                mode.HardWrap = true;

                var render = new Sundown.HtmlRenderer(mode);
                var toc = new Sundown.TableOfContentRenderer();

                var extension = new Sundown.MarkdownExtensions();
                extension.Autolink = true;
                extension.FencedCode = true;
                extension.Tables = true;
                extension.Strikethrough = true;
                extension.NoIntraEmphasis = true;
                extension.SuperScript = true;

                var mdtoc = new Sundown.Markdown(toc);
                var md = new Sundown.Markdown(render, extension);

                ResultText = mdtoc.Transform(ResultText) + md.Transform(ResultText);
            }
            else if (_markdownParserIndex == 1)  //SundownNet - Github Flovored Markdown
            {
                var mode = new Sundown.HtmlRenderMode();
                mode.HardWrap = true;

                var render = new Sundown.HtmlRenderer(mode);
                
                var extension = new Sundown.MarkdownExtensions();
                extension.Autolink = true;
                extension.FencedCode = true;
                extension.Tables = true;
                extension.Strikethrough = true;
                extension.NoIntraEmphasis = true;
                extension.SuperScript = true;

                var md = new Sundown.Markdown(render, extension);

                ResultText = md.Transform(ResultText);
            }
            else if (_markdownParserIndex == 2)  //SundownNet - Standard
            {
                var render = new Sundown.HtmlRenderer();
                var md = new Sundown.Markdown(render);

                ResultText = md.Transform(ResultText);
            }
            else if (_markdownParserIndex == 3)  //MarkdownSharp - StackOverFlow Style 
            {
                var md = new MarkdownSharp.Markdown();
                md.AutoNewLines = true;
                md.AutoHyperlink = true;
                md.LinkEmails = true;
                md.StrictBoldItalic = true;
                ResultText = md.Transform(ResultText);

            }
            else if (_markdownParserIndex == 4)   //MarkdownSharp - Standard
            {
                var md = new MarkdownSharp.Markdown();
                ResultText = md.Transform(ResultText);
            }
            else if (_markdownParserIndex == 5) //MarkdownDeep - Markdown Extra
            {
                var md = new MarkdownDeep.Markdown();

                md.ExtraMode = true;
                md.SafeMode = false;

                ResultText = md.Transform(ResultText);

            }
            else
            {
                var md = new MarkdownDeep.Markdown();
                var text = md.SectionHeader;
                md.ExtraMode = false;
                md.SafeMode = true;
                ResultText = md.Transform(ResultText);
            }

            //Creat HTML data
            ResultText = _htmlHeader + ResultText + _htmlFooter;

            //Search editing line in parsed data
            string OneLine;
            StringReader sr = new StringReader(ResultText);
            StringWriter sw = new StringWriter();
            while ((OneLine = sr.ReadLine()) != null)
            {
                if (OneLine.IndexOf("<!-- edit -->") >= 0)
                {
                    MkResultText += ("<div class='_mk'>" + OneLine + "</div>\n");
                }
                else
                {
                    MkResultText += (OneLine + "\n");
                }
            }

            //Encode and convert it to 'byte' value ( richEditBox default encoding is utf-8 = 65001 )
            byte[] bytesData = Encoding.GetEncoding(CodePageNum).GetBytes(MkResultText);

            //-----------------------------------
            // Navigate and view in browser
            {
                //Write data as it is, if the editing data is no title  
                ResultText = Encoding.GetEncoding(CodePageNum).GetString(bytesData).Replace("\n", "\r\n");
                e.Result = ResultText;
            }

        }

        private void bgWorker_Preview_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //Error!
            }
            else if (e.Cancelled)
            {
                //"Canceled";
            }
            else
            {
                if ((string)e.Result != "")
                {
                    this.txtSource.Text = (string)e.Result;
                    this.webPreview.DocumentText = (string)e.Result;

                }

                while (webPreview.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                WebBrowserMoveCursor();
            }
        }

        private void menuNewFile_Click(object sender, EventArgs e)
        {
            if (txtMarkdown.Modified == true)
            {
                //"Question"
                //"This file being edited. Do you wish to save before starting new file?"
                DialogResult ret = MessageBox.Show(Resources.MsgSaveFileToNewFile,
                Resources.DialogTitleQuestion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (ret == DialogResult.Yes)
                {
                    if (SaveToEditingFile() == true)
                    {
                        _fNoTitle = false;
                    }
                    else
                    {
                        //Cancel
                        return;
                    }
                }
                else if (ret == DialogResult.Cancel)
                {
                    return;
                }
            }

            //Add editing history
            if (File.Exists(_MarkDownTextFilePath) == true)
            {
                foreach (AppHistory data in AppSettings.Instance.ArrayHistoryEditedFiles)
                {
                    if (data.md == _MarkDownTextFilePath)
                    {
                        AppSettings.Instance.ArrayHistoryEditedFiles.Remove(data);
                        break;
                    }
                }
                AppHistory HistroyData = new AppHistory();
                HistroyData.md = _MarkDownTextFilePath;
                HistroyData.css = _SelectedCssFilePath;
                AppSettings.Instance.ArrayHistoryEditedFiles.Insert(0, HistroyData);
            }

            _fConstraintChange = true;

            //Clear the infomation of editing file
            _MarkDownTextFilePath = "";
            //Start to edit in no title
            _fNoTitle = true;
            txtMarkdown.Text = "";
            txtMarkdown.Modified = false;
            PreviewToBrowser();
            FormTextChange();
            _fConstraintChange = false;
        }

        //-----------------------------------
        // "File" menu
        //-----------------------------------
        private void menuFile_Click(object sender, EventArgs e)
        {
            menuHistoryFiles.DropDownItems.Clear();
            //Create submenu of editing history
            for (int i = 0; i < AppSettings.Instance.ArrayHistoryEditedFiles.Count; i++)
            {
                AppHistory History = AppSettings.Instance.ArrayHistoryEditedFiles[i];
                ToolStripMenuItem m = new ToolStripMenuItem(History.md);
                m.Tag = History.css;
                m.Click += new EventHandler(HistorySubMenuItemClickHandler);
                menuHistoryFiles.DropDownItems.Add(m);
            }

        }
        //-----------------------------------
        //Click editing history menu event
        private void HistorySubMenuItemClickHandler(object sender, EventArgs e)
        {

            ToolStripMenuItem clickItem = (ToolStripMenuItem)sender;

            string FilePath = clickItem.Text;

            if (File.Exists(FilePath) == true)
            {
                OpenFile(FilePath);
            }
        }

        private void frmMdEditor_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmMdEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtMarkdown.Modified == true)
            {
                //"Question"
                //"This file being edited. Do you wish to save before exiting?"
                DialogResult ret = MessageBox.Show(Resources.MsgSaveFileToEnd,
                Resources.DialogTitleQuestion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (ret == DialogResult.Yes)
                {
                    if (SaveToEditingFile() == true)
                    {
                        _fNoTitle = false;
                    }
                    else
                    {
                        //user cancel
                        e.Cancel = true;
                        return;
                    }
                }
                else if (ret == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            _fConstraintChange = true;

            //Data version
            System.Reflection.Assembly asmbly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Version ver = asmbly.GetName().Version;
            AppSettings.Instance.Version = ver.Major * 1000 + ver.Minor * 100 + ver.Build * 10 + ver.Revision;

            //( Form position & size )
            if (this.WindowState == FormWindowState.Minimized)
            {
                AppSettings.Instance.FormState = 1;
                //( Save temporary position & size value )
                AppSettings.Instance.FormPos = new Point(_preFormPos.X, _preFormPos.Y);
                AppSettings.Instance.FormSize = new Size(_preFormSize.Width, _preFormSize.Height);
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                AppSettings.Instance.FormState = 2;
                //( Save temporary position & size value )
                AppSettings.Instance.FormPos = new Point(_preFormPos.X, _preFormPos.Y);
                AppSettings.Instance.FormSize = new Size(_preFormSize.Width, _preFormSize.Height);
            }
            else
            {
                AppSettings.Instance.FormState = 0;
                AppSettings.Instance.FormPos = new Point(this.Left, this.Top);
                AppSettings.Instance.FormSize = new Size(this.Width, this.Height);
            }

            AppSettings.Instance.richEditWidth = this.txtMarkdown.Width;
            FontConverter fc = new FontConverter();
            AppSettings.Instance.FontFormat = fc.ConvertToString(txtMarkdown.Font);
            AppSettings.Instance.richEditForeColor = txtMarkdown.ForeColor.ToArgb();


            //Save view options etc
            AppSettings.Instance.fViewToolBar = this.menuViewToolBar.Checked;
            AppSettings.Instance.fViewStatusBar = this.menuViewStatusBar.Checked;

            AppSettings.Instance.fViewPreview = this.menuViewPreview.Checked;
            AppSettings.Instance.fViewVertical = this.menuViewVertical.Checked;
            AppSettings.Instance.fAutoBrowserPreview = this.menuViewAutoPreview.Checked;

            AppSettings.Instance.MarkdownParserIndex = this._markdownParserIndex;

            //Save search options
            //AppSettings.Instance.fSearchOptionIgnoreCase = chkOptionCase.Checked ? false : true;

            if (File.Exists(_MarkDownTextFilePath) == true)
            {
                //Save editing file path
                foreach (AppHistory data in AppSettings.Instance.ArrayHistoryEditedFiles)
                {
                    if (data.md == _MarkDownTextFilePath)
                    {
                        AppSettings.Instance.ArrayHistoryEditedFiles.Remove(data);
                        break;
                    }
                }
                AppHistory HistroyData = new AppHistory();
                HistroyData.md = _MarkDownTextFilePath;
                HistroyData.css = _SelectedCssFilePath;
                AppSettings.Instance.ArrayHistoryEditedFiles.Insert(0, HistroyData);
            }

            //Save settings
            AppSettings.Instance.SaveToXMLFile();

        }


        private void frmMdEditor_ResizeBegin(object sender, EventArgs e)
        {
            _preFormPos.X = this.Left;
            _preFormPos.Y = this.Top;
            _preFormSize.Width = this.Width;
            _preFormSize.Height = this.Height;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void menuViewChinese_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Resources.MsgRestartApplication,
                Resources.DialogTitleQuestion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppSettings.Instance.Lang = "zh";
                AppSettings.Instance.SaveToXMLFile();
                Application.Restart();
            }
            else if (result == DialogResult.No)
            {
                AppSettings.Instance.Lang = "zh";
                menuViewChinese.Checked = true;
                menuViewEnglish.Checked = false;
            }
            else
            {
                //Cancel
            }
        }

        private void menuViewEnglish_Click(object sender, EventArgs e)
        {
            //"Question"
            //"To change the setting of language, it is necessary to restart the application. 
            // Do you want to restart this application now?"
            DialogResult result = MessageBox.Show(Resources.MsgRestartApplication,
                Resources.DialogTitleQuestion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppSettings.Instance.Lang = "en";
                AppSettings.Instance.SaveToXMLFile();
                Application.Restart();
            }
            else if (result == DialogResult.No)
            {
                AppSettings.Instance.Lang = "en";
                AppSettings.Instance.SaveToXMLFile();
                menuViewChinese.Checked = false;
                menuViewEnglish.Checked = true;
            }
            else
            {
                //Cancel
            }

        }

        private void menuViewAutoPreview_Click(object sender, EventArgs e)
        {
            if (menuViewPreview.Checked == true)
            {
                if (menuViewAutoPreview.Checked == true)
                {
                    menuViewAutoPreview.Checked = false;
                    AppSettings.Instance.fAutoBrowserPreview = false;
                }
                else
                {

                    menuViewAutoPreview.Checked = true;
                    AppSettings.Instance.fAutoBrowserPreview = true;
                }
            }
            else
            {
                menuViewAutoPreview.Checked = false;
                AppSettings.Instance.fAutoBrowserPreview = false;
            }
        }

        private void txtMarkdown_VScroll(object sender, EventArgs e)
        {
            if (_fConstraintChange == false)
            {
                WebBrowserMoveCursor();
            }
        }

        //----------------------------------------------------------------------
        // TODO: WebBrowserMoveCursor [RichEditBox → WebBrowser scroll follow]
        //----------------------------------------------------------------------
        private void WebBrowserMoveCursor()
        {
            if (this.webPreview.Document == null)
            {
                return;
            }

            if (txtMarkdown.Focused == true)
            {
                //Calculate current position with internal height of richTextBox1
                int LineHeight = Math.Abs(txtMarkdown.GetPositionFromCharIndex(0).Y);
                float perHeight = (float)LineHeight / _richEditBoxInternalHeight;

                //float perHeight = (float)LineHeight / txtMarkdown.GetPositionFromCharIndex(0).Y;


                //Calculate scroll amount with the ratio
                int y = (int)(webPreview.Document.Body.ScrollRectangle.Height * perHeight);
                Point webScrollPos = new Point(0, y);
                //Follow to scroll browser component
                this.webPreview.Document.Window.ScrollTo(webScrollPos);
            }
        }

        public void OnScrollEventHandler(object sender, EventArgs e)
        {
            RichEditBoxMoveCursor();
        }


        //----------------------------------------------------------------------
        // HACK: RichEditBoxMoveCursor[ WebBrowser → RichEditBox scroll follow]
        //----------------------------------------------------------------------
        private void RichEditBoxMoveCursor()
        {
            //Position of scroll bar in browser component
            if (txtMarkdown.Focused == false && this.webPreview.Document != null)
            {
                float perHeight = (float)webPreview.Document.GetElementsByTagName("HTML")[0].ScrollTop / webPreview.Document.Body.ScrollRectangle.Height;
                int y = (int)(_richEditBoxInternalHeight * perHeight);
                txtMarkdown.VerticalPosition = y;
            }

        }

        private void webPreview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webPreview.Document.Window.AttachEventHandler("onscroll", OnScrollEventHandler);
        }

        private void tm_preview_Tick(object sender, EventArgs e)
        {
            PreviewToBrowser();
            tm_preview.Enabled = false;
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
            about.Dispose();
        }

        private void menuCut_Click(object sender, EventArgs e)
        {
            txtMarkdown.Cut();
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            if (txtMarkdown.Focused)
            {
                txtMarkdown.Copy();
            }
            else if (this.txtSource.Focused)
            {
                txtSource.Copy();
            }

        }

        //paste plain text without colours/fonts
        private void menuPaste_Click(object sender, EventArgs e)
        {
            txtMarkdown.Paste(DataFormats.GetFormat(DataFormats.Text));
        }

        private void menuRedo_Click(object sender, EventArgs e)
        {
            txtMarkdown.Redo();
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            txtMarkdown.Undo();
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            if (txtMarkdown.Focused)
            {
                txtMarkdown.SelectAll();
            }
            else if (this.txtSource.Focused)
            {
                txtSource.SelectAll();
            }

        }

        private void menuSearch_Click(object sender, EventArgs e)
        {

            int startIndex = 0;
            string searchText = "";
            if (txtMarkdown.SelectedText != "")
            {
                searchText = txtMarkdown.SelectedText;
                startIndex = txtMarkdown.SelectionStart;
            }


            string msgSearchInputBoxTitle = Resources.MsgSearchInputBoxTitle;
            string msgSearchInputBoxTip = Resources.MsgSearchInputBoxTip;


            if (InputBox.Show(msgSearchInputBoxTitle,
                msgSearchInputBoxTip, ref searchText) == DialogResult.OK)
            {
                int indexToText = txtMarkdown.Find(searchText, startIndex, RichTextBoxFinds.None);
                if (indexToText >= 0)
                {
                    int endIndex = searchText.Length;
                    txtMarkdown.Select(indexToText, endIndex);
                }
            }
        }

        private void menuReplace_Click(object sender, EventArgs e)
        {

        }

        private void menuSearchNext_Click(object sender, EventArgs e)
        {
            int startIndex = 0;
            string searchText = "";
            if (txtMarkdown.SelectedText != "")
            {
                searchText = txtMarkdown.SelectedText;
                startIndex = txtMarkdown.SelectionStart;
            }

            if (searchText != "")
            {
                int endIndex = searchText.Length;
                if (startIndex + endIndex < txtMarkdown.Text.Length)
                {
                    int indexToText = txtMarkdown.Find(searchText, startIndex + endIndex, RichTextBoxFinds.None);
                    if (indexToText >= 0)
                    {
                        txtMarkdown.Select(indexToText, endIndex);
                    }
                }
            }
        }

        private void menuSearchPrev_Click(object sender, EventArgs e)
        {
            int startIndex = 0;
            string searchText = "";
            if (txtMarkdown.SelectedText != "")
            {
                searchText = txtMarkdown.SelectedText;
                startIndex = txtMarkdown.SelectionStart;
            }

            if (searchText != "")
            {
                int endIndex = searchText.Length;

                int indexToText = txtMarkdown.Find(searchText, 0, startIndex, RichTextBoxFinds.Reverse);
                if (indexToText >= 0)
                {
                    txtMarkdown.Select(indexToText, endIndex);
                }
            }
        }

        private void frmMdEditor_Shown(object sender, EventArgs e)
        {
            string DirPath = AppSettings.GetAppDataLocalPath();

            ArrayList FileArray = new ArrayList();

            //Launch with arguments
            string[] cmds = System.Environment.GetCommandLineArgs();
            for (int i = 1; i < cmds.Count(); i++)
            {
                if (File.Exists(cmds[i]) == true)
                {
                    FileArray.Add(cmds[i]);
                }
            }

            try
            {
                if (FileArray.Count > 1)
                {
                    // "NO" button
                    bool fOpen = false;
                    foreach (string FilePath in FileArray)
                    {
                        //First file open in this window 
                        if (fOpen == false)
                        {
                            txtMarkdown.Modified = false;
                            OpenFile(FilePath);
                            fOpen = true;
                        }
                        else
                        {
                            //Other files open in new windows
                            System.Diagnostics.Process.Start(
                                Application.ExecutablePath, string.Format("{0}", FilePath));
                        }
                    }
                }
                else if (FileArray.Count == 1)
                {
                    txtMarkdown.Modified = false;
                    OpenFile((string)FileArray[0]);
                }
                else
                {
                    //Open it if there is editing file before
                    if (AppSettings.Instance.fOpenEditFileBefore == true)
                    {
                        if (AppSettings.Instance.ArrayHistoryEditedFiles.Count > 0)
                        {
                            AppHistory EditedFilePath = new AppHistory();
                            EditedFilePath = AppSettings.Instance.ArrayHistoryEditedFiles[0];
                            if (File.Exists(EditedFilePath.md) == true)
                            {
                                txtMarkdown.Modified = false;
                                OpenFile(EditedFilePath.md);
                                return;
                            }
                        }
                    }
                    if (_MarkDownTextFilePath == "")
                    {
                        // "No title" if no file exists
                        txtMarkdown.Modified = false;
                        OpenFile("");
                    }
                }
            }
            finally
            {
                _fConstraintChange = false;
                //SyntaxHighlighter
                txtMarkdown.Modified = false;
                //Refresh form caption
                FormTextChange();
            }
        }

        //----------------------------------------------------------------------
        // Output to HTML file
        //----------------------------------------------------------------------
        private bool OutputToHtmlFile(string FilePath, string SaveToFilePath, bool fToClipboard = false)
        {

            if (File.Exists(FilePath) == false)
            {
                return (false);
            }

            string ResultText = "";

            string HeaderString = "";
            string FooterString = "";

            string EncodingName;
            Encoding encRead = Encoding.UTF8;
            Encoding encHtml = Encoding.UTF8;

            //-----------------------------------
            //Editing file path or Drag & Dropped files
            string FileName = Path.GetFileName(FilePath);

            //-----------------------------------
            //DOCTYPE
            HtmlHeader htmlHeader = new HtmlHeader();
            string DocType = htmlHeader.GetHtmlHeader(AppSettings.Instance.HtmlDocType);

            //Codepage
            int CodePageNum = AppSettings.Instance.CodePageNumber;
            try
            {
                encHtml = Encoding.GetEncoding(CodePageNum);
                //Is the encoding supported browser?
                if (encHtml.IsBrowserDisplay == true)
                {
                    EncodingName = encHtml.WebName;
                }
                else
                {
                    EncodingName = "UTF-8";
                    encHtml = Encoding.UTF8;
                }
            }
            catch
            {
                //Default encoding if failing to get encoding
                EncodingName = "UTF-8";
                encHtml = Encoding.UTF8;
            }

            //Insert HTML Header
            if (AppSettings.Instance.fHtmlOutputHeader == true)
            {
                //Embeding CSS file contents
                string CssContents = "";

                if (File.Exists(_SelectedCssFilePath) == true)
                {
                    using (StreamReader sr = new StreamReader(_SelectedCssFilePath, encHtml))
                    {
                        CssContents = sr.ReadToEnd();
                    }
                }

                //ヘッダ ( Header )
                HeaderString = string.Format(
@"{0}
<html>
<head>
<meta http-equiv='Content-Type' content='text/html; charset={1}' />
<title>{2}</title>
<style>
<！--
{3}
-->
</style>
</head>
<body>
",
                    DocType,         //DOCTYPE
                    EncodingName,    //Encoding
                    FileName,        //Title = file name
                    CssContents);	 //Contents of CSS file
                //( Footer )
                FooterString = "</body>\n</html>";
            }
            else
            {
                HeaderString = "";
                FooterString = "";
            }

            //Editing file path
            if (_MarkDownTextFilePath == FilePath)
            {
                ResultText = txtMarkdown.Text;
            }
            else
            {
                encRead = TextFileEncodingDetector.GetEncoding(FilePath);
                if (File.Exists(FilePath) == true)
                {
                    ResultText = File.ReadAllText(FilePath, encRead);
                }                
            }


            if (_markdownParserIndex == 0)  //SundownNet - Github Flovored Markdown With TOC
            {
                var mode = new Sundown.HtmlRenderMode();
                mode.TOC = true;
                mode.HardWrap = true;

                var render = new Sundown.HtmlRenderer(mode);
                var toc = new Sundown.TableOfContentRenderer();

                var extension = new Sundown.MarkdownExtensions();
                extension.Autolink = true;
                extension.FencedCode = true;
                extension.Tables = true;
                extension.Strikethrough = true;
                extension.NoIntraEmphasis = true;
                extension.SuperScript = true;

                var mdtoc = new Sundown.Markdown(toc);
                var md = new Sundown.Markdown(render, extension);

                ResultText = mdtoc.Transform(ResultText) + md.Transform(ResultText);
            }
            else if (_markdownParserIndex == 1)  //SundownNet - Github Flovored Markdown
            {
                var mode = new Sundown.HtmlRenderMode();
                mode.HardWrap = true;

                var render = new Sundown.HtmlRenderer(mode);

                var extension = new Sundown.MarkdownExtensions();
                extension.Autolink = true;
                extension.FencedCode = true;
                extension.Tables = true;
                extension.Strikethrough = true;
                extension.NoIntraEmphasis = true;
                extension.SuperScript = true;

                var md = new Sundown.Markdown(render, extension);

                ResultText = md.Transform(ResultText);
            }
            else if (_markdownParserIndex == 2)  //SundownNet - Standard
            {
                var render = new Sundown.HtmlRenderer();
                var md = new Sundown.Markdown(render);

                ResultText = md.Transform(ResultText);
            }
            else if (_markdownParserIndex == 3)  //MarkdownSharp - StackOverFlow Style 
            {
                var md = new MarkdownSharp.Markdown();
                md.AutoNewLines = true;
                md.AutoHyperlink = true;
                md.LinkEmails = true;
                md.StrictBoldItalic = true;
                ResultText = md.Transform(ResultText);

            }
            else if (_markdownParserIndex == 4)   //MarkdownSharp - Standard
            {
                var md = new MarkdownSharp.Markdown();
                ResultText = md.Transform(ResultText);
            }
            else if (_markdownParserIndex == 5) //MarkdownDeep - Markdown Extra
            {
                var md = new MarkdownDeep.Markdown();

                md.ExtraMode = true;
                md.SafeMode = false;

                ResultText = md.Transform(ResultText);

            }
            else
            {
                var md = new MarkdownDeep.Markdown();
                var text = md.SectionHeader;
                md.ExtraMode = false;
                md.SafeMode = true;
                ResultText = md.Transform(ResultText);
            }

           
            //Header + Contents + Footer
            ResultText = HeaderString + ResultText + FooterString;
            //Ajust encoding to output HTML file
            ResultText = ConvertStringToEncoding(ResultText, Encoding.UTF8.CodePage, CodePageNum);

            if (fToClipboard == true)
            {
                //Set data to clipbord
                Clipboard.SetText(ResultText);
            }
            else
            {
                //Write file
                using (StreamWriter sw = new StreamWriter(SaveToFilePath, false, encHtml))
                {
                    sw.Write(ResultText);
                }
            }
            return (true);

        }

        //----------------------------------------------------------------------
        // Convert text data to user encoding characters
        //----------------------------------------------------------------------
        public string ConvertStringToEncoding(string source, int SrcCodePage, int DestCodePage)
        {
            Encoding srcEnc;
            Encoding destEnc;
            try
            {
                srcEnc = Encoding.GetEncoding(SrcCodePage);
                destEnc = Encoding.GetEncoding(DestCodePage);
            }
            catch
            {
                //Error: Codepage is incorrect
                return (source);
            }
            //Convert to byte values
            byte[] srcByte = srcEnc.GetBytes(source);
            byte[] destByte = Encoding.Convert(srcEnc, destEnc, srcByte);
            char[] destChars = new char[destEnc.GetCharCount(destByte, 0, destByte.Length)];
            destEnc.GetChars(destByte, 0, destByte.Length, destChars, 0);
            return new string(destChars);
        }

        private void menuOutputHtmlFile_Click(object sender, EventArgs e)
        {
            if (_MarkDownTextFilePath == "" || txtMarkdown.Text == "")
                return;
            string OutputFilePath;
            string DirPath = Path.GetDirectoryName(_MarkDownTextFilePath);

            if (File.Exists(_MarkDownTextFilePath) == true)
            {
                saveFileDialog1.InitialDirectory = DirPath;
            }

            //Show Save dialog
            if (AppSettings.Instance.fShowHtmlSaveDialog == true)
            {
                saveFileDialog1.Filter = "HTML file(*.html;*.htm)|*.html;*.htm;|All files(*.*)|*.*";
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    OutputToHtmlFile(_MarkDownTextFilePath, saveFileDialog1.FileName, false);
                }
            }
            else
            {
                //Save to editing folder in constrainting dialog
                OutputFilePath = Path.Combine(DirPath, Path.GetFileNameWithoutExtension(_MarkDownTextFilePath)) + ".html";

                if (File.Exists(OutputFilePath) == true)
                {
                    //"Question"
                    //"Same file exists.\nContinue to overwrite?"
                    DialogResult ret = MessageBox.Show(
                        Resources.MsgSameFileOverwrite + "\n" + OutputFilePath,
                        Resources.DialogTitleQuestion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (ret == DialogResult.Yes)
                    {
                        //Overwrite and output to HTML file
                        OutputToHtmlFile(_MarkDownTextFilePath, OutputFilePath, false);
                    }
                    else if (ret == DialogResult.No)
                    {
                        //It is no setting, but show save dialog 
                        saveFileDialog1.Filter = "HTML file(*.html;*.htm)|*.html;*.htm;|All files(*.*)|*.*";
                        saveFileDialog1.FileName = "";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            //Output to HTML file
                            OutputToHtmlFile(_MarkDownTextFilePath, saveFileDialog1.FileName, false);
                        }
                    }
                    else
                    {
                        //Cancel
                    }
                }
                else
                {
                    //Output to HTML file
                    OutputToHtmlFile(_MarkDownTextFilePath, OutputFilePath, false);
                }
            }
        }

        private void menuOutputHtmlToClipboard_Click(object sender, EventArgs e)
        {
            if (_MarkDownTextFilePath == "" || txtMarkdown.Text == "")
                return;
            //Output HTML source to clipboard
            OutputToHtmlFile(_MarkDownTextFilePath, "", true);

            //Show message to confirm when HTML source data is setting to clipboard
            if (AppSettings.Instance.fShowHtmlToClipboardMessage == true)
            {
                //"Information"
                //"This file has been output to the clipboard."
                MessageBox.Show(Resources.MsgOutputToClipboard,
                    Resources.DialogTitleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //paste plain text without colours/fonts
        //overiding richeditbox ctrl + v shortcut
        //Set the RichtTextBox.ShortcutsEnabled property to true and then handle the shortcuts yourself, using the KeyUp event.
        //use richeditbox paste method, don't use this method.
        private void txtMarkdown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                ((RichTextBox)sender).Paste(DataFormats.GetFormat("Text"));
                e.Handled = true;
            }
        }

        private void toolStripcbMarkdownParser_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._markdownParserIndex = toolStripcbMarkdownParser.SelectedIndex;
            this.PreviewToBrowser();
            this.txtMarkdown.Focus();
        }
    }
}
