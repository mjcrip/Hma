<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="NewStuffContent" runat="Server">
<div class="singlepost_area">
    <div class="singlepost_content">
        <a href="#" class="stuff_category">{Section_Name}</a> <span class="stuff_date">{Post_Month} <strong>{Post_Date}</strong></span>
        <h2><a href="#">{Post_Title}</a></h2>
        {Image_Source_Element}
        <p>{Paragraph_Content_1}</p>
        <blockquote>{Block_Quote}</blockquote>
        <ul>{List_Items}</ul>
        <p>{Paragraph_Content_2}</p>
        <div class="singlepage_pagination"> <a class="previous_btn" href="#">Previous</a> <a class="next_btn" href="#">Next</a> </div>
        <div class="social_area wow fadeInLeft">
            <ul>
                <li><a href="#"><span class="fa fa-facebook"></span></a></li>
                <li><a href="#"><span class="fa fa-twitter"></span></a></li>
                <li><a href="#"><span class="fa fa-google-plus"></span></a></li>
                <li><a href="#"><span class="fa fa-linkedin"></span></a></li>
                <li><a href="#"><span class="fa fa-pinterest"></span></a></li>
            </ul>
        </div>
        <div class="author">
            <a href="#"><img src="../images/100x100.jpg" alt=""></a>
            <div class="author_details">
                <h3><a href="#">{Author_Name}</a></h3>
                <p>{Author_Detail}</p>
            </div>
        </div>
    </div>
</div>
</asp:Content>