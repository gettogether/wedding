using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.Database.Imp
{
    public class Category
    {
        public static DO_Category.UOList_Category GetListByBigDateCode(string bigDateCode)
        {
            return Util.GetListByBigDateCode<DO_Category, DO_Category.UOList_Category, DO_Category.UO_Category>(bigDateCode, DO_Category.Columns.CategoryName.ToString());
        }
    }
}
