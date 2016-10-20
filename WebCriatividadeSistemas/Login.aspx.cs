using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Sistema.Entidades.Globais;
using Sistema.Interface.Negocio;
using Sistema.Negocio.Entidades;

public partial class Login : System.Web.UI.Page
{
    private IUsuarioBLL usuarioBLL = new UsuarioBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogar_Click(object sender, EventArgs e)
    {
        var usuario = new Usuario();
        usuario.Login = txtLogin.Text;
        usuario.Senha = txtSenha.Text;

        if (usuarioBLL.ValidarUsuario(usuario))
            FormsAuthentication.RedirectFromLoginPage("Login", false);
        else
            lbMsg.Text = "Usuário ou senha incorretos!";

    }
    protected void btnNovoUsuario_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Public/CadastroUsuario.aspx");        
    }
}