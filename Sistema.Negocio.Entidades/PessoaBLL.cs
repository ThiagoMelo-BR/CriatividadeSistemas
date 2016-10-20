using System;
using System.Collections.Generic;
using Sistema.Entidades.Globais;
using Sistema.Interface.Negocio;
using Sistema.Persistencia.Entidades;
using Sistema.Funcoes.Negocio;
using Sistema.Interface.Persistencia;
using System.Data;

namespace Sistema.Negocio.Entidades
{
    public class PessoaBLL : IPessoaBLL
    {
        private IPessoaDAO _pessoaDAO;

        public PessoaBLL()
        {
            this._pessoaDAO = new PessoaDAO();
        }

        public void Delete(Pessoa pessoa)
        {
            this._pessoaDAO.Delete(pessoa);
        }

        public void Insert(Pessoa pessoa)
        {
            ValidarRegistro(pessoa);

            this._pessoaDAO.Insert(pessoa);
        }

        public List<Pessoa> Select()
        {
            return this._pessoaDAO.Select();
        }

        public void Update(Pessoa pessoa)
        {
            ValidarRegistro(pessoa);

            this._pessoaDAO.Update(pessoa);
        }

        private static void ValidarRegistro(Pessoa pessoa)
        {
            if (pessoa.TipoPessoa == 'F')
            {
                if (ValidacaoPessoa.ValidaCPF(pessoa.Cpf_Cnpj) == false)
                {
                    throw new System.Exception("CPF inválido!");
                }
            }
            else
            {
                if (ValidacaoPessoa.ValidaCNPJ(pessoa.Cpf_Cnpj) == false)
                {
                    throw new System.Exception("CPNJ inválido!");
                }
            }
        }

        public Pessoa Select(int Id)
        {
            return this._pessoaDAO.Select(Id);
        }    

    }
}
