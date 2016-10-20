<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaPessoa.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Cadastro de Pessoa</h1>
        <asp:Button ID="btnTelaInicial" runat="server" OnClick="btnTelaInicial_Click" Text="Tela Inicial" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Código" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Cpf_Cnpj" HeaderText="Cpf / Cnpj" SortExpression="CPF" />
                <asp:BoundField DataField="DATANASCIMENTO" HeaderText="Data Nascimento" SortExpression="DATANASCIMENTO" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
        <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
        <asp:Button ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="Excluir" />
        <br />
        <br />
        <asp:Label ID="lbMessage" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
