<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GuestEdit.ascx.cs" Inherits="V1_Components_Guest_GuestEdit" %>
 <table>
                    <tr>
                        <td>
                            稱謂
                        </td>
                        <td>
                            客人名稱(英文)
                        </td>
                        <td>
                            客人名稱(中文)
                        </td>
                        <td>
                            類別
                        </td>
                        <td>
                            占席
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=WeddingLibrary.Web.Imp.Title.GenTitle(CurrentSession.Profile.BigDate.BigDateCode, "Guest_TitleCode", "sel", Guest.TitleCode, "","")%>
                            <a href="#">管理稱謂</a>
                        </td>
                        <td>
                            <input type="text" required="1" style="width:100px;" id="Guest_GuestName_en_us" value="<%=Guest.GuestName_en_us %>" class="txt" />
                        </td>
                        <td>
                            <input type="text" class="txt" required="1" style="width:100px;" id="Guest_GuestName_zh_tw" value="<%=Guest.GuestName_zh_tw %>" />
                        </td>
                        <td>
                             <%=WeddingLibrary.Web.Imp.Category.GenCategory(CurrentSession.Profile.BigDate.BigDateCode, "Guest_CategoryCode", "sel", Guest.CategoryCode, "","")%>
                            <a href="#">管理類別</a>
                        </td>
                        <td>
                          <%=CommonLibrary.WebObject.HtmlHelper.GenSelectForNumber(Guest.GuestQuantity.ToString(), "Guest_GuestQuantity", "sel", "", "", 1, 10, 1)%>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            顯示格式:
                        </td>
                        <td>
                            <input type="radio" id="Guest_Format_EN" onclick="$('#Guest_GuestNameFormat').val(0);" checked="checked" name="Guest_Format" /><label for="Guest_Format_EN">英文風格</label>
                            <input type="radio" id="Guest_Format_CN"onclick="$('#Guest_GuestNameFormat').val(1);" name="Guest_Format" /><label for="Guest_Format_CN">中文風格</label>
                            <input type="text" id="Guest_GuestNameFormat" value="0" style="display:none;" />
                        </td>
                        <td>
                        查找關鍵字:
                       </td>
                        <td><input type="text" id="Guest_GuestQueryWords" value="<%=Guest.GuestQueryWords %>" class="txt" />
                        
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            郵箱地址
                        </td>
                        <td>
                             <input type="text" class="txt" value="<%=Guest.GuestEmail %>" id="Guest_GuestEmail"/>
                        </td>
                        <td>手機號碼</td>
                        <td><input type="text" class="txt" id="Guest_GuestMobile" value="<%=Guest.GuestMobile %>" />
                        </td>
                        <td>
                         <input type="button" class="btn1" onclick="GuestSave('<%=Guest.GuestCode%>');" value="<%=string.IsNullOrEmpty(Guest.GuestCode)?"增加":"修改" %>" />
                        </td>
                    </tr>
                </table>