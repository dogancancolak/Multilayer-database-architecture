<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Food_Order_Website.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="welc" runat="server" Text="Label" Visible="False" Width="100%"></asp:Label>
    <div> 
        <asp:Image ID="Image1" runat="server" Height="91px" ImageUrl="~/images/Indonesian_Food.png" Width="191px" />
        <asp:Label ID="Label14" runat="server" Text="Ana Yemekler" Visible="true" Width="100%" Font-Size="Large" Font-Bold="true"></asp:Label>
        <asp:GridView ID="ProductGrid" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px">
            <Columns>
                <asp:TemplateField HeaderText="Miktar">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxOrderCount" runat="server" Height="18px" Width="53px" Text="0"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="YemekId" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ürün">
                    <ItemTemplate>
                        <asp:Label ID="LabelYemek" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fiyat">
                    <ItemTemplate>
                        <asp:Label ID="LabelPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Açıklama">
                    <ItemTemplate>
                        <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60%" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    
    </div>
    <div>
        <asp:Image ID="Image2" runat="server" Height="95px" ImageUrl="~/images/kahvaltılık-peynirli-kanepe-tarifi.png" Width="192px" />
        <asp:Label ID="Label15" runat="server" Text="Aperatifler" Visible="true" Width="100%" Font-Size="Large" Font-Bold="true"></asp:Label>
        <asp:GridView ID="aperatifGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px">
            <Columns>
                <asp:TemplateField HeaderText="Miktar">
                    <ItemTemplate>
                        <asp:TextBox ID="aperatifCount" runat="server" Height="18px" Width="53px">0</asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="YemekID" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ürün">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fiyat">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Açıklama">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60%" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>

    </div>
    <div>
        <asp:Image ID="Image3" runat="server" Height="96px" ImageUrl="~/images/tequila drinks.png" Width="194px" />
        <asp:Label ID="Label16" runat="server" Text="İçecekler" Visible="true" Width="100%" Font-Size="Large" Font-Bold="true"></asp:Label>
        <asp:GridView ID="IcecekGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px">
            <Columns>
                <asp:TemplateField HeaderText="Miktar">
                    <ItemTemplate>
                        <asp:TextBox ID="IcecekCount" runat="server" Height="18px" Width="53px">0</asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="YemekID" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ürün">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fiyat">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Açıklama">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60%" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>

    </div>
    <div>
        <asp:Image ID="Image4" runat="server" Height="103px" ImageUrl="~/images/desserts.png.jpg" Width="199px" />
        <asp:Label ID="Label17" runat="server" Text="Tatlılar" Visible="true" Width="100%" Font-Size="Large" Font-Bold="true"></asp:Label>
        <asp:GridView ID="tatlıGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="100%" ShowFooter="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px">
            <Columns>
                <asp:TemplateField HeaderText="Miktar">
                    <ItemTemplate>
                        <asp:TextBox ID="tatlıCount" runat="server" Height="18px" Width="53px">0</asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="YemekID" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ürün">
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fiyat">
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Açıklama">
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60%" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>

    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Sepete Yolla" OnClick="GoButton_Click" />
    </div>
    <asp:Label ID="feedback" runat="server" Text="Label" Visible="false"></asp:Label>
    
    

</asp:Content>
