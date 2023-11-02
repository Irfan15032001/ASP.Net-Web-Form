<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillDetailsWeb.aspx.cs" Inherits="Assignment5.BillDetailsWeb" %>

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
                    <asp:Label ID="lblResProdId" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drdProdName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdProdName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Customer ID"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCustIDRes" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drdCustName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdCustName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblResProdName" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCustName" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPriceProd" runat="server" Text="Product Price"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPrdPrice" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAddressRes" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProdQty" runat="server" Text="Product Quantity"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblResQty" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMobileRes" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblReqQty" runat="server" Text="Required Quantity"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtReqQty" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount to Pay"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBillNo" runat="server" Text="Bill No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBillNo" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblTotalBill" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnFillDetails" runat="server" OnClick="btnFillDetails_Click" Text="Fill Details" />
                </td>
                <td>
                    <asp:Button ID="btnPlaceOrder" runat="server" OnClick="btnPlaceOrder_Click" Text="Place the Order" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
