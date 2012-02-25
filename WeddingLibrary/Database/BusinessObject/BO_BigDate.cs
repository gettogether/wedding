﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccess;
using DataAccess.Data;
using DataMapping;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.Database.BusinessObject
{
    public class BO_BigDate
    {
        #region This source code was auto-generated by tool,Version=2.0.1004.01

        //------------------------------------------------------------------------------
        // <auto-generated>
        //     Date time = 2/18/2012 3:37:56 PM
        //     This code was generated by tool,Version=2.0.1004.01.
        //     Changes to this code may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        #region Condition functions
        ///<summary>
        ///Get conditions by primary key.
        ///</summary>
        public static ParameterCollection GetConditionsByPrimaryKey(string BigDateCode)
        {
            ParameterCollection primaryConditions = new ParameterCollection();
            primaryConditions.AddCondition(ParameterType.Initial, TokenTypes.Equal, DO_BigDate.Columns.BigDateCode, BigDateCode);
            return primaryConditions;
        }

        ///<summary>
        ///Get the tokenType of the column of condition query.
        ///</summary>
        private static TokenTypes GetColumnTokenType(TokenTypes defaultTokenType, DO_BigDate.Columns column, Dictionary<DO_BigDate.Columns, TokenTypes> extTokens)
        {
            if (extTokens != null && extTokens.ContainsKey(column))
                return extTokens[column];
            else
                return defaultTokenType;
        }

        ///<summary>
        ///Get conditions by object with Multi-TokenType.
        ///</summary>
        public static ParameterCollection GetConditionsByObject(DO_BigDate.UO_BigDate parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDate.Columns, TokenTypes> extTokens)
        {
            ParameterCollection objectConditions = new ParameterCollection();
            TokenTypes tt = tokenTypes;
            ParameterType pt = isAnd ? ParameterType.And : ParameterType.Or;
            if (!string.IsNullOrEmpty(parameterObj.BigDateCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDate.Columns.BigDateCode, extTokens), DO_BigDate.Columns.BigDateCode, parameterObj.BigDateCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.BigDateName))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDate.Columns.BigDateName, extTokens), DO_BigDate.Columns.BigDateName, parameterObj.BigDateName);
            }
            if (parameterObj.CreateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDate.Columns.CreateOn, extTokens), DO_BigDate.Columns.CreateOn, parameterObj.CreateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.CreateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDate.Columns.CreateBy, extTokens), DO_BigDate.Columns.CreateBy, parameterObj.CreateBy);
            }
            if (parameterObj.UpdateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDate.Columns.UpdateOn, extTokens), DO_BigDate.Columns.UpdateOn, parameterObj.UpdateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.UpdateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDate.Columns.UpdateBy, extTokens), DO_BigDate.Columns.UpdateBy, parameterObj.UpdateBy);
            }
            if (parameterObj.BigDate != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDate.Columns.BigDate, extTokens), DO_BigDate.Columns.BigDate, parameterObj.BigDate);
            }
            return objectConditions;
        }
        #endregion

        #region Query functions

        ///<summary>
        ///Get all records.
        ///</summary>
        public static DO_BigDate.UOList_BigDate GetAllList()
        {
            DO_BigDate da = new DO_BigDate();
            return da.GetAllList();
        }

        ///<summary>
        ///Get all records count.
        ///</summary>
        public static int GetAllRecordsCount()
        {
            DO_BigDate da = new DO_BigDate();
            return da.GetRecordsCount();
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_BigDate.UO_BigDate parameterObj)
        {
            return GetRecordsCount(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_BigDate.UO_BigDate parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDate.Columns, TokenTypes> extTokens)
        {
            DO_BigDate da = new DO_BigDate();
            return da.GetRecordsCount(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_BigDate.UOList_BigDate GetList(DO_BigDate.UO_BigDate parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDate.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_BigDate.UOList_BigDate GetList(DO_BigDate.UO_BigDate parameterObj)
        {
            return GetList(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get object by primary key.
        ///</summary>
        public static DO_BigDate.UO_BigDate GetObject(string BigDateCode)
        {
            DO_BigDate da = new DO_BigDate();
            DO_BigDate.UOList_BigDate l = da.GetList(GetConditionsByPrimaryKey(BigDateCode));
            return l.Count > 0 ? l[0] : null;
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_BigDate.UO_BigDate, DO_BigDate.UOList_BigDate> GetPagingList(DO_BigDate.UO_BigDate parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDate.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens), pageNumber, pageSize, sortBy, isAsc);
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_BigDate.UO_BigDate, DO_BigDate.UOList_BigDate> GetPagingList(DO_BigDate.UO_BigDate parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, true, TokenTypes.Like, null), pageNumber, pageSize, sortBy, isAsc);
        }
        #endregion

        #region Update functions
        ///<summary>
        ///Update object by primary key.
        ///</summary>
        public static bool UpdateObject(DO_BigDate.UO_BigDate obj, string BigDateCode)
        {
            return obj.Update(GetConditionsByPrimaryKey(BigDateCode)) > 0;
        }

        ///<summary>
        ///Update object by primary key(with transation).
        ///</summary>
        public static bool UpdateObject(DO_BigDate.UO_BigDate obj, string BigDateCode, IDbConnection connection, IDbTransaction transaction)
        {
            return obj.Update(connection, transaction, GetConditionsByPrimaryKey(BigDateCode)) > 0;
        }
        #endregion

        #region Delete functions
        ///<summary>
        ///Delete object by primary key.
        ///</summary>
        public static int Delete(string BigDateCode)
        {
            DO_BigDate da = new DO_BigDate();
            return da.Delete(GetConditionsByPrimaryKey(BigDateCode));
        }

        ///<summary>
        ///Delete object by primary key(with transation).
        ///</summary>
        public static int Delete(string BigDateCode, IDbConnection connection, IDbTransaction transaction)
        {
            DO_BigDate da = new DO_BigDate();
            return da.Delete(connection, transaction, GetConditionsByPrimaryKey(BigDateCode));
        }
        #endregion

        #endregion

        #region User extensions

        #endregion
    }
}
