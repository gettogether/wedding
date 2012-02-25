using System;
using System.Web;
using System.Web.SessionState;
using WeddingLibrary.Database.BusinessObject;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.App.ashx
{
    public class Guest : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                WeddingLibrary.SessionObject currentSession = WeddingLibrary.SessionHelper.GetCurrentSession();
                if (currentSession == null)
                {
                    currentSession = SessionHelper.GetTestSession();
                }

                if (currentSession != null)
                {
                    string operaType = context.Request["operation"];
                    bool done = false;
                    if (operaType == "add")
                    {
                        DO_Guest.UO_Guest addGuest = new DO_Guest.UO_Guest();
                        CommonLibrary.WebObject.WebHelper.SetValues<DO_Guest.UO_Guest>(addGuest, "Guest_");
                        addGuest.BigDateCode = currentSession.Profile.BigDate.BigDateCode;
                        addGuest.CreateBy = currentSession.Profile.LoginUser.LoginEmail;
                        int guestCount = WeddingLibrary.Database.Imp.Guest.GetRecordCountByBigDateCode(currentSession.Profile.BigDate.BigDateCode) + 1;
                        addGuest.GuestCode = guestCount.ToString("00000");
                        if (addGuest.Insert() > 0)
                        {
                            context.Response.Write(AppResult<string>.GetResult(""));
                        }
                        else
                        {
                            context.Response.Write(AppResult<string>.GetResult("增加失敗"));
                        }
                        done = true;
                    }
                    else if (operaType == "edit" && !string.IsNullOrEmpty(context.Request["guestCode"]))
                    {
                        DO_Guest.UO_Guest editGuest = WeddingLibrary.Database.Imp.Guest.GetObjectByBigDateCodeAndGuestCode(currentSession.Profile.BigDate.BigDateCode, context.Request["guestCode"]);
                        if (editGuest != null)
                        {
                            CommonLibrary.WebObject.WebHelper.SetValues<DO_Guest.UO_Guest>(editGuest, "Guest_");
                            editGuest.BigDateCode = currentSession.Profile.BigDate.BigDateCode;
                            editGuest.UpdateBy = currentSession.Profile.LoginUser.LoginEmail;
                            editGuest.UpdateOn = DataAccess.DateTimeValues.DbTime;
                            if (WeddingLibrary.Database.BusinessObject.BO_Guest.UpdateObject(editGuest, currentSession.Profile.BigDate.BigDateCode, editGuest.GuestCode))
                            {
                                WeddingLibrary.Web.JsonHelper.JsonSuccess();
                            }
                            else
                            {
                                context.Response.Write(AppResult<string>.GetResult("更新失敗"));
                            }
                        }
                        else
                        {
                            context.Response.Write(AppResult<string>.GetResult("找不到該客人信息"));
                        }
                        done = true;
                    }
                    if (!done)
                    {
                        context.Response.Write(AppResult<string>.GetResult("參數錯誤"));
                    }
                }
                else
                {
                    context.Response.Write(AppResult<string>.GetResult("Timeout"));
                }
            }
            catch (Exception ex)
            {
                WeddingLibrary.Logging.Files.Log.Error(ex);
                context.Response.Write(AppResult<string>.GetResult(ex.ToString()));
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

}