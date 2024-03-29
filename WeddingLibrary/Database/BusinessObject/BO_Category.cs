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
    public class BO_Category
    {
        #region This source code was auto-generated by tool,Version=2.0.1004.01

        //------------------------------------------------------------------------------
        // <auto-generated>
        //     Date time = 2/11/2012 4:58:40 PM
        //     This code was generated by tool,Version=2.0.1004.01.
        //     Changes to this code may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        #region Condition functions
        ///<summary>
        ///Get conditions by primary key.
        ///</summary>
        public static ParameterCollection GetConditionsByPrimaryKey(string BigDateCode, string CategoryCode)
        {
            ParameterCollection primaryConditions = new ParameterCollection();
            primaryConditions.AddCondition(ParameterType.Initial, TokenTypes.Equal, DO_Category.Columns.BigDateCode, BigDateCode);
            primaryConditions.AddCondition(ParameterType.And, TokenTypes.Equal, DO_Category.Columns.CategoryCode, CategoryCode);
            return primaryConditions;
        }

        ///<summary>
        ///Get the tokenType of the column of condition query.
        ///</summary>
        private static TokenTypes GetColumnTokenType(TokenTypes defaultTokenType, DO_Category.Columns column, Dictionary<DO_Category.Columns, TokenTypes> extTokens)
        {
            if (extTokens != null && extTokens.ContainsKey(column))
                return extTokens[column];
            else
                return defaultTokenType;
        }

        ///<summary>
        ///Get conditions by object with Multi-TokenType.
        ///</summary>
        public static ParameterCollection GetConditionsByObject(DO_Category.UO_Category parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_Category.Columns, TokenTypes> extTokens)
        {
            ParameterCollection objectConditions = new ParameterCollection();
            TokenTypes tt = tokenTypes;
            ParameterType pt = isAnd ? ParameterType.And : ParameterType.Or;
            if (!string.IsNullOrEmpty(parameterObj.BigDateCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Category.Columns.BigDateCode, extTokens), DO_Category.Columns.BigDateCode, parameterObj.BigDateCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.CategoryCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Category.Columns.CategoryCode, extTokens), DO_Category.Columns.CategoryCode, parameterObj.CategoryCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.QueryWords))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Category.Columns.QueryWords, extTokens), DO_Category.Columns.QueryWords, parameterObj.QueryWords);
            }
            if (!string.IsNullOrEmpty(parameterObj.CategoryName))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Category.Columns.CategoryName, extTokens), DO_Category.Columns.CategoryName, parameterObj.CategoryName);
            }
            if (parameterObj.CreateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Category.Columns.CreateOn, extTokens), DO_Category.Columns.CreateOn, parameterObj.CreateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.CreateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Category.Columns.CreateBy, extTokens), DO_Category.Columns.CreateBy, parameterObj.CreateBy);
            }
            if (parameterObj.UpdateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Category.Columns.UpdateOn, extTokens), DO_Category.Columns.UpdateOn, parameterObj.UpdateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.UpdateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Category.Columns.UpdateBy, extTokens), DO_Category.Columns.UpdateBy, parameterObj.UpdateBy);
            }
            return objectConditions;
        }
        #endregion

        #region Query functions

        ///<summary>
        ///Get all records.
        ///</summary>
        public static DO_Category.UOList_Category GetAllList()
        {
            DO_Category da = new DO_Category();
            return da.GetAllList();
        }

        ///<summary>
        ///Get all records count.
        ///</summary>
        public static int GetAllRecordsCount()
        {
            DO_Category da = new DO_Category();
            return da.GetRecordsCount();
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_Category.UO_Category parameterObj)
        {
            return GetRecordsCount(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_Category.UO_Category parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_Category.Columns, TokenTypes> extTokens)
        {
            DO_Category da = new DO_Category();
            return da.GetRecordsCount(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_Category.UOList_Category GetList(DO_Category.UO_Category parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_Category.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_Category.UOList_Category GetList(DO_Category.UO_Category parameterObj)
        {
            return GetList(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get object by primary key.
        ///</summary>
        public static DO_Category.UO_Category GetObject(string BigDateCode, string CategoryCode)
        {
            DO_Category da = new DO_Category();
            DO_Category.UOList_Category l = da.GetList(GetConditionsByPrimaryKey(BigDateCode, CategoryCode));
            return l.Count > 0 ? l[0] : null;
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_Category.UO_Category, DO_Category.UOList_Category> GetPagingList(DO_Category.UO_Category parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_Category.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens), pageNumber, pageSize, sortBy, isAsc);
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_Category.UO_Category, DO_Category.UOList_Category> GetPagingList(DO_Category.UO_Category parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, true, TokenTypes.Like, null), pageNumber, pageSize, sortBy, isAsc);
        }
        #endregion

        #region Update functions
        ///<summary>
        ///Update object by primary key.
        ///</summary>
        public static bool UpdateObject(DO_Category.UO_Category obj, string BigDateCode, string CategoryCode)
        {
            return obj.Update(GetConditionsByPrimaryKey(BigDateCode, CategoryCode)) > 0;
        }

        ///<summary>
        ///Update object by primary key(with transation).
        ///</summary>
        public static bool UpdateObject(DO_Category.UO_Category obj, string BigDateCode, string CategoryCode, IDbConnection connection, IDbTransaction transaction)
        {
            return obj.Update(connection, transaction, GetConditionsByPrimaryKey(BigDateCode, CategoryCode)) > 0;
        }
        #endregion

        #region Delete functions
        ///<summary>
        ///Delete object by primary key.
        ///</summary>
        public static int Delete(string BigDateCode, string CategoryCode)
        {
            DO_Category da = new DO_Category();
            return da.Delete(GetConditionsByPrimaryKey(BigDateCode, CategoryCode));
        }

        ///<summary>
        ///Delete object by primary key(with transation).
        ///</summary>
        public static int Delete(string BigDateCode, string CategoryCode, IDbConnection connection, IDbTransaction transaction)
        {
            DO_Category da = new DO_Category();
            return da.Delete(connection, transaction, GetConditionsByPrimaryKey(BigDateCode, CategoryCode));
        }
        #endregion

        #endregion

        #region User extensions

        #endregion
    }
}
