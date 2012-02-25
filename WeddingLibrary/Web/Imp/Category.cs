using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.Web.Imp
{
    public class Category
    {
        public static string GenCategory(string bigDateCode, string id, string css, string selected_value, string title, string jsEvent)
        {
            return Util.GenSelect<DO_Category.UO_Category, DO_Category.UOList_Category>(
                Database.Imp.Category.GetListByBigDateCode(bigDateCode), id, css, selected_value,
                title, jsEvent, DO_Category.Columns.CategoryCode.ToString(), DO_Category.Columns.CategoryName.ToString());
        }
    }
}
