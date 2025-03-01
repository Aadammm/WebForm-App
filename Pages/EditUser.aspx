<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="ProjektProgramia.Pages.EditUser" %>

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
                        <a class="navbar-brand" href="/Default.aspx">Home</a>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="nav-link active" href="/Default.aspx">Users</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="AddressList.aspx">Addresses</a>
                            </li>
                          
                        </ul>
                    </div>
                </div>
            </nav>

            <h2>
                <asp:Literal ID="FormTitle" runat="server"></asp:Literal></h2>

            <div class="mb-3">
                <label for="NameTextBox" class="form-label">Name</label>
                <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameValidator" runat="server"
                    ControlToValidate="NameTextBox" ErrorMessage="Required name"
                    CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
            </div>
            <div class="mb-3">
                <div class="row">
                    <div class="col-md-4">
                        <label for="CityTextBox" class="form-label">City</label>
                        <asp:TextBox ID="CityTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label for="PostalCodeTextBox" class="form-label">Postal Code</label>
                        <asp:TextBox ID="PostalCodeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label for="StreetTextBox" class="form-label">Street</label>
                        <asp:TextBox ID="StreetTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label for="HouseNumberTextBox" class="form-label">House Number</label>
                        <asp:TextBox ID="HouseNumberTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>
            </div>
            

            <div>
                <asp:Button ID="SaveButton" runat="server" Text="Save"
                    CssClass="btn btn-primary" OnClick="SaveButton_Click" />
                <asp:Button ID="CancelButton" runat="server" Text="Back"
                    CssClass="btn btn-secondary" OnClick="CancelButton_Click" CausesValidation="false" />
            </div>
            </div>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>
</body>
</html>
