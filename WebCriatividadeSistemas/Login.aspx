<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Login<br />
        <asp:TextBox ID="txtLogin" runat="server" Width="187px">thiago</asp:TextBox>
        <br />
        <br />
        Senha<br />
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password">123</asp:TextBox>
        <asp:Button ID="btnLogar" runat="server" OnClick="btnLogar_Click" Text="Logar" />
        <asp:Button ID="btnNovoUsuario" runat="server" OnClick="btnNovoUsuario_Click" Text="Novo usuário" />
        <br />
        <br />
        <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
    
    </div>
    </form>
</body>
</html>
