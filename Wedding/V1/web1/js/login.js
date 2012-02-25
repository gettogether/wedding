function doLogin(){
    //window.location="Home.aspx";
    var sldId='dv-login-form';
    sld(sldId);
    $.getJSON(SerUrl+'V1/Callback/Common.ashx?type=1'+getParams('dv-login-form','LG_'),{},function(d){
        CM();
        //trace(d);
        if(d.success){
        //trace(d);
            window.location="Home.aspx";
        }
        else{
            MsgBox(d.message,null,false,sldId);
        }
    });
}
$(document).ready(function(){
    $('#btn-login').click(function(){doLogin();});
});