<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetailed.aspx.cs" Inherits="艾维斯特.NewsDetailed" %>

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
                        
                    </div>
                    <%=news %>
              <%-- <div class="news">
                        <div class="newsTitle">华中科学仪器展会参展</div>
                        <div class="counts">
                            <p>修改时间：2015年11月26日 浏览次数：120</p>
                        </div>
                        <div class="newsImg">
                            <p>
                                <img src="images/1.jpg" style="width: 200px; height: 200px;" /></p>
                        </div>
                        <div class="otherNews">
                            <ul>
                                <li><span>上一条:</span><a href="#">上一条新闻</a></li>
                                <li><span>下一条：</span><a href="#">无新闻</a></li>
                            </ul>
                        </div>
                        <div class="print">
                            <a href="javascript:window.print()">【打印此文】</a>
                            <a href="javascript:window.close()">【关闭窗口】</a>
                        </div>
                    </div>--%>
                </div>
                <uc:Bottom runat="server" ID="ucBottom" />
            </div>
        </div>
    </form>
</body>
</html>
