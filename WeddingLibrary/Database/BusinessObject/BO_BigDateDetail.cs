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
    public class BO_BigDateDetail
    {
        #region This source code was auto-generated by tool,Version=2.0.1004.01

        //------------------------------------------------------------------------------
        // <auto-generated>
        //     Date time = 2/11/2012 4:57:59 PM
        //     This code was generated by tool,Version=2.0.1004.01.
        //     Changes to this code may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        #region Condition functions
        ///<summary>
        ///Get conditions by primary key.
        ///</summary>
        public static ParameterCollection GetConditionsByPrimaryKey(string BigDateCode, string Email)
        {
            ParameterCollection primaryConditions = new ParameterCollection();
            primaryConditions.AddCondition(ParameterType.Initial, TokenTypes.Equal, DO_BigDateDetail.Columns.BigDateCode, BigDateCode);
            primaryConditions.AddCondition(ParameterType.And, TokenTypes.Equal, DO_BigDateDetail.Columns.Email, Email);
            return primaryConditions;
        }

        ///<summary>
        ///Get the tokenType of the column of condition query.
        ///</summary>
        private static TokenTypes GetColumnTokenType(TokenTypes defaultTokenType, DO_BigDateDetail.Columns column, Dictionary<DO_BigDateDetail.Columns, TokenTypes> extTokens)
        {
            if (extTokens != null && extTokens.ContainsKey(column))
                return extTokens[column];
            else
                return defaultTokenType;
        }

        ///<summary>
        ///Get conditions by object with Multi-TokenType.
        ///</summary>
        public static ParameterCollection GetConditionsByObject(DO_BigDateDetail.UO_BigDateDetail parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDateDetail.Columns, TokenTypes> extTokens)
        {
            ParameterCollection objectConditions = new ParameterCollection();
            TokenTypes tt = tokenTypes;
            ParameterType pt = isAnd ? ParameterType.And : ParameterType.Or;
            if (!string.IsNullOrEmpty(parameterObj.BigDateCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateDetail.Columns.BigDateCode, extTokens), DO_BigDateDetail.Columns.BigDateCode, parameterObj.BigDateCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.Email))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateDetail.Columns.Email, extTokens), DO_BigDateDetail.Columns.Email, parameterObj.Email);
            }
            if (parameterObj.CreateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateDetail.Columns.CreateOn, extTokens), DO_BigDateDetail.Columns.CreateOn, parameterObj.CreateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.CreateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateDetail.Columns.CreateBy, extTokens), DO_BigDateDetail.Columns.CreateBy, parameterObj.CreateBy);
            }
            if (parameterObj.UpdateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateDetail.Columns.UpdateOn, extTokens), DO_BigDateDetail.Columns.UpdateOn, parameterObj.UpdateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.UpdateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_BigDateDetail.Columns.UpdateBy, extTokens), DO_BigDateDetail.Columns.UpdateBy, parameterObj.UpdateBy);
            }
            return objectConditions;
        }
        #endregion

        #region Query functions

        ///<summary>
        ///Get all records.
        ///</summary>
        public static DO_BigDateDetail.UOList_BigDateDetail GetAllList()
        {
            DO_BigDateDetail da = new DO_BigDateDetail();
            return da.GetAllList();
        }

        ///<summary>
        ///Get all records count.
        ///</summary>
        public static int GetAllRecordsCount()
        {
            DO_BigDateDetail da = new DO_BigDateDetail();
            return da.GetRecordsCount();
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_BigDateDetail.UO_BigDateDetail parameterObj)
        {
            return GetRecordsCount(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_BigDateDetail.UO_BigDateDetail parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDateDetail.Columns, TokenTypes> extTokens)
        {
            DO_BigDateDetail da = new DO_BigDateDetail();
            return da.GetRecordsCount(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_BigDateDetail.UOList_BigDateDetail GetList(DO_BigDateDetail.UO_BigDateDetail parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDateDetail.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_BigDateDetail.UOList_BigDateDetail GetList(DO_BigDateDetail.UO_BigDateDetail parameterObj)
        {
            return GetList(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get object by primary key.
        ///</summary>
        public static DO_BigDateDetail.UO_BigDateDetail GetObject(string BigDateCode, string Email)
        {
            DO_BigDateDetail da = new DO_BigDateDetail();
            DO_BigDateDetail.UOList_BigDateDetail l = da.GetList(GetConditionsByPrimaryKey(BigDateCode, Email));
            return l.Count > 0 ? l[0] : null;
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_BigDateDetail.UO_BigDateDetail, DO_BigDateDetail.UOList_BigDateDetail> GetPagingList(DO_BigDateDetail.UO_BigDateDetail parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_BigDateDetail.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens), pageNumber, pageSize, sortBy, isAsc);
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_BigDateDetail.UO_BigDateDetail, DO_BigDateDetail.UOList_BigDateDetail> GetPagingList(DO_BigDateDetail.UO_BigDateDetail parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, true, TokenTypes.Like, null), pageNumber, pageSize, sortBy, isAsc);
        }
        #endregion

        #region Update functions
        ///<summary>
        ///Update object by primary key.
        ///</summary>
        public static bool UpdateObject(DO_BigDateDetail.UO_BigDateDetail obj, string BigDateCode, string Email)
        {
            return obj.Update(GetConditionsByPrimaryKey(BigDateCode, Email)) > 0;
        }

        ///<summary>
        ///Update object by primary key(with transation).
        ///</summary>
        public static bool UpdateObject(DO_BigDateDetail.UO_BigDateDetail obj, string BigDateCode, string Email, IDbConnection connection, IDbTransaction transaction)
        {
            return obj.Update(connection, transaction, GetConditionsByPrimaryKey(BigDateCode, Email)) > 0;
        }
        #endregion

        #region Delete functions
        ///<summary>
        ///Delete object by primary key.
        ///</summary>
        public static int Delete(string BigDateCode, string Email)
        {
            DO_BigDateDetail da = new DO_BigDateDetail();
            return da.Delete(GetConditionsByPrimaryKey(BigDateCode, Email));
        }

        ///<summary>
        ///Delete object by primary key(with transation).
        ///</summary>
        public static int Delete(string BigDateCode, string Email, IDbConnection connection, IDbTransaction transaction)
        {
            DO_BigDateDetail da = new DO_BigDateDetail();
            return da.Delete(connection, transaction, GetConditionsByPrimaryKey(BigDateCode, Email));
        }
        #endregion

        #endregion

        #region User extensions

        #endregion
    }
}
