using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary.Utility;
using WeddingLibrary.Logging.Files;

namespace WeddingLibrary.Functions
{
    public class Common
    {
        public static string GetVersionNumber()
        {
            string fileName = System.Web.HttpContext.Current == null ? string.Concat(AppDomain.CurrentDomain.BaseDirectory, "WeddingLibrary.dll") : System.Web.HttpContext.Current.Server.MapPath(@"~\Bin\WeddingLibrary.dll");
            System.Diagnostics.FileVersionInfo version_info =
                System.Diagnostics.FileVersionInfo.GetVersionInfo(fileName);
            string version = version_info.FileVersion;
            if (!string.IsNullOrEmpty(version) && version.Length == 7)
            {
                version = version.Substring(0, 5);
            }
            return version;
        }

        public static string DesEncrypt(string str)
        {
            try
            {
                return SecretHelper.DesEncrypt(str, Config.Original.EncrKey);
            }
            catch (Exception ex)
            {
                Log.Error(ex, new string[] { ex.Message, string.Format("str={0},Config.EncrKey={1}", str, Config.Original.EncrKey) });
                return str;
            }
        }

        public static string DesDecrypt(string str)
        {
            try
            {
                return SecretHelper.DesDecrypt(str, Config.Original.EncrKey);
            }
            catch (Exception ex)
            {
                Log.Error(ex, new string[] { ex.Message, string.Format("str={0},Config.EncrKey={1}", str, Config.Original.EncrKey) });
                return str;
            }
        }
    }
}
