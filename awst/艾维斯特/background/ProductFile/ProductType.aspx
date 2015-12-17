<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductType.aspx.cs" Inherits="艾维斯特.background.ProductFile.ProductList" %>

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

            var height = $("#bodyTop").height();
            $("#bodyTopLeft").height(height);
            $("#bodyTopRight").height(height);
            $("#tableStyle tr").css("background", "#e6f0fc");

            //$(".clickEvent").click(function () {
            //    alert($(this).parent().parent().children("td").eq(0).text());
            //});
                        
            $("#tableStyle td").click(function () {
                var num = $(this).prev("td").text(); //当前行的编号
                if ($(this).parent("tr").next("tr").find("td").eq(1).hasClass(num)) {
                    $("#tableStyle tr").each(function () {
                        if($(this).children("td").eq(1).hasClass(num))
                        {
                            if ($(this).attr("display", "none"))
                            {
                                $(this).attr("display", "block");
                            }
                            if ($(this).hide() == true) {
                                $(this).show();
                                
                            }
                            else {                                
                                $(this).hide();
                            }                            
                        }
                        
                    })
                }                                
            })                       
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
        </div>
        <div id="bodyTop">
            <div id="bodyTopLeft"></div>
            <div id="bodyTopRight"></div>   
            <div class="Title">
                <span class="TitleName">栏目管理</span>
            </div>   
            <asp:Button ID="addBtn" runat="server" Text="添加" CssClass="btnBG" OnClick="addBtn_Click" />      
            <%=ProductColumnInfomation %>                           
        </div>
        <div id="bodyBottom">
            <img src="../images/ifrBottom_bg2.jpg" class="bgLeft" />
            <img src="../images/ifrBottom_bg3.jpg" class="bgRight" />
        </div>
    </form>
</body>
</html>
