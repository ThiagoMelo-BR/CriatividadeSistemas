using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema.Entidades.Globais;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var usuario = new Usuario();
        usuario = Session["UsuarioLogado"] as Usuario;
        lblUsuarioLogado.Text = "Bem vindo ao sistema " + usuario.Login;
    }
    protected void btnCadPessoas_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaPessoa.aspx");
    }
    protected void btnLogoult_Click(object sender, EventArgs e)
    {        
        Response.Redirect("Login.aspx");
    }
}