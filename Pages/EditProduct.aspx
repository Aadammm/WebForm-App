<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="WebForms.Pages.EditProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <nav class="navbar navbar-expand-lg navbar-light bg-light mb-4">
                <div class="container-fluid">
                    <div class="collapse navbar-collapse">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="nav-link active" href="/Default.aspx">Users</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="AddressList.aspx">Addresses</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="ProductsList.aspx">Producs</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <h2>
                <asp:Literal ID="FormTitle" runat="server"></asp:Literal></h2>
            <div>
                <div class="mb-3">
                    <label for="txtTitle" class="form-label">Title</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NameValidator" runat="server"
                        ControlToValidate="txtTitle" ErrorMessage="Can not be empty"
                        CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label for="txtDescription" class="form-label">Description</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtPrice" class="form-label">Price</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div>
                    <asp:Button ID="btnAddAddress" runat="server" Text="Save"
                        CssClass="btn btn-primary" OnClick="AddProductButton_Click" />
                    <asp:Button ID="CancelButton" runat="server" Text="Back"
                        CssClass="btn btn-secondary" OnClick="CancelButton_Click" CausesValidation="false" />
                </div>
            </div>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>
</body>
</html>
