<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Helper.aspx.cs" Inherits="WebForms.Pages.Helper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Helper</title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a class="center-box" href="/Default.aspx"><strong>Back</strong> "href="/Default.aspx"</a>
        </div>

        <label>Bindovanie hodnot z kodu</label>
        <div>
            <asp:Label ID="LabelBind" runat="server" CssClass="userNameCell"></asp:Label>
            <br />
            <asp:Literal ID="LiteralBind" runat="server"></asp:Literal>
            <br />
            <span><%=PropertyName %></span>
        </div>


        <label>Nacitanie dat zo stranky do kodu</label>
        <div>
            <label for="CityTextBox" class="form-label">Vlozeny text asp</label>
            <asp:TextBox ID="TextBox" runat="server" CssClass="textBox" placeholder="je pristupny v .cs"></asp:TextBox>
            <br />
            <label for="textInput" class="form-label">Textový vstup input:</label>
            <input type="text" class="textBox" id="textInput" name="textInput" placeholder="Neni pristupny v .cs" />
            <br />
        </div>


        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" BorderWidth="1px"
            CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Poradie" />
                <asp:BoundField DataField="Row1" HeaderText="Stlpec1" />
                <asp:BoundField DataField="Row2" HeaderText="Stlpec2" />
            </Columns>
        </asp:GridView>

        <div>
        </div>

        <div class="box-box">
            #
        </div>

        <div>
            <label id="jsChangeLabel" for="btn">Ahoj</label>
            <br />
            <button id="btn" class="btn btn-primary mb-3">Button</button>
        </div>
    </form>

</body>

</html>

<script>
    src = "/js/myScript1.js"
    let button = document.getElementById("btn");
    button.addEventListener("click", function () {
        event.preventDefault();
        if (jsChangeLabel.innerText === "Ahoj") {
            jsChangeLabel.innerText = "Text sa zmenil!";
        } else { jsChangeLabel.innerText = "Ahoj" }
    });

    function sumMix(x) {
        let result = 0;
        x.forEach(element=>{
            if (typeof element === "number")
                result += element;
        };
        return result;
    }
</script>
<style>
    .textBox {
        border-radius: 5px; /*zaoblenie rohov do asp sa vklada cez CssClass=""*/
    }
    /*  plati pre cely element form a vsetko v nom*/
    form {
        display: flex;
        flex-direction: column;
        gap: 20px;
        margin-left: 20%;
        margin-right: 20%;
    }
    /*    plati pre vsetky elementy p*/
    p {
        font-size: 10px;
    }

    div {
        background-color: #fff;
        border-radius: 8px;
        padding: 25px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    }

    .center-box {
        text-decoration: none; /*rusi dekoraciu na texte */
        width: 40%; /*nastavuje sirku */
        display: flex; /*Urobí z elementu flexbox kontajner, čo umožní lepšie zarovnanie obsahu.*/
        justify-content: center; /*zarovná obsah horizontálne.*/
        color: black; /**/
        background-color: darkgrey; /**/
        text-align: center; /*Zarovná text vnútri elementu na stred*/
        border: double red; /*Pridá dvojitý červený okraj.*/
        font-size: 25px; /**/
        border-radius: 20px; /*zaoblenie rohov*/
        margin: 0 auto; /*Vycentruje celý blok horizontálne (funguje len, ak má element width definovaný).*/
    }

    .box-box {
        width: 100px; /* Šírka kocky */
        height: 30px; /* Výška kocky */
        background-color: lightblue; /* Farba pozadia */
        padding: 30px; /* Vnútorná medzera medzi obsahom a okrajom */
        border: 1px solid red; /* Okraj (hrúbka, štýl, farba) */
        margin: auto; /* centruje automaticky do stredu*/
        text-align: center; /*centruje text do stredu*/
        display: flex; /* Aktivuje Flexbox */
        justify-content: center; /* Horizontálne centrovanie */
        align-items: center; /* Vertikálne centrovanie */
        opacity: 0.5; /*prehliadnost*/
    }
</style>
