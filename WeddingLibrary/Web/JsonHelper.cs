using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Web
{
    public class JsonHelper
    {
        #region Json Result

        public static string GetJsonReturnString(bool success, string message, string extraData)
        {
            message = CommonLibrary.WebObject.JavaScriptHelper.ReplaceSpecailChars(message.Replace("\r\n", "").Replace("'", "''").Replace("\n", ""), true);
            return string.Concat("{", string.Format("\"success\":{0},\"message\":\"{1}\"", success ? "true" : "false", message), string.IsNullOrEmpty(extraData) ? "" : string.Concat(",\"data\":\"", extraData, "\""), "}");
        }

        public static void JsonResult2(bool success, string message, string jsonData)
        {
            message = CommonLibrary.WebObject.JavaScriptHelper.ReplaceSpecailChars(message.Replace("\r\n", "").Replace("'", "''").Replace("\n", ""), true);
            System.Web.HttpContext.Current.Response.Write(string.Concat("{", string.Format("\"success\":{0},\"message\":\"{1}\"", success ? "true" : "false", message), string.Concat(",\"data\":", string.IsNullOrEmpty(jsonData) ? "null" : jsonData), "}"));
        }

        public static string GetJsonReturnString(bool success, string message)
        {
            return GetJsonReturnString(success, message, string.Empty);
        }

        public static void JsonSuccess()
        {
            System.Web.HttpContext.Current.Response.Write("{\"success\":true}");
        }

        public static void JsonResult(bool success, string message, string extraData)
        {
            System.Web.HttpContext.Current.Response.Write(GetJsonReturnString(success, message, extraData));
        }

        public static void JsonSuccess(string message)
        {
            System.Web.HttpContext.Current.Response.Write(GetJsonReturnString(true, message));
        }

        public static void JsonError(string message)
        {
            System.Web.HttpContext.Current.Response.Write(GetJsonReturnString(false, message));
        }

        #endregion
    }
}
