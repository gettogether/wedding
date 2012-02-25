<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="V1_Components_Header" %>
<div style="background-color: #bf7fa0; float: left; width: 100%; color: #fff;">
    <div style="margin: 5px 5px 25px 5px;">
        <div style="float: left;">
            歡迎您<%=CurrentSession.Profile.LoginUser.BrideName %>
            &
            <%=CurrentSession.Profile.LoginUser.CroomName %>
        </div>
        <div style="float: right;">
            <a href="#">我的帳戶</a>&nbsp; | &nbsp; <a href="login.aspx?out=1">登出</a></div>
    </div>
</div>
<div style="float: left;">
    <div style="margin: 20px 0px;">
        <span style="font-size: 22pt;">大日子</span> (<%=CurrentSession.Profile.BigDate.BigDateName %>[<span class="days-counter"><%=CurrentSession.Profile.BigDate.BigDate.ToString("MMM dd yyyy")%></span>]) 還有<span class="days-counter"><%=CurrentSession.Profile.BigDate.BigDate.Subtract(DateTime.Now).Days%></span>日就到您們的大日子.
    </div>
</div>
<div id="lay_menu">
    <div style="float: left" class="div-tab">
        <ul tabs="1">
            <li onclick="chShift(this,'N');fIndex();" data="index" class="li-focus">主頁 </li>
            <li onclick="chShift(this,'N');fParty();" data="party">我的婚宴 </li>
        </ul>
    </div>
    <div style="float: left; width: 100%;">
        <div id="index" class="div-tab-content">
            <%--<a href="#">日程</a>&nbsp;|&nbsp;<a href="#">賓客回應</a>&nbsp;|&nbsp;--%>
            日程 / 賓客回應 / 分享
        </div>
        <div id="party" class="div-tab-content" style="display: none;">
            <a href="#" onclick="fSubContent('party','guest',this);" class="a-focus">我的賓客</a>&nbsp;|&nbsp;<a href="#"
                onclick="fSubContent('party','area',this);">婚宴場地</a>&nbsp;|&nbsp;<a href="#" onclick="fSubContent('party','invite',this);">發送邀請</a></div>
    </div>
</div>
