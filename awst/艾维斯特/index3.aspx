<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index3.aspx.cs" Inherits="艾维斯特.index3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <style type="text/css">
        #all ul li {
            border-bottom:1px solid red;
        }
        #all2 {
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var obj = new Object();
            obj.name = 10;
            obj.go = 20;
            obj.game = function () { alert(1); }
            for (var i in obj) { alert(i); };
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="all">
        <ul>
            <li>afasdf</li>
            <li>afasdf</li>
            <li>afasdf</li>
            <li>afasdf</li>
        </ul>
    </div>
        <div id="all2">
            <ul>
                <li>asdfasdfa</li>
                <li>asdfasdfa</li>
                <li>asdfasdfa</li>
                <li>asdfasdfa</li>
            </ul>
        </div>
        <asp:Button ID="btn" runat="server" OnClick="btn_Click" />
        
    </form>
</body>
</html>
