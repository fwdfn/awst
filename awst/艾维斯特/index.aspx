<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="艾维斯特.index" %>

<%@ Register Src="~/ucManage/Bottom.ascx" TagName="Bottom" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=webTitle %></title>
    <meta name="keywords" content="<%=webKeywords%>" />
    <meta name="description" content="<%=webDescription %>" />
    <link href="css/css2.css" rel="stylesheet" />
    <link href="css/owl.carousel.min.css" rel="stylesheet" />
    <link href="css/owl.theme.default.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/js1.js"></script>
    <%--旋转木马--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".owl-carousel").owlCarousel({
                items: 5,
                loop: true,
                autoplay: true,
                autoplayTimeout: 1000,
                loop: true,
                nav: true,
                center: true,
                dots: false,
                autoplayHoverPause: true,
            });
        });
        // 设置为主页 仅ie10有效
        function SetHome(obj, vrl) {
            try {
                obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl);
            }
            catch (e) {
                if (window.netscape) {
                    try {
                        netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                    }
                    catch (e) {
                        alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入“about:config”并回车\n然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
                    }
                    var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
                    prefs.setCharPref('browser.startup.homepage', vrl);
                } else {
                    alert("您的浏览器不支持，请按照下面步骤操作：1.打开浏览器设置。2.点击设置网页。3.输入：" + vrl + "点击确定。");
                }
            }
        }
        // 加入收藏 兼容360和IE6 
        function shoucang(sTitle, sURL) {
            try {
                window.external.addFavorite(sURL, sTitle);
            }
            catch (e) {
                try {
                    window.sidebar.addPanel(sTitle, sURL, "");
                }
                catch (e) {
                    alert("加入收藏失败，请使用Ctrl+D进行添加");
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div id="header">
                <div id="logo">                    
                    <div id="logoLeft">
                        <img class="logo1" src="images/logo.jpg" />
                        <img class="logo2" src="images/companyName.jpg" />
                        <marquee>这是一条滚动信息</marquee>
                    </div>                    
                    <div id="logoRight">
                        <ul>
                            <li class="fore1"><a href="javascript:void(0)" onclick="SetHome(this,window.location)">设为首页</a></li> 
                            <li class="ge">|</li>
                            <li class="fore2"><a href="javascript:void(0)" onclick="shoucang(document.title,window.location)">加入收藏</a></li> 
                            <li class="ge">|</li> 
                            <li><a href="#">联系我们</a></li>
                        </ul>
                        <img src="images/phoneNumber.jpg" />
                    </div>
                </div>
                <div id="menu">
                    <ul>
                        <li><a href="index.aspx">网站首页</a></li>
                        <%=bindMenu %>
                    </ul>
                    <input id="searchTxt" runat="server" type="text" />
                    <input id="searchBtn" type="button" runat="server" onserverclick="searchBtn_ServerClick" />
                </div>
            </div>
            <div id="center">
                <div id="productType">
                    <div id="productTypePic">
                        <img src="images/productTypePic.jpg" />
                        <a href="/Product.aspx?id=9&pid=0">
                            <img class="more" src="images/more.jpg" /></a>
                    </div>
                    <%=productType %>
                    <%-- <div id="productTypeTxt">
                        <ul>
                            <li class="li1">酶标仪和洗板机系列
                               <ul>
                                   <li>酶标仪系列</li>
                                   <li>洗板机系列</li>
                               </ul>
                            </li>
                            <li>超微量分光光度计系列
                               <ul>
                                   <li>超微量分光光度计</li>
                                   <li>超微量核酸分析仪</li>
                               </ul>
                            </li>
                            <li>生特样品前处理仪器系列
                               <ul>
                                   <li>生物样品均质器</li>
                                   <li>微孔板热封仪</li>
                               </ul>
                            </li>
                            <li>干式恒温器(金属浴)系列
                               <ul>
                                   <li>普通加热型</li>
                                   <li>加热制冷型</li>
                               </ul>
                            </li>
                            <li>振荡/混匀/孵育/摇床系列
                               <ul>
                                   <li>恒温混匀仪</li>
                                   <li>微孔板孵育器</li>
                                   <li>微孔板振荡器</li>
                                   <li>多管涡旋混合仪</li>
                                   <li>试剂卡孵育器</li>
                                   <li>摇床系列</li>
                               </ul>
                            </li>
                        </ul>
                    </div>--%>
                </div>
                <div id="centerRight">
                    <div id="example">
                        <%=imgs %>
                        <img src="Upload/horse.jpg" />
                    </div>
                    <div id="introduce">
                        <div id="companyIntroduce">
                            <img src="images/companyIntroduce.jpg" />
                            <%=companyIntroduce %>
                            <%--                            <p>
                                &nbsp;&nbsp;&nbsp;
                             &nbsp;
                             &nbsp;
                             &nbsp;
                             &nbsp;武汉艾维斯特科技有限公司是经营分析仪器、实验设备、环保仪器、教学设备、各种检测仪器设备以及相应的配件和耗材的专业公司。我公司是杭州奥盛仪器有限公司华中办事处、杭州柏恒科技有限公司华中办事处、北京君意东方电泳设备有限公司特约代理商。凭着诚信、诚实、互信的公司理念和卓越的商业信用以及强大的专业背景，和美国安捷伦
                            </p>--%>
                            <a href="/AboutUS.aspx?id=3&pid=1">[详细]</a>
                        </div>
                        <div id="news">
                            <div id="newsTitle">
                                <img src="images/news.jpg" />
                                <a href="/News.aspx?id=5&pid=0">
                                    <img class="more" src="images/more2.jpg" /></a>
                            </div>
                            <div id="newsInfo">
                                <ul>
                                    <%=newsList %>
                                    <%--                            <li><a href="#">华中科学仪器展会参展</a></li>
                                    <li><a href="#">华中科学仪器展会参展之不同</a></li>
                                    <li><a href="#">华中科学仪器展会参展</a></li>
                                    <li><a href="#">华中科学仪器展会参展</a></li>
                                    <li><a href="#">华中科学仪器展会参展之不同3</a></li>
                                    <li><a href="#">华中科学仪器展会参展</a></li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="gogoing">
                    <div id="productShow">
                        <img src="images/productShow.jpg" class="show" />
                        <a href="/Product.aspx?id=9&pid=0">
                            <img src="images/more2.jpg" class="more" /></a>
                    </div>
                    <div class="owl-carousel">
                        <div class="owl-item">
                            <img src="images/carousel1.jpg" />
                            MK2000-1 干式恒温器
                          <img src="images/price.gif" class="price" />
                        </div>
                        <div class="owl-item">
                            <img src="images/carousel2.jpg" />
                            MK2000-1 干式恒温器
                          <img src="images/price.gif" class="price" />
                        </div>
                        <div class="owl-item">
                            <img src="images/carousel3.jpg" />
                            MK2000-1 干式恒温器
                          <img src="images/price.gif" class="price" />
                        </div>
                        <div class="owl-item">
                            <img src="images/carousel4.jpg" />
                            MK2000-1 干式恒温器
                          <img src="images/price.gif" class="price" />
                        </div>
                        <div class="owl-item">
                            <img src="images/carousel5.jpg" />
                            MK2000-1 干式恒温器
                          <img src="images/price.gif" class="price" />
                        </div>
                    </div>
                </div>
            </div>
            <%--<div id="footer">
             <div id="logo2">
                 <img src="images/logo2.jpg" />
             </div>
             <div id="copyRight">
                 <%=companyInfo %>                 
             </div>
         </div>--%>
            <uc:Bottom runat="server" ID="ucBottom" />
        </div>
    </form>
</body>
</html>
