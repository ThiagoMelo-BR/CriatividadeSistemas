<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastroUsuario.aspx.cs" Inherits="CadastroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Login<br />
        <asp:TextBox ID="txtLogin" runat="server" Width="218px"></asp:TextBox>
        <br />
        <br />
        Senha<br />
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" Text="Cadastrar" />
        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
    
    </div>
    </form>
</body>
</html>
