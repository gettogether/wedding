using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary.Utility;

namespace WeddingLibrary
{
    public class Initialize
    {
        public static void SetInitialize()
        {
            SetAppSettings();
            string url = System.Web.HttpContext.Current == null ? string.Concat(AppDomain.CurrentDomain.BaseDirectory, Config.Original.LogConfig) : System.Web.HttpContext.Current.Server.MapPath(Config.Original.LogConfig);
            LogHelper.SetConfig(url);
        }
        public static void SetAppSettings()
        {
            Config.InitConfig();
        }
    }
}
