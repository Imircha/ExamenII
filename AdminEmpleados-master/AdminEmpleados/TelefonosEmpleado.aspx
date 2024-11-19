<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="TelefonosEmpleado.aspx.cs" Inherits="AdminEmpleados.TelefonosEmpleado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD de Teléfonos de Empleados</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Administrar Teléfonos de Empleados</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label><br />
            <asp:Label ID="lblCedula" runat="server" Text="Cédula Empleado: "></asp:Label>
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblTelefono" runat="server" Text="Número de Teléfono: "></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="BtnAdd_Click" CssClass="styled-button"/>
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" CssClass="styled-button"/>
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="BtnDelete_Click" CssClass="styled-button"/>
            <br /><br />

            <!-- Tabla para mostrar teléfonos de empleados -->
            <asp:GridView ID="gvTelefonos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GvTelefonos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CedulaEmpleado" HeaderText="Cédula Empleado" />
                    <asp:BoundField DataField="NumeroTelefono" HeaderText="Teléfono" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>