<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" Runat="Server">
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
    </asp:Content>
