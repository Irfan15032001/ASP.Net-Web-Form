<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="Assignment5.WelcomePage" %>

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
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="lblCustId" runat="server" Text="Customer ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustID" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="drdCustName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdCustName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCustName" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCustAddress" runat="server" Text="Customer Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMobNo" runat="server" Text="Mobile Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobNo" runat="server"></asp:TextBox>
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
    
    </div>
    </form>
</body>
</html>
