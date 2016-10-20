using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema.Entidades.Globais;
using Sistema.Interface.Negocio;
using Sistema.Negocio.Entidades;

public partial class CadastroUsuario : System.Web.UI.Page
{
    private IUsuarioBLL usuarioBLL = new UsuarioBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Login.aspx");
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        var usuario = new Usuario();
        usuario.Login = txtLogin.Text;
        usuario.Senha = txtSenha.Text;

        usuarioBLL.Insert(usuario);
        Response.Redirect("/Default.aspx");
    }
}