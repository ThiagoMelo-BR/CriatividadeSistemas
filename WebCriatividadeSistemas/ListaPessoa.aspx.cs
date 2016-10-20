using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema.Negocio.Entidades;
using Sistema.Entidades.Globais;
using Sistema.Interface.Negocio;
using Sistema.Helper;
using System.Data;


public partial class _Default : System.Web.UI.Page
{
    private Pessoa pessoa = new Pessoa();
    private IPessoaBLL oPessoaBLL = new PessoaBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarPessoas();
            Session["PessoaSelecionada"] = null;
        }
    }
    private DataSet SelecionarPessoas()
    {
        return HelperDB.GetDataSet(oPessoaBLL.Select(),pessoa);        
    }
    private void CarregarPessoas()
    {
        GridView1.DataSource = SelecionarPessoas();
        GridView1.DataBind();
        lbMessage.Text = String.Empty;
    }
    private void ExcluirPessoa()
    {
        pessoa = Session["PessoaSelecionada"] as Pessoa;

        if (pessoa == null)
        {
            lbMessage.Text = "Nenhum registro selecionado!";
        }
        else
        {
            oPessoaBLL.Delete(pessoa);            
            Session["PessoaSelecionada"] = null;
            CarregarPessoas();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        pessoa = oPessoaBLL.Select(int.Parse(GridView1.SelectedRow.Cells[1].Text));
        Session["PessoaSelecionada"] = pessoa;
    }
    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        ExcluirPessoa();
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        pessoa = Session["PessoaSelecionada"] as Pessoa;

        if (pessoa != null)
        {
            Response.Redirect("CadastroPessoa.aspx");
        }
        else
            lbMessage.Text = "Nenhum registro selecionado!";
    }
    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Session["PessoaSelecionada"] = null;
        Response.Redirect("CadastroPessoa.aspx");
    }

    protected void btnTelaInicial_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}