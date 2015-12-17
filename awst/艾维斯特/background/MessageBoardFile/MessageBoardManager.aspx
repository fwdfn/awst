<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageBoardManager.aspx.cs" Inherits="艾维斯特.background.MessageBoardFile.MessageBoardManager" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/bg_index_css.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <title></title>
    <script type="text/javascript">
        $(function () {
            $("#iframe", window.parent.parent.document).height($("body").height());
            $("#bodyTopLeft").height($("#bodyTop").height());
            $("#bodyTopRight").height($("#bodyTop").height());
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="title">
            <img src="../images/bg_index_right_topBg2.jpg" class="bgLeft" />
            <img src="../images/bg_index_right_topBg3.jpg" class="bgRight" />
        </div>
        <div id="bodyTop">
            <div id="bodyTopLeft"></div>
            <div id="bodyTopRight"></div>
            <div class="Title">
                <span class="TitleName">回复留言</span>
            </div>
            <table id="EditColumnTable" cellspacing="1px">
                <tr>
                    <td class="editColumnLeft">留言主题：</td>
                    <td class="editColumnRight">
                        <input type="text" id="msgTitle" runat="server" disabled="disabled" /></td>
                </tr>
                <tr>
                    <td class="editColumnLeft">姓名：</td>
                    <td class="editColumnRight">
                        <input type="text" id="username" runat="server" disabled="disabled" /></td>
                </tr>
                <tr>
                    <td class="editColumnLeft">单位名称：</td>
                    <td class="editColumnRight">
                        <input type="text" id="companyName" runat="server" disabled="disabled" />
                    </td>
                </tr>
                <tr>
                    <td class="editColumnLeft">联系电话：</td>
                    <td class="editColumnRight">
                        <input type="text" id="phone" runat="server" disabled="disabled" />
                    </td>
                </tr>
                <tr>
                    <td class="editColumnLeft">电子邮件：</td>
                    <td class="editColumnRight">
                        <input type="text" id="email" runat="server" disabled="disabled" />
                    </td>
                </tr>
                <tr>
                    <td class="editColumnLeft">留言内容：</td>
                    <td class="editColumnRight">
                        <textarea id="message" runat="server" rows="10" cols="90" disabled="disabled"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="editColumnLeft">回复内容：</td>
                    <td class="editColumnRight">
                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Width="650" Height="400"></FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border-right: 0;">
                        <input type="button" id="submitBtn" runat="server" value="提交" class="btnBG" onserverclick="submitBtn_ServerClick" />
                        <input type="button" id="cancelBtn" runat="server" value="取消" class="btnBG" onserverclick="cancelBtn_ServerClick" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="bodyBottom">
            <img src="../images/ifrBottom_bg2.jpg" class="bgLeft" />
            <img src="../images/ifrBottom_bg3.jpg" class="bgRight" />
        </div>
    </form>
</body>
</html>
