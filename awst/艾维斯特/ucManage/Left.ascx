<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="艾维斯特.ucManage.Left" %>

<div id="ucLeft" style="float: left; margin-bottom: 13px;">
    <div id="About">
        <div id="about_25">
            <%=img%>
            <div id="aboutTitle">
                <%=getMenu %>
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





