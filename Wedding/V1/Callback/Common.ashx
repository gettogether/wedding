<%@ WebHandler Language="C#" Class="Common" %>

using System;
using System.Web;
using System.Web.SessionState;
using WeddingLibrary.Database.DataObject;
using WeddingLibrary.Database.BusinessObject;

public class Common : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "text/plain";
        try
        {
            bool done = false;
            //System.Threading.Thread.Sleep(5000);
            if (context.Request["type"] == "1")
            {
                done = true;
                WeddingLibrary.Profiles.Entities.UO_User login = WeddingLibrary.Profiles.Imp.Login.GetLogin(context.Request["LG_Email"], context.Request["LG_Pwd"]);
                if (login != null)
                {
                    WeddingLibrary.SessionObject sess = new WeddingLibrary.SessionObject();
                    sess.Profile = new WeddingLibrary.Profiles.LoginProfile();
                    sess.Profile.LoginUser = login;
                    WeddingLibrary.SessionHelper.SetSession(sess);
                    DO_BigDateJoin.UOList_BigDateJoin bigDates = WeddingLibrary.Database.Imp.BigDate.GetListByEmail(login.LoginEmail);
                    if (bigDates.Count > 0)
                    {
                        WeddingLibrary.Profiles.Entities.UO_BigDate bigDate = new WeddingLibrary.Profiles.Entities.UO_BigDate();
                        DataMapping.ObjectHelper.CopyAttributes<DO_BigDateJoin.UO_BigDateJoin, WeddingLibrary.Profiles.Entities.UO_BigDate>(bigDates[0], bigDate);
                        sess.Profile.BigDate = bigDate;
                        WeddingLibrary.Web.JsonHelper.JsonResult(true, "", "");
                    }
                    else
                    {
                        WeddingLibrary.Logging.Files.Log.Warning("Setting Error(BigDate not found)" + CommonLibrary.Utility.SerializationHelper.SerializeToXml(login));
                        WeddingLibrary.Web.JsonHelper.JsonError("Login incorrect - Please contact us");
                    }

                }
                else
                {
                    WeddingLibrary.Web.JsonHelper.JsonError("Login incorrect - Please try again");
                }
            }
            if (!done)
            {
                WeddingLibrary.Web.JsonHelper.JsonError("Invalid Parameter");
            }
        }
        catch (Exception ex)
        {
            WeddingLibrary.Logging.Files.Log.Error(ex);
            WeddingLibrary.Web.JsonHelper.JsonError(ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}