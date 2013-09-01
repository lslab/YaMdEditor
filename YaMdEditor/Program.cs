using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace YaMdEditor
{
    static class Program
    {

        //public static AppSettings Settings = new AppSettings();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppSettings.Instance.ReadFromXMLFile();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Check culture
            if (AppSettings.Instance.Lang == "zh")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh", false);
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("", false);
                AppSettings.Instance.Lang = "en";
            }
            Application.Run(new FormMdEditor());
        }
    }
}
