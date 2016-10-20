<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastroPessoa.aspx.cs" Inherits="CadastroPessoa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Cadastro Pessoa</h1>
        Nome<br />
        <asp:TextBox ID="txtNome" runat="server" Width="327px"></asp:TextBox>
        <br />
        <br />
        Tipo Pessoa
        <asp:RadioButtonList ID="rblTipoPessoa" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="F">Física</asp:ListItem>
            <asp:ListItem Value="J">Jurídica</asp:ListItem>
        </asp:RadioButtonList>
&nbsp;
        <br />
        Cpf / Cnpj<br />
        <asp:TextBox ID="txtCpfCnpj" runat="server" Width="189px"></asp:TextBox>
        <br />
        <br />
        Data Nascimento<br />
        <asp:TextBox ID="txtDataNascimento" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    
    </div>
    </form>
</body>
</html>
