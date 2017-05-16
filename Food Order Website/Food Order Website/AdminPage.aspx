<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Food_Order_Website.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="PRODUCTS" runat="server" Font-Bold="True" Font-Size="20pt" Text="PRODUCTS"></asp:Label>
    
        <asp:GridView ID="AdminProductGrid" runat="server" Width="100%" AutoGenerateColumns ="False" OnRowDeleting="AdminProductGrid_RowDeleting"
             OnRowEditing="AdminProductGrid_RowEditing" ShowFooter="True" OnRowCancelingEdit="AdminProductGrid_RowCancelingEdit" OnRowUpdating="AdminProductGrid_RowUpdating"
             CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"/>
            <asp:TemplateField HeaderText="ProductID" InsertVisible="False" 
                    SortExpression="ProductID" Visible="true">
                    <EditItemTemplate>
                        <asp:Label ID="LabelProductID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="InsertProduct" runat="server" OnClick="InsertProduct_Click" Text="Insert" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName" >
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertProductName" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category" SortExpression="CategoryID">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListCategories" runat="server" SelectedValue='<%# Bind("CategoryID") %>'>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListInsertCategory" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxPrice" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertPrice" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stock" SortExpression="Stock">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBoxStock" runat="server" Text='<%# Bind("Stock") %>'></asp:CheckBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="Label5" runat="server" Enabled="False" Checked='<%# Bind("Stock") %>'></asp:CheckBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="TextBoxInsertStock" runat="server"></asp:CheckBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertDescription" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>


        </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    
        <asp:Label ID="feedbackProduct" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <p>
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="20pt" Text="USERS"></asp:Label>
        </p>
        <asp:GridView ID="AdminUserGrid" ShowFooter="True" runat="server" AutoGenerateDeleteButton="True" 
            AutoGenerateEditButton="True" Width="100%" AutoGenerateColumns="False" 
            OnRowCancelingEdit="AdminUserGrid_RowCancelingEdit" OnRowDeleting="AdminUserGrid_RowDeleting" 
            OnRowEditing="AdminUserGrid_RowEditing" OnRowUpdating="AdminUserGrid_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:TemplateField HeaderText="UserID">
                    <EditItemTemplate>
                        <asp:Label ID="LabelEditID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="InsertUser" runat="server" OnClick="InsertUser_Click" Text="Insert" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxEditName" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertName" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelName" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Surname">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxEditSurname" runat="server" Text='<%# Bind("surname") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertSurname" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelSurname" runat="server" Text='<%# Bind("surname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telephone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxEditTelephone" runat="server" Text='<%# Bind("telephone") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertTelephone" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelTelephone" runat="server" Text='<%# Bind("telephone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxEditEmail" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertEmail" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelEmail" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxEditPassword" runat="server" Text='<%# Bind("password") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertPassword" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelPassword" runat="server" Text='<%# Bind("password") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxEditAddress" runat="server" Text='<%# Bind("address") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxInsertAddress" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelAddress" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="isAdmin">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBoxEditIsAdmin" runat="server" Checked='<%# Bind("isAdmin") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxInsertIsAdmin" runat="server" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxIsAdmin" runat="server" Enabled="false" Checked='<%# Bind("isAdmin") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:Label ID="feedbackUser" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>
