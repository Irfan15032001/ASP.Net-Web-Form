<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginFormWeb.aspx.cs" Inherits="Assignment5.LoginFormWeb" %>

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
                    <asp:Label ID="lblLogIn" runat="server" Text="Login ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassWord" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lnkProdPage" runat="server" OnClick="lnkProdPage_Click">Login To Product Page</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lnkCust" runat="server" OnClick="lnkCust_Click">Login To Customer Page</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lnkBill" runat="server" OnClick="lnkBill_Click">Login To Billing Page</asp:LinkButton>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
