<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsInformationManager.aspx.cs" Inherits="艾维斯特.background.NewsFile.NewsInformationManager" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/bg_index_css.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(function () {            
            $("#iframe", window.parent.document).height($("body").height());
            $('#imgColor').click(function () {
                $('#colourPalette').css({ "left": $(this).position().left + 15 + "px", "top": $(this).position().top + 45 + "px" });
                if (document.getElementById("colourPalette").style.visibility == "hidden") {
                    document.getElementById("colourPalette").style.visibility = "visible";
                } else {
                    document.getElementById("colourPalette").style.visibility = "hidden";
                }
            });
            //序号不能为空(添加新闻功能)
            $("#EditColumnRightsort").blur(function () {
                //不是数字时
                if (isNaN($("#EditColumnRightsort").val()))
                {                    
                    setTimeout(function () {
                        $("#EditColumnRightsort").focus();
                        $("#EditColumnRightsort").val(0);
                        alert("请输入数字");                        
                    }, 300);
                }
                else if($(this).val()=="")
                {                    
                    setTimeout(function () {
                        $("#EditColumnRightsort").focus();
                        $("#EditColumnRightsort").val(0);
                        alert("不能为空");
                    }, 300);
                }
            });
        });
        function setColor(color) {
            $('#txtColor').val(color);
            $('#imgColor').css("backgroundColor", color);
            document.getElementById("colourPalette").style.visibility = "hidden";
        }
        //$("table tr").last().css("border-bottom", 0);
        //$("table tr").find("td:last").css("border-right", 0);
        //$("table tr").find("th:last").css("border-right", 0);

        ////动态获取gv左右2边样式的长宽
        //$("#bodyTopLeft").height($("#bodyTop").height());
        //$("#bodyTopRight").height($("#bodyTop").height());
        $(window).resize(
            function () {
                $("#bodyTopLeft").height($("#bodyTop").height());
                $("#bodyTopRight").height($("#bodyTop").height());
                //当window变小时gv不会因为过大而溢出
                $("#gv").width($("#bodyTop").width() - 16);
            }
        );

    </script>
</head>
<body>
     <iframe width="260" height="165" id="colourPalette" src="../images/post/nc_selcolor.htm"
            style="visibility: hidden; position: absolute; z-index:999; left: 0px; top: 0px; border: 1px gray solid"
            frameborder="0" scrolling="no"></iframe>
    <form id="form1" runat="server">
        <div id="title">    
            <img src="../images/bg_index_right_topBg2.jpg" class="bgLeft" />
            <img src="../images/bg_index_right_topBg3.jpg" class="bgRight" />
        </div>
        <div id="bodyTop">
            <div id="bodyTopLeft"></div>
            <div id="bodyTopRight"></div>  
             <div class="Title">
                <span class="TitleName"><%=columnInfo %></span>
              </div>
              <table id="EditColumnTable" cellspacing="1px">                     
                     <tr>
                         <td class="editColumnLeft" >信息标题：</td>
                         <td class="editColumnRight" ><input type="text" id="NewsTitle" runat="server" /></td>
                     </tr>
                     <tr>
                         <td class="editColumnLeft">所属栏目：</td>
                         <td class="editColumnRight">
                             <asp:DropDownList runat="server" ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                 <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                             </asp:DropDownList>
                             <asp:DropDownList ID="ddlPSY" runat="server">
                                 <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                     </tr>                       
                     <tr>
                         <td class="editColumnLeft">序号：</td>
                         <td class="editColumnRight"><input type="text" id="EditColumnRightsort" runat="server" value="0" />
                             <label style="color:red;">*请输入数字</label>
                         </td>
                     </tr>
                     <tr>
                         <td class="editColumnLeft">链接地址：</td>
                         <td class="editColumnRight"><input type="text" id="LinkUrl" runat="server" /></td>
                     </tr>  
                     <tr>
                         <td class="editColumnLeft" >新闻来源：</td>
                         <td class="editColumnRight" >                             
                             <asp:DropDownList ID="ddlNewSource" runat="server">
                                 <asp:ListItem Value="0">本站原创</asp:ListItem>
                                 <asp:ListItem Value="1">外部新闻</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                     </tr>                                   
                     <tr>
                         <td class="editColumnLeft" >点击数：</td>
                         <td class="editColumnRight" ><input type="text" id="Clicks" runat="server" disabled="disabled" value="0" /></td>
                     </tr>
                     <tr>
                         <td class="editColumnLeft" >标题颜色：</td>
                         <td class="editColumnRight" >
                             <input type="text" style="width:50px" id="txtColor" runat="server" name="txtColor" maxlength="7"/>                           
		         <img id="imgColor" runat="server" border="0" src="../Images/post/Rect.gif" style="cursor: pointer;
                     background-color: #000000;" onclick="Getcolor(this,'txtColor');" title="选取颜色!" /> 
                         </td>

                     </tr>
                     <tr>
                         <td class="editColumnLeft">操作：</td>
                         <td class="editColumnRight">
                             是否隐藏：
                             <asp:CheckBox runat="server" ID="isHide" />
                             是否推荐：
                             <asp:CheckBox runat="server" ID="isRecommand" />
                             是否热点：
                             <asp:CheckBox runat="server" ID="isHot" />
                             是否审核：
                             <asp:CheckBox runat="server" ID="isVerify" />
                             是否首页：
                             <asp:CheckBox runat="server" ID="isIndex" />
                         </td>
                     </tr> 
<%--                     <tr>
                         <td class="editColumnLeft">图片路径：</td>
                         <td class="editColumnRight">
                             <asp:FileUpload ID="upload" runat="server" />
                             <input type="button" id="uploadBtn" value="上传" runat="server" onserverclick="uploadBtn_Click" />
                         </td>                         
                     </tr>  --%>        
                    <tr>
                        <td class="editColumnLeft">内容：</td>
                        <td class="editColumnRight">
                            <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Width="650" Height="400"></FCKeditorV2:FCKeditor>
                        </td>
                    </tr>
                     <tr>
                         <td colspan="2" style="border-right:0;" >
                             <input type="button" id="submitBtn" runat="server" value="提交" class="btnBG" onserverclick="submitBtn_ServerClick" />
                             <input type="button" id="cancelBtn" runat="server" value="取消" class="btnBG"  />
                         </td>
                     </tr>               
                </table>             
                <%--<img id="uploadImg" src="#" runat="server" />--%>          
        </div>
        <div id="bodyBottom">
            <img src="../images/ifrBottom_bg2.jpg" class="bgLeft" />
            <img src="../images/ifrBottom_bg3.jpg" class="bgRight" />
        </div>
    </form>
</body>
</html>
