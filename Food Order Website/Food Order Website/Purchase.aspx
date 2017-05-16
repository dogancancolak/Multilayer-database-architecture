<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Food_Order_Website.Purchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="PurchaseGrid" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Ürün">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("allProducts") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fiyat">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("totalPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sipariş Notu">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("purchaseNote") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ödeme Tipi">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Checked='<%# Bind("payment") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sipariş Zamanı">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("orderDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
