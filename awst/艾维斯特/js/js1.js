$(function () {
    $("#productType #productTypeTxt ul li").children("ul").hide();
    //控制加减图片距离
    $("#productType #productTypeTxt ul").css("margin-left", "10px");
    $("#productType #productTypeTxt ul ul").css("margin-left", "0px");
    //一级li的下划线
    $("#productType #productTypeTxt ul li li").css("border-bottom", "1px solid #c7c7c7");
    //含有ul的li添加下划线
    $("#productType #productTypeTxt ul li:has(ul)").css("border-bottom", "1px solid #c7c7c7");
    //ul添加一个上划线
    $("#productType #productTypeTxt ul li ul").css("border-top", "1px solid #c7c7c7");
    $("#productType #productTypeTxt ul li").hover(function () {
       $(this).children("ul").show();
       //当前li里面ul的最后一个li
       $(this).find("li").last().css("border-bottom", "none");       
    }, function () {
       $(this).children("ul").hide();
    })

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
    //$("#iframe", window.parent.document).height($("body").height());


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

//判断搜索文本框是否为空
function isNull() {
    if ($("#searchText").val() == "") {
        alert("请输入要查询的条件");
        return false;
    }
}

