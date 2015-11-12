<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="艾维斯特.index2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                   <ul >
                    <li><a href="#">设为首页</a> |</li>
                    <li><a href="#">加入收藏</a> |</li>
                    <li><a href="#">联系我们</a></li>
                   </ul>
                   <img src="images/phoneNumber.jpg" />
                 </div>
             </div>
             <div id="menu">
                <ul>
                    <li><a href="#">网站首页</a></li>
                    <li><a href="#">关于我们</a></li>
                    <li><a href="#">新闻中心</a></li>
                    <li><a href="#">产品中心</a></li>
                    <li><a href="#">服务与售后</a></li>
                    <li><a href="#">人才招聘</a></li>
                    <li><a href="#">留言板</a></li>
                    <li><a href="#">联系我们</a></li>
                </ul>
                <input id="searchTxt" type="text" />
                <input id="searchBtn" type="button" />
             </div>
         </div>
         <div id="center">
             <div id="productType">
                 <div id="productTypePic">
                       <img src="images/productTypePic.jpg" />
                       <img class="more" src="images/more.jpg" />
                 </div>                                        
                 <div id="productTypeTxt" >
                       <ul>
                           <li class="li1">酶标仪和洗板机系列</li>
                           <li>                               
                               <ul>
                                   <li>酶标仪系列</li>
                                   <li>洗板机系列</li>
                               </ul>
                           </li>
                           <li>超微量分光光度计系列</li>
                           <li>                               
                               <ul>
                                   <li>超微量分光光度计</li>
                                   <li>超微量核酸分析仪</li>
                               </ul>
                           </li>
                           <li>生特样品前处理仪器系列</li>
                           <li>                               
                               <ul>
                                   <li>生物样品均质器</li>
                                   <li>微孔板热封仪</li>
                               </ul>
                           </li>
                           <li>干式恒温器(金属浴)系列</li>
                           <li>                               
                               <ul>
                                   <li>普通加热型</li>
                                   <li>加热制冷型</li>
                               </ul>
                           </li>
                           <li>振荡/混匀/孵育/摇床系列</li>
                           <li>                               
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
                 </div>
             </div>
             <div id="centerRight">
                 <div id="example">
                     <img src="images/1.jpg" />
                     <img src="images/2.jpg" />
                     <img src="images/3.jpg" />
                     <img src="images/4.jpg" />
                     <img src="images/5.jpg" />
                 </div> 
                 <div id="introduce">
                     <div id="companyIntroduce">
                         <img src="images/companyIntroduce.jpg" />
                         <p>&nbsp;&nbsp;&nbsp;
                             &nbsp;
                             &nbsp;
                             &nbsp;
                             &nbsp;武汉艾维斯特科技有限公司是经营分析仪器、实验设备、环保仪器、教学设备、各种检测仪器设备以及相应的配件和耗材的专业公司。我公司是杭州奥盛仪器有限公司华中办事处、杭州柏恒科技有限公司华中办事处、北京君意东方电泳设备有限公司特约代理商。凭着诚信、诚实、互信的公司理念和卓越的商业信用以及强大的专业背景，和美国安捷伦</p>
                         <a href="#">[详细]</a>
                     </div>
                     <div id="news">
                         <div id="newsTitle" >
                             <img src="images/news.jpg" />
                             <img class="more" src="images/more2.jpg" />
                         </div>
                         <div id="newsInfo">
                             <ul>
                                 <li><a href="#">华中科学仪器展会参展</a></li>
                                 <li><a href="#">华中科学仪器展会参展之不同</a></li>
                                 <li><a href="#">华中科学仪器展会参展</a></li>
                                 <li><a href="#">华中科学仪器展会参展</a></li>
                                 <li><a href="#">华中科学仪器展会参展之不同3</a></li>
                                 <li><a href="#">华中科学仪器展会参展</a></li>                                 
                             </ul>
                         </div>
                     </div>
                 </div>
             </div>
             <div id="gogoing">
                 <div id="productShow">
                       <img src="images/productShow.jpg" class="show"  />
                       <img src="images/more2.jpg" class="more" />
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
         <div id="footer">
             <div id="logo2">
                 <img src="images/logo2.jpg" />
             </div>
             <div id="copyRight">
                 公司电话：027－87166527 公司传真：027-87530722 公司QQ：1740864522 公司地址：武汉市洪山区雄楚大街450号
                 <br />
                 公司邮箱：avist_wh@163.com 技术支持：<a href="#">仙桃赵斌</a> <a href="#">[网站管理]</a> 
                 <br />
                 武汉艾维斯特科技有限公司 版权所有 ©
             </div>
         </div>
    </div>
    </form>
</body>
</html>
