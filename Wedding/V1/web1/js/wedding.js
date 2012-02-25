$(document).ready(function(){
    $('input[type="button"]').mouseout(function(){this.className='btn1';});
    $('input[type="button"]').mouseover(function(){this.className='btn2';});
});
$(document).ready(function(){
    $('#CircleGroup .outer-circle').each(function(i){
        $.CircleControl._Create($(this).attr('Id'), {left:i*100+200+'px',top:'200px'});
    });
});
function fIndex(){
    fShowContent('index');
}
function fParty(){
    fShowContent('party');
    if($('#dv-guest-search-content').css('display')=='none'){
        $('#dv-guest-search-content').show();
        window.setTimeout(function(){GuestSearch();},500);
    }
}
function fShowContent(contentFlag){
    $('div[id^="content-"]').hide();
    $('div[id^="content-'+contentFlag+'"]').toggle('slow');
}
function fSubContent(contentFlag,contentFlagSub,sender){
    var $main=$('#content-'+contentFlag);
    $main.find('div[id^="'+contentFlag+'-"]').hide();
    $main.find('div[id^="'+contentFlag+'-'+contentFlagSub+'"]').fadeIn();
    $('#'+contentFlag).find('a[onclick^="fSubContent"]').attr('class','a-nul');
    $(sender).attr('class','a-focus');
}

function GuestSearch(pageIndex, pageSize, sortBy, isAsc) {
    if($('#dv-guest-search-content').length>0){
        CommonSearch("V1/Callback/Guest.aspx", 1, "dv-guest-search-content", "dv-guest-search-content", "dv-guest-search-form", "GuestSch_", "", pageIndex, pageSize, sortBy, isAsc);
    }
}
function CheckSelects(obj,objId){
    if(obj.checked){
        $('#'+objId).find('input[class="sel-result"]').attr('checked','checked');
    }
    else{
        $('#'+objId).find('input[class="sel-result"]').removeAttr('checked');
    }
}
function DelectGuest(){
    var selectedGuestCodes=GetSelect('dv-guest-search-content','',true,',',false);
    if(selectedGuestCodes!=''){
        $.getJSON(SerUrl+"V1/Callback/Guest.aspx",{type:2,guestCodes:selectedGuestCodes},function(d){
            if(d.success){
                GuestSearch();
            }
            else{
                MsgBox(d.message);
            }
        });
    }
}
function GuestAdd(){
    if(ValidateTxtAndSel('dv-guest-add')){
        $.getJSON(SerUrl+'V1/Callback/Guest.ashx?operation=add'+getParams('dv-guest-add'),null,function(d){
            GuestSearch();
        });
    }
}
function GuestEdit(gCode){
    if(ValidateTxtAndSel('dv-guest-edit-'+gCode)){
        $.getJSON(SerUrl+'V1/Callback/Guest.ashx?operation=edit&guestCode='+gCode+getParams('dv-guest-edit-'+gCode),null,function(d){
            if(d.success){
                GuestSearch(1,10,'UpdateOn',false)
            }
            else{
                MsgBox(d.message,'错误',false,'dv-guest-edit-'+gCode);
            }
        });
    }
}
function GuestSave(gCode){
    if(IsEmpty(gCode)){GuestAdd();}else{GuestEdit(gCode);}
}
function LoadGuest(gCode){
    $('div[id^="dv-guest-edit-"]').hide();
    $('tr[id^="tr-guest-"]').attr('class','');
    $('#dv-guest-edit-'+gCode).show();
    sld('dv-guest-edit-'+gCode);
    $.get(SerUrl+"V1/Callback/Guest.aspx",{type:3,guestCode:gCode},function(t){
        CM();
        $('#dv-guest-edit-'+gCode).html(t).attr('class','box3').show();
        $('#tr-guest-'+gCode).attr('class','title');
    });
}