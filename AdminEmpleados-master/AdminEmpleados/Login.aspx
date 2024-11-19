<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdminEmpleados.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Iniciar Sesión</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="BtnLogin_Click" CssClass="styled-button"/><br /><br />
        </div>
    </form>
</body>
</html>
