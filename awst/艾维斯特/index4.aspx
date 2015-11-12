<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index4.aspx.cs" Inherits="艾维斯特.index4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            setInterval(function () {
                $("#timeLabel").html(new Date().toLocaleString());
            }, 1000)            
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
        
    </div>
    </form>
</body>
</html>
