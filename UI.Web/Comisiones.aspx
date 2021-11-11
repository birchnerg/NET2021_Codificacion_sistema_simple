<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="anio plan" DataField="AnioEspecialidad" />
                <asp:BoundField HeaderText="plan" DataField="Plan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns> 
        </asp:GridView>
        <asp:Panel ID="Panel2" runat="server">
            <asp:LinkButton ID="editarLinkButrron" runat="server" OnClick="editarLinkButrron_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
<asp:Panel ID="formPanel" runat="server" Visible="false">
        <br />
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion:"></asp:Label>
        <asp:TextBox ID="descripcionTextBox" ValidationGroup="ValidationGroup" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="anioLabel" runat="server" Text="Anio Calendario: "></asp:Label>
        <asp:TextBox ID="anioTextBox" runat="server" ValidationGroup="ValidationGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorAnio" runat="server" ForeColor="Red" ValidationGroup="ValidationGroup" ControlToValidate="anioTextBox" ErrorMessage="El anio no puede estar vacio">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="AnioRegularValidator" runat="server" ControlToValidate="anioTextBox" ErrorMessage="Ingrese un anio valido" ForeColor="Red" ValidationExpression="^(19|20)\d{2}$" ValidationGroup="ValidationGroup">*</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
        <asp:RequiredFieldValidator ID="validatorDesc" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripcion no puede estar vacio" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <asp:DropDownList ID="planList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Panel ID="EnableForm" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" ValidationGroup="ValidationGroup" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ForeColor="Red" ValidationGroup="ValidationGroup" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
