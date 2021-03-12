<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="VAWeb.Source.Item" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table id="parentTable" style="border-style: none; border-color: inherit; border-width: medium; height: 100%; width: 100%">
            <tr>
                <td>
                    <table style="height: 50px">
                        <tr>
                            <td class="tdPage">
                                <cc1:TextBox ID="txtbx1" runat="server" Width="300px" CssClass="textbox"></cc1:TextBox>
                                <cc1:Button ID="btnAdd" runat="server" CausesValidation="true" Text="Add" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                    </table>
                    <table style="height: 50px">
                        <tr>
                        </tr>
                    </table>
                    <table style="height: 50px">
                        <tr>
                            <td class="tdPage1">
                                <cc1:Label ID="lbl1" runat="server" Width="150px" Visible="true"></cc1:Label>
                                <cc1:Button ID="btnEdit" runat="server" CausesValidation="true" Text="Edit" OnClick="btnEdit_Click" />
                                <cc1:Button ID="btnDone" runat="server" CausesValidation="true" Text="Done" OnClick="btnDone_Click" />
                                <cc1:Button ID="btnDelete" runat="server" CausesValidation="true" Text="Delete" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                    </table>
                    <table style="height: 50px">
                        <tr>
                        </tr>
                    </table>
                    <table style="height: 50px">
                        <tr>
                            <cc1:ListBox ID="lbValues" runat="server" Height="550px" SelectionMode="Multiple" Width="100%"></cc1:ListBox>
                        </tr>
                    </table>


                </td> <%--  End of Parent Column  --%>
            </tr> <%--  End of Parent Row --%>
        </table> <%--  End of Parent Table  --%>
    </form>
</body>
</html>
