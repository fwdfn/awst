<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="艾维斯特.background.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/css1.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function abc() {
            alert("取消");
        }

        //此方法和login_btn点击事件二选一
        //function isNull() {
        //    if ($("#verity").val() == "" || $("#userName").val() == "" || $("#userPwd").val() == "") {
        //        alert("用户名，密码，验证码不能为空");
        //        return false;
        //    }
        //}
        $(function () {
            //通过js判断文本框是否为空，不为空则进行后台判断
            $("#login_btn").click(function () {
                if ($("#verity").val() == "" || $("#userName").val() == "" || $("#userPwd").val() == "") {
                    alert("用户名，密码，验证码不能为空");
                    return false ;
                }                                                   
            });
            //回车时自动点击登陆
            $(window).keydown(function (e) {
                if (e.keyCode == 13)
                {
                    $("#login_btn").click();          //点击登陆按钮
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="backgroundLogin">
        <div id="bg_top">
            
        </div>
        <div id="bg_center">
            <div id="bg_center_left">
                <div id="aboutLogo">
                    <img id="backgroundLogo" src="images/aboutlogo.jpg" />
                    <p>1-门户站的首选</p>
                    <p>1-门户站的首选</p>
                    <p>1-门户站的首选</p>
                    <div id="server1">
                        <a href="#">使用说明</a>                        
                    </div>
                    <div id="server2">
                        <a href="#">在线客服</a>                        
                    </div>                                        
                </div>                
            </div>
            <div id="bg_center_right">
                 <table id="login_info" >
                     <tr>
                         <td colspan="3"><h2>登陆信息网站后台管理</h2></td>
                     </tr>
                     <tr>
                         <td class="tableLeft">管理员:</td>
                         <td class="inputTxt"><input class="inputTxt" id="userName" type="text" runat="server" /></td>
                     </tr>
                     <tr>
                         <td class="tableLeft">密码:</td>
                         <td class="inputTxt"><input type="text" id="userPwd" runat="server" /></td>
                         <td><img src="images/luck.gif" /></td>
                     </tr>
                     <tr>
                         <td class="tableLeft">验证码:</td>
                         <td id="ooo" ><input class="inputTxt"  type="text" id="verity" runat="server" />
                             <img src="VerifyCode.aspx" id="verifyCode" onclick="this.src=this.src+'?'" />
                         </td>                         
                     </tr>
                     <tr>
                         <td></td>                         
                         <td colspan="2">
                             <%--<input class="button1"  type="button" id="login_btn" value="登陆" runat="server" onserverclick="login_btn_Click" />--%>                                                          
                             <asp:Button ID="login_btn" runat="server" CssClass="button1" Text="登陆" OnClientClick="return isNull()"  OnClick="login_btn_Click"  />
                             <input  class="button1" id="cancel" type="button" value="取消" runat="server" onclick="abc()"  />
                         </td>                         
                     </tr>
                 </table>
            </div>
        </div>
        <div id="bg_bottom">
               <p>Copyright&copy2009-2015</p>             
        </div>
    </div>
    </form>
</body>
</html>
