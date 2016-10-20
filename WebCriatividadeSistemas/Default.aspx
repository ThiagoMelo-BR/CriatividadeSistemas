<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 style="font-size: xx-large">SISTEMA GERENCIADOR</h1>
        <h1 style="font-size: xx-large"><span class="auto-style1"><br />
            <asp:Label ID="lblUsuarioLogado" runat="server"></asp:Label>
            </span>
        <br />
        <br />
        <asp:Button ID="btnCadPessoas" runat="server" Text="Cadastro de Pessoas" OnClick="btnCadPessoas_Click" />
    
        <asp:Button ID="btnLogoult" runat="server" OnClick="btnLogoult_Click" Text="Logoult" />
    
        </h1>
    
    </div>
    </form>
</body>
</html>
