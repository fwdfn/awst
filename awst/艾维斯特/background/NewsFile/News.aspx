<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="艾维斯特.background.NewsFile.News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <link href="../css/bg_index_css.css" rel="stylesheet" />
    <script type="text/javascript">
        //判断是否选中
        //函数里使用return false才不会刷新页面               
        $(function () {
            //全选
            $("#selAll").click(function () {                
                $("#gv :checkbox").prop("checked", "true");
            });
            //反选 
            //prop:获取在匹配的元素集中的第一个元素的属性值。
            $("#selOpposite").click(function () {
                $("#gv :checkbox").prop("checked", function (e, val) {
                    return !val;
                });
            });
                      
            //获取新闻图片
            $("#gv a").click(function (e) {
                if ($(this).attr("src") != "") {
                    var X = e.pageX;
                    var Y = e.pageY;
                    $("#NewsImg").css({ "left": X - 100, "top": Y - 60 });
                    var path = $(this).attr("src");
                    $("#NewsImg").attr("src", path);
                    $("#NewsImg").show();
                }
            });
            $("#NewsImg").mouseout(function () {
                $(this).hide();
            });            
            $("#iframe", window.parent.parent.document).height($("body").height());
            $("#bodyTopLeft").height($("#bodyTop").height());
            $("#bodyTopRight").height($("#bodyTop").height());
        });

        function isChecked(str) {
            //每次点击时num会被重新赋值为0
            var num = 0;
            $("#gv :checked").each(function () {
                if ($(this).prop("checked") == true) {
                    num++;
                }
            });
            if (num == 0) {
                alert("请至少选一个");
                return false;
            }
            return confirm(str);
        }
        //修改新闻判断是否只选择了一个
        function oneChecked() {
            var num = 0;
            $("#gv :checkbox").each(function () {
                if ($(this).prop("checked")) {
                    num++;
                }
            });
            //没选择时
            if (num == 0) {
                alert("请选择一个");
                return false;
            }
                //只选择了一个
            else if (num > 1) {
                alert("只能选择一个");
                $("#gv :checkbox").each(function () {
                    if ($(this).prop("checked")) {
                        $(this).prop("checked", false);
                    }
                });
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--标题--%>
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
                <span class="TitleName">栏目管理</span>
            </div>           
            
            <input id="selAll" type="button" runat="server" value="全选" class="btnBG" />         
            <input id="selOpposite" type="button" runat="server" value="反选" class="btnBG" />             
            <asp:Button ID="BtnAdd" runat="server" CssClass="btnBG" Text="添加" OnClick="BtnAdd_Click" />
            <asp:Button ID="BtnUpdate" runat="server" CssClass="btnBG" Text="修改" OnClientClick="return oneChecked()" OnClick="BtnUpdate_Click" />            
            <asp:Button ID="BtnDelete" runat="server" Text="删除" CssClass="btnBG" OnClientClick='return isChecked("是否确定删除")' OnClick="BtnDelete_Click" />
            <asp:Button ID="BtnVerify" runat="server" Text="审核" CssClass="btnBG" OnClientClick='return isChecked("是否审核")' OnClick="BtnVerify_Click" />
            <asp:DropDownList ID="ddlSort" runat="server" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>排序方式</asp:ListItem>
                <asp:ListItem>按ID升序</asp:ListItem>
                <asp:ListItem>按ID降序</asp:ListItem>
                <asp:ListItem>按日期升序</asp:ListItem>
                <asp:ListItem>按日期降序</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSelect_SelectedIndexChanged">
                <asp:ListItem>快速定位</asp:ListItem>
                <asp:ListItem>已审核</asp:ListItem>
                <asp:ListItem>未审核</asp:ListItem>
                <asp:ListItem>已推荐</asp:ListItem>
                <asp:ListItem>未推荐</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" >
            </asp:DropDownList>
            <input type="text" runat="server" id="searchText" />            
            <asp:Button Text="搜索" ID="searchBtn" runat="server" OnClientClick="return isNull()"  OnClick="searchBtn_Click" CssClass="btnBG" />
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" OnRowCreated="gv_RowCreated" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_PageIndexChanging" >
                 <PagerStyle HorizontalAlign="Right"  />
                 <PagerSettings FirstPageText="首页" PreviousPageText="上一页" NextPageText="下一页" LastPageText="尾页" Mode="NextPreviousFirstLast" />
                 <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <input type="checkbox" runat="server" id="chk" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="编号" /> 
                     <asp:BoundField DataField="title" HeaderText="标题" />                      
                     <asp:TemplateField HeaderText="所属栏目">
                         <ItemTemplate>
                             <label><%#getParentName(Convert.ToInt32(Eval("pid"))) %></label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="是否隐藏">
                         <ItemTemplate>
                              <%#Convert.ToInt32(Eval("isHide"))==1?"隐藏":"显示" %>
                         </ItemTemplate>
                     </asp:TemplateField>     
                     <asp:TemplateField HeaderText="是否推荐">
                         <ItemTemplate>
                              <%# Convert.ToInt32(Eval("isrecommand"))==1 ?"已推荐":"未推荐" %>
                         </ItemTemplate>
                     </asp:TemplateField> 
                     <asp:TemplateField HeaderText="是否热点">
                         <ItemTemplate>
                              <%#Convert.ToInt32(Eval("ishot"))==1?"是":"否" %>
                         </ItemTemplate>
                     </asp:TemplateField> 
                     <asp:TemplateField HeaderText="是否审核">
                         <ItemTemplate>
                              <%#Convert.ToInt32(Eval("isverify"))==1?"已审核":"未审核" %>
                         </ItemTemplate>
                     </asp:TemplateField> 
        <%--             <asp:TemplateField HeaderText="是否首页">
                         <ItemTemplate>
                              <%# Convert.ToInt32(Eval("isindex"))==1?"是":"否" %>
                         </ItemTemplate>
                     </asp:TemplateField>--%>
                     <asp:TemplateField HeaderText="标示图片">
                         <ItemTemplate>
                              <a href="javascript:void(0)" id="ShowPic" src='<%#Eval("picpath") %>' style="color:#333333"><%#(Eval("picpath")==""||Eval("picpath")==DBNull.Value)?"暂无图片":"显示图片" %></a>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="新闻来源">
                         <ItemTemplate>
                             <label><%#(Eval("source")==""||Eval("source")==DBNull.Value)?"外部新闻":"本站原创" %></label>
                         </ItemTemplate>
                     </asp:TemplateField>
            <%--         <asp:BoundField DataField="sort" HeaderText="序号" />    --%>                                       
                     
                     <%--<asp:BoundField DataField="cdate" HeaderText="创建日期" />--%>
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
