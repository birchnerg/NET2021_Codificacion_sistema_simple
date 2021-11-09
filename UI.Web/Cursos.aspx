<%@ Page Title="Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Materia" DataField="Materia" />
                <asp:BoundField HeaderText="Comisión" DataField="Comision" />
                <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>           
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButrron" runat="server" OnClick="editarLinkButrron_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            <asp:LinkButton ID="linkReporte" runat="server" OnClick="linkReporte_Click">Exportar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="false">
        <asp:Label ID="materiaLabel" runat="server" Text="Materia: "></asp:Label>
        <asp:DropDownList ID="materiaList" runat="server" ></asp:DropDownList>
        <br />
        <asp:Label ID="comisionLabel" runat="server" Text="Comision: "></asp:Label>
        <asp:DropDownList ID="comisionList" runat="server" ></asp:DropDownList>
        <br />
        <asp:Label ID="anioLabel" runat="server" Text="Anio Calendario: "></asp:Label>
        <asp:TextBox ID="anioTextBox" ValidationGroup="ValidationGroup" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorAnio" runat="server" ForeColor="Red" ValidationGroup="ValidationGroup" ControlToValidate="anioTextBox" ErrorMessage="El anio no puede estar vacio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
        <asp:TextBox ID="cupoTextBox" ValidationGroup="ValidationGroup" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorCupo" runat="server" ForeColor="Red" ValidationGroup="ValidationGroup" ControlToValidate="cupoTextBox" ErrorMessage="El cupo no puede estar vacio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="ValidationGroup">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ForeColor="Red" ValidationGroup="ValidationGroup" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
