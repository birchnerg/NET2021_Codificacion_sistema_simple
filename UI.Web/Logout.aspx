<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="UI.Web.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" Runat="Server">

    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="¿Está seguro que desea salir?"></asp:Label>
        </div>
        <asp:Button ID="btnSalir" runat="server" OnClick="btnSalir_Click" style="margin-bottom: 0px" Text="Salir" />
        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
    </div>

</asp:Content>