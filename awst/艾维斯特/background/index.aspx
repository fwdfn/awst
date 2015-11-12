<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="艾维斯特.background.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bg_index_css.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //jquery动态获取现在时间
            setInterval(function () {
                $("#time2").html(new Date().toLocaleString());
            }, 1000);
            //菜单栏点击事件
            $(".bg_index_left_son").hide();          //隐藏所有二级
            //点击某个一级时
            $("#bg_index_left h4").click(function () {
                $(".bg_index_left_son").hide();             //当点击已经打开的时，这个为什么无效
                // 如果当前二级是隐藏的就展开，否则不动
                if ($(this).next(".bg_index_left_son").show()==false)        
                {                    
                    $(this).next(".bg_index_left_son").slideDown();
                }                                
            });
            //获取右边iframe的动态宽度
            $(window).resize(function () {
                var a = $(window).width();
                var b = $("#bg_index_left").width();
                var ab = a - b-20;                
                $("#iframe").css("width", ab);     //初始宽度怎么设置                
            });
            $("#iframe").height("100%");
            //title bodyTop bodyBottom
            //alert($("#title").height());
            //alert($("#bodyTop").height());
            //alert($("#bodyBottom").height());
            
           // alert($("#bg_index_right").height());
            //alert($("#iframe").height());
            //$("#bg_index_right").height = $("#iframe").height();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="bg_index">
        <div id="bg_index_top">
            <asp:ScriptManager ID="sm" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <asp:timer ID="time" runat="server" OnTick="Unnamed1_Tick" Interval="1000" ></asp:timer>
                    <label runat="server" id="currentTime"></label>
                </ContentTemplate>
            </asp:UpdatePanel>                        
            <label id="welcomLab">管理员：<%=Session["UserName"] %>&nbsp;&nbsp;你好,欢迎登陆使用！</label>
            <input type="button" id="bg_exitBtn" runat="server" />
            <%--<span id="time2"></span>--%>
        </div>
        <div id="bg_index_other">
            <div id="bg_index_left">         
                 <%=sb %>                                                         
            </div>
            <div id="bg_index_right">
              <iframe id="iframe" name="iframe" src="column.aspx" scrolling="no" ></iframe>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
