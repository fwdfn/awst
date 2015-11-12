<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abc.aspx.cs" Inherits="艾维斯特.background.abc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <title></title>
    <style type="text/css">
        body {
            margin:0;
            padding:0;
        }
        * {
            margin:0 ;
            padding:0;
        }
        #left {
            width:50%;
            height:300px;  
            float:left;
            background:green;
                      margin:0;
                      padding:0;
        }
        #h4 {
            background:red;
            width:182px;
            height:30px;
        }
        #img2 {
            position:relative;
            top:-10px;
            
        }
        #right {
            width:50%;
            height:300px;
            float:left;
            background:yellow;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //全选
            $("#selAll").click(function () {
                $("#gv :checkbox").attr("checked", "true");
            });
            //反选
            $("#selFan").click(function () {
                $("#gv :checkbox").each(function () {                    
                   $(this).checked = !$(this).checked;
                });
            });
            //$("#delete").click(function () {
            //    ///alert($("#gv :checkbox").attr("checked", "true").length);
            //});

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">       
        <input type="button" value="全选" runat="server" id="selAll" />
        <input type="button" value="反选" runat="server" id="selFan" />
        <input type="button" value="删除" runat="server" id="delete"  />
        <input type="button" value="全选" runat="server" />

           <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false">
               <Columns>
                   <asp:TemplateField>
                       <ItemTemplate>
                           <input type="checkbox" runat="server" />
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="title" HeaderText="asdfa" />
               </Columns>
           </asp:GridView>               
<%--       <div style="width:100%;height:500px;">
       <div id="left">
           <h4 id="h4">广告位管理</h4>
           <img id="img2" src="images/bg_index_left_bgTu2.jpg" style="width:182px;height:4px;" />
           <div>
               <ul>
                   <li>asdfasd</li>
                   <li>asdfasd</li>
                   <li>asdfasd</li>
               </ul>
           </div>
       </div>
        <div id="right">
            asdfasd

        </div>--%>
    <%--</div>--%>
    </form>
</body>
</html>
