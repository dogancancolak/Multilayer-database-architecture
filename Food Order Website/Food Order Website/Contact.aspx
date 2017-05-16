<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Food_Order_Website.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>İletişim</h2>
    <h3>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Contact-Us-PNG.png" Width="216px" />
    </h3>
    <address>
        Buca kaynaklar Tınaztepe kampüsü
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">dogancancolak1@gmail.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:reza-da@hotmail.com">reza-da@hotmail.com</a>&nbsp;
        </address>

        <div id="fb-root"></div>
         <script>(function(d, s, id) {
          var js, fjs = d.getElementsByTagName(s)[0];
          if (d.getElementById(id)) return;
          js = d.createElement(s); js.id = id;
          js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=1396861977224095";
          fjs.parentNode.insertBefore(js, fjs);
            }(document, 'script', 'facebook-jssdk'));</script>
<div class="fb-share-button" data-href="http://www.yemekgonder.com" data-width="100px" data-type="box_count"></div>
 <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://www.yemekgonder.com" data-text="Yemeğn tek adresi !" data-via="YemekGönder" data-count="vertical">Tweet</a>
<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script>


</asp:Content>
