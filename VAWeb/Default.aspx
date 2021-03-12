<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VAWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VAWeb</title>
    <script type="text/javascript">
        javascript: window.history.forward(1);

        function ValidateSite(sender, args) {

            if (IsEmptyString(args.Value))
                args.IsValid = false;
            else
                args.IsValid = true;

            return
        }
    </script>
</head>
<body ms_positioning="GridLayout" scroll="no">
    <form id="form1" runat="server">
        <table id="parentTable" style="border-style: none; border-color: inherit; border-width: medium; height: 100%; width: 100%">
            <tr>
                <td>                   
                    <table style="background-color: #FFFBEF; border-left: 5px solid #000000; border-right: 5px solid #000000; border-top: 5px solid #000000; margin-left: 95px; margin-right: 85px">
                        
                    </table> 
                </td> <%--  End of Parent Column  --%>
            </tr> <%--  End of Parent Row --%>
        </table> <%--  End of Parent Table  --%>
    </form>
</body>
</html>
