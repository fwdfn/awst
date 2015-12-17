<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index4.aspx.cs" Inherits="艾维斯特.index4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            
            setInterval(function () {
                $("#timeLabel").html(new Date().toLocaleString());
            }, 1000)
            function sayAge()
            {
                alert("你的年龄：29");
            }
            var age = 29;
            window.abc = "red";
            //alert(window.abc);
            alert(Window.age);                      
        });
    </script>
</head>
<body>
    <%--2种获取时间的方法存在时间差，猜想1：系统处理这2种时间存在先后顺序;猜想2：asp通过后台交互反应慢--%>
    <form id="form1" runat="server">
        <div>
            <%--通过js动态获取当前时间--%>
            <label id="timeLabel"></label>

            <%--asp控件动态获取当前时间--%>
            <asp:ScriptManager ID="sm" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="time" runat="server" OnTick="time_Tick" Interval="1000"></asp:Timer>
                    <label id="showTime" runat="server"></label>
                </ContentTemplate>
            </asp:UpdatePanel>               
            <div id="productType">
                <ul>
                    <li><a href="#">酶标仪和洗板机系列</a>
                        <ul>
                            <li><a href="#">酶标仪系列</a></li>
                            <li><a href="#">洗板机系列</a></li>
                        </ul>
                    </li>
                    <li><a href="#">超微量分光光度计系列</a>
                        <ul>
                            <li><a href="#">超微量分光光度计</a></li>
                            <li><a href="#">超微量核酸分析仪</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
