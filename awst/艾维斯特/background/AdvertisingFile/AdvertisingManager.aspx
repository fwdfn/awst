<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertisingManager.aspx.cs" Inherits="艾维斯特.background.AdvertisingFile.AdvertisingManager" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/bg_index_css.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <style type="text/css">
        #bodyTop #upLoadImg {
            border-top:1px solid black;
            border-left:1px solid black;            
            width:120px;
            height:120px;
            position:absolute;
            right:20px;
            top:60px;
        }
    </style>
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
                <span class="TitleName"><%=operation %></span>
              </div>
              <table id="EditColumnTable" cellspacing="1px">
                     <tr>
                         <td class="editColumnLeft" >图片名称：</td>
                         <td class="editColumnRight" ><input type="text" id="name" runat="server" value="Upload/" />
                             <label style="color:red;">*请将图片名设置为Upload/a.jpg的格式</label>
                         </td>
                     </tr>       
                     <tr>
                         <td class="editColumnLeft">所属类别：</td>
                         <td class="editColumnRight">
                             <input type="text" id="type" runat="server" value="0" />
                             <label style="color:red;">*首页图片请设置为0,子页图片请设置为1</label>
                         </td>
                     </tr>   
                     <tr>
                         <td class="editColumnLeft">序号：</td>
                         <td class="editColumnRight"><input type="text" id="EditColumnRightsort" runat="server" /></td>
                     </tr>                          
                     <tr>
                         <td class="editColumnLeft">是否隐藏：</td>
                         <td class="editColumnRight">
                             是：<input type="checkbox" runat="server" id="hide" name="isHide" />                             
                             否：<input type="checkbox" runat="server" id="show" name="isHide" checked="checked" />                             
                         </td>
                     </tr>
                     <tr>
                         <td class="editColumnLeft">上传图片：</td>
                         <td class="editColumnRight">
                             <asp:FileUpload ID="upLoad" runat="server" />
                             <asp:Button ID="upLoadBtn" runat="server" Text="上传" CssClass="btnBG" OnClick="upLoadBtn_Click" />
                             <label style="color:red;">*选择图片前，请改好图片名</label>
                         </td>
                     </tr>                                                                   
                     <tr>
                         <td colspan="2" style="border-right:0;" >
                             <input type="button" id="submitBtn" runat="server" value="提交" class="btnBG" onserverclick="submitBtn_ServerClick" />
                             <input type="button" id="cancelBtn" runat="server" value="取消" class="btnBG"  />
                         </td>
                     </tr>               
                </table>
                <img id="upLoadImg" runat="server" />                              
        </div>
        <div id="bodyBottom">
            <img src="../images/ifrBottom_bg2.jpg" class="bgLeft"  />
            <img src="../images/ifrBottom_bg3.jpg" class="bgRight" />
        </div>
    </form>
</body>
</html>
