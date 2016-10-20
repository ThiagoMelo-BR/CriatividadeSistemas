using System.Collections.Generic;
using Sistema.Entidades.Globais;
using System.Data;

namespace Sistema.Interface.Negocio
{
    public interface IPessoaBLL
    {
        void Insert(Pessoa pessoa);
        void Delete(Pessoa pessoa);
        void Update(Pessoa pessoa);
        List<Pessoa> Select();
        Pessoa Select(int Id);
        
    }
}