<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressList.aspx.cs" Inherits="ProjektProgramia.Pages.AddressList" MasterPageFile="~/Site.Master" %>

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
                            <a class="nav-link" href="ProductsList.aspx">Products</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <h2>Address List</h2>
        <asp:GridView ID="AddressesGridView" runat="server" AutoGenerateColumns="False"
            CssClass="table table-striped" OnRowCommand="AddressesGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Street" HeaderText="Street" />
                <asp:BoundField DataField="HouseNumber" HeaderText="House Number" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" />
                <asp:TemplateField HeaderText="Akcie">
                    <ItemTemplate>
                        <asp:Button ID="EditButton" runat="server" Text="Edit"
                            CommandName="EditAddress" CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="DeleteButton" runat="server" Text="Remove"
                            CommandName="DeleteAddress" CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-danger btn-sm"
                            OnClientClick="return confirm('Really want remove this address?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="AddNewAddressButton" runat="server" Text="Add new address"
            CssClass="btn btn-primary mb-3" OnClick="AddNewAddressButton_Click" />
    </div>
</asp:Content>
