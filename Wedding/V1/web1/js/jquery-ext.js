
//jquery plugin include http://plugins.jquery.com/project/includedemand
var SerUrlValue='';
if(typeof(SerUrl)!='undefined'&&SerUrl!=null)SerUrlValue=SerUrl;
(function(a){a.extend({ImportBasePath:"",__WaitingTasks:new Object(),__loadedSuccessfully:function(c,b){if(c in a.__WaitingTasks){if((a.__WaitingTasks[c].loading-=1)<1){var d=a.__WaitingTasks[c].task;if(typeof d=="function"){d()}delete a.__WaitingTasks[c]}}},fileinfo:function(c){c=c.replace(/^\s|\s$/g,"");var b;if(/\.\w+$/.test(c)){b=c.match(/([^\/\\]+)\.(\w+)$/);if(b){if(b[2]=="js"){return{filename:b[1],ext:b[2],tag:"script"}}else{if(b[2]=="css"){return{filename:b[1],ext:b[2],tag:"link"}}else{return{filename:b[1],ext:b[2],tag:null}}}}else{return{filename:null,ext:null}}}else{b=c.match(/([^\/\\]+)$/);if(b){return{filename:b[1],ext:null,tag:null}}else{return{filename:null,ext:null,tag:null}}}},fileExist:function(c,e,b){var f=document.getElementsByTagName(e);for(var d=0;d<f.length;d++){if(f[d].getAttribute(b)==a.ImportBasePath+c){return true}}return false},createElement:function(c,d){switch(d){case"script":if(!a.fileExist(c,d,"src")){var e=document.createElement(d);e.setAttribute("language","javascript");e.setAttribute("type","text/javascript");e.setAttribute("src",a.ImportBasePath+c);return e}else{return false}break;case"link":if(!a.fileExist(c,d,"href")){var b=document.createElement(d);b.setAttribute("type","text/css");b.setAttribute("rel","stylesheet");b.setAttribute("href",a.ImportBasePath+c);return b}else{return false}break;default:return false;break}},cssReady:function(d,e){function c(){for(var f=0;f<document.styleSheets;f++){var g=new RegExp(d+"$");if(g.exec(document.styleSheets[f].href)){window.clearInterval(b);a.__loadedSuccessfully(e);return}}}var b=window.setInterval(c,200)},include:function(d,k){var h=document.getElementsByTagName("head")[0];var b=document.getElementsByTagName("body")[0];var e=[];typeof d=="string"?e[0]=d:e=d;var j=new Date().getTime().toString();a.__WaitingTasks[j]={loading:e.length,task:k};for(var f=0;f<e.length;f++){var g=a.fileinfo(e[f]).tag;var c=[];if(g!==null){c[f]=a.createElement(e[f],g);if(c[f]){if(g=="link"){h.appendChild(c[f])}else{b.appendChild(c[f])}if(a.browser.msie){c[f].onreadystatechange=function(){if(this.readyState==="loaded"||this.readyState==="complete"){a.__loadedSuccessfully(j)}}}else{if(g=="link"){a.cssReady(a.fileinfo(e[f]).filename,j)}else{a(c[f]).load(function(){a.__loadedSuccessfully(j)})}}}else{a.__loadedSuccessfully(j)}}else{return false}}}})})(jQuery);
//jquery outerHtml
(function($) {
    $.fn.outerHTML = function(s) {
        return (s) ? this.before(s).remove() : $('<p>').append(this.eq(0).clone()).html();
    }
})(jQuery);
function CommonSearch(Url,type,divId,divBgId,divParId,inputPrefix,parAppend,pageIndex,pageSize,sortBy,isAsc,dType,jsFun,funComplete)
{
    var params="";
    params=getParams(divParId,inputPrefix);
    if(IsEmpty(params))params="";
    if(!IsEmpty(pageIndex)){params+="&page="+pageIndex;}
    if(!IsEmpty(pageSize)){params+="&size="+pageSize;}
    if(!IsEmpty(sortBy)){params+="&sort="+sortBy;}
    if(!IsEmpty(isAsc)){params+="&asc="+(isAsc?"Y":"N");}
    if(!IsEmpty(parAppend)){params+=parAppend;}
    params="type="+type+"&parms="+params;
    CallAjaxForGetList(SerUrlValue+Url,params,divId,divBgId,dType,jsFun,funComplete);
}

function CommonCall(Url,type,divId,divBgId,divParId,inputPrefix,parAppend,dType,jsFun,funComplete)
{
    var params="";
    params=getParams(divParId,inputPrefix);
    if(IsEmpty(params))params="";
    if(!IsEmpty(parAppend)){params+=parAppend;}
    params="type="+type+"&parms="+params;
    CallAjaxForGetList(SerUrlValue+Url,params,divId,divBgId,dType,jsFun,funComplete);
}

function CallAjaxForGetList(url, params, divId, divBgId, dType, jsFun,funComplete) {
    if (dType == null) dType = "text";
    $.ajax({
        url: url+(url.indexOf('?')>-1?'&':'?')+'_r='+Math.random(),
        type: 'post',
        cache: false,
        dataType: dType,
        data: params,
        beforeSend: function() {
            if (!IsEmpty(divBgId)) sld(divBgId);
        },
        error: function(XMLHttpRequest, textStatus, errorThrown) {
            if (IsTimeout(XMLHttpRequest.responseText)) { RedirectLogin(); return;}
            if (!IsEmpty(divBgId)) CloseMsgBox();
            $("#" + divId).html('error occured.');
        },
        success: function(data, textStatus) {
	   	    if (IsTimeout(data)) { RedirectLogin(); return;}	
            if (dType == 'text'||dType == 'html') {
                if (!IsEmpty(divBgId)) CloseMsgBox();
                if (!IsEmpty(divId)) $("#" + divId).html(data);
                if (jsFun != null)
                {
                    if($.isFunction(jsFun))
                        jsFun(data,textStatus);
                    else    
                        eval(jsFun);
                }
            }
            else if (dType == 'json') {
                if (data.success) {
                    if (jsFun != null)
                    {
                        if($.isFunction(jsFun))
                            jsFun(data,textStatus);
                        else    
                            eval(jsFun);
                    }
                }
                else {
                    if (!IsEmpty(divBgId))
                        CM();
                    MsgBox(data.message, 'System Information', true, divBgId);
                }
            }
            if (funComplete != null) {
                if ($.isFunction(funComplete))
                    funComplete(data, textStatus);
                else
                    eval(funComplete);
            }
        }
    });
}
//CallAjaxForDelSel('Callback/Sys/RightRef.aspx',3,'RC','keys','dv_rightRef_list','content','','','','json','SearchRightRefList();')
function CallAjaxForDelSel(Url,type,chkPrefix,callBackParaName,divId,divBgId,divParId,inputPrefix,parAppend,dType,jsFunc,isChecked)
{
    var params="";
    if(IsEmpty(dType)) dType='json';
    if(!IsEmpty(callBackParaName)) params="&"+callBackParaName+'='+GetSelect(divId,chkPrefix,isChecked);
    if(!IsEmpty(params))parAppend=parAppend+params;
    CommonCall(Url,type,divId,divBgId,divParId,inputPrefix,parAppend,dType,jsFunc);
}
function ConfirmAndDelSel(Url, type, chkPrefix, callBackParaName, divId, divBgId, divParId, inputPrefix, parAppend, dType, jsFunc, isChecked, confirmMsg, atLeastMsg)
{
   if (atLeastMsg == null)
        atLeastMsg = 'You must select at least one item.';
   if (confirmMsg == null)
       confirmMsg = 'Are you sure to delete the select items?'
   if (GetSelect(divId, chkPrefix, isChecked) == '') { MsgBox(atLeastMsg, 'Information', true, divBgId); return; } 
   Confirm(confirmMsg,'Information',true,divBgId,'CallAjaxForDelSel(\''+Url+'\','+type+',\''+chkPrefix+'\',\''+callBackParaName+'\',\''+divId+'\',\''+divBgId+'\',\''+divParId+'\',\''+inputPrefix+'\',\''+parAppend+'\',\''+dType+'\',\''+jsFunc+'\','+isChecked+')');
}
function ConfirmAndDelSelCss(content,title,Url,type,chkPrefix,callBackParaName,divId,divBgId,divParId,inputPrefix,parAppend,dType,jsFunc,isChecked)
{
   if(GetSelect(divId,chkPrefix,isChecked)==''){ MsgBox('You must select at least one item!','Information',true,divId);return;} 
   Confirm(content,title,true,divBgId,'CallAjaxForDelSel(\''+Url+'\','+type+',\''+chkPrefix+'\',\''+callBackParaName+'\',\''+divId+'\',\''+divBgId+'\',\''+divParId+'\',\''+inputPrefix+'\',\''+parAppend+'\',\''+dType+'\',\''+jsFunc+'\','+isChecked+')','btn7','btn4');
}
function ValidateTxt(dvForm,prefix,inputTypes)
{
    var success=true;
    $((inputTypes==null||inputTypes=='')?'input:text:visible':inputTypes,dvForm==null?null:('#'+dvForm)).filter(IsEmpty(prefix)?'*':"[id^='"+prefix+"']").each(function(i) {
        if (isRequired(this) && $.trim(this.value) == "") {
               $(this).addClass('txtrq').removeClass('txt');
               success = false; 
        }
        else{
               $(this).addClass('txt').removeClass('txtrq');
        }
    });
    return success;
}
function ValidateTxtAndSel(dvForm,prefix,inputTypes)
{
    var success=true;
    success=ValidateTxt(dvForm,prefix,inputTypes);
    success=ValidateSel(dvForm,prefix,inputTypes) && success;    
    return success;
}
function ValidateSel(dvForm,prefix,inputTypes)
{
   var success=true;
    $((inputTypes==null||inputTypes=='')?'select:visible':inputTypes,dvForm==null?null:('#'+dvForm)).filter(IsEmpty(prefix)?'*':"[id^='"+prefix+"']").each(function(i) {        
        if(isRequired(this) && $.trim(this.value)=="")
        {
            if($(this).is('.sel'))
                $(this).removeClass('sel').addClass('sel_rq');
            else if($(this).is('.select'))
                $(this).removeClass('select').addClass('select_rq'); 
            success=false;
        }
        else{
            if($(this).is('.sel_rq'))
                $(this).removeClass('sel_rq').addClass('sel');
            else if($(this).is('.select_rq'))
                $(this).removeClass('select_rq').addClass('select');    
        }
    });
    return success;
}
function ValidateTextareaLenghth(dvForm,maxlength,prefix,inputTypes)
{
    var success=true;
    maxlength=maxlength=null?500:maxlength;
    $((inputTypes==null||inputTypes=='')?'textarea:visible':inputTypes,dvForm==null?null:('#'+dvForm)).filter(IsEmpty(prefix)?'*':"[id^='"+prefix+"']").each(function(i) {
        if(this.value.length>maxlength)
        {
            success=false;
            $(this).addClass('textarea_rq').removeClass('textarea');
        }
        else
        {
            $(this).addClass('textarea').removeClass('textarea_rq');
        }
    });
    return success;
}
function ValidateTxtAndAreaAndSel(dvForm,prefix,inputTypes){
    var success=true;
    success=ValidateTxt(dvForm,prefix,inputTypes)
    success=ValidateTxtArea(dvForm,prefix,inputTypes) && success;
    success=ValidateSel(dvForm,prefix,inputTypes)  && success;    
    return success;    
}
function ValidateTxtArea(dvForm,prefix,inputTypes){
    var success=true;
    $((inputTypes==null||inputTypes=='')?'textarea:visible':inputTypes,dvForm==null?null:('#'+dvForm)).filter(IsEmpty(prefix)?'*':"[id^='"+prefix+"']").each(function(i) {
        if(isRequired(this) && $.trim(this.value)=='')
        {
            $(this).addClass('textarea_rq').removeClass('textarea');
            success=false;
        }
        else
        {
            $(this).addClass('textarea').removeClass('textarea_rq');
        }
    });
    return success;    
}
function SelectAll(chkObj,chkPrefix,divID)
{
    var chks;
    if(IsEmpty(divID))
       chks=$('input:checkbox');
    else
       chks=$('input:checkbox','#'+divID)           
    chks.each(function(i){
        if(!this.disabled)
        {
            if(IsEmpty(chkPrefix)||this.id.indexOf(chkPrefix,0)>-1)
            {
                this.checked=chkObj.checked;
            }
        }
    });     
}

function GetSelect(divId,chkPrefix,isChecked,separator,includeDisabled)
{
    var sel="";
    if(IsEmpty(isChecked)) isChecked=true;
    var chks;
    if(IsEmpty(divId))
       chks=$('input:checkbox');
    else
       chks=$('input:checkbox','#'+divId)          
    chks.each(function(i){
        if(this.checked==isChecked&&(includeDisabled || !this.disabled)) {
           if(IsEmpty(chkPrefix)||(!IsEmpty(chkPrefix)&&this.id.indexOf(chkPrefix,0)>-1))
           {
              sel+=this.value+(separator==null? ",":separator);
           }
        }
    });
    var l = separator == null ? sel.length - 1 : sel.length - separator.length;
    sel=sel.substr(0,l);
    return encodeURIComponent(sel);
}

function AjaxMsg(title,width,height,serUrl,page,sId,func)
{
    var f=func;
    if(f==null)f=EndRequestAndValidate;
    MsgAjax(title,width,height,serUrl,page,sId,f);
}

function GetTextAreaPara(dvId,prefix)
{
    var params='';
    var isIE= $.browser.msie;
    $('textarea[id^="'+prefix+'"]','#'+dvId).each(function (){
        params += "&" + this.id + "=" + encodeURIComponent(isIE ? this.value : this.value.replace(/\n/g, '\r\n'));
    });
    return params;
}

/*usage:
<input id="txtDep" class="txt" style="width: 80px;" value='' type="text" maxlength="12" months='2' maxdate='10/12/2010' mindate='+1m'/>
<span id="cal-dep" class="img-cal">&nbsp;</span>
new RegDateControl('txtRet', "cal-ret", AirSchDate, true, 2, '+0d','err-tip',true);
remark:
if DateControljQuery numberOfMonths,minDate,maxDate not equal null,the parameter priority will higer than the control attribute
*/
function DateControljQuery(sId, butId, onchange, allowEmpty, left, top, error_lb, isAddErrCss,minDate, maxDate, numberOfMonths, isDateTime) {
    var lang=(typeof(LangType)=='undefined')? "en-us":LangType;
    var lid=null;
    var oj = o(sId);
    if (oj == null) { alert('Miss the "' + sId + '"'); return; }
    if (IsEmpty(isDateTime)) {
        if (!IsEmpty($(oj).attr("datetype")))
            isDateTime = $(oj).attr("datetype")=="datetime";
        else
            isDateTime = false;
    }
    if(isDateTime)
    {
        RegJs(SerUrlValue+"js"+(FVersion==null?"":FVersion)+"/jquery/jquery.ui.datetimepicker-"+lang+".js");
    }
    else
    {
        RegJs(SerUrlValue+"js"+(FVersion==null?"":FVersion)+"/jquery/jquery.ui.datepicker-"+lang+".js");
    } 
    RegCss(SerUrlValue+"css"+(FVersion==null?"":FVersion)+"/jquery-ui.css");   
    var errMsg = isDateTime ? "Invalid date time format" : "Invalid date format";
    if (oj.attributes["errmsg"] != null) { errMsg = oj.attributes["errmsg"].value; }
    if (oj.attributes["lid"] != null) { lid = oj.attributes["lid"].value; }
    
    if (IsEmpty(numberOfMonths)) {
        if (!IsEmpty($(oj).attr("months")))
            numberOfMonths = parseInt($(oj).attr("months"));
        else
            numberOfMonths = 1;
    }
    if (IsEmpty(maxDate)) {
        if (!IsEmpty($(oj).attr("maxdate")))
            maxDate = $(oj).attr("maxdate");
        else
            maxDate = null;
    }
    else
    {
        if(!TestType(maxDate,'date'))
        {
            if(ValidateDate(maxDate, isDateTime)){
                maxDate=ConvertDate(maxDate);
            }
        }    
    }
    if (IsEmpty(minDate)) {
        if (!IsEmpty($(oj).attr("mindate")))
            minDate = $(oj).attr("mindate");
        else
            minDate = null;
    }
    else
    {
        if(!TestType(minDate,'date'))
        {
            if(ValidateDate(minDate, isDateTime)){
                minDate=ConvertDate(minDate);
            }
        }    
    }
    var showAnim=null;
    var animDuration;
    if($.browser.msie)
    {
        if($.browser.version=='6.0')
        {
            showAnim=null;
            animDuration=100;
        }
        else
        {
            showAnim=null;
            animDuration=0;
        }
    }
    else
    {
        showAnim=null;
        animDuration=300;
    }
    
    //if (oj.attributes["errmsg"] != null) { errMsg = $(oj).attr("errmsg").value; }
    if(isDateTime)
    {
        $(oj).datetimepicker({
            buttonId: butId,
            showOn: 'button',
            buttonImageOnly: true,
            buttonText: 'Date',
            dateFormat: 'dd/mm/yyyy HH:MM',
            showButtonPanel: false,
            showAnim: null,
            duration: 100,
            changeYear: true,
            changeMonth: true,
            numberOfMonths: numberOfMonths,
            maxDate: maxDate,
            minDate: minDate,            
            yearRange: 'c-5:c+5',
            showButtonPanel:false
        });
    }
    else
    {
        $(oj).datepicker({
            buttonId: butId,
            showOn: 'button',
            buttonImageOnly: true,
            buttonText: 'Date',
            dateFormat: 'dd/mm/yy',
            showButtonPanel: false,
            showAnim: showAnim,
            duration: animDuration,
            changeYear: true,
            changeMonth: true,
            numberOfMonths: numberOfMonths,
            maxDate: maxDate,
            minDate: minDate,
            yearRange: 'c-5:c+5',
            showButtonPanel:false,
            left:left,
            top:top
        });
    }
    var lv = oj.value;
    oj.onfocus = "";
    oj.onblur = "";
    oj.onchange = function() { if (formatDate(oj, allowEmpty, isDateTime)) { if (isAddErrCss && error_lb!=null) { oj.className = 'txt'; o(error_lb).innerHTML = ''; } if (onchange != null && oj.value != "") { onchange(sId); } } else { if (isAddErrCss) { oj.className = 'txtrq'; } inputErr(); } };

    function inputErr() {
        if (error_lb == null)
            Error(errMsg,lid);
        else
            o(error_lb).innerHTML = errMsg;
        oj.value = lv;
    }
    return $(oj);
}

$.aws = function(url, dm, fs,dt) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: url,
        data: typeof dm=='string'?dm:o2s(dm),
        dataType: dt==null?"json":dt,
        success: fs
    });
}

function FixReportViewer()
{
    if(!$.browser.msie)
        $('table').each(function(){if(this.id.indexOf('ReportViewer')>0){if(this.title=='Refresh'){$(this).parent().css({"display":"none"});}}});
}

var loading = "<img src='" + SerUrlValue + "images/loading.gif' />";
var sloading = "<img src='" + SerUrlValue + "images/s_loading.gif' style='border-width:0px;'/>";
var hloading = "<img src='" + SerUrlValue + "images/hbload.gif' style='border-width:0px;'/>";
var errorImg = "<img src='" + SerUrlValue + "images/problem.gif' style='padding:0px 5px 0px 5px;' />";
function GetLoading(img)
{
    return "<img src='" + SerUrlValue + "images/"+img+"' style='border-width:0px;'/>";
}
function IsTimeout(ret_text) {
    return ret_text == "Timeout";
}
function RedirectLogin() {
    window.location = SerUrlValue + 'login.aspx' + '?to=1' + GetPara("lang");
}
function EndRequestAndValidate(str,objId)
{
    if(IsTimeout(str))RedirectLogin();
    else if(o(objId)!=null) o(objId).innerHTML=str;
}
function ValidateSession(ret_text) {
    if (IsTimeout(ret_text)) { RedirectLogin(); return false; }
    else
        return true;
}
function GetPara(lang) {
    if (GetUrlParaValue(lang))
    { return "&lang=" + GetUrlParaValue("lang"); }
    return "";
}
function GetUrlParams(url) {
    if (url == null) url = location.search.substring(1); 
    var ps = new Object();
    var psi = url.split("&");
    for (var i = 0; i < psi.length; i++) {
        var pos = psi[i].indexOf('='); 
        if (pos == -1) continue;
        var n = psi[i].substring(0, pos);
        var v = psi[i].substring(pos + 1);
        ps[n] = unescape(v);
    }
    return ps;
}
function GetUrlParaValue(argname) {
    return GetUrlParams()[argname];
}
function ChangeSort(value) {
    sld();
    var url = GetCurrentPage();
    if (url.indexOf('#') > 0)
        url = url.substring(0, url.indexOf('#'))
    window.location = url + '?sort=' + value;
}
function ChangePageSize(obj, evalCode) {
    sld();
    if (evalCode != null && evalCode != "") { eval(evalCode.replace("{0}", obj.value)); }
    else {
        var url = GetCurrentPage();
        if (url.indexOf('#') > 0)
            url = url.substring(0, url.indexOf('#'))
        window.location = url + '?size=' + obj.value;
    }
}
function ChangePageSizeNoSld(obj, evalCode) {
    if (evalCode != null && evalCode != "") { eval(evalCode.replace("{0}", obj.value)); }
    else {
        var url = GetCurrentPage();
        if (url.indexOf('#') > 0)
            url = url.substring(0, url.indexOf('#'))
        window.location = url + '?size=' + obj.value;
    }
}
$(document).ready(function(){
    $.ajaxSetup({
        random: Math.random(),
        cache: false,
        error: function(XMLHttpRequest, textStatus, errorThrown) {
            if (IsTimeout(XMLHttpRequest.responseText)) { RedirectLogin(); return;}
            else throw(errorThrown);
        }
    });
});
function SelectAdd(obj, value, text, position) {
    var $option=$('<option>').val(value).text(text);
    if(position==null||obj.options.length-1<position)
        $option.appendTo(obj);
    else
        $option.insertBefore(obj.options[position]);
}
function o(obj) { return document.getElementById(obj); }
function oaen(obj) { return encodeURIComponent(o(obj).value); }
function oa(obj) {var oj=o(obj);return oj==null?"":oj.value; }
function sf(sId) { if (o(sId) == null) return; try { o(sId).focus(); } catch (e) { } }
function IsEmpty(fData) { return ((fData == null) || (fData.length == 0)) }
function IsEmail(mail) { return (new RegExp(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/).test(mail)); }
function IsEmails(mails) { var m = mails.split(','); for (var i = 0; i < m.length; i++) { if (!IsEmail(m[i])) return false; } return true; }
function chkEmail(sId, dId, allowEmpty) {
    var v = oa(sId);
    if (allowEmpty) {
        if (IsEmpty(v)) { return true; }
    }
    if (IsEmail(v)) { return true; }
    else { o(dId).innerHTML = $('#'+sId).attr('erremail'); sf(sId); }
    return false;
}
function IsPhone(fData) { var str; var fDatastr = ""; if (IsEmpty(fData)) { return false; } for (var i = 0; i < fData.length; i++) { str = fData.substring(i, i + 1); if (str != "(" && str != ")" && str != "（" && str != "）" && str != "+" && str != "-" && str != " ") { fDatastr = fDatastr + str; } } if (isNaN(fDatastr)) { return false } return true; }
function copyAttributes(obj, copyTo) {
    $.each(obj.attributes,function(){
        if(this.name!='id'&&this.name!='name')
            $(copyTo).attr(this.name,this.value);
    });
}
function getParams(dvId, str,inputTypes) {
    if (IsEmpty(dvId)) return '';
    str=IsEmpty(str)?'':str;
    var params = "";
    function setParams(subObj) {
        if (subObj.id.indexOf(str, 0) >= 0) {
            if (subObj.type.toLowerCase() == "checkbox")
            { params += "&" + subObj.id + "=" + (($(subObj).val()==''||$(subObj).val()=='on')? subObj.checked:encodeURIComponent(subObj.value)); }
            else { params += "&" + subObj.id + "=" + encodeURIComponent(subObj.value); }
        }
    }
    if(inputTypes==null)
    {
        inputTypes=$('#'+dvId).attr('parameters');
    }
    $((inputTypes==null||inputTypes=='')?'input,select':inputTypes,dvId==null?null:('#'+dvId)).each(function(){
        setParams(this);
    });
    return params;
}

function getParamsIgnoreReadonly(dvId, str) {
    if (IsEmpty(dvId)) return '';
    str = IsEmpty(str) ? '' : str;
    var params = "";
    var isIE = $.browser.msie;
    function setParams(subObj) {
        if (subObj.id.indexOf(str, 0) >= 0) {
            if (subObj.type.toLowerCase() == "checkbox")
            { params += "&" + subObj.id + "=" + (($(subObj).val() == '' || $(subObj).val() == 'on') ? subObj.checked : encodeURIComponent(subObj.value)); }
            else {
                var v= $.trim(subObj.value);
                if (!isIE && subObj.type.toLowerCase() == 'textarea')
                    v = v.replace(/\n/g, '\r\n');
                params += "&" + subObj.id + "=" + encodeURIComponent(v);
              }
        }
    }
    $('input,select,textarea', dvId == null ? null : ('#' + dvId)).each(function() {
        if ($(this).attr('disabled') || $(this).attr('readonly'))
            return;
        else
            setParams(this);
    });
    return params;
}

function getParamsToJson(dvId, prefixStr, isKeepPrefix, isEncoding) {
    if (IsEmpty(dvId)) return '';
    prefixStr=IsEmpty(prefixStr)?'':prefixStr;
    isEncoding = (typeof(isEncoding)!='undefined'&&isEncoding!=null&&isEncoding)?true:false;
    var params = {};
    function setParams(subObj) {
        var jsonName = subObj.id.split(prefixStr)[1];
        if(typeof(isKeepPrefix)!='undefined'&&isKeepPrefix!=null&&isKeepPrefix)
        {
            jsonName = subObj.id;
        }
        if (subObj.id.indexOf(prefixStr, 0) >= 0) {
            if (subObj.type.toLowerCase() == "checkbox")
            { params[jsonName] = (($(subObj).val()==''||$(subObj).val()=='on')? subObj.checked:(isEncoding?encodeURIComponent(subObj.value):subObj.value)); }
            else { params[jsonName] = isEncoding?encodeURIComponent(subObj.value):subObj.value; }
        }
    }
    $('input,select',dvId==null?null:('#'+dvId)).each(function(){
        setParams(this);
    });
    return params;
}

function tableScroll(divId, tbId, hdrId) {
    var ds = o(tbId);
    var dsDIV = o(divId);
    var pad = ds.getAttribute("cellpadding");
    var dsTR = ds.getElementsByTagName("tr")[0];
    var divHdr = o(hdrId);
    //divdocument.createElement("div");
    //divDS.parentNode.appendChild(divHdr);
    //divHdr.style.cssText="position: absolute; text-align: center;";
    divHdr.style.width = dsDIV.clientWidth + "px";

    var tbHdr = document.createElement("table");
    //tbHdr.id='tbHdr';
    divHdr.appendChild(tbHdr);
    copyAttributes(ds, tbHdr);

    var tr = tbHdr.insertRow(0);
    copyAttributes(dsTR, tr);
    for (var i = 0; i <= dsTR.getElementsByTagName("td").length - 1; i++) {
        var dsTD = dsTR.getElementsByTagName("td")[i];
        var td = tr.insertCell(i);
        td.innerHTML = dsTD.innerHTML;
        copyAttributes(dsTD, td);
        td.style.width = dsTD.offsetWidth - (pad * 2) + "px";
    }
    tbHdr.style.width = ds.clientWidth + "px";
}
if(typeof(String.prototype.trim)=="undefined")
{
    String.prototype.trim = function()
    { return $.trim(this); };
}
Array.prototype.clean = function(C)
{ var B = []; for (var A = 0; A < this.length; A++) { if (this[A] != C) { B.push(this[A]) } } return B };
Array.prototype.indexOf = function(B) { for (var A = 0; A < this.length; A++) { if (this[A] == B) { return A } } return -1 };
function a(objId, url, pars, method, onComplete, asynchronous, args)
{
     $.ajax({
        url: url+(url.indexOf('?')>-1?'&':'?')+'_r='+Math.random(),
        type: method.toLowerCase()=='get'?'get':'post',
        cache: false,
        async:asynchronous,
        dataType: 'text',
        data: pars,
        error: function(XMLHttpRequest, textStatus, errorThrown) {
            if (IsTimeout(XMLHttpRequest.responseText)) { RedirectLogin(); return;}
            $("#" + objId).html('error occured.');
        },
        success: function(data, textStatus) {
            if (IsTimeout(data)) { RedirectLogin(); return;}
            if ($.isFunction(onComplete))
                onComplete(data, objId, args);
            else if(typeof(onComplete)=="string")
                eval(onComplete);
        }
    });
}
function EndRequest(responseTest, objId, args) { if (o(objId) != null) o(objId).innerHTML = responseTest; }
function addEvent(obj, evenTypeName, fn) { $(obj).bind(evenTypeName,fn);}
function removeEvent(obj, type, fn) {
    $(obj).unbind(evenTypeName,fn);
}
function getUrlParam(pn) {
    var v= GetUrlParams()[pn];return v == null ? "" : v;
}
function getUrlParameter(pn) { return getUrlParam(pn); }
function setUrlParam(url, param, v) {
    var re = new RegExp("(\\\?|&)" + param + "=([^&]+)(&|$)", "i");
    var m = url.match(re);
    if (m) {
        return (url.replace(re, function($0, $1, $2) { return ($0.replace($2, v)); }));
    }
    else {
        if (url.indexOf('?') == -1)
            return (url + '?' + param + '=' + v);
        else
            return (url + '&' + param + '=' + v);
    }
}
var Browser = new Object();
Browser.isIE =  $.browser.msie;
Browser.isIE7 = $.browser.msie&&$.browser.version=='7.0';
Browser.isIE8 = $.browser.msie&&$.browser.version=='8.0';
Browser.isMozilla = $.browser.mozilla;
GetBrowser = function() {
    var ua = navigator.userAgent;
    var i;

    var re = /(MSIE [1-9]\.[0-9])/;
    var matchResult = ua.match(re);
    if (ua.indexOf("TencentTraveler") >= 0) {
        return "TencentTraveler-" + matchResult[1] + navigator.appMinorVersion;
    }
    else if (ua.indexOf("Maxthon") >= 0) {
        return "Maxthon-" + matchResult[1] + navigator.appMinorVersion;
    }
    else if (ua.toLowerCase().indexOf("myie") >= 0) {
        return "MyIE-" + matchResult[1] + navigator.appMinorVersion;
    }
    else if (ua.indexOf("MSIE") >= 0) {
        return matchResult[1] + navigator.appMinorVersion;
    }
    i = ua.indexOf("Firefox");
    if (i >= 0) {
        return ua.substring(i);
    }
    i = ua.indexOf("Netscape");
    if (i >= 0) {
        return ua.substring(i);
    }
    i = ua.indexOf("Opera");
    if (i >= 0) {
        return ua.substring(i);
    }
    i = ua.indexOf("Konqueror");
    if (i >= 0) {
        return ua.substring(i, i + 13);
    }
    i = ua.indexOf("Chrome");
    if (i >= 0) {
        return ua.substring(i, i + 17);
    }
    return "OTHER";
}
function getAttibuteValue(sId, text) {
    return $('#'+sId).attr(text);
}
function isRequired(obj) {
    if (obj != null) {
        if($(obj).attr("disabled")) return false;
        return obj!=null && obj.attributes['required']!=null && (obj.attributes['required'].value=="1"||$(obj).attr('required')) && obj.attributes['required'].value!="0";
    }
    else { return false; }
}
//new DateControl('DateObj', "DateObj", DateRelation, true,null,null,null,null,new Date(),'15/08/2011',true);
function DateControl(sId, butId, onchange, allowEmpty, left, top, error_lb, isAddErrCss, minDate, maxDate, numberOfMonths, isDateTime) {
    return DateControljQuery(sId,butId,onchange,allowEmpty,left,top,error_lb,isAddErrCss,minDate,maxDate,numberOfMonths,isDateTime);
}
//format ddMMyyyy,ddMMMyyyy to dd/MM/yyyy 
function formatDate(oj, allowEmpty, isDateTime) {
    if(isDateTime==null) isDateTime = false;
    var str = oj.value;
    if (allowEmpty) { if (str == "") return true; }
    if (str == "") { return false; }
    var month_array = new Array("", "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC");
    var d = str;
    var m = d.match(/^(\d{2})([a-zA-Z]{3}|\d{2})(\d{2,4})( \d{2}:\d{2})?$/);
    if (!(m == null || (!isDateTime&&m.length < 4)||(isDateTime&&m.length<5))) {
        for (var j = 0; j < month_array.length; j++) {
            if (month_array[j] == m[2].toUpperCase()) {
                m[2] = j;
                if (j < 10) {
                    m[2] = "0" + m[2];
                }
            }
        }
        if (isNaN(m[2]) == false) {
            if (m[3].length < 3) {
                m[3] = "20" + m[3];
            }
        }
        str = m[1] + "/" + m[2] + "/" + m[3] + (isDateTime? " " + m[4] : "");
    }
    if (ValidateDate(str, isDateTime)) {
        oj.value = str;
        lv = str;
        return true;
    }
    else {
        return false;
    }
}

function ConvertDate(v,interval,num) {
    var vi=v.split(' ');
    var str=vi[0];
    var a = str.split('/');
    var nd=new Date(a[2], a[1] - 1, a[0]);
    var ret = interval!=null?DateAdd(interval,num,nd):nd;
    if(vi.length>1)
    {
        var ti=vi[1].split(':');
        ret.setHours(ti[0]);
        if(ti.length>1)ret.setMinutes(ti[1]);
        ret.setSeconds(0);
    }
    return ret;
}

function ValidateDate(str,isDateTime) {
    try {
        if(isDateTime==null) isDateTime = false;
        var datetime = str.split(' ')
        var dateinfo = datetime[0].split("/");
        if(isDateTime){
            if(datetime.length==2){
                var timeinfo = datetime[1].split(':');
                if(timeinfo.length!=2||timeinfo[0].length!=2||isNaN(parseInt(timeinfo[0],10))
                    ||parseInt(timeinfo[0],10) > 24||parseInt(timeinfo[0],10) < 0||timeinfo[1].length!=2
                    ||isNaN(parseInt(timeinfo[1],10))||parseInt(timeinfo[1],10) > 59||parseInt(timeinfo[1],10) < 0){
                    return false;
                }
            }
            else{
                return false;
            }
        }
        if (dateinfo.length == 3) {
            if (dateinfo[2].length != 4 || parseInt(dateinfo[1]) > 12 || dateinfo[1].length != 2)
                return false;
            var day = parseInt(dateinfo[0], 10);
            var moth = parseInt(dateinfo[1], 10);
            var year = parseInt(dateinfo[2], 10);
            var maxday = new Date(parseInt(year), parseInt(moth), 0).getDate();

            if (parseInt(day, 10) > parseInt(maxday, 10) || (parseInt(year, 10) > 2099 || parseInt(year, 10) < 1900)
                || parseInt(moth, 10) <= 0 || parseInt(day, 10) <= 0
                || isNaN(day) || isNaN(moth) || isNaN(year)) {
                return false;
            }
            else{
                return true;
            }
        }
        else{
            return false;
        }
    }
    catch (e) {
        alert(e);
        return false;
    }
}

function getDateToStr(date, isDateTime) {
    if(isDateTime==null) isDateTime = false;
    var d = date.getDate();
    var day = (d < 10) ? '0' + d : d;
    var m = date.getMonth() + 1;
    var month = (m < 10) ? '0' + m : m;
    var yy = date.getYear();
    var year = (yy < 1000) ? yy + 1900 : yy;
    var hour = (date.getHours()<10)?'0'+date.getHours():date.getHours();
    var minute = (date.getMinutes()<10)?'0'+date.getMinutes():date.getMinutes();
    return day + "/" + month + "/" + year + (isDateTime ? (" " + hour + ":" + minute) : "");
}
function compareDate(date1, date2, changeId, num, enforce, useDate2, isDateTime) {
     var obj = o(changeId);
     if (obj == null) { alert('Miss the "' + changeId + '"'); return; }
     if (IsEmpty(isDateTime)) {
        if (!IsEmpty($(obj).attr("datetype")))
            isDateTime = $(obj).attr("datetype")=="datetime";
        else
            isDateTime = false;
    }
    if (isNaN(date1) || isNaN(date2))
        return true;
    if (num == null) { num = 1; }
    if (daysElapsed(date2, date1, isDateTime) >= num && !enforce) {
        return true;
    }
    else {
        var d = DateAdd("D", num, useDate2==null||!useDate2?date1:date2);
        obj.value = getDateToStr(d, isDateTime);
        return false;
    }
}

var imgTipsSrc = "images/tips.gif";
function GetHtml(content, isError) {
    var imgsrc = SerUrlValue + imgTipsSrc;
    if (isError)
        imgsrc = imgErrorSrc;
    var fontcolor = "";
    if (isError)
        fontcolor = "red";
    var layer = "<div id='myDiv'>"
        + "<table onclick=\"RemovePopMain()\" width='238' border='0' cellspacing='5' class='boxblue' style='z-index:200'>"
        + "<tr>"
        + "<td valign=top><img src='" + imgsrc + "'></td>"
        + "<td width=100% valign=top><font color='" + fontcolor + "'>" + content + "</font></td>"
        + "</tr>"
        + "</table>"
        + "</div>";
    return layer;
}
function getScroll() {
    var t, l, w, h;
    if (document.documentElement && document.documentElement.scrollTop) {
        t = document.documentElement.scrollTop;
        l = document.documentElement.scrollLeft;
        w = document.documentElement.scrollWidth;
        h = document.documentElement.scrollHeight;
    }
    else if (document.body) {
        t = document.body.scrollTop;
        l = document.body.scrollLeft;
        w = document.body.scrollWidth;
        h = document.body.scrollHeight;
    }
    return { t: t, l: l, w: w, h: h };
}
function ShowDiv(content, width, height, bordercolor, borderstyle) {
    ShowDiv(content, width, height, bordercolor, "", 0, 0);
}
function ShowDiv(content, width, height, bordercolor, borderstyle, left, top, sId,bgColor) {
    if (o("alert_div") != null) {
        CloseMsgBox();
    }

    var scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    var scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    var clientWidth;
    if (window.innerWidth) {
        clientWidth = Math.min(window.innerWidth, document.documentElement.clientWidth);
    }
    else {
        clientWidth = document.documentElement.clientWidth;
    }
    var clientHeight;
    if (window.innerHeight) {
        clientHeight = Math.min(window.innerHeight, document.documentElement.clientHeight);
    }
    else {
        clientHeight = document.documentElement.clientHeight;
    }
    var alert_div = document.createElement("div");

    with (alert_div) {
        id = "alert_div";
        if (borderstyle == "MSGBOX") id = "alert_div_MSGBOX";
        style.position = "absolute";
        //style.zIndex = "1001";
        style.textAlign = 'center';
        style.verticalAlign = 'middle';
        if (width > 0)
            style.width = width + "px";
        if (height > 0)
            style.height = height + 'px';

        switch (borderstyle) {
            case "MSGBOX":
                var border = "<table border='0px' cellpadding='0px' cellspacing='0px' width='100%'><tr><td colspan='3' style='height: 5px' /></tr><tr><td class='msg-lt' /><td class='msg-mt' /><td class='msg-rt' /></tr><tr><td class='msg-l' /><td class='msg-bg' align='left'>" + content + "</td><td class='msg-r' /></tr><tr><td class='msg-lb' /><td class='msg-mb' /><td class='msg-rb' /></tr></table>";
                innerHTML = border;
                break;
            case "SHADOW":
                var border = "<div id=\"shadow\"><div class=\"shadow1\"><div class=\"shadow2\"><div class=\"shadow3\"><div class=\"content\">" + content + "</div></div></div></div></div>";
                innerHTML = border;
                break;
            default:
                innerHTML = content;
//                if (bordercolor != '') {
//                    style.border = "1px solid " + bordercolor;
//                    style.backgroundColor = '#F4F4F4';
//                }
                break;
        }
//        if(bgColor!=null)
//        style.backgroundColor=bgColor;
    }
    var bgObj = o('bgDiv');
    if (bgObj != null && sId != null) {
        var sTop = GetPosition(bgObj).top + (GetPosition(bgObj).height - height) / 2 - 20;
        //if (sTop > 500 && GetPosition(bgObj).height>1000) sTop = 500;
        alert_div.style.left = GetPosition(bgObj).left + (GetPosition(bgObj).width - width) / 2 + 'px';
        alert_div.style.top = sTop + 'px';
    }
    else {
        var nleft = (left == 0 ? scrollLeft + ((clientWidth - width) / 2) : left);
        if (nleft < 0) nleft = 0;
        alert_div.style.left = nleft + 'px';
        var ntop = (top == 0 ? scrollTop + ((clientHeight - height) / 2 - 20) : top);
        if (ntop < 0) ntop = 0;
        //if (ntop > 500&& GetPosition(bgObj).height>1000) ntop = 500;
        alert_div.style.top = ntop + 'px';
    }
    document.body.appendChild(alert_div);
}
function MsgBoxAction(content, title, script_str, sId) {
    MsgBoxFun(false, content, title, true, sId, script_str);
}
function MsgBox(content, title, is_error, sId) {
    MsgBoxFun(false, content, title, is_error, sId, "");
}
function Confirm(content, title, is_error, sId, script_str, btn_ok_css, btn_cancel_css, script_cancel) {
    MsgBoxFun(true, content, title, is_error, sId, script_str, btn_ok_css, btn_cancel_css, script_cancel);
}

function MsgIframe(title, width, height, serUrl, page, sId, left, top) {
    if (IsEmpty(title)) title = "System Information";
    var content_body = "<table width='100%' border='0px' cellpadding='0px' cellspacing='0px'><tr class=\"msg-title\"><td align='left'>&nbsp;<span id='iframe-header-title'>" + title +
    "</span></td><td align='right' style='text-align:right;'><div onclick='CloseMsgBox();' class='msg-cs'></div></td></tr><tr><td align='center' colspan='2' id='td_content' style='background-color:white;'>" +
     "<iframe id=\"iframe_target\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\" style=\" width:" + (width - 10) + "px; height:" + (height - 50) + "px;\" src=\"" + serUrl + page + "\"></iframe>" +
    "</td></tr></table>";
    ShowBackgroup(sId);
    ShowDiv(content_body, width, height, "#FFB97A", "MSGBOX", left == null ? 0 : left, top == null ? 0 : top, sId);
    ShowBackgroup(sId);
    sf("_MsgBtn");
}

function MsgAjax(title, width, height, serUrl, page, sId, func) {
    if (IsEmpty(title)) title = "System Information";
    var content_body = "<table width='100%' border='0px' cellpadding='0px' cellspacing='0px'><tr class=\"msg-title\"><td align='left'>&nbsp;" + title +
    "</td><td align='right' style='text-align:right;'><div onclick='CloseMsgBox();' class='msg-cs'></div></td></tr><tr><td colspan='2' id='ajax-content' style='background-color:white;'><div style='text-align:center;width:100%;'><img src='" + serUrl + "images/loading.gif' /></div>" +
    "</td></tr></table>";
    a("ajax-content", serUrl + page, '', 'post', func == null ? EndRequest : func, true);
    ShowBackgroup(sId);
    ShowDiv(content_body, width, height, "#FFB97A", "MSGBOX", 0, 0, sId);
    ShowBackgroup(sId);
    sf("_MsgBtn");
}

function MsgBoxFun(is_confirm, content, title, is_error, sId, script_str, btn_ok_css, btn_cancel_css,script_cancel) {
    CM();
    if (IsEmpty(btn_ok_css)) btn_ok_css = "btn1";
    if (IsEmpty(btn_cancel_css)) btn_cancel_css = "btn1";
    if (IsEmpty(title)) title = "System Information";
    if (is_error) content = "<table width='100%'><tr><td align='center' style='padding-left: 10px; padding-right: 20px; width: 1px'><img src='" + SerUrlValue + "images/error1.gif' /></td><td width='99%' align='left'>" + content + "</td></tr></table>";
    var content_body = "<table width='100%' border='0px' cellpadding='0px' cellspacing='0px'><tr class=\"msg-title\"><td>&nbsp;" + title +
    "</td></tr><tr><td class=\"msg-bb\" /></tr><tr height='80px'><td align='center'>" + content +
    "</td></tr><tr><td align='center'>";
    var btn_name = "OK";
    if (is_confirm) { content_body += "<input type='button' id=\"_MsgBtn\"  onmouseover='this.className=\"btn1\";' onmouseout='this.className=\"btn2\";' class='" + btn_ok_css + "' width='50px' value='OK' onclick=\"" + script_str + "\"/>&nbsp;"; btn_name = "Cancel"; }
    var click_event = 'CloseMsgBox();';
    if (script_str != '' && !is_confirm) click_event = script_str;
    if (!IsEmpty(script_cancel) && is_confirm) click_event = script_cancel;
    var btn_css;
    if (btn_name == "Cancel") btn_css = btn_cancel_css;
    else btn_css = btn_ok_css;
    content_body += "<input type='button' id=\"_MsgBtn\" class='" + btn_css + "' onmouseover='this.className=\"btn1\";' onmouseout='this.className=\"btn2\";' width='50px' value='" + btn_name + "' onclick=\"" + click_event + "\"/></td></tr><tr><td height='10px'></td></tr></table>";
    ShowBackgroup(sId);
    ShowDiv(content_body, 300, 130, "#FFB97A", "MSGBOX", 0, 0, sId);
    ShowBackgroup(sId);
    sf("_MsgBtn");
}
function Error(content) {
    Error(content,null);
}
function Error(content,sId) 
{
    MsgBox(content,"",true,sId);
}
function sld(sId)//ShowLoading
{
    CM();
    ShowLoading(loading, sId);
}
function ShowLoading(l, sId)//ShowLoading
{
    ShowBackgroup(sId);

        ShowDiv("<div class='loading-container'><div class='loading'>&nbsp;</div></div>",110, 40, "#614b4b", "", 0, 0, sId,'#614b4b');

}
function ShowBackgroup(sId) {
    if (o(sId) == null) sId = null;
    if($.browser.msie && $.browser.version=='6.0')
        ShowSelect(false, sId);
    var issb = false;
    var obj = sId ? o(sId) : null;
    if (obj == null)
    { obj = document.body; issb = true; }

    if (o("bgDiv") != null) return;
    var bgObj = document.createElement("div");
    bgObj.id = 'bgDiv';
    document.body.appendChild(bgObj);

    bgObj = o('bgDiv');
    if (!Browser.isIE || Browser.isIE8) {
        bgObj.style.top = GetPosition(obj).top + "px";
        bgObj.style.left = GetPosition(obj).left + "px";
    }
    else {
        bgObj.style.top = GetPosition(obj).top + 3 + "px";
        bgObj.style.left = GetPosition(obj).left + 3 + "px";
    }
    bgObj.style.width = GetPosition(obj).width + "px";
    if (issb){
        bgObj.style.height =$(document).height()+'px';// String(document.body.offsetHeight < screen.height ? screen.height : document.body.offsetHeight + 20) + "px";
    }
    else
        bgObj.style.height = GetPosition(obj).height + "px";
    bgObj.style.backgroundColor = "Black";
    bgObj.style.position = "absolute";
    bgObj.style.opacity = "0.1";
    bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=15";
    //bgObj.style.width=String(document.body.offsetWidth+20) + "px";
    //bgObj.style.height= String(document.body.offsetHeight<screen.height? screen.height : document.body.offsetHeight+20) + "px";
    //bgObj.style.zIndex = "1000";
}
function ShowSelect(xShow, objId) {
    $('select',objId==null?null:('#'+objId)).each(function(){
        if(xShow && this.attributes["hidden"]==null)
            $(this).show();
        else
            $(this).hide();    
    });
}
function ShowObject(xShow, objId) {
    $('object',objId==null?null:('#'+objId)).each(function(){
        if(xShow)
            $(this).show();
        else
            $(this).hide();    
    });
}
function CloseMsgBox() {
    $('#bgDiv').fadeOut(); if (o('alert_div_MSGBOX') == null) { $('#alert_div').fadeOut(); window.setTimeout("CM();", 250); } else { CM(); }
}
function CM() {
    if (o('alert_div') != null) document.body.removeChild(o("alert_div"));
    if (o('alert_div_MSGBOX') != null) document.body.removeChild(o("alert_div_MSGBOX"));
    if($.browser.msie && $.browser.version=='6.0')
        ShowSelect(true);
    var bgObj = document.getElementById("bgDiv");
    if (bgObj != null) {
        document.body.removeChild(bgObj);
    }
    if (bgObj != null) {
        bgObj = null;
    }
}
function showTip(objId, isShow, tips, iWidth, iHeight) {
    var obj = o(objId);
    addEvent(obj, "click", RemovePopMain);
    if (isShow == 1) {
        //obj.className="focusinp";
        if (!IsEmpty(tips)) {
            if (GetBrowser().indexOf("Firefox") >= 0)
                popupDialog(GetHtml(tips, false), GetPosition(obj).top + GetPosition(obj).height, GetPosition(obj).left, iWidth, iHeight);
            else
                popupDialog(GetHtml(tips, false), GetPosition(obj).top + GetPosition(obj).height + 1, GetPosition(obj).left + 1, iWidth, iHeight);
        }
        else {
            RemovePopMain();
        }
    }
    else {
        //obj.className="normalinp";
        RemovePopMain();
    }
}

function popupDialog(html, top, left, iWidth, iHeight) {
    if (!window.popUpReady) {
        createPopUpDom(iWidth, iHeight);
    }
    var content = o("popUpMain");
    var strHTML = html;
    with (content) {
        innerHTML = html; //g_Templet["dialog"].replace(/__Title__/gi,title).replace(/__HTML__/gi,html);;
        style.display = "";
        style.left = left + "px";
        style.top = top + "px";
    }
    var content_iframe = o("popUpIframe");
    var strHTML = html;
    with (content_iframe) {
        height = content.height + 300 + "px";
        style.display = "";
        style.left = left + "px";
        style.top = top + "px";
    }
}
function RemovePopMain() {
    if (o('popUpMain') != null) {
        o('popUpMain').style.display = 'none';
    }
    if (o('popUpIframe') != null) {
        o('popUpIframe').style.display = 'none';
    }
}
function createPopUpDom(iWidth, iHeight) {
    var content = document.createElement("div");
    with (content) {
        id = "popUpMain";
        style.cssText = "position:absolute;z-index:900;";
        //className = "dragItem";
    }
    document.body.appendChild(content);

    var content_iframe = document.createElement("div");
    with (content_iframe) {
        id = "popUpIframe";

        style.cssText = "position:absolute;z-index: 899;padding-left:0px;padding-right:1px; padding-bottom:1px; padding-top:0px;";
        //className = "dragItem";
        height = content.height + "px";
    }
    document.body.appendChild(content_iframe);
    if (GetBrowser().indexOf("Firefox") >= 0) {
        iWidth = iWidth - 5;
        iHeight = iHeight - 1;
    }
    o('popUpIframe').innerHTML = "<iframe id='hidenIframe' frameborder='1px' style='width: " + iWidth + "px; height:" + iHeight + "px; background: #E4F0FE; color: Transparent;position: absolute; z-index: 898;'></iframe>";

    window.popUpReady = true;
}

function GetPosition(obj) {
    if (obj == null) return { "top": 0, "left": 0, "width": 0, "height": 0 };
    var top = 0;
    var left = 0;
    var width = obj.offsetWidth;
    var height = obj.offsetHeight;
    if (height == 0) { height = screen.height; }
    while (obj.offsetParent) {
        top += obj.offsetTop;
        left += obj.offsetLeft;
        obj = obj.offsetParent;
    }
    return { "top": top, "left": left, "width": width, "height": height };
}
function GetCurrentPage() {
    var u = document.location.href;
    var i = u.indexOf('?');
    if (i > 0)
        u = u.substring(0, u.indexOf('?'))
    var info = u.split('/');
    var page_info = info[info.length - 1].split('?');
    //if(page_info[0]=="Index.aspx")
    //return "Search.aspx";
    //else
    return page_info[0];
}
//Vinson
function GetParentPage() {
    var u = document.location.href;
    var i = u.indexOf('?');
    if (i > 0)
        u = u.substring(0, u.indexOf('?'))
    var info = u.split('/');
    var page_info = info[info.length - 2].split('?');
    return page_info[0];
}
function focusInput(focusClass, normalClass) {
    var elements = document.getElementsByTagName("input");
    for (var i = 0; i < elements.length; i++) {
        if (typeof(elements[i].onblur)=='undefined'||elements[i].onblur==''||elements[i].onblur==null)
        {
            if (elements[i].type != "button" && elements[i].type != "submit" && elements[i].type != "reset" && elements[i].id != "txtDst" && elements[i].id != "txtAirline" && elements[i].id != "txtDstTwo" && elements[i].id != "txtAir" && elements[i].id != "txtChkIn") {
                if (elements[i].type == "text") {
                    elements[i].className = normalClass;
                    elements[i].onfocus = function() { this.className = focusClass; };
                    elements[i].onblur = function() { this.className = normalClass || ''; };
                }
            }
        }
    }
}
function RegCss(src) {
    var styles = document.getElementsByTagName('link');
    for (var i = 0; i < styles.length; i++) {
        if (styles[i].type == 'text/css' && styles[i].href.indexOf(src) > -1)
            return;
    }
    var style = document.createElement("link");
    style.setAttribute("type", "text/css");
    style.type = 'text/css';
    style.setAttribute("href", src);
    style.setAttribute("rel", "stylesheet");
    document.getElementsByTagName("head")[0].appendChild(style);
}
function RegJs(src) {
    var jslist = document.getElementsByTagName('script');
    for (var i = 0; i < jslist.length; i++) {
        if (jslist[i].src.indexOf(src) > -1)
            return;
    }
    var js = document.createElement("script");
    js.type = 'text/javascript';
    js.src = src;
    document.body.appendChild(js);
}

function chShift(obj,type) {
    var objParent=$(obj).parent();
    if(objParent.attr('tabs')){
        objParent.find('li').each(function (){
            if(this==obj){
                $('#'+$(this).attr('data')).show();
                $(obj).attr('class','li-focus');
            }
            else{
                $(this).attr('class','');
                $('#'+$(this).attr('data')).hide();
            }
        });
    }
    else{
        var cssNormal = "";
        var cssNormalL = "";
        var cssNormalR = "";
        var cssActive = "";
        var cssActiveL = "";
        var cssActiveR = "";
        if (type == "S") {
            cssNormal = "st_normal";
            cssActive = "st_active";
        }
        else if (type == "N") {
            cssNormal = "m-m-n";
            cssNormalL = "m-n";
            cssNormalR = "m-r-n";
            cssActive = "m-m-a";
            cssActiveL = "m-l-a";
            cssActiveR = "m-r-a";
        }
        objParent.find('li:has(a)').each(function (){
            $(this).css('cursor','pointer');
            if(this==obj)
            {
              if(cssActive!='')
                $(this).removeClass(cssNormal).addClass(cssActive)
                    .prev('li').removeClass(cssNormalL).addClass(cssActiveL).end()
                    .next('li').removeClass(cssNormalR).addClass(cssActiveR).end();
                $('#'+$(this).attr('data')).show();
            }
            else
            { 
              if(cssNormal!='')
                $(this).removeClass(cssActive).addClass(cssNormal)
                .prev('li').removeClass(cssActiveL).addClass(cssNormalL).end()
                .next('li').removeClass(cssActiveR).addClass(cssNormalR).end();
                $('#'+$(this).attr('data')).hide();
            }
        });
    }
}
function daysElapsed(date1, date2, isDateTime) {
    if(isDateTime==null) isDateTime = false;
    var difference = Date.UTC(date1.getYear(), date1.getMonth(), date1.getDate(), isDateTime ? date1.getHours() : 0, isDateTime? date1.getMinutes() : 0, 0) - Date.UTC(date2.getYear(), date2.getMonth(), date2.getDate(), isDateTime? date2.getHours() : 0, isDateTime? date2.getMinutes() : 0, 0);
    return difference / 1000 / 60 / 60 / 24;
}
function TimeCom(dateValue) {
    var newCom = new Date(dateValue);
    this.year = newCom.getYear();
    this.year = (this.year < 1900 ? (1900 + this.year) : this.year);
    this.month = newCom.getMonth() + 1;
    this.day = newCom.getDate();
    this.hour = newCom.getHours();
    this.minute = newCom.getMinutes();
    this.second = newCom.getSeconds();
    this.msecond = newCom.getMilliseconds();
    this.week = newCom.getDay();
}
function GetDateString(d) {
    return "";
}
function DateDiff(interval, date1, date2) {
    var TimeCom1 = new TimeCom(date1);
    var TimeCom2 = new TimeCom(date2);
    var result;
    switch (String(interval).toLowerCase()) {
        case "y":
        case "year":
            result = TimeCom1.year - TimeCom2.year;
            break;
        case "n":
        case "month":
            result = (TimeCom1.year - TimeCom2.year) * 12 + (TimeCom1.month - TimeCom2.month);
            break;
        case "d":
        case "day":
            result = Math.round((Date.UTC(TimeCom1.year, TimeCom1.month - 1, TimeCom1.day) - Date.UTC(TimeCom2.year, TimeCom2.month - 1, TimeCom2.day)) / (1000 * 60 * 60 * 24));
            break;
        case "h":
        case "hour":
            result = Math.round((Date.UTC(TimeCom1.year, TimeCom1.month - 1, TimeCom1.day, TimeCom1.hour) - Date.UTC(TimeCom2.year, TimeCom2.month - 1, TimeCom2.day, TimeCom2.hour)) / (1000 * 60 * 60));
            break;
        case "m":
        case "minute":
            result = Math.round((Date.UTC(TimeCom1.year, TimeCom1.month - 1, TimeCom1.day, TimeCom1.hour, TimeCom1.minute) - Date.UTC(TimeCom2.year, TimeCom2.month - 1, TimeCom2.day, TimeCom2.hour, TimeCom2.minute)) / (1000 * 60));
            break;
        case "s":
        case "second":
            result = Math.round((Date.UTC(TimeCom1.year, TimeCom1.month - 1, TimeCom1.day, TimeCom1.hour, TimeCom1.minute, TimeCom1.second) - Date.UTC(TimeCom2.year, TimeCom2.month - 1, TimeCom2.day, TimeCom2.hour, TimeCom2.minute, TimeCom2.second)) / 1000);
            break;
        case "ms":
        case "msecond":
            result = Date.UTC(TimeCom1.year, TimeCom1.month - 1, TimeCom1.day, TimeCom1.hour, TimeCom1.minute, TimeCom1.second, TimeCom1.msecond) - Date.UTC(TimeCom2.year, TimeCom2.month - 1, TimeCom2.day, TimeCom2.hour, TimeCom2.minute, TimeCom2.second, TimeCom1.msecond);
            break;
        case "w":
        case "week":
            result = Math.round((Date.UTC(TimeCom1.year, TimeCom1.month - 1, TimeCom1.day) - Date.UTC(TimeCom2.year, TimeCom2.month - 1, TimeCom2.day)) / (1000 * 60 * 60 * 24)) % 7;
            break;
        default:
            result = "invalid";
    }
    return (result);
}

function DateAdd(interval, num, dateValue) {
    var newCom = new TimeCom(dateValue);
    switch (String(interval).toLowerCase()) {
        case "y": case "year": newCom.year += num; break;
        case "n": case "month": newCom.month += num; break;
        case "d": case "day": newCom.day += num; break;
        case "h": case "hour": newCom.hour += num; break;
        case "m": case "minute": newCom.minute += num; break;
        case "s": case "second": newCom.second += num; break;
        case "ms": case "msecond": newCom.msecond += num; break;
        case "w": case "week": newCom.day += num * 7; break;
        default: return ("invalid");
    }
    //var now = newCom.year + "/" + newCom.month + "/" + newCom.day + " " + newCom.hour + ":" + newCom.minute + ":" + newCom.second;
    return (new Date(newCom.year,newCom.month-1, newCom.day, newCom.hour, newCom.minute, newCom.second));
}
function FormatUrl(type,ignoreparams) {
    var str_url, str_pos, str_para, new_para, new_url, str_lang, ignoreparam;
    var arr_param = new Array();
    new_para = "";
    str_lang = "";
    new_para = "";
    str_lang = "lang=" + type;
    str_url = window.location.href;
    str_url = str_url.replace("#", "");
    str_pos = str_url.indexOf("?");
    str_para = str_url.substring(str_pos + 1);
    new_url = str_url.split("?")[0];
    if(ignoreparams!=null) ignoreparam = ignoreparams.split(",");
    if (str_pos > 0) {
        arr_param = str_para.split("&");
        for (var i = 0; i < arr_param.length; i++) {
            var temp_str = new Array()
            temp_str = arr_param[i].split("=")
            if (temp_str[0].toUpperCase() != "LANG") {
                var exist = false;
                if(ignoreparams!=null)
                {
                    for(var j=0;j< ignoreparam.length;j++)
                    {
                        if(ignoreparam[j].toUpperCase()==temp_str[0].toUpperCase()) 
                        {
                            exist = true;
                            break;  
                        }
                    }
                }
                if(exist) continue;
                var obj = new Object()
                obj.param_name = temp_str[0]
                obj.param_str = arr_param[i].substring(temp_str[0].length+1)
                arr_param[i] = obj
            }
        }

        for (var i = 0; i < arr_param.length; i++) {
            if (arr_param[i].param_name != null && arr_param[i].param_str != null)
                new_para += "&" + arr_param[i].param_name + "=" + arr_param[i].param_str;
        }
    }

    if (new_para != "")
        new_url = new_url + "?" + str_lang + new_para;
    else
        new_url = new_url + "?" + str_lang;

    window.location.href = new_url;
    return false;
}//numType -> 0:only positive; 1:both ; 2: only negative;
function onlyNumber(obj, e,numType) {
    function Invalid() {
        if (Browser.isIE) { e.returnValue = false; }
        else { e.preventDefault(); }
    }
    function onlyNumberKeyUp()
    {
       if(obj.value.indexOf('.')==0)
           obj.value = obj.value.length==1?'0.':'0.'+obj.value.substring(1); 
       if(obj.value.length>1&&obj.value.indexOf('0')==0&&obj.value.indexOf('.')!=1)
       {
           obj.value = obj.value.substring(1); 
           onlyNumberKeyUp();
       }
       if(obj.value.indexOf('-')==0&&obj.value.length>2&&obj.value.indexOf('0')==1&&obj.value.indexOf('.')!=2)
       {
           obj.value = '-'+obj.value.substring(2); 
           onlyNumberKeyUp();
       }
       if(obj.value.indexOf('-')==0&&obj.value.indexOf('.')==1)
       {
           obj.value = obj.value.length==2?'-0.':'-0.'+obj.value.substring(2); 
       }
       if(obj.value.indexOf('-')>0)
       {
           obj.value = obj.value.substring(0,obj.value.indexOf('-'))+obj.value.substring(obj.value.indexOf('-')+1); 
       }
       
    }
    numType=numType==null?0:numType;
    var k = window.event ? e.keyCode : e.which;
    if(numType==2&&k==45)
    {
       return obj.value.indexOf('-') == -1 ? true : Invalid();
    }
    else if(numType==1&&k==45)
    {
        if(obj.value.indexOf('-') == -1)
           return true;
    }
    obj.onkeyup = onlyNumberKeyUp;
    if (k == 46) {
        return obj.value.indexOf('.') == -1 ? true : Invalid(); 
    }
    if (((k > 47) && (k < 58))||k == 0||k==8)
    { return true; }
    else
    { Invalid(); }
}
function MaskTime(_sId, _focusId) {
    var obj = o(_sId);
    if (obj == null) return;
    obj.setAttribute("autocomplete", "off");
    if (obj == null) return;
    obj.maxLength = 5;
    obj.onkeypress = _maskTime;
    obj.onblur = fixTime;
    obj.onkeyup = _skipFocus;

    function _maskTime(e) {
        if(typeof(e)=="undefined") e = event;
        var k = (Browser.isIE ? event.keyCode : (e.keyCode == 0 ? e.charCode : e.keyCode));
        if (IntNumber(e)) {
            if (k == 8 || k == 0) return true;
            var postion;
            if (Browser.isIE) {
                if (document.selection.createRange().text != "" && obj.value.indexOf(document.selection.createRange().text, 0) == 0)
                { postion = 0; }
                else
                { postion = obj.value.length; }
            }
            else { postion = obj.selectionStart; }
            switch (postion) {
                case 0:
                    return k <= 50 ? true : false;
                case 1:
                    if (obj.value.length>0 && obj.value.indexOf("2")==0)
                        return k <= 51 ? true : false;
                    else
                        return true;
                case 2:
                    if (obj.value.indexOf(":", 2) < 0) obj.value += ":";
                    return k <= 53 ? true : false;
                case 3:
                    return k <= 53 ? true : false;
                default:
                    return true;
            }
        }
        else
            return false;
    }
    function fixTime(e) {
        if(obj.value.indexOf(":")==0)
            return obj.value="00:00";
        switch (obj.value.length) {
            case 0:
                return true;
            case 1:
                if(obj.value==':')
                    obj.value="00:00";
                else if(parseInt(obj.value)<=9)
                {
                    obj.value='0'+obj.value+":00";    
                }
                return false;
            case 2:
                var vs=obj.value.split(":");
                if(vs.length==1&&parseInt(vs[0])<=23)
                    obj.value += ':00'; 
                else if(vs.length==2)
                {
                    if(parseInt(vs[0])<=23&&vs[0].length==1)
                    {
                        if(parseInt(vs[0])<2)
                            obj.value=vs[0]+"0:00";
                        else
                            obj.value="0"+vs[1]+":00";
                    }
                }    
                return false;
            case 3:
                if(obj.value.indexOf(':')==2&&parseInt(obj.value.substr(0,2))<=23)
                    obj.value += '00';
                else if(obj.value.indexOf(':')==1)
                {
                    var m=obj.value.substr(2,1);
                    if(parseInt(m)>5)
                        obj.value="0"+obj.value.substr(0,2)+"0"+m;
                    else
                        obj.value="0"+obj.value+"0";
                }
                 return false;
            case 4:
                if(obj.value.indexOf(':')==2)
                {
                    if(parseInt(obj.value.substr(3,1))>=6)
                         obj.value = obj.value.substr(0,3)+'0'+obj.value.substr(3,1);
                    else
                         obj.value += '0';
                }
                else if(obj.value.indexOf(':')==1)
                    obj.value='0'+obj.value;
                return false;
            default:
                return true;
        }
    }
    function _skipFocus()
    {
        if(obj.value.length == obj.maxLength&&typeof(_focusId)!='undefined'&&o(_focusId)!=null)
        {
            o(_focusId).focus();
        }
    }
}
function IsTime(t)
{
    if(IsEmpty(t)) return true;
    if(t.length==5&&t.indexOf(':')==2)
    {
        var hm=t.split(':');
        if(hm[0]<=23&&hm[1]<=59)
            return true; 
    }
    return false;
}
function IntNumber(e) {
    function Invalid() {
        if($.isFunction(e.preventDefault))
            e.preventDefault();
        else{
            e.returnValue = false;
        }    
    }
    var k = window.event ? e.keyCode : e.which;
    
    if (((k > 47) && (k < 58)) || k == 8 || k == 0)
    {return true; }
    else
    {return Invalid(); }
}

//Scroll To Control
function elementPosition(obj) {
    var curleft = 0, curtop = 0;

    if (obj.offsetParent) {
        curleft = obj.offsetLeft;
        curtop = obj.offsetTop;

        while (obj = obj.offsetParent) {
            curleft += obj.offsetLeft;
            curtop += obj.offsetTop;
        }
    }

    return { x: curleft, y: curtop };
}

function ScrollToControl(id, abligate_height) {
    var elem = document.getElementById(id);
    if($(document).scrollTop()>elementPosition(elem).y){
        $(document).scrollTop(elementPosition(elem).y);
    }
    var scrollPos = elementPosition(elem).y;
    var scrollTop = document.documentElement.scrollTop;
    if(scrollTop==0) 
        scrollTop = document.body.scrollTop;
    scrollPos = scrollPos - scrollTop;
    var remainder = scrollPos % 50;
    var repeatTimes = (scrollPos - remainder) / 50;
    ScrollSmoothly(scrollPos, repeatTimes);
    var h = 0;
    if (!IsEmpty(abligate_height)) h = abligate_height;
    window.scrollBy(0, remainder - h);
}
var repeatCount = 0;
var cTimeout;
var timeoutIntervals = new Array();
var timeoutIntervalSpeed;
function ScrollSmoothly(scrollPos, repeatTimes) {
    if (repeatCount < repeatTimes) {
        window.scrollBy(0, 50);
    }
    else {
        repeatCount = 0;
        clearTimeout(cTimeout);
        return;
    }
    repeatCount++;
    cTimeout = setTimeout("ScrollSmoothly('" + scrollPos + "','" + repeatTimes + "')", 10);
}
//End Scroll To Control
function PrintPage(start, end, printFrame) {
    if (start != null) eval(start);
    if (printFrame == null)
        window.print();
    else {
        printFrame.focus();
        printFrame.print();
    }
    if (end != null) {
        if (Browser.isIE)
        { eval(end); }
        else
        { setTimeout(end, 5000); }
    }
}
function EnterEvent(fn, e) {
    if (e.keyCode == 13) {
        eval(fn);
    }
}
function isNumAndGtZero(num) {
    return !isNaN(num) && num >= 0;
}
function getCK(name) { var start = document.cookie.indexOf(name + "="); var len = start + name.length + 1; if ((!start) && (name != document.cookie.substring(0, name.length))) { return null; } if (start == -1) return null; var end = document.cookie.indexOf(';', len); if (end == -1) end = document.cookie.length; return unescape(document.cookie.substring(len, end)); }
function setCK(name, value, expires, path, domain, secure) { var today = new Date(); today.setTime(today.getTime()); if (expires) { expires = expires * 1000 * 60 * 60 * 24; } var expires_date = new Date(today.getTime() + (expires)); document.cookie = name + '=' + escape(value) + ((expires) ? ';expires=' + expires_date.toGMTString() : '') + ((path) ? ';path=' + path : '') + ((domain) ? ';domain=' + domain : '') + ((secure) ? ';secure' : ''); }
function delCK(name, path, domain) { if (getCK(name)) { document.cookie = name + '=' + ((path) ? ';path=' + path : '') + ((domain) ? ';domain=' + domain : '') + ';expires=Thu, 01-Jan-1970 00:00:01 GMT'; } }
function ChgBtnEnable(btnId, isEnable) {
    var btn = o(btnId);
    if(btnId!=null)
    {
        if (isEnable) {
            btn.style.color = "";
            btn.style.cursor = "pointer";
            btn.disabled = false;
        }
        else {
            btn.style.color = "#BFBFBF";
            btn.style.cursor = "default";
            btn.disabled = true;
        }
    }
}
function ReplaceStr(str, orgStr, regOption, repStr) {
    return str.replace(new RegExp(orgStr, regOption), repStr);
}

var cX = 0; var cY = 0; var rX = 0; var rY = 0;
function BindCursorCal() {
    if (document.all) { document.onmousemove = UpdateCursorPositionDocAll; }
    else { document.onmousemove = UpdateCursorPosition; }
}
function UpdateCursorPosition(e) { cX = e.pageX; cY = e.pageY; }
function UpdateCursorPositionDocAll(e) { cX = event.clientX; cY = event.clientY; }

function AssignPosition(d) {
    if (self.pageYOffset) {
        rX = self.pageXOffset;
        rY = self.pageYOffset;
    }
    else if (document.documentElement && document.documentElement.scrollTop) {
        rX = document.documentElement.scrollLeft;
        rY = document.documentElement.scrollTop;
    }
    else if (document.body) {
        rX = document.body.scrollLeft;
        rY = document.body.scrollTop;
    }
    if (document.all) {
        cX += rX;
        cY += rY;
    }
    if (cX > 1100) {
        cX = 1100;
    }
    d.style.left = eval(cX - (d.offsetWidth / 2)) + "px";
    d.style.top = (cY + 15) + "px";
}
function AssignPositionpopup(d) {
    if (self.pageYOffset) {
        rX = self.pageXOffset;
        rY = self.pageYOffset;
    }
    else if (document.documentElement && document.documentElement.scrollTop) {
        rX = document.documentElement.scrollLeft;
        rY = document.documentElement.scrollTop;
    }
    else if (document.body) {
        rX = document.body.scrollLeft;
        rY = document.body.scrollTop;
    }
    if (document.all) {
        cX += rX;
        cY += rY;
    }
    d.style.left = eval(cX - (d.offsetWidth / 2)) + "px";
    d.style.top = (cY + 15) + "px";
    if (cY + 25 + d.offsetHeight > 460) {
        d.style.top = eval((cY - 15 - d.offsetHeight)) + "px";
    }
    if (cX - (d.offsetWidth / 2) < 0) {
        d.style.left = "15px";
    }
    if (cX - (d.offsetWidth / 2) + d.offsetWidth > 700) {
        d.style.left = eval(685 - d.offsetWidth) + "px";
    }
}
function HideContent(d) {
    if (d.length < 1) { return; }
    document.getElementById(d).style.display = "none";
}
function ShowContent(d) {
    if (d.length < 1) { return; }
    var dd = document.getElementById(d);
    dd.style.display = "block";
    AssignPosition(dd);
}
function ShowContent_ab(d) {
    if (d.length < 1) { return; }
    var dd = document.getElementById(d);
    dd.style.display = "block";
}
function ShowContentPopup(d) {
    if (d.length < 1) { return; }
    var dd = document.getElementById(d);
    dd.style.display = "block";
    AssignPositionpopup(dd);
}
function ReverseContentDisplay(d) {
    if (d.length < 1) { return; }
    var dd = document.getElementById(d);
    if (dd.style.display == "none") { dd.style.display = "block"; }
    else { dd.style.display = "none"; }
    AssignPosition(dd);
}
function GetYearDiff(birth, sDate) {
    var age = sDate.getFullYear() - birth.getFullYear();
    if (age < 0 || (age == 0 && sDate.getMonth() < birth.getMonth()) || (age == 0 && sDate.getMonth() == birth.getMonth() && sDate.getDate() < birth.getDate())) {
        return -1;
    }
    if (age == 0 || age == 1) return 1;
    if (birth.getMonth() > sDate.getMonth()) {
        return age - 1;
    }
    else if (birth.getMonth() == sDate.getMonth() && birth.getDate() >= sDate.getDate()) {
        return age - 1;
    }
    else {
        return age;
    }
}

function FCKReg(conId,extraParams, width, height, toolbarSet)
{       
    $.include(SerUrlValue+'fck/fckeditor.js',function (){
        extraParams=extraParams || {};
        var editor = new FCKeditor(conId,width,height||350,toolbarSet||"AD",null,"&"+$.param(extraParams));
        editor.BasePath = SerUrlValue+'fck/';
        editor.Config["HtmlEncodeOutput"]=true;
        editor.Config["DefaultLanguage"]=LangType=='zh-tw'? "zh":(LangType=='zh-cn'?'zh-cn':'en');
        editor.ReplaceTextarea();
        return editor;
    });
}
function FCKGetContentLength(conId)
{
    var oEditor = FCKeditorAPI.GetInstance(conId) ;
    var oDOM = oEditor.EditorDocument;
    var iLength=0;
    if (document.all)
    {
        iLength = oDOM.body.innerText.length ;
    }
    else                    // If Gecko.
    {
        var r = oDOM.createRange() ;
        r.selectNodeContents( oDOM.body ) ;
        iLength = r.toString().length ;
    }
    return iLength;
}
function FCKGetContent(conId)
{
    var oEditor = FCKeditorAPI.GetInstance(conId) ;
    return oEditor.GetXHTML();  
}
function FCKSetContent(conId,text)
{
    var oEditor = FCKeditorAPI.GetInstance(conId) ;
    return oEditor.SetHTML(text);  
}
function TestType(obj,type)
{
    if(type=='undefined')
    {
        return typeof(obj)=='undefined';
    }
    if(IsEmpty(type)||obj==null)
        return false;
    else
        type=type.toLowerCase(); 
    var types=["array", "boolean", "date", "number", "object", "regexp", "string", "window", "htmldocument","function"];    
    if($.inArray(type,types)){
        var typeFmt=type.substr(0,1).toUpperCase()+type.substr(1);
        return Object.prototype.toString.call(obj)=="[object "+typeFmt+"]";        
    }
    else
        return false;
}
function o2s(o,i,max)
{
    if(i!=null)i++;
    if(max==null)max=10000;
    var arr = [];
    var fmt = function (s,dv)
    {
    if(s==null)s=dv;
        if (typeof s == 'object' && s != null && i<max) return o2s(s,i,max);
        return /^(string|number)$/.test(typeof s) ? "'" + s + "'" : s;
    }
    for (var i in o)
    {
        var name=i;var ni=name.split('_dv_');
        if(ni[0]=='innerHTML'||ni[0]=='innerText'||ni[0]=='outerHTML'||ni[0]=='outerText'||ni[0]=='textContent')continue;
        arr.push(ni[0] + ':' + fmt(o[i],ni.length==2?ni[1]:null));
    }
    return '{' + arr.join(', ') + '}';
}
/*---- Tabs ----*/

(function($) {
    $.wm = {
        tabs: {
            init: function(navID, initIndex, option) {
                //option effect:default,ajax
                var settings = $.extend({}, { effect: "default" }, option);
                $(o(navID)).data("settings", settings);
                var $li = $('.nav-item', '#' + navID);
                initIndex = $.wm.tabs.getTabIndex(navID, initIndex);
                initIndex = (initIndex == null || (initIndex > $li.length - 1)) ? 0 : initIndex;
                $li.each(function(i) {
                    $(this).data('onclick', $(this).attr('onclick'));
                    if ($(this).hasClass('nav-disabled')) {
                        $(this).removeAttr('onclick');
                    }
                    else {
                        $(this).click(function() {
                            $.wm.tabs.fc(navID, i);
                        });
                    }
                });
                $.wm.tabs.focus(navID, initIndex);
            },
            focus: function(navID, index) {
                index = $.wm.tabs.getTabIndex(navID, index);
                if (index == -1)
                    index = 0;
                $('.nav-item', '#' + navID).eq(index).click();
            },
            getTabIndex: function(navID, indexOrTabId) {
                var index = -1;
                if (typeof (indexOrTabId) == "number")
                    index = indexOrTabId;
                else if (typeof (indexOrTabId) == "string") {
                    index = parseInt(indexOrTabId);
                    if (isNaN(index)) {
                        index = $('.nav-item[data="' + indexOrTabId + '"]', '#' + navID).index();
                    }
                }
                return index;
            },
            getFocusIndex: function(navID) {
                var ti = 0;
                $('.nav-item', '#' + navID).each(function(i) {
                    if ($(this).hasClass('nav-active')) {
                        ti = i;
                        return false;
                    }
                });
                return ti;
            },
            changeEnable: function(navID, index, enable) {
                var $item = $('.nav-item', '#' + navID).eq($.wm.tabs.getTabIndex(navID, index));
                $.wm.tabs._changeEnable(navID, $item, enable);
            },
            changeEnableByAnchorId: function(navID, id, enable) {
                $.wm.tabs._changeEnable(navID, $('#' + id).parent(), enable);
            },
            _changeEnable: function(navID, obj, enable) {
                if (enable == null)
                    enable = true;
                obj.removeClass('nav-active');
                if (enable) {
                    obj.removeClass('nav-disabled').attr('onclick', obj.data('onclick'));
                }
                else {
                    obj.addClass('nav-disabled');
                }
                $('.nav-item', '#' + navID).unbind('click');
                $.wm.tabs.init(navID, $.wm.tabs.getFocusIndex(navID));
            },
            fc: function(navID, index) {
                index = $.wm.tabs.getTabIndex(navID, index);
                var obj = $('.nav-item', '#' + navID)[index];
                if (obj == null) return;
                var actId;
                if ($(obj).hasClass('nav-disabled'))
                    return;
                $(obj).parent().find('.nav-item').not('.nav-disabled').each(function() {
                    if (this != obj) {
                        $(this).removeClass("nav-active");
                        $("#" + $(this).attr('data')).hide();
                    }
                    else {
                        $(this).addClass("nav-active");
                        $("#" + $(this).attr('data')).show();
                    }
                });
                $.wm.tabs.getContent(navID, index);
            },
            getContent: function(navID, index) {
                var obj;
                index = $.wm.tabs.getTabIndex(navID, index);
                obj = $('.nav-item', '#' + navID)[index];
                if (obj == null) return;
                var settings = $(o(navID)).data("settings");
                var $dvContent = $('#' + $(obj).attr("data"));
                if (settings.effect == "ajax" && $dvContent.html() == '' && !IsEmpty($(obj).attr('ajax'))) {
                    $dvContent.html(sloading);
                    CommonCall($(obj).attr('ajax'), 0, $dvContent.attr('id'), '', '', '', '', 'html', function(data) {
                    });
                }
            }
        },
        listControl: function(containerId, prefix, options) {
            ///options={initValues:[{},{}],initCount:3,onDeleteItem:function(){},onAddItem:function(){},onInit:function(){}}
            var settings = $.extend(true,{ prefix: prefix }, { addBtnId: containerId + "-btn-add", itemPrefix: "-item-", atLeastCount: 0, initValues: null, initCount: 0, onDeleteItem: null, onAddItem: null, onInit: null, hideWhenEmpty: true, itemInit: null }, options);
            var $container = $('#' + containerId);
            var $hdItemNum = $("#" + prefix + "Num");
            if ($container.length == 0 || IsEmpty(prefix))
                return;
            var itemPredicate = '[id^="' + containerId + settings.itemPrefix + '"]';
            if($hdItemNum.length == 0)
            {
                _SetContainerVisual();
                return;
            }
            if (settings.atLeastCount > 0 && settings.initCount == 0)
                settings.initCount = settings.atLeastCount;
            if (settings.initCount == 0)
                settings.initCount = parseInt($hdItemNum.val());
                            
            _Init();

            function _Init() {
                if ($container.hasClass('has-list-control')) return;
                //delete the sample item 
                var hasSample = true;
                var $sampleItem = $('#' + containerId + settings.itemPrefix + "0");
                if ($sampleItem.length > 0) {
                    $container.data("sample", $sampleItem.outerHTML());
                    $container.data("sample-parent", $sampleItem.parent());
                   // alert($container.data("sample-parent").html());
                    $sampleItem.remove();
                }
                else {
                    hasSample = false;
                }
                //delete function
                $('.f-delete', $container).unbind('click').bind('click', function() {
                    _DeleteItem($(this).parents(itemPredicate).attr("id"));
                });
                //delete all function
                $('.f-delete-all', $container).unbind('click').click(function() {
                    $(this).siblings(":checked").attr('checked', false);
                    $(':checkbox:checked[id^="Chk_' + prefix + '"]', $container).attr('checked', false).each(function() {
                        var infos = this.id.split('_');
                        if (infos[infos.length - 1] != 0)
                            _DeleteItem(containerId + settings.itemPrefix + infos[infos.length - 1]);
                    });
                });

                //add function
                $(o(settings.addBtnId)).add('.f-add', $container).bind('click',function(e) {
                    _BindAddItem(e);
                });
                
                //seleect all checkbox
                $('.f-ckb-all', $container).unbind('click').bind("click", function() {
                
                    SelectAll(this, 'Chk_' + prefix, containerId);
                })

                //foreach existed item
                var itemCount=0;
                $(itemPredicate, $container).each(function() {
                    if(settings.atLeastCount>0 && itemCount<settings.atLeastCount)
                    {
                        $(this).find('.f-delete').remove();
                        $(this).find("input[id^='Chk_']").remove();
                        itemCount++;
                    }
                    if (settings.itemInit != null) {
                        if ($.isFunction(settings.itemInit)) settings.itemInit(this.id);
                        else
                            eval(settings.itemInit);
                    }
                    if (settings.onAddItem != null) {
                        if ($.isFunction(settings.onAddItem)) settings.onAddItem(this.id.replace(containerId + settings.itemPrefix, ""), this.id);
                        else eval(settings.onAddItem);
                    }
                });
                if (!hasSample) return;

                var itemCount = $(itemPredicate, $container).length;
                if (settings.initValues != null && settings.initValues.length > 0) {
                    for (var i = 0; i < settings.initValues.length; i++) {
                        if (i >= itemCount) {
                            _AddItem(settings.initValues[i]);
                        }
                    }
                }
                itemCount = $(itemPredicate, $container).length;
                if (settings.initCount != null && itemCount < settings.initCount) {
                    for (var i = 0; i < settings.initCount - itemCount; i++) {
                        _AddItem();
                    }
                }
                if (settings.onInit != null) {
                    if ($.isFunction(settings.onInit)) settings.onInit($hdItemNum.val());
                    else eval(settings.onInit);
                }
                _SetContainerVisual();
                $container.data('settings', settings).addClass('has-list-control');
            }
            function _AddItem(initValue,e) {
                $hdItemNum.val(parseInt($hdItemNum.val()) + 1);
                var newItemId = containerId + settings.itemPrefix + $hdItemNum.val();
                var $newItem = $($container.data("sample")).attr("id", newItemId).find("*").each(function() {
                    $(this).removeClass('hasDatepicker').removeClass('ui-datepicker-trigger');
                    if (!IsEmpty(this.id) && this.id.indexOf(prefix) > -1) {
                        $(this).attr("id", ReplaceStr(this.id, prefix + "0", "g", prefix + $hdItemNum.val()));
                        if (!IsEmpty(this.name))
                            $(this).attr("name", ReplaceStr(this.name, prefix + "0", "g", prefix + $hdItemNum.val()));
                    }
                }).end().appendTo($container.data("sample-parent")).show();
                if (settings.atLeastCount > 0 && $(itemPredicate, $container).length <= settings.atLeastCount) {
                    $newItem.find('.f-delete').remove().end().find(':checkbox[id^="Chk_' + prefix + '"]').remove();
                }
                 $('.f-add', o(newItemId)).bind('click',function(e) {
                    _BindAddItem(e);
                });
                $('.f-delete', o(newItemId)).click(function() {
                    _DeleteItem(newItemId);
                });
                if (initValue != null) {
                    _InitItemValues(newItemId, initValue);
                }
                if (settings.itemInit != null) {
                    if ($.isFunction(settings.itemInit)) settings.itemInit(newItemId, e, $hdItemNum.val());
                    else
                        eval(settings.itemInit);
                }
                if (settings.onAddItem != null) {
                    if ($.isFunction(settings.onAddItem)) settings.onAddItem($hdItemNum.val(), newItemId, initValue);
                    else eval(settings.onAddItem);
                }
            }
            function _SetContainerVisual() {
                if (settings.hideWhenEmpty) {
                    if ($(itemPredicate, $container).length > 0)
                        $container.show();
                    else
                        $container.hide();
                }
            }
            function _InitItemValues(itemId, values,itemIndex) {
                var index = itemId.split(settings.itemPrefix)[1];
                var $inputs = $(o(itemId)).find(":input[id^='" + prefix + "']");
                if (TestType(values, "object")) {
                    for (var attr in values) {
                        $inputs.filter("[id$='" + prefix + index + '_' + attr + "']").each(function() {
                            if ($(this).is(":checkbox")) {
                                $(this).attr('checked', values[attr]);
                            }
                            else {
                                if (values[attr] != null && typeof (values[attr]) == "string" && values[attr].indexOf('Date') == 1)
                                    $(this).val(values[attr].parseJsonDate());
                                else
                                    $(this).val(values[attr]);
                            }
                        });
                    }
                }
                else {
                    $inputs.filter("[id$='" + prefix + index + "']").each(function() {
                        if ($(this).is(":checkbox")) {
                            $(this).attr('checked', values);
                        }
                        else {
                            if (values != null && typeof (values) == "string" && values.indexOf('Date') == 1)
                                $(this).val(values.parseJsonDate());
                            else
                                $(this).val(values);
                        }
                    });
                }
            }
//            function GetItemValueObject(itemId,itemIndex){
//                var jsonObject={};
//                var $inputs = $(o(itemId)).find(":input[id^='" + prefix + "']");
//            }
            function _DeleteItem(itemId) {
                if (o(itemId)) {
                    $('#' + itemId).remove();
                }
                _SetContainerVisual();
            }
            function _BindAddItem(e){
                _AddItem(null,e);
                _SetContainerVisual();
                e.stopPropagation();
            }
            $.wm.listControl.initItemValues=function(itemId, values, itemIndex){_InitItemValues(itemId, values, itemIndex);};
        }
    }
})(jQuery);
/*---- Tabs End----*/

/*---------- Admin Menu Start ------------*/
function InitAdminMenu(pmenuId,pdefaultItemId){
    var menu_url = null;
    var menuId=pmenuId||"admin_menu";
    var defaultItemId=pdefaultItemId||"defaultmenu";
    var imageFold=SerUrlValue+'images/';
    if(o(menuId)==null)
        return;
	if(!$.browser.msie||$.browser.version>7.0){
	    $('div.menu_body').css("float","left");
	    $('div.menu_list').css("float","left");
	    $('p.menu_head').css("float","left");
	}
	$('#'+menuId+' p.menu_head').click(function()
    {
		$(this).children('.mark').css('backgroundImage').indexOf(imageFold+'admin_menu_left.gif')>0?
		$(this).children('.mark').css({backgroundImage:('url('+imageFold+'admin_menu_down.gif)')}):
		$(this).children('.mark').css({backgroundImage:('url('+imageFold+'admin_menu_left.gif)')});
		if($(this).hasClass('menu_head_btmborder')){
		    $(this).css('border-bottom-width')=='1px'?
		    $(this).css({"border-bottom-width":"0px"}):$(this).css({"border-bottom-width":"1px"});		    
		}
		else{
		    $('p.menu_head_btmborder').css({"border-bottom-width":"1px"});
		}
		$(this).css({backgroundImage:('url('+imageFold+'admin_menu_headerover.gif)')})
		.next('div.menu_body')
		.slideToggle(200,function(){
		    if($(this).css('display')=='none'){
		        $(this).prev('p.menu_head').css({backgroundImage:("url("+imageFold+"admin_menu_header.gif)")});
		    }
		})
		.siblings('div.menu_body')
		.slideUp(200);   
		$(this).siblings('p.menu_head').css({backgroundImage:('url('+imageFold+'admin_menu_header.gif)')});
		$(this).siblings().children('.mark').css({backgroundImage:('url('+imageFold+'admin_menu_down.gif)')}); 
	});
    $('#'+menuId+' a').each(function(i){$(this).attr('id','sub-m-'+i);});
    $('#'+menuId+' a').click(function(){setCK('selectmenu', $(this).attr('id'),1);});
    $('#'+menuId+' a').each(function(){
        var pageName = $(this).attr('href').indexOf('/')>=0 ? $(this).attr('href').substring($(this).attr('href').lastIndexOf('/')+1) : $(this).attr('href');
        if(location.href.toLowerCase().indexOf(pageName.toLowerCase())>=0){
            setCK('selectmenu',$(this).attr('id'));
            menu_url = $(this).attr('href').toLowerCase();
            return false;
        }
    });
    $('#'+menuId+' p.menu_head').last().attr('class','menu_head menu_head_btmborder');
    $('#'+menuId+' div.menu_body a:last-child').attr('class','nobtmborder');
    $('#'+menuId+' div.menu_body:last-child a:last-child').attr('class','');
    if(menu_url==null){
        for(i=0;i<adm_menu.length;i++){
            main_menu = adm_menu[i][0];                
            arrayroot = adm_menu[i][1];
            for(j=0;j<arrayroot.length;j++){
                if(location.href.toLowerCase().indexOf(arrayroot[j].toLowerCase())>=0){
                    menu_url = main_menu[0].toLowerCase();
                    break;
                }
            }
            if(menu_url!=null)break;
        }
        $('#'+menuId+' a').each(function(){    
            if($(this).attr('href').toLowerCase().indexOf(menu_url)>=0){
                setCK('selectmenu',$(this).attr('id'));
                return false;
            }         
        });
    }
	if(getCK('selectmenu')!='undefined'){//if(getCK('selectmenu')!=null){ 
        $('#'+getCK('selectmenu')).parent('div.menu_body').prev('p.menu_head').click();
        if($('#'+getCK('selectmenu')).height()>25)
        {

             $('#'+getCK('selectmenu')).toggleClass('selected-outheight');
        }
        else
        {
            $('#'+getCK('selectmenu')).toggleClass('selected');
        }
        $('#'+getCK('selectmenu')).css('color','#ff6600');
    }
    else{
        $('#'+defaultItemId).click();
    }
}
/*------- Admin Menu End -------*/

function ToggleImgArrow(divId,imgId)
{
    $('#'+divId).toggle();
    if($('#'+divId).css("display")=='none')
       $('#'+imgId).attr('class','imgArrowDown');
    else
        $('#'+imgId).attr('class','imgArrowUp');
}
function oc(ck) {return o(ck) != null && o(ck).checked;
}

String.prototype.parseJsonDate = function() {
    var str = getDateToStr(new Date(parseInt(this.substr(6))));
    return str == '01/01/1' ? '' : str;
};
//"Chi{}a".format("n")
String.prototype.format = function() {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,
        function(m, i) {
            return args[i];
        });
}

function Roundup(d,f)
{
    d=d*Math.pow(10,f); 
    d=Math.ceil(d)/Math.pow(10,f); 
    return d;
}
window.history.back=function(i){if(i==null||i==0){i=1;}if(history.length==0){window.location=SerUrlValue+'Home.aspx';}else{history.go(-i);}}

function DrillBtnToggle(btnId,relatedDiv){
    var $btn=$(o(btnId));
    var $div=$(o(relatedDiv));
    if($btn.hasClass('imgDrillUp')){
       $btn.removeClass('imgDrillUp').addClass('imgDrillDown');
    }
    else{
        $btn.removeClass('imgDrillDown').addClass('imgDrillUp');
    }
    $div.toggle();
}
function GenHtmlMsg(text,width,contentHeight)
{
    width=width?width:"450px";
    contentHeight=contentHeight?contentHeight:"100px";
    var html='<table width="100%"><tbody><tr><td align="center"><table border="0px" cellpadding="0px" cellspacing="0px" width="{1}"><tbody><tr><td class="ad-lt"></td><td class="ad-mt"></td><td class="ad-rt"></td></tr><tr><td class="ad-l"></td><td class="ad-bg" align="left" style="height: {2}"><table width="90%" border="0"><tbody><tr><td style="padding: 5px 10px 5px 10px; width: 10%"><img src="/Admin/images/error1.gif" alt=""></td><td align="left" style="width: 90%">{0}</td></tr></tbody></table></td><td class="ad-r"></td></tr><tr><td class="ad-lb"></td><td class="ad-mb"></td><td class="ad-rb"></td></tr></tbody></table></td></tr></tbody></table>';
    return html.format(text,width,contentHeight);
}

function RegRangeDateControl(fromTxtId,fromBtnId,toTxtId,toBtnId,dateNum,allowEmpty,enforce,minDate,maxDate,isDateTime)
{
     var obj = o(fromTxtId);
     if (obj == null) { alert('Miss the "' + fromTxtId + '"'); return; }
     if (IsEmpty(isDateTime)) {
        if (!IsEmpty($(obj).attr("datetype")))
            isDateTime = $(obj).attr("datetype")=="datetime";
        else
            isDateTime = false;
    }
    dateNum=dateNum?dateNum:0;
    var onChangeFunc=function(txtId){
        compareDate(ConvertDate(oa(fromTxtId)), ConvertDate(oa(toTxtId)), toTxtId, dateNum,enforce,false,isDateTime);
        if(txtId==fromTxtId){
            if(isDateTime)
            {
                $('#'+toTxtId).datetimepicker('option','minDate',IsEmpty(oa(fromTxtId))?null:ConvertDate(oa(fromTxtId).substring(0,oa(fromTxtId).indexOf(' ')),'d',dateNum));
            }
            else
            {
                $('#'+toTxtId).datepicker('option','minDate',IsEmpty(oa(fromTxtId))?null:ConvertDate(oa(fromTxtId),'d',dateNum));
            }
        } 
    };
    var fromMaxDate=null;
    if(maxDate!=null)
        fromMaxDate=ConvertDate(TestType(maxDate,'date')?getDateToStr(maxDate):maxDate,'d',-dateNum);
    new DateControl(fromTxtId,fromBtnId,onChangeFunc,allowEmpty,null,null,null,null,minDate,fromMaxDate);
    var toMinDate=null;
    if(!IsEmpty(oa(fromTxtId)))
    {
        if(isDateTime)
        {
            toMinDate = ConvertDate(oa(fromTxtId).substring(0,oa(fromTxtId).indexOf(' ')),'d',dateNum);
        }
        else
        {
            toMinDate = ConvertDate(oa(fromTxtId),'d',dateNum);
        }
    }
    new DateControl(toTxtId,toBtnId,onChangeFunc,allowEmpty,null,null,null,null,toMinDate,maxDate);
}

function GetMultiLang(key,data){
    if(data==null&&typeof(mtls)!='undefined')data=mtls;
    if(data==null)return key;
    var text="";
    if(!IsEmpty(key))
    {
        if(typeof(data)!='undefined'&&data!=null&&data.length>0)
        {
            text=key;
            for(var i=0;i<data.length;i++)
            {
                if(key==data[i][0]){
                    text=data[i][1];
                }  
            }
        }
        return text;
    }
    else
        return "";
}
function obc2sbc(s){return s.replace(/[\uff01-\uff5e]/g,function(a){return String.fromCharCode(a.charCodeAt(0)-65248);}).replace(/\u3000/g," ");}
function SetRequired(obj,isRequired){
    if(obj!=null){
        if(typeof(obj)=='string')
        {
            obj=o(obj);
            SetRequired(obj,isRequired);
            return;
        }
        if(obj.attributes['required']==null)    
            $(obj).attr('required','');
        $(obj).attr('required',(isRequired? "1":""));     
    }
}
function ValidateDrill(dvId,prefix)
{
    var isValid=true;
    $('.imgDrillDown,.imgDrillUp,.imgArrowDown,.imgArrowUp',IsEmpty(dvId)?null:('#'+dvId)).filter('[ref]').each(function(){
         var success=true;
         var relDiv=$(this).attr('ref');
         success=ValidateTxt(relDiv,prefix,':text')
         success=ValidateTxtArea(relDiv,prefix,'textarea') && success;
         success=ValidateSel(relDiv,prefix,'select')  && success;    
         if(!success){
            isValid=false;
            if($(this).is('.imgDrillDown')){
                DrillBtnToggle(this.id,relDiv);
            }
            else if($(this).is('.imgArrowDown')){
                ToggleImgArrow(relDiv,this.id);
            }
         } 
    });
    return isValid;
}
function HtmlEncode(s) {
    s = String(s === null ? "" : s);
    return s.replace(/&(?!\w+;)|["<>\\]/g, function(s) {
        switch(s) {
            case "&": return "&amp;";
            case "\\": return "\\\\";
            case '"': return '\"';
            case "<": return "&lt;";
            case ">": return "&gt;";
            default: return s;
        }
    });
}
HtmlDecode = function(html){
    return html
        .replace(/&lt;?/g,'<')
        .replace(/&gt;?/g,'>')
        .replace(/&quot;?/g, '\"')
        .replace(/&amp;/g,'&');
}

function trace(s,isAppend,isNoEncode){Trace(s,isAppend,isNoEncode);};
function Trace(s,isAppend,isNoEncode)
{
    if(typeof(s)=='object')s=o2s(s,0);
    var tId='textarea-trace';
    var tTrace=o(tId);
    if(tTrace==null)
    {
        tTrace=document.createElement('textarea');
        tTrace.id=tId;
        with(tTrace.style)
        {
            width='99%';
            border='solid 1px #369';
            backgroundColor='#fff';
            textAlign='left';
            position='fixed';
            left='1px';
            top='1px';
            padding='2px';
            zIndex=9000;
            fontSize='12pt';
            maxHeight='300px';
            height='200px';
        }
        tTrace.cols='200';
        tTrace.onkeydown=function(e){
        if(e==null)e=event;
            if(e.keyCode=='27'){
                var vt=o(tId);
                if(vt!=null){document.body.removeChild(vt);}
            }
        }
        document.body.appendChild(tTrace);
    }
    if(isNoEncode==null||isNoEncode==false)s=HtmlEncode(s);
    if(isAppend)
    {
        if(tTrace.innerHTML!='')s='\r\n--------------------------------------\r\n'+s;
        tTrace.innerHTML+=s;
    }
    else tTrace.innerHTML=s;
}
document.onkeydown=function(e)
{
    if(e==null)e=event;
    if(e.ctrlKey && e.shiftKey && e.keyCode=='86')
    {
        EvalByDev();
    }
    else if(e.ctrlKey==true && e.shiftKey && e.keyCode=='70')
    {
        
    }
}
function GetEvent()
{ 
    if(document.all) // IE 
    { 
        return window.event; 
    } 

    func = this.GetEvent.caller; 
    while(func != null) 
    { 
        var arg0 = func.arguments[0]; 
        if(arg0) 
        { 
            if((arg0.constructor == Event || arg0.constructor == MouseEvent) 
                ||(typeof(arg0) == "object" && arg0.preventDefault && arg0.stopPropagation)) 
            { 
                return arg0; 
            } 
        } 
        func = func.caller; 
    } 
    return null; 
} 
function EvalByDev()
{
    var tfId='textarea-dev';
    var tf=o(tfId);
    if(tf!=null){document.body.removeChild(tf);return;}
    tf=document.createElement('textarea');
    tf.id=tfId;
    with(tf.style)
    {
        position='fixed';
        width='100%';
        height='300px';
        width='500px';
        top=(parseInt($(window).height())-310)+'px';
        left=(parseInt(document.body.offsetWidth)-505)+'px';
        border='solid 1px #369';
        zIndex=88888;
    }
    tf.value=getCK(tf.id);
    var preKeyCode='';
    tf.onkeydown=function(e)
    {
        if(e==null)e=event;
        //Trace(e);
        if(e.keyCode=="9")
        {
            var evt = GetEvent();
            if (tf.createTextRange && tf.InsertPosition) // IE 
            { 
                obj.InsertPosition.text = '\t'; 
                evt.returnValue = false; 
            } 
            else if (window.getSelection)  //OP
            { 
                var scrollTop = tf.scrollTop; 
                var start = tf.selectionStart; 
                var pre = tf.value.substr(0, tf.selectionStart); 
                var next = tf.value.substr(tf.selectionEnd); 
                tf.value = pre + '\t' + next; 
                evt.preventDefault(); 
                tf.selectionStart = start + 1; 
                tf.selectionEnd = start + 1; 
                tf.scrollTop = scrollTop; 
            }    
        }
        else if(e.keyCode=='13' && e.ctrlKey==true)
        {
            Trace('');
            setCK(tf.id,tf.value);
            if(tf.value.indexOf('format:')==0){
            }
            else{
                Trace('Eval:'+eval(tf.value),true);    
            }
        }
        else if(e.keyCode=='27')
        {
            tf.onkeydown=null;
            document.body.removeChild(tf);
        }
        else if(e.ctrlKey==true && preKeyCode=='75' && e.keyCode=='68')
        {
            
        }
        preKeyCode=e.keyCode;
    }
    document.body.appendChild(tf);
}
function IframeAutoHeight(iframe){
	try{
		var bh = iframe.contentWindow.document.body.scrollHeight;
		var dh= iframe.contentWindow.document.documentElement.scrollHeight;
		var h = Math.max(bh, dh);
		iframe.height =  h;
	}catch (ex){}
}
