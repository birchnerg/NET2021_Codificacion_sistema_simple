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
        <asp:TextBox ID="nombreTextBox" ValidationGroup="ValidationGroup" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorNombre0" runat="server" ForeColor="Red" ValidationGroup="ValidationGroup" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorApellido" runat="server" ForeColor="Red" ControlToValidate="nombreTextBox" ErrorMessage="El apellido no puede estar vacio" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="validatorEmail" runat="server" ForeColor="Red" ControlToValidate="emailTextBox" ErrorMessage="El mail es inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ValidationGroup">*</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilidatoCheckBox" runat="server" />
        <br />
        <asp:Label ID="IDPersonaLabel" runat="server" Text="ID Persona: "></asp:Label>
        <asp:TextBox ID="IDPersonaTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorUsuario0" runat="server" ControlToValidate="IDPersonaTextBox" ErrorMessage=" El id de persona no puede estar vacio" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorUsuario" runat="server" ForeColor="Red" ControlToValidate="nombreTextBox" ErrorMessage=" El nombre de usuario no puede estar vacio" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="validatorClave0" runat="server" ControlToCompare="repetirClaveTextBox" ControlToValidate="claveTextBox" ErrorMessage="Las claves no coinciden" ValidationGroup="ValidationGroup" ValueToCompare="Equal">*</asp:CompareValidator>
        <asp:RequiredFieldValidator ID="validatorClaveVacia" runat="server" ForeColor="Red" ControlToValidate="claveTextBox" ErrorMessage="Ingrese una clave" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="validatorRepetirClave" runat="server" ForeColor="Red" ControlToCompare="repetirClaveTextBox" ControlToValidate="claveTextBox" ErrorMessage="Las claves no coinciden" ValidationGroup="ValidationGroup" ValueToCompare="Equal">*</asp:CompareValidator>
        <asp:RequiredFieldValidator ID="validatorRepetirClaveVacia" runat="server"  ControlToValidate="claveTextBox" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="ValidationGroup">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ForeColor="Red" ValidationGroup="ValidationGroup" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
