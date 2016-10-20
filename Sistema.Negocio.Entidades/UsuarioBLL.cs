using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidades.Globais;
using Sistema.Interface.Negocio;
using Sistema.Interface.Persistencia;
using Sistema.Persistencia.Entidades;
using Sistema.Funcoes.Negocio;


namespace Sistema.Negocio.Entidades
{

    public class UsuarioBLL : IUsuarioBLL
    {
        private IUsuarioDAO _usuarioDAO;
        public UsuarioBLL()
        {
            this._usuarioDAO = new UsuarioDAO();
        }
        public void Delete(Usuario usuario)
        {
            this._usuarioDAO.Delete(usuario);
        }
        public void Insert(Usuario usuario)
        {
            usuario.Senha = EncryptDecrypt.Encrypt(usuario.Senha);
            this._usuarioDAO.Insert(usuario);
        }
        public List<Usuario> Select()
        {
            return this._usuarioDAO.Select();
        }
        public Usuario Select(int Id)
        {
            return this._usuarioDAO.Select(Id);
        }
        public void Update(Usuario usuario)
        {
            this._usuarioDAO.Update(usuario);
        }
        public bool ValidarUsuario(Usuario usuario)
        {
            usuario.Senha = EncryptDecrypt.Encrypt(usuario.Senha);       
            return this._usuarioDAO.ValidarUsuario(usuario);
        }
    }
}
