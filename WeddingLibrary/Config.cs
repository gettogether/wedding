using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary.Utility;

namespace WeddingLibrary
{
    public class Config
    {
        public class ConnectionKeys
        {
            public static string Wedding = "Wedding";
        }
        public static string Version;

        public static OriginalSettings Original = new OriginalSettings();

        public static CommonLibrary.Enums.SystemMode Mode = CommonLibrary.Enums.SystemMode.DEV;

        public static string[] RecipientEmails;

        #region Function

        public static void InitConfig()
        {
            Config.Mode = (CommonLibrary.Enums.SystemMode)NumberHelper.ToInt(ConfigHelper.GetAppSetting("Mode"), -1);
            Original.ReadSetting();
            Original.InitSetting();
        }

        public static string GetFilesVersion()
        {
            if (!Original.IsDebugMode) return Original.FilesVersion;

            return Original.FilesVersion;
        }
        #endregion
    }
}