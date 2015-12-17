<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product.ascx.cs" Inherits="艾维斯特.ucManage.Product" %>
<div id="ucProduct" style="float: left; margin-bottom: 13px;">
    <div id="About">
        <div id="about_25" style="margin-bottom:30px;">
             <img src="../images/product_05.jpg" />
            <div id="aboutTitle">
                <%=productType %>
            </div>
        </div>
    </div>
    <div id="contact">
        <div id="about_26">
            <img src="../images/about_26.jpg" />
            <div id="aboutContact">
                <%=getCompanyInfo %>
            </div>
        </div>
    </div>
</div>