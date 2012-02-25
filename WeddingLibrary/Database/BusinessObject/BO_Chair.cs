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
    public class BO_Chair
    {
        #region This source code was auto-generated by tool,Version=2.0.1004.01

        //------------------------------------------------------------------------------
        // <auto-generated>
        //     Date time = 2/11/2012 4:59:29 PM
        //     This code was generated by tool,Version=2.0.1004.01.
        //     Changes to this code may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        #region Condition functions
        ///<summary>
        ///Get conditions by primary key.
        ///</summary>
        public static ParameterCollection GetConditionsByPrimaryKey(string BigDateCode, string DecorationCode, string GuestCode)
        {
            ParameterCollection primaryConditions = new ParameterCollection();
            primaryConditions.AddCondition(ParameterType.Initial, TokenTypes.Equal, DO_Chair.Columns.BigDateCode, BigDateCode);
            primaryConditions.AddCondition(ParameterType.And, TokenTypes.Equal, DO_Chair.Columns.DecorationCode, DecorationCode);
            primaryConditions.AddCondition(ParameterType.And, TokenTypes.Equal, DO_Chair.Columns.GuestCode, GuestCode);
            return primaryConditions;
        }

        ///<summary>
        ///Get the tokenType of the column of condition query.
        ///</summary>
        private static TokenTypes GetColumnTokenType(TokenTypes defaultTokenType, DO_Chair.Columns column, Dictionary<DO_Chair.Columns, TokenTypes> extTokens)
        {
            if (extTokens != null && extTokens.ContainsKey(column))
                return extTokens[column];
            else
                return defaultTokenType;
        }

        ///<summary>
        ///Get conditions by object with Multi-TokenType.
        ///</summary>
        public static ParameterCollection GetConditionsByObject(DO_Chair.UO_Chair parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_Chair.Columns, TokenTypes> extTokens)
        {
            ParameterCollection objectConditions = new ParameterCollection();
            TokenTypes tt = tokenTypes;
            ParameterType pt = isAnd ? ParameterType.And : ParameterType.Or;
            if (!string.IsNullOrEmpty(parameterObj.BigDateCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Chair.Columns.BigDateCode, extTokens), DO_Chair.Columns.BigDateCode, parameterObj.BigDateCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.DecorationCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Chair.Columns.DecorationCode, extTokens), DO_Chair.Columns.DecorationCode, parameterObj.DecorationCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.GuestCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Chair.Columns.GuestCode, extTokens), DO_Chair.Columns.GuestCode, parameterObj.GuestCode);
            }
            if (parameterObj.ChairNum != 0 || (extTokens != null && extTokens.ContainsKey(DO_Chair.Columns.ChairNum)))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Chair.Columns.ChairNum, extTokens), DO_Chair.Columns.ChairNum, parameterObj.ChairNum);
            }
            if (parameterObj.CreateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Chair.Columns.CreateOn, extTokens), DO_Chair.Columns.CreateOn, parameterObj.CreateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.CreateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Chair.Columns.CreateBy, extTokens), DO_Chair.Columns.CreateBy, parameterObj.CreateBy);
            }
            if (parameterObj.UpdateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Chair.Columns.UpdateOn, extTokens), DO_Chair.Columns.UpdateOn, parameterObj.UpdateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.UpdateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_Chair.Columns.UpdateBy, extTokens), DO_Chair.Columns.UpdateBy, parameterObj.UpdateBy);
            }
            return objectConditions;
        }
        #endregion

        #region Query functions

        ///<summary>
        ///Get all records.
        ///</summary>
        public static DO_Chair.UOList_Chair GetAllList()
        {
            DO_Chair da = new DO_Chair();
            return da.GetAllList();
        }

        ///<summary>
        ///Get all records count.
        ///</summary>
        public static int GetAllRecordsCount()
        {
            DO_Chair da = new DO_Chair();
            return da.GetRecordsCount();
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_Chair.UO_Chair parameterObj)
        {
            return GetRecordsCount(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_Chair.UO_Chair parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_Chair.Columns, TokenTypes> extTokens)
        {
            DO_Chair da = new DO_Chair();
            return da.GetRecordsCount(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_Chair.UOList_Chair GetList(DO_Chair.UO_Chair parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_Chair.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_Chair.UOList_Chair GetList(DO_Chair.UO_Chair parameterObj)
        {
            return GetList(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get object by primary key.
        ///</summary>
        public static DO_Chair.UO_Chair GetObject(string BigDateCode, string DecorationCode, string GuestCode)
        {
            DO_Chair da = new DO_Chair();
            DO_Chair.UOList_Chair l = da.GetList(GetConditionsByPrimaryKey(BigDateCode, DecorationCode, GuestCode));
            return l.Count > 0 ? l[0] : null;
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_Chair.UO_Chair, DO_Chair.UOList_Chair> GetPagingList(DO_Chair.UO_Chair parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_Chair.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens), pageNumber, pageSize, sortBy, isAsc);
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_Chair.UO_Chair, DO_Chair.UOList_Chair> GetPagingList(DO_Chair.UO_Chair parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, true, TokenTypes.Like, null), pageNumber, pageSize, sortBy, isAsc);
        }
        #endregion

        #region Update functions
        ///<summary>
        ///Update object by primary key.
        ///</summary>
        public static bool UpdateObject(DO_Chair.UO_Chair obj, string BigDateCode, string DecorationCode, string GuestCode)
        {
            return obj.Update(GetConditionsByPrimaryKey(BigDateCode, DecorationCode, GuestCode)) > 0;
        }

        ///<summary>
        ///Update object by primary key(with transation).
        ///</summary>
        public static bool UpdateObject(DO_Chair.UO_Chair obj, string BigDateCode, string DecorationCode, string GuestCode, IDbConnection connection, IDbTransaction transaction)
        {
            return obj.Update(connection, transaction, GetConditionsByPrimaryKey(BigDateCode, DecorationCode, GuestCode)) > 0;
        }
        #endregion

        #region Delete functions
        ///<summary>
        ///Delete object by primary key.
        ///</summary>
        public static int Delete(string BigDateCode, string DecorationCode, string GuestCode)
        {
            DO_Chair da = new DO_Chair();
            return da.Delete(GetConditionsByPrimaryKey(BigDateCode, DecorationCode, GuestCode));
        }

        ///<summary>
        ///Delete object by primary key(with transation).
        ///</summary>
        public static int Delete(string BigDateCode, string DecorationCode, string GuestCode, IDbConnection connection, IDbTransaction transaction)
        {
            DO_Chair da = new DO_Chair();
            return da.Delete(connection, transaction, GetConditionsByPrimaryKey(BigDateCode, DecorationCode, GuestCode));
        }
        #endregion

        #endregion

        #region User extensions

        #endregion
    }
}
