<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUS.aspx.cs" Inherits="艾维斯特.AboutUS" %>

<%@ Register TagName="Top" TagPrefix="uc" Src="~/ucManage/Top.ascx" %>
<%@ Register TagName="Left" TagPrefix="uc" Src="~/ucManage/Left.ascx" %>
<%@ Register TagName="Bottom" TagPrefix="uc" Src="~/ucManage/Bottom.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="css/css2.css" rel="stylesheet" />
    <script src="js/js1.js"></script>
    <script type="text/javascript">
        $(function () {
            //动态设置Left用户控件第一个方框的高度
            var num = $("#ucLeft #aboutTitle li").length * 50 + 50;
            $("#ucLeft #aboutTitle").height(num);

            //var num = window.location.href.charAt(window.location.href.length - 1) - 1;
            //if (num == -1) {
            //    num = 0;
            //}
            //$("#aboutTitle a").eq(num).css({ "color": "#006087", "font-weight": "bold" });
        });
        function publish() {
            $("#publishBtn1").click();
        }
        function publish2()
        {
            $("#publishBtn2").click();
        }

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
                    <%--留言板--%>
                    <div id="hideDiv" runat="server" class="main" style="margin: 15px auto 0px; padding: 0px; width: 1003px; font-family: 宋体; display: none;">
                        <div class="mod" style="margin: 0px 0px 0px 9px; padding: 0px; display: inline; float: left; width: 726px; min-height: 508px; height: auto !important;">
                            <div class="message_cont" style="margin: 0px; padding: 0px;">
                                <div class="ny_msg" style="margin: 0px auto; padding: 30px 0px 0px;">
                                    <div class="cont" style="margin: 0px; padding: 0px 20px;">
                                        <p class="bridge" style="margin: 0px; padding: 0px; line-height: 30px; text-align: right;"><a href="/Message.aspx" style="text-decoration: none; color: rgb(51, 51, 51);">查看留言</a>&nbsp;|&nbsp;<a href="http://www.avist.com.cn/cn/message.aspx" style="text-decoration: none; color: rgb(51, 51, 51);">填写留言</a></p>
                                        <p class="welcome" style="margin: 0px; padding: 0px; border-bottom-style: dashed; border-bottom-width: 1px; border-bottom-color: rgb(204, 204, 204); width: 651.6875px; height: 45px; line-height: 45px; text-align: center;">欢迎访问，请留下您宝贵的意见，我们真诚的为您服务</p>
                                        <ul class="msg_form" style="margin: 0px auto; padding: 25px 0px 0px; width: 380px;">
                                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                                <p class="type" style="margin: 0px; padding: 0px; width: 80px; float: left; line-height: 21px;"><font color="#FF0000">*</font>留言主题：</p>
                                                <input runat="server" name="guestbook1$ctlTitle" type="text" id="guestbook1_ctlTitle" maxlength="120" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" />&nbsp;</li>
                                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                                <p class="type" style="margin: 0px; padding: 0px; width: 80px; float: left; line-height: 21px;"><font color="#FF0000">*</font>姓　　名：</p>
                                                <input runat="server" name="guestbook1$ctlName" type="text" id="guestbook1_ctlName" maxlength="10" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" /></li>
                                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                                <p class="type" style="margin: 0px; padding: 0px; width: 80px; float: left; line-height: 21px;"><font color="#FF0000">*</font>单位名称：</p>
                                                <input runat="server" name="guestbook1$ctlUnitName" type="text" id="guestbook1_ctlUnitName" maxlength="50" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" /></li>
                                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                                <p class="type" style="margin: 0px; padding: 0px; width: 80px; float: left; line-height: 21px;"><font color="#FF0000">*</font>联系电话：</p>
                                                <input runat="server" name="guestbook1$ctlPhone" type="text" id="guestbook1_ctlPhone" maxlength="70" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" /></li>
                                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                                <p class="type" style="margin: 0px; padding: 0px; width: 80px; float: left; line-height: 21px;"><font color="#FF0000">&nbsp;</font>电子邮件：</p>
                                                <input runat="server" name="guestbook1$ctlEmail" type="text" id="guestbook1_ctlEmail" maxlength="120" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" /></li>
                                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                                <p class="type" style="margin: 0px; padding: 0px; width: 80px; float: left; line-height: 21px;"><font color="#FF0000">*</font>留言内容：</p>
                                                <textarea runat="server" name="guestbook1$ctlContent" id="guestbook1_ctlContent" rows="5" cols="40" style="margin: 0px; padding-top: 0px; padding-left: 0px; font-size: 12px; font-family: Tahoma, Helvetica, Arial, sans-serif;"></textarea></li>
                                            <li class="butbox" style="margin: 0px; padding: 10px 0px 2px; list-style-type: none; width: 380px; float: left;">
                                                <input name="guestbook1$btnSave" type="button" id="guestbook1_btnSave" value="发表" onclick="publish()" style="margin: 0px 0px 0px 100px; padding: 2px 0px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 24px; width: 60px;" />
                                                <input name="res" type="reset" id="res" value="重写" style="margin: 0px; padding: 2px 0px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 24px; width: 60px;" />
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--在线报修--%>
                    <div id="hideDiv2" runat="server" class="main" style="display:none;" >
                        <p class="welcome" style="margin: 0px; padding: 0px; border-bottom-style: dashed; border-bottom-width: 1px; border-bottom-color: rgb(204, 204, 204); width: 651.6875px; height: 45px; line-height: 45px; text-align: center; font-family: 宋体;">欢迎访问,我们真诚的为您服务!</p>
                        <ul class="msg_form" style="margin: 0px auto; padding: 25px 0px 0px; width: 380px; font-family: 宋体;">
                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                <p class="type" style="margin: 0px; padding: 0px; width: 100px; float: left; line-height: 21px;"><font color="#FF0000">*</font>设备名称：</p>
                                <input runat="server" name="guestbook1$ctlTitle2"  type="text" id="guestbook1_ctlTitle2" maxlength="120" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" />&nbsp;</li>
                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                <p class="type" style="margin: 0px; padding: 0px; width: 100px; float: left; line-height: 21px;"><font color="#FF0000">*</font>故障描述：</p>
                                <textarea runat="server" name="guestbook1$ctldescription2" id="guestbook1_ctldescription2" rows="5" cols="40" style="margin: 0px; padding-top: 0px; padding-left: 0px; font-size: 12px; font-family: Tahoma, Helvetica, Arial, sans-serif;"></textarea></li>
                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                <p class="type" style="margin: 0px; padding: 0px; width: 100px; float: left; line-height: 21px;"><font color="#FF0000">*</font>保修期内：</p>
                                <span id="guestbook1_ctlwarranty_span">
                                    <input  runat="server" id="guestbook1_ctlwarranty1" type="radio" name="guestbook1$ctlwarranty" value="是" checked="true" style="margin-top: 0px; margin-right: 0px; margin-left: 0px; padding: 2px 0px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" />
                                    <label for="guestbook1_ctlwarranty1">是</label>
                                    <input id="guestbook1_ctlwarranty2" type="radio" name="guestbook1$ctlwarranty" value="否" style="margin-top: 0px; margin-right: 0px; margin-left: 0px; padding: 2px 0px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" />
                                    <label runat="server" for="guestbook1_ctlwarranty2">否</label>
                                </span>                
                            </li>
                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                <p class="type" style="margin: 0px; padding: 0px; width: 100px; float: left; line-height: 21px;"><font color="#FF0000">*</font>单位名称：</p>
                                <input runat="server" name="guestbook1$ctlcompanyName2" type="text" id="guestbook1_ctlcompanyName2" maxlength="120" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" /></li>
                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                <p class="type" style="margin: 0px; padding: 0px; width: 100px; float: left; line-height: 21px;"><font color="#FF0000">*</font>联 系 人：</p>
                                <input runat="server" name="guestbook1$ctluserName2" type="text" id="guestbook1_ctluserName2" maxlength="50" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" /></li>
                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                <p class="type" style="margin: 0px; padding: 0px; width: 100px; float: left; line-height: 21px;"><font color="#FF0000">*</font>联系电话：</p>
                                <input runat="server" name="guestbook1$ctlphone2" type="text" id="guestbook1_ctlphone2" maxlength="50" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" /></li>
                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                <p class="type" style="margin: 0px; padding: 0px; width: 100px; float: left; line-height: 21px; text-indent: 7px">电子邮件：</p>
                                <input runat="server" name="guestbook1$ctlemail2" type="text" id="guestbook1_ctlemail2" maxlength="50" size="40" style="margin: 0px; padding-top: 2px; padding-bottom: 2px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 14px;" /></li>
                            <li style="margin: 0px; padding: 2px 0px; list-style-type: none; width: 380px; float: left;">
                                <p class="type" style="margin: 0px; padding: 0px; width: 100px; float: left; line-height: 21px; text-indent: 7px">备　　注：</p>
                                <textarea runat="server" name="guestbook1$ctlremarks2" id="guestbook1_ctlremarks2" rows="5" cols="40" style="margin: 0px; padding-top: 0px; padding-left: 0px; font-size: 12px; font-family: Tahoma, Helvetica, Arial, sans-serif;"></textarea></li>
                            <li class="butbox" style="margin: 0px; padding: 10px 0px 2px; list-style-type: none; width: 380px; float: left;">
                                <%--<input name="guestbook1$btnSave" type="button" id="guestbook1_btnSave" value="发表" onclick="publish()" style="margin: 0px 0px 0px 100px; padding: 2px 0px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 24px; width: 60px;" />--%>

                                <input runat="server" name="guestbook1$btnSave2" type="button" id="guestbook1_btnSave2" value="发表" onclick="publish2()" style="margin: 0px 0px 0px 100px; padding: 2px 0px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 24px; width: 60px;" />                                
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name="res2" type="reset" id="res2" value="重写" style="margin: 0px; padding: 2px 0px; font-size: 12px; line-height: 14px; font-family: Tahoma, Helvetica, Arial, sans-serif; border: 1px solid rgb(192, 206, 218); height: 24px; width: 60px;" /></li>
                        </ul>
                        <p>&nbsp;</p>
                    </div>

                    <%--留言板隐藏button--%>
                    <asp:Button ID="publishBtn1" runat="server" CssClass="hideBtn" OnClick="publishBtn1_Click" />
                    <%--在线报修隐藏button--%>
                    <asp:Button ID="publishBtn2" runat="server" CssClass="hideBtn" OnClick="publishBtn2_Click" />
                </div>
            </div>
            <uc:Bottom runat="server" ID="ucBottom" />
        </div>
    </form>
</body>
</html>
