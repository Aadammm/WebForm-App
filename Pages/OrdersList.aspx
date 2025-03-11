<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdersList.aspx.cs" Inherits="WebForms.Pages.OrdersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <nav class="navbar navbar-expand-lg navbar-light bg-light mb-4">
            <div class="container-fluid">
                <div class="collapse navbar-collapse">
                    <a class="nav-link active" href="/Default.aspx">Back to Users List</a>
                </div>
            </div>
        </nav>

        <asp:ListView ID="OrdersListView" runat="server">
            <LayoutTemplate>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Product</th>
                            <th>Price</th>
                            <th>Order Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("Id") %></td>
                    <td><%# Eval("Product.Title") %></td>
                    <td><%# Eval("Product.Price", "{0:C}") %></td>
                    <td><%# Eval("OrderDate", "{0:HH:mm dd-MM-yyyy }") %></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <h3 id="TotalAmountLabel" runat="server" aria-atomic="true"></h3>
    </div>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            document.querySelectorAll(".delete-btn").forEach(button => {
                button.addEventListener("click", function (event) {
                    if (!confirm("Naozaj chceš odstrániť túto objednávku?")) {
                        event.preventDefault();
                    }
                });
            });
        });
</script>
</asp:Content>
