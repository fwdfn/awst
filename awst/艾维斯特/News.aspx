<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="艾维斯特.News" %>

<%@ Register Src="~/ucManage/Top.ascx" TagName="Top" TagPrefix="uc" %>
<%@ Register Src="~/ucManage/Left.ascx" TagName="Left" TagPrefix="uc" %>
<%@ Register Src="~/ucManage/Bottom.ascx" TagName="Bottom" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="css/css2.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            //动态设置左边的高度
            var num = $("#aboutTitle li").length * 50 + 50;
            $("#aboutTitle").height(num);

            //var num = window.location.href.charAt(window.location.href.length - 1) - 1;
            //if (num == -1) {
            //    num = 0;
            //}
            //$("#aboutTitle a").eq(num).css({ "color": "#006087", "font-weight": "bold" });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <uc:Top runat="server" ID="ucTop" />
            <div id="ucCenter">
                <uc:Left runat="server" />
                <div id="content">
                    <%=guide %>
                    <%=difInfo %>
                    <div id="newsList">
<%--                        <asp:Repeater ID="repNews" runat="server">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><a href='News.aspx?id=<%#Eval("id") %>&pid=<%#Eval("pid") %>&type=News'><%#Eval("title") %></a><span><%#getTime(Convert.ToDateTime(Eval("cdate"))) %></span></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>--%>
                        <%=NewsList %>
                                             
                    </div>
                </div>
                <uc:Bottom runat="server" ID="ucBottom" />
            </div>
        </div>
    </form>
</body>
</html>
