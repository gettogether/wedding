using System;
using System.Web;
using System.Web.SessionState;
using WeddingLibrary.Database.BusinessObject;
using WeddingLibrary.Database.DataObject;
using System.Collections.Generic;

namespace WeddingLibrary.App.ashx
{
    public class Schedule : IHttpHandler, IRequiresSessionState
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
                        DO_Schedule.UO_Schedule addSchedule = new DO_Schedule.UO_Schedule();
                        CommonLibrary.WebObject.WebHelper.SetValues<DO_Schedule.UO_Schedule>(addSchedule, "Schedule_");
                        addSchedule.BigDateCode = currentSession.Profile.BigDate.BigDateCode;
                        addSchedule.CreateBy = currentSession.Profile.LoginUser.LoginEmail;
                        int scheduleCount = WeddingLibrary.Database.Imp.Schedule.GetRecordCountByBigDateCode(currentSession.Profile.BigDate.BigDateCode) + 1;
                        addSchedule.ScheduleCode = scheduleCount.ToString("00000");
                        if (addSchedule.Insert() > 0)
                        {
                            context.Response.Write(AppResult<string>.GetResult(""));
                        }
                        else
                        {
                            context.Response.Write(AppResult<string>.GetResult("增加失敗"));
                        }
                        done = true;
                    }
                    else if (operaType == "edit" && !string.IsNullOrEmpty(context.Request["scheduleCode"]))
                    {
                        DO_Schedule.UO_Schedule editSchedule = WeddingLibrary.Database.Imp.Schedule.GetObjectByBigDateCodeAndScheduleCode(currentSession.Profile.BigDate.BigDateCode, context.Request["scheduleCode"]);
                        if (editSchedule != null)
                        {
                            CommonLibrary.WebObject.WebHelper.SetValues<DO_Schedule.UO_Schedule>(editSchedule, "Schedule_");
                            editSchedule.BigDateCode = currentSession.Profile.BigDate.BigDateCode;
                            editSchedule.UpdateBy = currentSession.Profile.LoginUser.LoginEmail;
                            editSchedule.UpdateOn = DataAccess.DateTimeValues.DbTime;
                            if (WeddingLibrary.Database.BusinessObject.BO_Schedule.UpdateObject(editSchedule, currentSession.Profile.BigDate.BigDateCode, editSchedule.ScheduleCode))
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
                    else if (operaType == "get")
                    {
                        DO_Schedule.UO_Schedule uoSeach = new DO_Schedule.UO_Schedule();
                        string Sort = context.Request["SortBy"];
                        if (string.IsNullOrEmpty(Sort)) Sort = DO_Schedule.Columns.ScheduleName.ToString();
                        bool IsAsc = CommonLibrary.Utility.NumberHelper.ToInt(context.Request["IsAsc"], 0) == 1;
                        int pageSize = CommonLibrary.Utility.NumberHelper.ToInt(context.Request["pageSize"], 0);
                        if (pageSize == 0) pageSize = 10;
                        int pageIndex = CommonLibrary.Utility.NumberHelper.ToInt(context.Request["PageIndex"], 1);
                        uoSeach.BigDateCode = currentSession.Profile.BigDate.BigDateCode;
                        CommonLibrary.WebObject.WebHelper.SetValues<DO_Schedule.UO_Schedule>(uoSeach, "GuestSch");
                        DataAccess.Data.PagingResult<DO_Schedule.UO_Schedule, DO_Schedule.UOList_Schedule> data = BO_Schedule.GetPagingList(uoSeach, pageIndex, pageSize, Sort, IsAsc);
                        if (data.Total > 0)
                        {
                            foreach (Database.DataObject.DO_Schedule.UO_Schedule s in data.Result)
                            {
                                s.ConnInfo = null;
                            }

                            context.Response.Write(new AppResult<DataAccess.Data.PagingResult<DO_Schedule.UO_Schedule, DO_Schedule.UOList_Schedule>>(data, "").ToString());
                        }
                        else
                        {
                            context.Response.Write(AppResult<string>.GetResult("目前您的日程表是空的"));
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