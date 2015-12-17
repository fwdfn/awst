<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="艾维斯特.ucManage.Top" %>
<div id="ucTop">
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
                    <li><a href="index.aspx">网站首页</a></li>
                    <%=bindMenu %>
                </ul>
                <input id="searchTxt" type="text" />
                <input id="searchBtn" type="button" />
             </div>
             <div id="TopBan">
                <img src="images/TopBan.jpg" />
             </div>
         </div>
</div>