<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPageWeb.aspx.cs" Inherits="Assignment5.ProductPageWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="lblProdId" runat="server" Text="Product ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProdId" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="drdProdName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdProdName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProdName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProdPrice" runat="server" Text="Product Price"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProdPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblQty" runat="server" Text="Product Quantity"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProdQty" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
