<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CopyRight.aspx.cs" Inherits="艾维斯特.background.CopyRight" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <link href="css/bg_index_css.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            //动态获取gv左右2边样式的长宽
            $("#bodyTopLeft").height($("#bodyTop").height());
            $("#bodyTopRight").height($("#bodyTop").height());
            $("#iframe", window.parent.document).height($("body").height());
            $(window).resize(
                function () {
                    $("#bodyTopLeft").height($("#bodyTop").height());
                    $("#bodyTopRight").height($("#bodyTop").height());
                    //当window变小时gv不会因为过大而溢出
                    $("#gv").width($("#bodyTop").width() - 16);
                }
            );
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="title">
            <img src="images/bg_index_right_topBg2.jpg" class="bgLeft" />
            <img src="images/bg_index_right_topBg3.jpg" class="bgRight" />
            <span>欢迎界面</span>
        </div>
        <div id="bodyTop">
            <div id="bodyTopLeft"></div>
            <div id="bodyTopRight"></div>  
            <div class="Title">
                <span class="TitleName">网站信息管理</span>
            </div>          
              <table id="optimize" cellspacing="1px" >
                     <tr style="height:50px;font-size:25px;">
                         <th colspan="2">网站优化</th>                         
                     </tr>
                     <tr>
                         <td class="editColumnLeft margin" >Title优化：</td>
                         <td class="editColumnRight" >
                             <textarea id="titleOP" runat="server"  cols="80" rows="5" class="resize"  ></textarea>
                         </td>
                     </tr>  
                     <tr>
                         <td class="editColumnLeft" >Keywords优化：</td>
                         <td class="editColumnRight" >
                             <textarea id="keywordsOP" runat="server" cols="80" rows="5" class="resize"></textarea>
                         </td>
                     </tr>  
                     <tr>
                         <td class="editColumnLeft" >description优化：</td>
                         <td class="editColumnRight" >
                             <textarea id="descriptionOP" runat="server" cols="80" rows="5" class="resize"></textarea>
                         </td>
                     </tr>  
              </table> 
              <table id="EditColumnTable" cellspacing="1px">       
                     <tr style="height:50px;font-size:25px;">
                         <th colspan="2">公司信息配置</th>                         
                     </tr>
                     <tr>
                         <td class="editColumnLeft margin" >公司名称：</td>
                         <td class="editColumnRight" >
                             <textarea id="name" runat="server" cols="80" class="resize" ></textarea>                             
                         </td>
                     </tr>       
                     <tr>
                         <td class="editColumnLeft" >公司地址：</td>
                         <td class="editColumnRight" >
                             <textarea id="address" runat="server" cols="80" class="resize" ></textarea>                             
                             <%--<input type="text" id="address" runat="server" value="images/" />--%>                             
                         </td>
                     </tr>       
                     <tr>
                         <td class="editColumnLeft">公司网址：</td>
                         <td class="editColumnRight"><textarea id="website" runat="server" cols="80" class="resize" ></textarea></td>
                     </tr>
                     <tr>
                         <td class="editColumnLeft" >电话：</td>
                         <td class="editColumnRight" >
                             <textarea id="phone" runat="server" cols="80" class="resize" ></textarea>                             
                             <%--<input type="text" id="phone" runat="server" value="images/" />--%>                             
                         </td>
                     </tr>
                     <tr>
                         <td class="editColumnLeft">移动电话：</td>
                         <td class="editColumnRight"><textarea id="cellphone" runat="server" cols="80" class="resize" ></textarea></td>
                     </tr>       
                     <tr>
                         <td class="editColumnLeft" >传真：</td>
                         <td class="editColumnRight" >
                             <textarea id="fax" runat="server" cols="80" class="resize" ></textarea>                             
                             <%--<input type="text" id="fax" runat="server" value="images/" />--%>                             
                         </td>
                     </tr>
                     <tr>
                         <td class="editColumnLeft" >QQ：</td>
                         <td class="editColumnRight" >
                             <textarea id="qq" runat="server" cols="80" class="resize" ></textarea>                             
                             <%--<input type="text" id="qq" runat="server" value="images/" />--%>                             
                         </td>
                     </tr>         
                     <tr>
                         <td class="editColumnLeft" >Email：</td>
                         <td class="editColumnRight" >
                             <textarea id="email" runat="server" cols="80" class="resize" ></textarea>                             
                             <%--<input type="text" id="email" runat="server" value="images/" />--%>                             
                         </td>
                     </tr>                                 
                     <tr>
                         <td class="editColumnLeft" >技术支持：</td>
                         <td class="editColumnRight" >
                             <textarea id="support" runat="server" cols="80" class="resize" ></textarea>                             
                             <%--<input type="text" id="support" runat="server" value="images/" />--%>                             
                         </td>
                     </tr>    
                     <tr>
                         <td class="editColumnLeft" >版权信息：</td>
                         <td class="editColumnRight" >
                             <textarea id="copyright" runat="server" cols="80" class="resize" ></textarea>                             
                             <%--<input type="text" id="copyright" runat="server" value="images/" />                             --%>
                         </td>
                     </tr>                                                                                                              
                     <tr>
                         <td colspan="2" style="border-right:0;" >
                             <input type="button" id="submitBtn" runat="server" value="提交" class="btnBG" onserverclick="submitBtn_ServerClick" />
                             <input type="button" id="cancelBtn" runat="server" value="取消" class="btnBG"  />
                         </td>
                     </tr>               
                </table>   
        </div>
        <div id="bodyBottom">
            <img src="images/ifrBottom_bg2.jpg" class="bgLeft" />
            <img src="images/ifrBottom_bg3.jpg" class="bgRight" />
        </div>
    </form>
</body>
</html>
