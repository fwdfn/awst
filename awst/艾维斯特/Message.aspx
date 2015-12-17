<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="艾维斯特.Message" %>

<%@ Register Src="~/ucManage/Top.ascx" TagName="Top" TagPrefix="uc" %>
<%@ Register Src="~/ucManage/Bottom.ascx" TagName="Bottom" TagPrefix="uc" %>
<%@ Register Src="~/ucManage/Left.ascx" TagName="Left" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/css2.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <uc:Top runat="server" ID="ucTop" />
            <div id="ucCenter">
                <uc:Left runat="server" />
                <div id="content">
                    <div id="guide">
                        <h3>留言板</h3>
                        <span>
                            <a href="#">首页</a> > 
                         <a href="#">留言板</a> > 
                         <a href="#">查看留言</a>
                        </span>
                    </div>
                    <%=difInfo %>
                </div>
            </div>
            <uc:Bottom runat="server" ID="ucBottom" />
        </div>
    </form>
</body>
</html>
