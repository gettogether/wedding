using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Database.Imp
{
    public class BigDate
    {
        public static WeddingLibrary.Database.DataObject.DO_BigDateJoin.UOList_BigDateJoin GetListByEmail(string email)
        {
            DataAccess.ParameterCollection conditions = new DataAccess.ParameterCollection();
            conditions.AddCondition(DataAccess.ParameterType.Initial, DataAccess.TokenTypes.Equal, WeddingLibrary.Database.DataObject.DO_BigDateJoin.Columns.Email, email);
            return new WeddingLibrary.Database.DataObject.DO_BigDateJoin().GetList(conditions);
        }
    }
}
