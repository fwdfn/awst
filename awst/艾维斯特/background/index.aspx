<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="艾维斯特.background.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bg_index_css.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">  
        //返回后台登陆页面
        function jumpPage() {            
            window.location.href = "/background/login.aspx";
        }
        $(function () {            
            //jquery动态获取现在时间
            setInterval(function () {
                $("#time2").html(new Date().toLocaleString());
            }, 1000);
            //菜单栏点击事件

            //隐藏所有二级
            $(".bg_index_left_son").hide();          
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
                var a = $(window).width();            //屏幕的宽度
                var b = $("#bg_index_left").width();  //左边菜单栏的宽度
                var ab = a - b-20;                    //菜单栏和框架间的间隔为20。ab即为框架的宽度
                $("#iframe").css("width", ab);        
            });
            $("#iframe").height("100%");              //框架高度设为100%
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
            <label id="welcomLab">管理员：<%=Session["UserName"] %>你好,欢迎登陆使用！</label>
            <input type="button" id="bg_exitBtn" runat="server" onclick="jumpPage()"  />
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
