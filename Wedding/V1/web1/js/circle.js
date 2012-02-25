(function($){
    $.CircleControl = {
        _DefaultSetting :{
            groupId : 'CircleGroup',
            innerClass : 'inner-circle',
            outerClass : 'outer-circle',
            closeId : 'CloseCircle'
        },
        _DefaultStyle : {
            top:0,
            left:0
//          width:'50px',
//          height:'50px'
        },
        _Create : function(divId, extStyle){
            var obj = $('#'+divId);
	        var closeObj = $('#'+$.CircleControl._DefaultSetting.closeId);            
            if(obj==null) return;
            if(extStyle!=null){
                $.CircleControl._DefaultStyle = $.extend($.CircleControl._DefaultStyle, extStyle);
                for(var item in $.CircleControl._DefaultStyle){
                    obj.css(item, $.CircleControl._DefaultStyle[item]);
                }
            }
	        $.CircleControl._Drag(obj, closeObj);	//设置拖动
            $.CircleControl._InitCloseCircle(closeObj);            
        },
        _SetDivLevel : function(obj){
            $('#'+$.CircleControl._DefaultSetting.groupId+' .'+ $.CircleControl._DefaultSetting.outerClass).each(function(){
                if($(this).attr('Id')==obj.attr('Id')){
                    $(this).css('z-index',100);
                }else{
                    $(this).css('z-index',10);
                }
            });
        },
        _InitCloseCircle : function(closeObj){
            closeObj.mouseover(function(){
                closeObj.show();
            });
            closeObj.click(function(){
                closeObj.hide();
                $('#'+closeObj.attr('field_id')).remove();
            });
        },
        _IsMouseLeaveOrEnter : function(event, handler){
            if (event.type != 'mouseout' && event.type != 'mouseover') return false;  
            var reltg = event.relatedTarget ? event.relatedTarget : event.type == 'mouseout' ? event.toElement : event.fromElement;  
            while (reltg && reltg != handler){  
                reltg = reltg.parentNode;  
            }
            return (reltg != handler);
        },
        _GetNumber : function(n){//处理px单位	
	        return parseInt(n.split("p")[0]);            
        },
        _DragHandle : function(obj, isStopMove, oLeft, oTop){//拖动处理
            var r1 = $.CircleControl._GetNumber(obj.css('width')) / 2;
            var x_1 = $.CircleControl._GetNumber(obj.css('left')) + r1;
            var y_1 = $.CircleControl._GetNumber(obj.css('top')) + r1;
            var isSelect = false;
            $('#'+$.CircleControl._DefaultSetting.groupId+' .'+ $.CircleControl._DefaultSetting.outerClass).each(function(){
                if($(this).attr('Id')==obj.attr('Id')) return true;
                var r2 = $.CircleControl._GetNumber($(this).css('width')) / 2;
                var x_2 = $.CircleControl._GetNumber($(this).css('left')) + r2;
                var y_2 = $.CircleControl._GetNumber($(this).css('top')) + r2;  
                var r = r1 + r2;
                if(isStopMove){
                    if(Math.sqrt(Math.pow(x_1 - x_2, 2) + Math.pow(y_1 - y_2, 2)) <= r){
		                obj.css('left',$(this).css('left'));
	                    obj.css('top',$(this).css('top'));
	                    $(this).css('top', oTop);
	                    $(this).css('left', oLeft);
	                    $(this).removeClass('circle-dstborder');
	                    return false;
                    }
                }else{
                    if(Math.sqrt(Math.pow(x_1 - x_2, 2) + Math.pow(y_1 - y_2, 2)) <= r && !isSelect){
	                    $(this).addClass('circle-dstborder');
	                    isSelect = true;
	                }else{
	                    $(this).removeClass('circle-dstborder');
	                }
                }
            });          
        },
        _StartDrag : function(event, obj, relLeft, relTop){//拖动操作
            var l = event.clientX - relLeft;
            var t = event.clientY - relTop;
            if (t < 0){
	            t = 0;	//防止头部消失
            }
            obj.css('left', l +"px");
            obj.css('top', t +"px");
        },
        _EndDrag : function(obj, oLeft, oTop){//结束拖动
            $(document).unbind('mousemove');
            $(document).unbind('mouseup');
            $.CircleControl._DragHandle(obj, true, oLeft, oTop);
        },
        _Drag : function(obj, closeObj){
            var relLeft = 0;	//记录横坐标
            var relTop = 0;	//记录纵坐标
            
            obj.mousedown(function(event){//鼠标按下
                $.CircleControl._SetDivLevel(obj);	//设置窗口优先级
                var oLeft = obj.css('left');
                var oTop = obj.css('top');
	            relLeft = event.clientX -  $.CircleControl._GetNumber(oLeft); 
	            relTop = event.clientY - $.CircleControl._GetNumber(oTop);
	            $(document).bind('mousemove',function(event){
		            $.CircleControl._StartDrag(event, obj, relLeft, relTop);
		            obj.removeClass('circle-mouseup');
		            obj.addClass('circle-mousemove');
		            $.CircleControl._DragHandle(obj, false);
	                closeObj.hide();
	                event.stopPropagation();
                });
	            $(document).bind('mouseup',function(){
		            $.CircleControl._EndDrag(obj, oLeft, oTop);
		            obj.removeClass('circle-mousemove');
		            obj.addClass('circle-mouseup');
	                obj.mouseover();
	            });
            });
            obj.mouseover(function(event){
                if($.CircleControl._IsMouseLeaveOrEnter(event, this)){
                    var left = $.CircleControl._GetNumber(obj.css('left')) + $.CircleControl._GetNumber(obj.css('width')) - $.CircleControl._GetNumber(closeObj.css('width'));
                    var top = $.CircleControl._GetNumber(obj.css('top')) - $.CircleControl._GetNumber(closeObj.css('width'))/2 + 5;
                    closeObj.css('left', left);
                    closeObj.css('top', top);
                    closeObj.attr('field_id', obj.attr('Id'));
                    closeObj.fadeIn();
                }
            });
            obj.mouseout(function(event){
                if($.CircleControl._IsMouseLeaveOrEnter(event, this)){
                    closeObj.hide();
                }
            });
        }
    };   
})(jQuery);