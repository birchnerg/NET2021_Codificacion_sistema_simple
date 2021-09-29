<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="EMail" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" />
                <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>           
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButrron" runat="server" OnClick="editarLinkButrron_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="false">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilidatoCheckBox" runat="server"></asp:CheckBox>
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox"  runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
