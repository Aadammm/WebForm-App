<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ProjektProgramia._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <nav class="navbar navbar-expand-lg navbar-light bg-light mb-4">
            <div class="container-fluid">
                <div class="collapse navbar-collapse">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="Pages/AddressList.aspx">Addresses</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Pages/ProductsList.aspx">Products</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

         <h2>Users List</h2>
        <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False"
            CssClass="table table-striped" OnRowCommand="UsersGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <%# Eval("Address.Street") %> <%# Eval("Address.HouseNumber") %>, 
                        <%# Eval("Address.City") %>, <%# Eval("Address.PostalCode") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Orders">
                    <ItemTemplate>
                        <asp:Button ID="OrdersButton" runat="server"
                            Text='<%# Eval("Orders.Count")+" orders "  %>'
                            CommandName="ShowOrders"
                            CssClass="btn btn-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' />
                        <asp:Button ID="AddOrdersButton" runat="server"
                            Text="New Order"
                            CommandName="AddOrders"
                            CssClass="btn btn-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="EditButton" runat="server" Text="Edit"
                            CommandName="EditUser" CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="DeleteButton" runat="server" Text="Remove"
                            CommandName="DeleteClient" CommandArgument='<%# Eval("Id") %>'
                            CssClass="btn btn-danger btn-sm"
                            OnClientClick="return confirm('Really want remove this user ?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="AddNewClientButton" runat="server" Text="Create New User"
            CssClass="btn btn-primary mb-3" OnClick="AddNewClientButton_Click" />
        <div id="alertBoxSuccess" class="alert alert-success" role="alert" runat="server" visible="false" />
        <div id="alertBoxRemove" class="alert alert-danger" role="alert" runat="server" visible="false" />
    </div>
</asp:Content>
