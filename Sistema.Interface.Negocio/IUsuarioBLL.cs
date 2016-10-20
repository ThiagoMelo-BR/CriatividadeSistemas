using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidades.Globais;

namespace Sistema.Interface.Negocio
{
    public interface IUsuarioBLL
    {
        void Insert(Usuario usuario);
        void Delete(Usuario usuario);
        List<Usuario> Select();
        Usuario Select(int Id);
        void Update(Usuario usuario);
        bool ValidarUsuario(Usuario usuario);
    }
}
