using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Web.Imp
{
    public class Util
    {
        public static string GenSelect<T, C>(C dataSource, string id, string css, string selected_value, string title, string jsEvent,string codeColumn,string nameColumn)
            where T : DataAccess.Data.UOBase<T, C>, new()
            where C : CommonLibrary.ObjectBase.ListBase<T>, new()
        {
            StringBuilder sb_ret = new StringBuilder();
            foreach (T u in dataSource)
            {
                if ((string)u[codeColumn] == selected_value)
                {
                    sb_ret.Append(string.Format(CommonLibrary.WebObject.HtmlHelper.STR_SELECT_ITEM_SELECTED, u[codeColumn], u[nameColumn]));
                }
                else
                {
                    sb_ret.Append(string.Format(CommonLibrary.WebObject.HtmlHelper.STR_SELECT_ITEM, u[codeColumn], u[nameColumn]));
                }
            }
            return string.Format(CommonLibrary.WebObject.HtmlHelper.STR_SELECT, id, css, title, sb_ret.ToString());
        }
    }
}
