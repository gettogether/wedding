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
using System.Xml.Linq;

public partial class V1_Components_Guest_GuestList : WeddingLibrary.Web.TemplatePagingControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JsFunction = "GuestSearch";
        rpList.DataSource = BindingResult;
        rpList.DataBind();
    }
    public new string GetSortHeader(string title, string sortBy)
    {
        return CommonLibrary.WebObject.HtmlHelper.GetSortHeader(
                    "GuestSearch(1," + PageSize + ",'" + sortBy + "'," + (!IsAsc ? "true" : "false") + ")",
                    title, sortBy, IsAsc, Sort);
    }


}