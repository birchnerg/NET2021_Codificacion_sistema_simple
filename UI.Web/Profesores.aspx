<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profesores.aspx.cs" Inherits="UI.Web.Profesores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="IDDocente" HeaderText="ID Docente" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                <asp:BoundField DataField="IDCurso" HeaderText="ID Curso" />
                <asp:BoundField DataField="Materia" HeaderText="Materia" />
                <asp:BoundField DataField="Comision" HeaderText="Comision" />
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
        <asp:Label ID="IDDocenteLabel" runat="server" Text="ID Docente:"></asp:Label>
        <asp:TextBox ID="iDDocenteTextBox" runat="server" ValidationGroup="ValidationGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorIDAlumno1" runat="server" ControlToValidate="iDDocenteTextBox" ErrorMessage="El docente no puede estar vacio" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="CargoLabel" runat="server" Text="Cargo:"></asp:Label>
        <asp:TextBox ID="CargoTextBox" runat="server" ValidationGroup="ValidationGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorIDAlumno2" runat="server" ControlToValidate="CargoTextBox" ErrorMessage="El alumno no puede estar vacio" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="IDCursoLabel" runat="server" Text="ID Curso:"></asp:Label>
        <asp:DropDownList ID="idCursoList" runat="server" ValidationGroup="ValidationGroup">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="validatorIdCurso" runat="server" ControlToValidate="idCursoList" ErrorMessage="El curso no puede estar vacio" ForeColor="Red" ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="ValidationGroup">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ForeColor="Red" ValidationGroup="ValidationGroup" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
