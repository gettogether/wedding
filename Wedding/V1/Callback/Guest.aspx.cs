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

public partial class V1_Callback_Guest : WeddingLibrary.Web.TemplateCallbackPage
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
            string guestCode = Request["guestCode"];
            DO_Guest.UO_Guest uoGuest = null;
            V1_Components_Guest_GuestEdit control = (V1_Components_Guest_GuestEdit)Page.LoadControl("~/V1/Components/Guest/GuestEdit.ascx");

            if (!string.IsNullOrEmpty(guestCode))
            {
                uoGuest = WeddingLibrary.Database.BusinessObject.BO_Guest.GetObject(CurrentSession.Profile.BigDate.BigDateCode, guestCode);
                control.Guest = uoGuest;
            }
            this.Controls.Add(control);
        }
    }

    private void GetList()
    {
        V1_Components_Guest_GuestList c = (V1_Components_Guest_GuestList)Page.LoadControl("~/V1/Components/Guest/GuestList.ascx");
        DO_GuestJoin.UO_GuestJoin uoSeach = new DO_GuestJoin.UO_GuestJoin();
        DefaultSort = DO_GuestJoin.Columns.CreateOn.ToString();
        DefaultIsAsc = false;
        c.Sort = Sort;
        c.IsAsc = IsAsc;
        if (string.IsNullOrEmpty(Request["size"]))
            c.PageSize = 10;
        else
            c.PageSize = PageSize;
        c.PageIndex = PageIndex;
        uoSeach.BigDateCode = CurrentSession.Profile.BigDate.BigDateCode;
        CommonLibrary.WebObject.WebHelper.SetValues<DO_GuestJoin.UO_GuestJoin>(uoSeach, "GuestSch");

        DataAccess.Data.PagingResult<DO_GuestJoin.UO_GuestJoin, DO_GuestJoin.UOList_GuestJoin> data = BO_GuestJoin.GetPagingList(uoSeach, c.PageIndex, c.PageSize, c.Sort, c.IsAsc);
        if (data.Total > 0)
        {
            c.SetData<DO_GuestJoin.UO_GuestJoin, DO_GuestJoin.UOList_GuestJoin>(data);
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
        string[] guestCodes = CommonLibrary.Utility.StringHelper.String2StringArray(System.Web.HttpUtility.UrlDecode(Request["guestCodes"]), ',');
        if (guestCodes != null && guestCodes.Length > 0)
        {
            if (WeddingLibrary.Database.Imp.Guest.DeleteByBigDateCodeAndGuestCodes(
                CurrentSession.Profile.BigDate.BigDateCode, guestCodes,CurrentSession.Profile.LoginUser.LoginEmail))
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
