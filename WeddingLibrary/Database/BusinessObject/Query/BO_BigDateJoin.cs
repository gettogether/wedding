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
    public class BO_BigDateJoin
    {
        #region This source code was auto-generated by tool,Version=2.0.1004.01

        //------------------------------------------------------------------------------
        // <auto-generated>
        //     Date time = 2/18/2012 6:39:19 PM
        //     This code was generated by tool,Version=2.0.1004.01.
        //     Changes to this code may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        #region Condition functions
        ///<summary>
        ///Get conditions by primary key.
        ///</summary>
        public static ParameterCollection GetConditionsByPrimaryKey(System.String Email)
        {
            ParameterCollection primaryConditions = new ParameterCollection();
            primaryConditions.AddCondition(ParameterType.Initial, TokenTypes.Equal, DO_BigDateJoin.Columns.Email, Email);
            return primaryConditions;
        }

        ///<summary>
        ///Get the tokenType of the column of condition query.
        ///</summary>
        private static TokenTypes GetColumnTokenType(TokenTypes defaultTokenType, DO_BigDateJoin.Columns column, Dictionary<DO_BigDateJoin.Columns, TokenTypes> extTokens)
        {
            if (extTokens != null && extTokens.ContainsKey(column))
                return extTokens[column];
            else
                return defaultTokenType;
        }

        ///<summary>
        ///Get conditions by object with Multi-TokenType.
        ///</summary>
        public static ParameterCollection GetConditionsByObject(DO_BigDateJoin.UO_BigDateJoin parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDateJoin.Columns, TokenTypes> extTokens)
        {
            ParameterCollection objectConditions = new ParameterCollection();
            TokenTypes tt = tokenTypes;
            ParameterType pt = isAnd ? ParameterType.And : ParameterType.Or;
            if (!string.IsNullOrEmpty(parameterObj.Email))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateJoin.Columns.Email, extTokens), DO_BigDateJoin.Columns.Email, parameterObj.Email);
            }
            if (!string.IsNullOrEmpty(parameterObj.BigDateCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateJoin.Columns.BigDateCode, extTokens), DO_BigDateJoin.Columns.BigDateCode, parameterObj.BigDateCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.BigDateName))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateJoin.Columns.BigDateName, extTokens), DO_BigDateJoin.Columns.BigDateName, parameterObj.BigDateName);
            }
            if (parameterObj.BigDate != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateJoin.Columns.BigDate, extTokens), DO_BigDateJoin.Columns.BigDate, parameterObj.BigDate);
            }
            return objectConditions;
        }
        #endregion

        #region Query functions

        ///<summary>
        ///Get all records.
        ///</summary>
        public static DO_BigDateJoin.UOList_BigDateJoin GetAllList()
        {
            DO_BigDateJoin da = new DO_BigDateJoin();
            return da.GetAllList();
        }

        ///<summary>
        ///Get all records count.
        ///</summary>
        public static int GetAllRecordsCount()
        {
            DO_BigDateJoin da = new DO_BigDateJoin();
            return da.GetRecordsCount();
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_BigDateJoin.UO_BigDateJoin parameterObj)
        {
            return GetRecordsCount(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_BigDateJoin.UO_BigDateJoin parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDateJoin.Columns, TokenTypes> extTokens)
        {
            DO_BigDateJoin da = new DO_BigDateJoin();
            return da.GetRecordsCount(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_BigDateJoin.UOList_BigDateJoin GetList(DO_BigDateJoin.UO_BigDateJoin parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDateJoin.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_BigDateJoin.UOList_BigDateJoin GetList(DO_BigDateJoin.UO_BigDateJoin parameterObj)
        {
            return GetList(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get object by primary key.
        ///</summary>
        public static DO_BigDateJoin.UO_BigDateJoin GetObject(System.String Email)
        {
            DO_BigDateJoin da = new DO_BigDateJoin();
            DO_BigDateJoin.UOList_BigDateJoin l = da.GetList(GetConditionsByPrimaryKey(Email));
            return l.Count > 0 ? l[0] : null;
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_BigDateJoin.UO_BigDateJoin, DO_BigDateJoin.UOList_BigDateJoin> GetPagingList(DO_BigDateJoin.UO_BigDateJoin parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDateJoin.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens), pageNumber, pageSize, sortBy, isAsc);
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_BigDateJoin.UO_BigDateJoin, DO_BigDateJoin.UOList_BigDateJoin> GetPagingList(DO_BigDateJoin.UO_BigDateJoin parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, true, TokenTypes.Like, null), pageNumber, pageSize, sortBy, isAsc);
        }

        #endregion
        #endregion

        #region User extensions

        #endregion
    }
}