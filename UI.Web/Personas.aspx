<%@ Page Title="Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="EMail" DataField="Email" />
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText="Tipo Persona" DataField="TipoPersona" />
                <asp:BoundField HeaderText="Plan" DataField="Plan" />
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
        <asp:Label ID="direccionLabel" runat="server" Text="Direccion: "></asp:Label>
        <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorDireccion" runat="server" ForeColor="Red" ControlToValidate="direccionTextBox" ErrorMessage="La direccion no puede estar vacia" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: "></asp:Label>
        <asp:TextBox ID="telefonoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorTelefono" runat="server" ForeColor="Red" ControlToValidate="telefonoTextBox" ErrorMessage=" El telefono no puede estar vacio" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
        <asp:TextBox ID="fechaNacimientoTextBox" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorFechaNacimiento" runat="server" ForeColor="Red" ControlToValidate="fechaNacimientoTextBox" ErrorMessage="La fecha de nacimiento no puede estar vacia" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
        <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorLegajo" runat="server" ForeColor="Red" ControlToValidate="legajoTextBox" ErrorMessage="El legajo no puede estar vacio" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo Persona: "></asp:Label>
        <asp:DropDownList ID="tipoPersonaList" runat="server" ></asp:DropDownList>
        <br />
        <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="planList" runat="server" ></asp:DropDownList>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="ValidationGroup">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ForeColor="Red" ValidationGroup="ValidationGroup" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
