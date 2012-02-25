using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.Web.Imp
{
    public class Title
    {
        public static string GenTitle(string bigDateCode, string id, string css, string selected_value, string title, string jsEvent)
        {
            return Util.GenSelect<DO_Title.UO_Title, DO_Title.UOList_Title>(
                Database.Imp.Title.GetListByBigDateCode(bigDateCode), id, css, selected_value, 
                title, jsEvent, DO_Title.Columns.TitleCode.ToString(), DO_Title.Columns.TitleName.ToString());
        }

    }
}
