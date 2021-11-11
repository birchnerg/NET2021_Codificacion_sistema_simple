<%@ Page Title="Materias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" SortExpression="HSSemanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" SortExpression="HSTotales" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>           
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButrron" runat="server" OnClick="editarLinkButrron_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="false">
        <asp:Label ID="descLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descTextBox" ValidationGroup="ValidationGroup" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorDesc" runat="server" ForeColor="Red" ValidationGroup="ValidationGroup" ControlToValidate="descTextBox" ErrorMessage="El nombre no puede estar vacio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="descLabel4" runat="server" Text="Horas Semanales: "></asp:Label>
        <asp:TextBox ID="HSSemanalesTextBox" runat="server" ValidationGroup="ValidationGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorDesc0" runat="server" ControlToValidate="HSSemanalesTextBox" ErrorMessage="No puede darse de Alta una materia sin Horas Semanales" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="descLabel5" runat="server" Text="Horas Totales: "></asp:Label>
        <asp:TextBox ID="HSTotalesTextBox" runat="server" ValidationGroup="ValidationGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorDesc1" runat="server" ControlToValidate="HSTotalesTextBox" ErrorMessage="No puede darse de Alta una materia sin Horas Totales" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="descLabel6" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="planesList" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="validatorDesc2" runat="server" ControlToValidate="planesList" ErrorMessage="La Materia debe pertenecer a un Plan" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="ValidationGroup">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ForeColor="Red" ValidationGroup="ValidationGroup" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
