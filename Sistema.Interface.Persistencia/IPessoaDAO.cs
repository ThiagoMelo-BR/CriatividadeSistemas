using System;
using System.Collections.Generic;
using Sistema.Entidades.Globais;
using System.Data;

namespace Sistema.Interface.Persistencia
{
    public interface IPessoaDAO
    {
        void Insert(Pessoa pessoa);
        void Delete(Pessoa pessoa);
        List<Pessoa> Select();
        Pessoa Select(int Id);
        void Update(Pessoa pessoa);
    }
}
