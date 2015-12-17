<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="艾维斯特.Product" %>

<%@ Register TagName="Top" TagPrefix="uc" Src="~/ucManage/Top.ascx" %>
<%@ Register TagName="Left" TagPrefix="uc" Src="~/ucManage/Left.ascx" %>
<%@ Register TagName="Bottom" TagPrefix="uc" Src="~/ucManage/Bottom.ascx" %>
<%@ Register TagName="Product" TagPrefix="uc" Src="~/ucManage/Product.ascx" %>
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
            var num = $("#ucLeft #aboutTitle li").length * 50 + 50;
            $("#ucLeft #aboutTitle").height(num);
            //var dosth = function () {
            //    a = !a;   //false
            //    if (a) {
            //        alert("aa");
            //        //do sth
            //    } else {
            //        alert("bb");
            //        //do sth
            //    }
            //}
            //产品栏目点击后显示与隐藏 此交互事件源于上面注释的
            $("#ucProduct #aboutTitle ul li ul").css({ "color": "black", "font-size": "weight" })
            $("#ucProduct #aboutTitle ul li ul").hide();
            var a = true;  //开始时显示
            $("#ucProduct #aboutTitle ul li").click(function () {
                a = !a;    //点击后进行隐藏
                if (a) {
                    $(this).children("ul").hide();
                }
                else {
                    $("#ucProduct #aboutTitle ul li ul").hide();
                    $(this).children("ul").show();
                }
            });
            $("#difContent ul li div").hover(function () {
                $(this).children("img").css({ "border": "13px solid #006087" });
            }, function () {
                $(this).children("img").css({ "border": "13px solid #eaeaea" });
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <uc:Top runat="server" ID="ucTop" />
            <div id="ucCenter">
                <uc:Product runat="server" />
                <div id="content">
                    <%=guide %>
                    <%=difInfo %>
                    <%--                     <div class="news">
                        <div class="newsTitle">华中科学仪器展会参展</div>
                        <div class="counts">
                            <p>修改时间：2015年11月26日 浏览次数：120</p>
                        </div>
                        <div class="newsImg">
                            <p><img src="images/1.jpg" style="width: 200px; height: 200px;" /></p>
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
                    <%--                    <ul>
                        <li>
                        <div >
                            <img src="images/1.jpg" style="width:186px;height:186px;" />
                            <p>WDT-W-100B系列电子万...</p>
                        </div>
                        <p>
                            <img src="images/p_btn.gif" /></p>
                        </li>
                    </ul>--%>
                </div>
            </div>
            <uc:Bottom runat="server" ID="ucBottom" />
        </div>
    </form>
</body>
</html>
