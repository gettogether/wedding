<%@ Page Language="C#" MasterPageFile="~/V1/MP_LinksOnly.master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="V1_login" Title="Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        ul
        {
            float: left;
            margin-top: 5px;
            width: 100%;
        }
        li
        {
            width: 80px;
            float: left;
            list-style: none;
            white-space: nowrap;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div style="width: 380px; margin-top: 200px; text-align: left;">
            <div>
                <h2>
                    大日子</h2>
            </div>
            <div style="min-height: 250px; padding-bottom: 10px;" class="box" id='dv-login-form'>
                <div>
                    <ul>
                        <li style="width: 160px;">
                            <h3>
                                選擇您的大日子</h3>
                        </li>
                    </ul>
                    <ul>
                        <li>電郵地址</li><li>
                            <input type="text" class="txt" id="LG_Email" value="wedding-app@qq.com" /></li>
                    </ul>
                    <ul>
                        <li>密碼</li><li>
                            <input type="password" class="txt" id="LG_Pwd" value="111111" /></li>
                    </ul>
                    <ul>
                        <li>&nbsp;</li>
                        <li>
                            <input type="checkbox" id="LG_RememberLogin" /><label for="LG_RememberLogin">記住登入</label>
                            <a href="#">忘記密碼</a></li></ul>
                    <ul>
                        <li>&nbsp;</li><li>
                            <input type="button" class="btn2" id="btn-login" value="登錄" /><input type="button"
                                style="margin-left: 15px;" class="btn1" id="btn-reg" value="註冊" /></li></ul>
                    <br />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">

    <script src="web1/js/login.js" type="text/javascript"></script>

</asp:Content>
