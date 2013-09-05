using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Threading;
using System.Globalization;

namespace YaMdEditor
{
    [Serializable()]
    [XmlInclude(typeof(AppHistory))]
    public class AppSettings
    {
        //-----------------------------------
        #region
        //-----------------------------------
        private int _Version;
        private int _FormState;
        private System.Drawing.Point _FormPos;
        private System.Drawing.Size _FormSize;
        private int _richEditWidth;
        private string _FontFormat;
        private int _richEditForeColor;
        private string _Lang;
        private bool _fSplitBarWidthEvenly;
        private bool _fViewToolBar;
        private bool _fViewStatusBar;

        private bool _fViewVertical;
        private bool _fViewPreview;


        private int _TabPageSelectedIndex;
        private int _MkColorTabPageSelectedIndex;
        private bool _fOpenEditFileBefore;
        [XmlArrayItem(typeof(AppHistory))]
        private List<AppHistory> _ArrayHistoryEditedFiles = new List<AppHistory>();
        private bool _fShowHtmlSaveDialog;
        private bool _fShowHtmlToClipboardMessage;
        private bool _fHtmlHighLightColor;
        private int _HtmlHighLightColor;
        private bool _fAutoBrowserPreview;
        private int _AutoBrowserPreviewInterval;
        private bool _fSearchOptionIgnoreCase;
        private bool _fMarkdownExtraMode;


        private List<string> _ArrayCssFileList = new List<string>();
        private bool _fHtmlOutputHeader;
        private string _HtmlDocType;
        private int _HtmlCssFileOption;
        private int _HtmlEncodingOption;
        private int _CodePageNumber;
        private int _HtmlDocTypeSelectedIndex;
        private bool _fViewAllEncoding;
        private string AppDataPath;

        private int _markdownParserIndex;
        

        #endregion

        //-----------------------------------
        #region
        //-----------------------------------
        public int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        public int FormState
        {
            get { return _FormState; }
            set { _FormState = value; }
        }
        public System.Drawing.Point FormPos
        {
            get { return _FormPos; }
            set { _FormPos = value; }
        }
        public System.Drawing.Size FormSize
        {
            get { return _FormSize; }
            set { _FormSize = value; }
        }
        public string FontFormat
        {
            get { return _FontFormat; }
            set { _FontFormat = value; }
        }
        public int richEditForeColor
        {
            get { return _richEditForeColor; }
            set { _richEditForeColor = value; }
        }
        public string Lang
        {
            get { return _Lang; }
            set { _Lang = value; }
        }
        public int richEditWidth
        {
            get { return _richEditWidth; }
            set { _richEditWidth = value; }
        }
        public bool fSplitBarWidthEvenly
        {
            get { return _fSplitBarWidthEvenly; }
            set { _fSplitBarWidthEvenly = value; }
        }
        public bool fViewToolBar
        {
            get { return _fViewToolBar; }
            set { _fViewToolBar = value; }
        }
        public bool fViewStatusBar
        {
            get { return _fViewStatusBar; }
            set { _fViewStatusBar = value; }
        }

        public bool fViewVertical
        {
            get { return _fViewVertical; }
            set { _fViewVertical = value; }
        }
        public bool fViewPreview
        {
            get { return _fViewPreview; }
            set { _fViewPreview = value; }
        }
        public int TabPageSelectedIndex
        {
            get { return _TabPageSelectedIndex; }
            set { _TabPageSelectedIndex = value; }
        }
        public int MkColorTabPageSelectedIndex
        {
            get { return _MkColorTabPageSelectedIndex; }
            set { _MkColorTabPageSelectedIndex = value; }
        }
        public bool fOpenEditFileBefore
        {
            get { return _fOpenEditFileBefore; }
            set { _fOpenEditFileBefore = value; }
        }
        public List<AppHistory> ArrayHistoryEditedFiles
        {
            get { return _ArrayHistoryEditedFiles; }
            set { _ArrayHistoryEditedFiles = value; }
        }
        public bool fShowHtmlSaveDialog
        {
            get { return _fShowHtmlSaveDialog; }
            set { _fShowHtmlSaveDialog = value; }
        }
        public bool fShowHtmlToClipboardMessage
        {
            get { return _fShowHtmlToClipboardMessage; }
            set { _fShowHtmlToClipboardMessage = value; }
        }
        public bool fHtmlHighLightColor
        {
            get { return _fHtmlHighLightColor; }
            set { _fHtmlHighLightColor = value; }
        }
        public int HtmlHighLightColor
        {
            get { return _HtmlHighLightColor; }
            set { _HtmlHighLightColor = value; }
        }
        public bool fAutoBrowserPreview
        {
            get { return _fAutoBrowserPreview; }
            set { _fAutoBrowserPreview = value; }
        }
        public int AutoBrowserPreviewInterval
        {
            get
            {
                if (_AutoBrowserPreviewInterval > 3600000 || _AutoBrowserPreviewInterval < -1)
                {
                    _AutoBrowserPreviewInterval = 1000;
                }
                return _AutoBrowserPreviewInterval;
            }
            set
            {
                
                if (value > 3600000)
                {
                    value = 3600000;
                }
                else if (value < -1)
                {
                    value = -1;
                }
                _AutoBrowserPreviewInterval = value;
            }
        }
        public bool fSearchOptionIgnoreCase
        {
            get { return _fSearchOptionIgnoreCase; }
            set { _fSearchOptionIgnoreCase = value; }
        }
        public bool fMarkdownExtraMode
        {
            get { return _fMarkdownExtraMode; }
            set { _fMarkdownExtraMode = value; }
        }
        
        [XmlIgnore]
        public List<string> ArrayCssFileList
        {
            get { return _ArrayCssFileList; }
            set { _ArrayCssFileList = value; }
        }

        //-----------------------------------
        public bool fHtmlOutputHeader
        {
            get { return _fHtmlOutputHeader; }
            set { _fHtmlOutputHeader = value; }
        }
        public string HtmlDocType
        {
            get { return _HtmlDocType; }
            set { _HtmlDocType = value; }
        }
        public int HtmlCssFileOption
        {
            get { return _HtmlCssFileOption; }
            set { _HtmlCssFileOption = value; }
        }
        public int HtmlEncodingOption
        {
            get { return _HtmlEncodingOption; }
            set { _HtmlEncodingOption = value; }
        }
        public int CodePageNumber
        {
            get { return _CodePageNumber; }
            set { _CodePageNumber = value; }
        }
        public int HtmlDocTypeSelectedIndex
        {
            get { return _HtmlDocTypeSelectedIndex; }
            set { _HtmlDocTypeSelectedIndex = value; }
        }
        public bool fViewAllEncoding
        {
            get { return _fViewAllEncoding; }
            set { _fViewAllEncoding = value; }
        }

        public int MarkdownParserIndex
        {
            get { return _markdownParserIndex; }
            set { _markdownParserIndex = value; }
        }

        #endregion
        //-----------------------------------

        //-----------------------------------
        //( Constructor )
        //-----------------------------------
        public AppSettings()
        {
           
            //Default window position ( in screen center )
            int defautPosX = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - 420;
            int defautPosY = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2 - 320;

            //AppData
            AppDataPath = GetAppDataLocalPath();

            string AppDirPath = Path.GetDirectoryName(Application.ExecutablePath);

            //Initial directory of CSS files
            string CssDirPath = Path.Combine(AppDirPath, "css");

            _Version = 0; 
            _FormState = 0;
            _FormPos.X = defautPosX;
            _FormPos.Y = defautPosY;
            _FormSize.Width = 840;
            _FormSize.Height = 640;

            _richEditWidth = 320;
            _FontFormat = "Courier New,9pt";
            _richEditForeColor = 0;

            // Check culture
            if (Thread.CurrentThread.CurrentCulture.Name.StartsWith("zh") == true)
            {
                _Lang = "zh";                      // Chinese
            }
            else
            {
                _Lang = "";                        // Culture lang ( default = "" )
            }

            _fSplitBarWidthEvenly = true;
            _fViewToolBar = true;
            _fViewStatusBar = true;

            _fViewVertical = true;
            _fViewPreview = true;


            _TabPageSelectedIndex = 0;
            _MkColorTabPageSelectedIndex = 0;
            _fOpenEditFileBefore = true;
            _ArrayHistoryEditedFiles.Clear();
            _fShowHtmlSaveDialog = true;
            _fShowHtmlToClipboardMessage = true;
            _fHtmlHighLightColor = true;
            _HtmlHighLightColor = Color.FromArgb(255, 255, 200).ToArgb();
            _fAutoBrowserPreview = true;
            _AutoBrowserPreviewInterval = 1000;

            _fSearchOptionIgnoreCase = true;

            _fMarkdownExtraMode = true;        //Markdown Extra Mode


            
            //List of buit-in CSS files
            _ArrayCssFileList.Clear();
            
            _fHtmlOutputHeader = true;
            _HtmlDocType = "strict";
            _HtmlCssFileOption = 0;
            _HtmlEncodingOption = 0;
            _CodePageNumber = 65001;             //utf-8
            _HtmlDocTypeSelectedIndex = 0;
            _fViewAllEncoding = false;

            _markdownParserIndex = 0;
            

        }

        // This instance itself is able to access this class .
        //----------------------------------------------------
        [NonSerialized()]
        private static AppSettings _instance;
        [System.Xml.Serialization.XmlIgnore]
        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppSettings();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        //-----------------------------------
        // Load from XML file of settings.
        //-----------------------------------
        public void ReadFromXMLFile()
        {
            string FilePath = Path.Combine(GetAppDataLocalPath(), "settings.config");

            if (System.IO.File.Exists(FilePath) == true)
            {
                object obj;

                try
                {
                    using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
                        obj = xs.Deserialize(fs);
                        Instance = (AppSettings)obj;
                        Instance.InitCssFileList();
                    }
                }
                catch
                {
                    //Fail to read
                    if (Thread.CurrentThread.CurrentCulture.Name.StartsWith("zh") == true)
                    {
                        MessageBox.Show("加载配置文件失败，启动默认配置。",
                        "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Failed to load the file of settings. Launch with default options.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    // Initialize history data
                    Instance.InitHistoryData();
                    
                    // Initialize list of CSS files 
                    Instance.InitCssFileList();
                }
            }
            else
            {
                Instance.InitHistoryData();
                Instance.InitCssFileList();
            }

        }

        //-----------------------------------
        // Write to XML file of settings.
        //-----------------------------------
        public void SaveToXMLFile()
        {
            string FilePath = Path.Combine(GetAppDataLocalPath(), "settings.config");

            OptimizeHistoryData();

            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
                    xs.Serialize(fs, Instance);
                }
            }
            catch
            {
                //Fail to write
                if (Thread.CurrentThread.CurrentCulture.Name.StartsWith("zh") == true)
                {
                    MessageBox.Show("写配置文件失败，未保存选项退出。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Failed writing the file of settings.\nExit without saving options.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

        }

        //-----------------------------------
        // Initialize history data
        //-----------------------------------
        private void InitHistoryData()
        {
            // Set default data when history data do no exists
            if (ArrayHistoryEditedFiles.Count > 0)
            {
                foreach (AppHistory data in ArrayHistoryEditedFiles)
                {
                    // Inspect first element because blank element is created when XML file is read. 
                    if (File.Exists(data.md) == true)
                    {
                        return;
                    }
                }
            }

            //Initial directory of CSS files.
            string CssDirPath = Path.Combine(AppDataPath, "css");

            ArrayHistoryEditedFiles.Clear();

        }

        //-----------------------------------
        // Initialize the list of CSS files. 
        //-----------------------------------
        private void InitCssFileList()
        {
            // Set default data when the list of CSS files do not exist.
            /*
            foreach (string data in ArrayCssFileList)
            {
                // Inspect first element because blank element is created when XML file is read. 
                if (File.Exists(data) == true)
                {
                    return;
                }
            }
            */

            //Initial directory of CSS files

            string AppDirPath = Path.GetDirectoryName(Application.ExecutablePath);

            string CssDirPath = Path.Combine(AppDirPath, "css");
            ArrayCssFileList.Clear();

            string[] files = System.IO.Directory.GetFiles(CssDirPath, "*.css");
            foreach (string file in files)
            {
                //System.IO.Path.GetFileName(file);
                ArrayCssFileList.Add(file);
            }
        }

        //-----------------------------------
        // Remove history data if there is a duplicate data.
        //-----------------------------------
        public void OptimizeHistoryData()
        {

            int ArrayHistoryFilesLimit = 20;

            for (int i = 0; i < ArrayHistoryEditedFiles.Count; i++)
            {
                AppHistory HistoryData = ArrayHistoryEditedFiles[i];

                for (int c = i + 1; c < ArrayHistoryEditedFiles.Count; c++)
                {
                    AppHistory item = ArrayHistoryEditedFiles[c];
                    if (HistoryData.md == item.md)
                    {
                        ArrayHistoryEditedFiles.RemoveAt(c);
                    }
                }
            }
            for (int i = ArrayHistoryEditedFiles.Count - 1; i > -1; --i)
            {
               if(!File.Exists((ArrayHistoryEditedFiles[i]).md))
               {
                   ArrayHistoryEditedFiles.RemoveAt(i);
               }
            }

            // Remove older data when limit of history data is over.
            if (ArrayHistoryEditedFiles.Count > ArrayHistoryFilesLimit)
            {
                ArrayHistoryEditedFiles.RemoveRange(
                ArrayHistoryFilesLimit, ArrayHistoryEditedFiles.Count - ArrayHistoryFilesLimit - 1);
            }
        }

        //--------------------------------------------
        // AppData/Local/mdOpenEditor directory
        //--------------------------------------------
        public static string GetAppDataLocalPath()
        {
            string DirPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DirPath = Path.Combine(DirPath, "YdMdEditor");

            if (Directory.Exists(DirPath) == false)
            {
                Directory.CreateDirectory(DirPath);
            }
            return (DirPath);
        }

    }

}
