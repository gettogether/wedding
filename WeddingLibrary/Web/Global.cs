using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using CommonLibrary.Utility;

namespace WeddingLibrary.Web
{
    public class Global : CommonLibrary.WebObject.TemplateGlobal
    {
        public static int EnableSimultaneousLogin;
        public static string AdholidaysUrl;
        public Global()
        {

        }
        protected void Application_Start(Object sender, EventArgs e)
        {
            EnableSimultaneousLogin = ConfigHelper.GetIntergerSetting("EnableSimultaneousLogin");
            AdholidaysUrl = ConfigHelper.GetAppSetting("AdholidaysUrl");
            WeddingLibrary.Initialize.SetInitialize();
            DataAccess.Log.InitLogging(string.Concat(Server.MapPath("~/."), "/DA.config"));
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Server != null)
            {
                Exception ex = System.Web.HttpContext.Current.Server.GetLastError();
                if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
                {
                    WeddingLibrary.Logging.Files.Log.Warning(ex.Message);
                    return;
                }
                WeddingLibrary.Logging.Files.Log.Error(ex);
            }
        }

        public void Session_OnStart(object sender, EventArgs e)
        {
            if (Session["culture_string"] == null) Session["culture_string"] = "en-us";
        }

        public void Session_End(object sender, EventArgs e)
        {
            //if (EnableSimultaneousLogin > 0)
            CommonLibrary.WebObject.SimultaneousLogin.ValidateOnSessionEnd(Application, Session);
        }

        //public void Application_OnStart(object sender, EventArgs e)
        //{
        //    string str = string.Format(eventStr, sender.ToString(), "Application_OnStart");
        //    Application["Event"] = str;
        //}
        //public void Application_BeginRequest(object sender, EventArgs e)
        //{

        //}
        //public void Application_AuthenticateRequest(object sender, EventArgs e)
        //{

        //}
        //public void Application_PostAuthenticateRequest(object sender, EventArgs e)
        //{

        //}
        //public void Application_AuthorizeRequest(object sender, EventArgs e)
        //{

        //}
        //public void Application_ResolveRequestCache(object sender, EventArgs e)
        //{

        //}
        //public void Application_PostResolveRequestCache(object sender, EventArgs e)
        //{

        //}

        //public void Application_AcquireRequestState(object sender, EventArgs e)
        //{

        //}
        //public void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        //{

        //}
        //public void Application_ReleaseRequestState(object sender, EventArgs e)
        //{

        //}
        //public void Application_PostReleaseRequestState(object sender, EventArgs e)
        //{

        //}
        //public void Application_UpdateRequestCache(object sender, EventArgs e)
        //{

        //}
        //public void Application_EndRequest(object sender, EventArgs e)
        //{

        //}
        //public void Application_PreSendRequestHeaders(object sender, EventArgs e)
        //{

        //}
        //public void Application_PreSendRequestContent(object sender, EventArgs e)
        //{

        //}
        //public void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        //{

        //}
    }
    //public class AsynchronousInit
    //{
    //    public void Start()
    //    {

    //    }
    //}
}