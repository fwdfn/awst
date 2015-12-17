<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="column.aspx.cs" Inherits="艾维斯特.background.column" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bg_index_css.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">        
        $(function () {
            //去掉gridview最下面和最右边的边框
            $("table tr").last().css("border-bottom", 0);
            $("table tr").find("td:last").css("border-right", 0);
            $("table tr").find("th:last").css("border-right", 0);

            //动态获取gv左右2边样式的长宽
            $("#bodyTopLeft").height($("#bodyTop").height());
            $("#bodyTopRight").height($("#bodyTop").height());
            $(window).resize(
                function(){
                    $("#bodyTopLeft").height($("#bodyTop").height());
                    $("#bodyTopRight").height($("#bodyTop").height());
                    //当window变小时gv不会因为过大而溢出
                    $("#gv").width($("#bodyTop").width() - 16);
                }                                
            );                        
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--标题--%>
        <div id="title">
            <img src="images/bg_index_right_topBg2.jpg" class="bgLeft" />
            <img src="images/bg_index_right_topBg3.jpg" class="bgRight" />
            <span>欢迎界面</span>
        </div>
        <div id="bodyTop">
            <div id="bodyTopLeft"></div>
            <div id="bodyTopRight"></div>  
            <div class="Title">
                <span class="TitleName">栏目管理</span>
            </div>
            <asp:Button ID="addBtn" runat="server" Text="添加" OnClick="addBtn_Click" />            
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" OnRowCreated="gv_RowCreated" >
                 <Columns>
                      <asp:BoundField DataField="id" HeaderText="编号" />
                      <asp:BoundField DataField="title" HeaderText="标题" />
                      <asp:TemplateField HeaderText="是否隐藏">
                            <ItemTemplate >
                                <label><%#Convert.ToInt32(Eval("isHide"))==0?"显示":"隐藏" %></label>
                            </ItemTemplate>
                      </asp:TemplateField>                          
                      <asp:TemplateField HeaderText="顺序">
                            <ItemTemplate >
                                <%--AutoPostBack自动回传。在此处当文本框的值发生改变时会和服务器进行交互--%>
                                <%--后台无法获取gv里控件的id。因此无法通过id.Text获取值--%>
                                <asp:TextBox ID="sort" runat="server" AutoPostBack="true" Text='<%#Eval("sort") %>' OnTextChanged="sort_TextChanged" ></asp:TextBox>                                
                            </ItemTemplate>
                      </asp:TemplateField>               
                     <asp:TemplateField HeaderText="修改">
                            <ItemTemplate>
                                <a href='EditColumn.aspx?id=<%#Eval("id") %>'>修改</a>
                            </ItemTemplate>
                      </asp:TemplateField>               
                     <asp:TemplateField HeaderText="删除">
                            <ItemTemplate >
                                <asp:LinkButton ID="lkb" runat="server" Text="删除" OnClientClick="return confirm('是否确定删除')" CommandArgument='<%#Eval("id") %>' OnCommand="lkb_Command"  ></asp:LinkButton>
                            </ItemTemplate>
                      </asp:TemplateField>                      
                 </Columns>                
            </asp:GridView> 
            <%--<asp:Button ID="updateSort" runat="server" Text="更新排序" />这里可以做一个按钮排序的功能--%>            
        </div>
        <div id="bodyBottom">
            <img src="images/ifrBottom_bg2.jpg" class="bgLeft" />
            <img src="images/ifrBottom_bg3.jpg" class="bgRight" />
        </div>
    </form>
</body>
</html>
