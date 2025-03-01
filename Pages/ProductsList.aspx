<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="ProjektProgramia.Pages.ProductsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <nav class="navbar navbar-expand-lg navbar-light bg-light mb-4">
            <div class="container-fluid">
                <div class="collapse navbar-collapse">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="/Default.aspx">Users</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="AddressList.aspx">Addresses</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <h2>Products List</h2>
        <asp:GridView ID="ProductsGridView" runat="server" AutoGenerateColumns="False"
            CssClass="table table-striped" OnRowCommand="ProductsGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="MakeOrderButton" runat="server" Text="Make Order"
                            CommandName="MakeOrder" CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-secondary btn-sm" />

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="EditButton" runat="server" Text="Edit"
                            CommandName="EditProduct" CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="DeleteButton" runat="server" Text="Remove"
                            CommandName="DeleteProduct" CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-danger btn-sm"
                            OnClientClick="return confirm('Really want remove this product?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="NewProductButton" runat="server" Text="Add new product"
            CssClass="btn btn-primary mb-3" OnClick="AddNewProductButton_Click" Visible="true" />
        <div id="alertBoxSuccess" class="alert alert-success" role="alert" runat="server" visible="false" />
        <div id="alertBoxRemove" class="alert alert-danger" role="alert" runat="server" visible="false" />
    </div>
</asp:Content>
