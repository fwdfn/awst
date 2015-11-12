$(function () {
    $("#productTypeTxt ul li:has(ul)").css("background", "none")        //含有ul的li的边线设为0
    $("#productTypeTxt ul li ul").hide();    
    $("#productTypeTxt ul").css("margin-left", "10px");   //将整个ul右移，这时ul里的ul会产生双重位移
    $("#productTypeTxt ul ul").css("margin-left", "0px");  //将ul回移一半
    $("#productTypeTxt ul li").css("border-bottom", "1px dotted #c7c7c7");      //给所有的li设置底部边线
    $("#productTypeTxt ul li:has(ul)").each(function () {
        $(this).last("li").last("li").css("border-bottom", 0);                  //将双重边线去掉一个    
    })
    //$("#productTypeTxt ul li ul li").css("background", function () {        
    //});
    //一二级效果
    //$("#productTypeTxt ul li:even").css("border-bottom", "1px dotted #c7c7c7");
    //$("#productTypeTxt ul").css("border-bottom", "1px dotted #c7c7c7");
    //$("#productTypeTxt ul li:has(ul)").css("background", "none")        //含有ul的li的边线设为0
    //$("#productTypeTxt ul li ul").hide();

    
    $("#productTypeTxt ul li").each(function () {
        $(this).hover(function () {
            $(this).next().children("ul").show();
        }, function () {            
            $(this).next().children("ul").hide();
        });
    });

    //渐隐渐显效果
    var i = 0;
    setInterval(function () {
        $("#example img").hide();
        $("#example img").eq(0).show();        
        $("#example img").eq(i).fadeOut();
        i++;
        if (i >= $("#example img").length)
            i = 0;
        $("#example img").eq(i).fadeIn();        
    }, 1000);
    //全选
    $("#selAll").click(function () {
        $("#gv :checkbox").prop("checked", "true");    
    });
    //反选 
    //prop:获取在匹配的元素集中的第一个元素的属性值。
    $("#selOpposite").click(function () {
        $("#gv :checkbox").prop("checked", function (e, val) {
            return !val;
        });
    });        
    //设置iframe的初始高度(不包含头和底)
    $("#bodyTopLeft").height($("#bodyTop").height());
    $("#bodyTopRight").height($("#bodyTop").height());
    //设置iframe的初始宽度

    ////动态获取gv左右2边样式的长宽
    //$("#bodyTopLeft").height($("#bodyTop").height());
    //$("#bodyTopRight").height($("#bodyTop").height());
    //$(window).resize(
    //    function () {
    //        $("#bodyTopLeft").height($("#bodyTop").height());
    //        $("#bodyTopRight").height($("#bodyTop").height());
    //        //当window变小时gv不会因为过大而溢出
    //        $("#gv").width($("#bodyTop").width() - 16);
    //    }
    //);
    $("#iframe", window.parent.document).height($("body").height());
});
//iframe高度自适应
$(window).resize(
    function () {
        $("#bodyTopLeft").height($("#bodyTop").height());
        $("#bodyTopRight").height($("#bodyTop").height());
        //当window变小时gv不会因为过大而溢出
        $("#gv").width($("#bodyTop").width() - 16);
    }
);
function isChecked(str) {
    //每次点击时num会被重新赋值为0
    var num = 0;
    $("#gv :checked").each(function () {
        if ($(this).prop("checked") == true) {
            num++;
        }
    });
    if (num == 0) {
        alert("请至少选一个");
        return false;
    }
    return confirm(str);
}
//判断搜索文本框是否为空
function isNull() {
    if ($("#searchText").val() == "") {
        alert("请输入要查询的条件");
        return false;
    }
}