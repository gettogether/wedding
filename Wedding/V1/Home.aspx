<%@ Page Language="C#" MasterPageFile="~/V1/MP.master" AutoEventWireup="true" CodeFile="Home.aspx.cs"
    Inherits="V1_Home" Title="Home" %>
<%@ Register src="~/V1/Components/Guest/GuestEdit.ascx" tagname="GuestEdit" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content-index">
        <div style="float: left; width: 60%;">
            <div class="box-content">
                <div class="box-title">
                    日程表</div>
                <table style="width: 100%;">
                    <tr class="tb-header">
                        <td>
                            <input type="checkbox" />
                        </td>
                        <td>
                            將會進行的事件
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" />
                        </td>
                        <td>
                            21,Now2011 18:00 試衫
                        </td>
                    </tr>
                </table>
            </div>
            <div class="box-content">
                <div class="box-title">
                    賓客回應</div>
                <div style="padding: 5px 5px;">
                    暫沒賓客回應消息</div>
            </div>
        </div>
        <div style="float: right; width: 39%; margin-left: 10px;">
            <div class="box-content">
                <div class="box-title">
                    分享您的大日子</div>
                <div>
                    <img src="http://www.egil.cn/blog/attachments/month_0805/4200851113315.jpg" /></div>
                <div class="line">
                </div>
                <div style="margin: 5px 0px 10px 0px; text-align: center;">
                    <a href="#">寄給朋友</a></div>
            </div>
        </div>
    </div>
    <div id="content-party" style="display: none;">
        <div id="party-guest" class="box-content">
            <div class="box-title">
                賓客列表</div>
            <div style="padding: 5px 5px;">
            <div id="dv-guest-search-form">
            客人名稱(英文):<input type="text" class="txt" id="GuestSch_GuestName_en_us" style="width:100px;" />
            客人名稱(中文):<input type="text" class="txt" id="GuestSch_GuestName_zh_tw" style="width:100px;" />
            <input type="button" class="btn1" value="刷新" onclick="GuestSearch();"/>
            
            </div>
            <div id="dv-guest-search-content" style="min-height:80px;margin-top:5px;display:none;"></div>
                </div>
            <div class="line">
            </div>
            <div style="padding: 5px 5px;">
                上載名單</div>
            <div style="margin: 0px 10px 10px 10px;" class="box2">
                <div style="padding: 3px 0px 3px 3px;">
                    <input type="file" disabled="disabled" />&nbsp;<input disabled="disabled" type="button" class="btn1" value="上載" /></div>
                <div style="margin: 0px 5px 5px 0px;">
                    *格式必須是xls&nbsp;(<a href="#">Excel示例模板下載</a>)</div>
            </div>
            <div class="line">
            </div>
            <div style="padding: 5px 5px;">
                新增賓客資訊</div>
            <div id="dv-guest-add" style="margin: 0px 10px 10px 10px;" class="box2">
                <uc2:GuestEdit ID="GuestEdit1" runat="server" />
            </div>
        </div>
        <div id="party-area" style="display: none;">
            <div id="CircleGroup">
                <div class="outer-circle" id="1">
                    <div class="inner-circle">
                        <span class="table-cell">亲属席<br />
                            二伯父</span></div>
                </div>
                <div class="outer-circle" id="2">
                    <div class="inner-circle">
                        <span class="table-cell">亲属席<br />
                            三伯父</span></div>
                </div>
                <div class="outer-circle" id="3">
                    <div class="inner-circle">
                        <span class="table-cell">朋友席<br />
                            张三</span></div>
                </div>
                <div class="outer-circle" id="4">
                    <div class="inner-circle">
                        <span class="table-cell">朋友席<br />
                            李四</span></div>
                </div>
                <div class="close-circle" id="CloseCircle" field_id="" style="z-index: 1000; display: none;">
                    X
                </div>
            </div>
        </div>
        <div id="party-invite" class="box-content" style="display:none;">
            <div class="box-title">
                發送邀請</div>
            
            <div style="padding: 10px 10px;">
                <div class="box2">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 50px;">
                                賓客
                            </td>
                            <td>
                                <input type="text" class="txt" style="width: 99%;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                主題
                            </td>
                            <td>
                                <input type="text" class="txt" style="width: 99%;" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                正文
                            </td>
                            <td>
                                <div style="border: solid 1px #cccccc; background-color: White;">
                                    <textarea rows="20" cols="20" style="width: 99%; border: none;"></textarea></div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="line" style="margin:5px 0px;"></div>
                 <div><input type="button" class="btn1" value="發送" /></div>
            </div>
           
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
