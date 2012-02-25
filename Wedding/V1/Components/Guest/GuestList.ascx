<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GuestList.ascx.cs" Inherits="V1_Components_Guest_GuestList" %>
<div class="divborderpad">
    <table width="100%" border="0" cellpadding="1px" cellspacing="1px">
        <tr>
            <td>
                共<span class="days-counter"><%=Total %></span>位客人（<%=GenPageSize()%>）
            </td>
            <td align="right">
            <div style="float:right;"><%=ShowPaging() %>
                <%--<%=PageIndex %>/<%=CommonLibrary.Utility.NumberHelper.Rounding((double)(Total / PageSize), CommonLibrary.Utility.NumberHelper.RoundingTypes.Ceiling, 0) %>--%>
                </div>
            </td>
        </tr>
        <tr class="tb-header2">
            <td colspan="2" style="padding: 3px 3px;">
                <input type="button" value="刪除" onclick="DelectGuest();" />&nbsp;|&nbsp;<input type="button" value="导出" disabled="disabled" />
            </td>
        </tr>
        <tr>
            <td colspan="2" colspan="2">
                <div class="line3">
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="1" cellpadding="0" style="background-color: #fff;
        text-align: left;">
        <asp:Repeater ID="rpList" runat="server">
            <HeaderTemplate>
                <tr class="tb-header">
                <td></td>
                <td class="td-2"><input type="checkbox" onclick="CheckSelects(this,'dv-guest-search-content');"; /></td>
                    <td class="td-2">
                        <%=GetSortHeader("英文名", "GuestName_en_us")%>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("中文名", "GuestName_zh_tw")%>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("稱謂","TitleName") %>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("類別", "CategoryName")%>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("占席", "GuestQuantity")%>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("郵箱", "GuestEmail")%>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("電話", "GuestMobile")%>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("已出席", "GuestAttended")%>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("增加日期", "CreateOn")%>
                    </td>
                    <td class="td-2">
                        <%=GetSortHeader("修改日期", "UpdateOn")%>
                    </td>
                    <td class="td-2">
                        已發邀請
                    </td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr id="tr-guest-<%#Eval("GuestCode") %>"><td><span class="num"><%#Container.ItemIndex+1+(PageSize*(PageIndex-1)) %></span></td>
                <td><input type="checkbox" class="sel-result" value="<%#Eval("GuestCode") %>" /></td>
                    <td>
                        <a href="javascript:;;" onclick="LoadGuest('<%#Eval("GuestCode") %>');"><%#Eval("GuestName_en_us") %></a>
                    </td>
                    <td>
                        <a href="javascript:;;" onclick="LoadGuest('<%#Eval("GuestCode") %>');"><%#Eval("GuestName_zh_tw") %></a>
                    </td>
                    <td>
                        <%#Eval("TitleName") %>
                    </td>
                    <td>
                        <%#Eval("CategoryName") %>
                    </td>
                    <td>
                        <%#Eval("GuestQuantity")%>位
                    </td>
                    <td>
                        <%#Eval("GuestEmail")%>
                    </td>
                    <td>
                        <%#Eval("GuestMobile")%>
                    </td>
                    <td>
                        <%#(int)Eval("GuestAttended")==0?"未":"是"%>
                    </td>
                    <td>
                        <%#CommonLibrary.Utility.DateHelper.FormatDateTimeToString((DateTime)Eval("CreateOn"), CommonLibrary.Utility.DateHelper.DateFormat.yyMMddHHmms)%>
                    </td>
                    <td>
                        <%#CommonLibrary.Utility.DateHelper.FormatDateTimeToString((DateTime)Eval("UpdateOn"), CommonLibrary.Utility.DateHelper.DateFormat.yyMMddHHmms)%>
                    </td>
                    <td>
                        未
                    </td>
                </tr>
                <tr>
                    <td colspan="13" class="td">
                    <div id="dv-guest-edit-<%#Eval("GuestCode") %>" style="display:none;min-height:100px;"></div>
                        <div class="line2">
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <%if (Total > PageSize)
          { %>
        <tr>
            <td colspan="13" class="td">
                
            </td>
        </tr>
        <%} %>
    </table>
</div>
