using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.Database.Imp
{
    public class Util
    {
        public static C GetListByBigDateCode<D, C, T>(string bigDateCode, string sortBy)
            where D : DataAccess.Data.DOBase<T, C>, new()
            where C : CommonLibrary.ObjectBase.ListBase<T>, new()
            where T : DataAccess.Data.UOBase<T, C>, new()
        {
            DataAccess.ParameterCollection conditions = new DataAccess.ParameterCollection();
            conditions.AddCondition(DataAccess.ParameterType.Initial, DataAccess.TokenTypes.Equal, Definition.Database.Columns.BigDateCode, bigDateCode);
            return new D().GetList(conditions, sortBy);
        }
    }
}
