<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageBoard.aspx.cs" Inherits="艾维斯特.background.MessageBoardFile.MessageBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/bg_index_css.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#iframe", window.parent.document).height($("body").height());
            var height = $("#bodyTop").height();
            $("#bodyTopLeft").height(height);
            $("#bodyTopRight").height(height);

        });
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
    <form id="form1" runat="server">
        <div id="title">
            <img src="../images/bg_index_right_topBg2.jpg" class="bgLeft" />
            <img src="../images/bg_index_right_topBg3.jpg" class="bgRight" />
            <span>欢迎界面</span>
        </div>
        <div id="bodyTop">
            <img id="NewsImg" runat="server" src="#" />
            <div id="bodyTopLeft"></div>
            <div id="bodyTopRight"></div>
            <div class="Title">
                <span class="TitleName">留言管理</span>
            </div>
            
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" OnRowCreated="gv_RowCreated" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_PageIndexChanging">
                <PagerStyle HorizontalAlign="Right" />
                <PagerSettings FirstPageText="首页" PreviousPageText="上一页" NextPageText="下一页" LastPageText="尾页" Mode="NextPreviousFirstLast" />
                <Columns>                    
                    <asp:BoundField DataField="id" HeaderText="编号" />
                    <asp:BoundField DataField="title" HeaderText="留言主题" />                    
                    <asp:BoundField DataField="username" HeaderText="姓名" />
                    <asp:BoundField DataField="companyName" HeaderText="单位名称" />
                    <asp:BoundField DataField="phone" HeaderText="联系电话" />
                    <asp:BoundField DataField="email" HeaderText="电子邮件" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href='MessageBoardManager.aspx?id=<%#Eval("id") %>'>回复</a>
                            <asp:LinkButton ID="lkb" runat="server" OnCommand="lkb_Command" OnClientClick='return confirm("是否确定删除")'  CommandArgument='<%#Eval("id") %>'>删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <label>无数据</label>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div id="bodyBottom">
            <img src="../images/ifrBottom_bg2.jpg" class="bgLeft" />
            <img src="../images/ifrBottom_bg3.jpg" class="bgRight" />
        </div>
    </form>
</body>
</html>
