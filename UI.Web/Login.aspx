<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <style type="text/css">
        .auto-style1 {
            width: 161px;
        }
        .auto-style2 {
            height: 52px;
        }
        .auto-style4 {
            height: 30px;
        }
        .auto-style5 {
            width: 161px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style2" colspan="3">
            <asp:Label ID="lblBienvenido" runat="server" Text="Bienvenido a la academia!"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
                </td>
                <td>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>           
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
                </td>
                <td>
            <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5"></td>
                <td class="auto-style4">
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>
            <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" OnClick="lnkRecordarClave_Click" ></asp:LinkButton>
                </td>
            </tr>
        </table>            
        </div>
    </form>
</body>
</html>
