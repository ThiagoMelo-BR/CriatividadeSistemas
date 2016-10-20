using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema.Entidades.Globais;
using Sistema.Negocio.Entidades;
using Sistema.Interface.Negocio;

public partial class CadastroPessoa : System.Web.UI.Page
{
    private IPessoaBLL _PessoaBLL = new PessoaBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Pessoa pessoa = new Pessoa();
            pessoa = Session["PessoaSelecionada"] as Pessoa;
            if(pessoa != null)
                CarregarDadosParaTela(pessoa);
        }        
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaPessoa.aspx");
    }
    private void CarregarDadosParaTela(Pessoa pessoa)
    {
        txtNome.Text                = pessoa.Nome;
        txtCpfCnpj.Text             = pessoa.Cpf_Cnpj;
        txtDataNascimento.Text      = pessoa.DataNascimento.ToShortDateString();
        rblTipoPessoa.SelectedValue = pessoa.TipoPessoa.ToString();

    }
    private Pessoa CarregarDadosParaClasse(Pessoa pessoa)
    {
        /*Recarregar da sessão para buscar o id do registro*/
        if(Session["PessoaSelecionada"] != null)
            pessoa = Session["PessoaSelecionada"] as Pessoa;

        pessoa.Nome             = txtNome.Text;
        pessoa.Cpf_Cnpj         = txtCpfCnpj.Text;
        pessoa.DataNascimento   = DateTime.Parse(txtDataNascimento.Text);
        pessoa.TipoPessoa       = char.Parse(rblTipoPessoa.SelectedItem.Value.ToString());     

        return pessoa;
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Pessoa pessoa = new Pessoa();

        try
        {
            pessoa = CarregarDadosParaClasse(pessoa);

            if (pessoa.Id > 0)
                _PessoaBLL.Update(pessoa);
            else
                _PessoaBLL.Insert(pessoa);
        }
        catch(Exception msg)
        {
            lblMsg.Text = "Erro ao salvar registro!" + "<p>" + "Motivo: " + msg.Message;
            return;
        }
        
        Response.Redirect("ListaPessoa.aspx");
    }
}