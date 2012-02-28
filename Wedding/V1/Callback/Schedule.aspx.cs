using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WeddingLibrary.Database.DataObject;
using WeddingLibrary.Database.BusinessObject;
using System.Xml.Linq;

public partial class V1_Callback_Schedule : WeddingLibrary.Web.TemplateCallbackPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (type == 1)
        {
            GetList();
        }
        else if (type == 2)
        {
            Delete();
        }
        else if (type == 3)
        {
            string scheduleCode = Request["scheduleCode"];
            DO_Schedule.UO_Schedule uoSchedule = null;
            V1_Components_Schedule_ScheduleEdit control = (V1_Components_Schedule_ScheduleEdit)Page.LoadControl("~/V1/Components/Schedule/ScheduleEdit.ascx");

            if (!string.IsNullOrEmpty(scheduleCode))
            {
                uoSchedule = WeddingLibrary.Database.BusinessObject.BO_Schedule.GetObject(CurrentSession.Profile.BigDate.BigDateCode, scheduleCode);
                control.Schedule = uoSchedule;
            }
            this.Controls.Add(control);
        }
    }

    private void GetList()
    {
        V1_Components_Schedule_ScheduleList c = (V1_Components_Schedule_ScheduleList)Page.LoadControl("~/V1/Components/Schedule/ScheduleList.ascx");
        DO_Schedule.UO_Schedule uoSeach = new DO_Schedule.UO_Schedule();
        DefaultSort = DO_Schedule.Columns.CreateOn.ToString();
        DefaultIsAsc = false;
        c.Sort = Sort;
        c.IsAsc = IsAsc;
        if (string.IsNullOrEmpty(Request["size"]))
            c.PageSize = 10;
        else
            c.PageSize = PageSize;
        c.PageIndex = PageIndex;
        uoSeach.BigDateCode = CurrentSession.Profile.BigDate.BigDateCode;
        CommonLibrary.WebObject.WebHelper.SetValues<DO_Schedule.UO_Schedule>(uoSeach, "ScheduleSch");

        DataAccess.Data.PagingResult<DO_Schedule.UO_Schedule, DO_Schedule.UOList_Schedule> data = BO_Schedule.GetPagingList(uoSeach, c.PageIndex, c.PageSize, c.Sort, c.IsAsc);
        if (data.Total > 0)
        {
            c.SetData<DO_Schedule.UO_Schedule, DO_Schedule.UOList_Schedule>(data);
            c.IsAsc = IsAsc;
            this.Page.Controls.Add(c);
        }
        else
        {
            Response.Write("目前您的賓客列表是空的");
        }
    }

    private void Delete()
    {
        string[] scheduleCodes = CommonLibrary.Utility.StringHelper.String2StringArray(System.Web.HttpUtility.UrlDecode(Request["scheduleCodes"]), ',');
        if (scheduleCodes != null && scheduleCodes.Length > 0)
        {
            if (WeddingLibrary.Database.Imp.Schedule.DeleteByBigDateCodeAndScheduleCodes(
                CurrentSession.Profile.BigDate.BigDateCode, scheduleCodes,CurrentSession.Profile.LoginUser.LoginEmail))
            {
                JsonSuccess();
            }
            else
            {
                JsonError("刪除錯誤");
            }
        }
        else
        {
            JsonError("參數錯誤");
        }
    }
}
