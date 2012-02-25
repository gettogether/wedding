using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.Database.Imp
{
    public class Title
    {
        public static DO_Title.UOList_Title GetListByBigDateCode(string bigDateCode)
        {
            return Util.GetListByBigDateCode<DO_Title, DO_Title.UOList_Title, DO_Title.UO_Title>(bigDateCode, DO_Title.Columns.TitleName.ToString());
        }
    }
}
