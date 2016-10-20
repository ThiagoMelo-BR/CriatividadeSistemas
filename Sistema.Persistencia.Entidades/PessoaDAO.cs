using System;
using System.Collections.Generic;
using System.Data;
using Sistema.Interface.Persistencia;
using Sistema.Banco.Conexao;
using Sistema.Helper;
using Sistema.Entidades.Globais;

namespace Sistema.Persistencia.Entidades
{
    public class PessoaDAO : IPessoaDAO
    {
        private ConexaoDB _conection;
        private IDbConnection conexao;

        public PessoaDAO()
        {
            this._conection = FactoryConexao.Fabricar(BancoDeDados.PostgreSQL);
            conexao = this._conection.RetornarConexao();
        }
        public void Delete(Pessoa pessoa)
        {
            try
            {
                var SQL = "delete from PESSOA where ID = @ID";
                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                HelperDB.AddParameter(comandoSQL, "@ID", pessoa.Id);
                comandoSQL.CommandType = CommandType.Text;
                conexao.Open();
                comandoSQL.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }

        }

        public void Insert(Pessoa pessoa)
        {
            try
            {
                var SQL = "insert into PESSOA (NOME, CPF_CNPJ, TIPOPESSOA, DATANASCIMENTO)" +
                           " values (@NOME, @CPF_CNPJ, @TIPOPESSOA, @DATANASCIMENTO)";

                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                HelperDB.AddParameter(comandoSQL, "@NOME", pessoa.Nome);
                HelperDB.AddParameter(comandoSQL, "@CPF_CNPJ", pessoa.Cpf_Cnpj);
                HelperDB.AddParameter(comandoSQL, "@TIPOPESSOA", pessoa.TipoPessoa);
                HelperDB.AddParameter(comandoSQL, "@DATANASCIMENTO", pessoa.DataNascimento);
                comandoSQL.CommandType = CommandType.Text;
                conexao.Open();
                comandoSQL.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
        }

        public Pessoa Select(int Id)
        {
            var OPessoa = new Pessoa();
            try
            {

                var SQL = "select ID, NOME, CPF_CNPJ, TIPOPESSOA, DATANASCIMENTO from PESSOA where ID = @ID";
                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                comandoSQL.CommandType = CommandType.Text;
                HelperDB.AddParameter(comandoSQL, "@ID", Id);
                conexao.Open();

                IDataReader reader = comandoSQL.ExecuteReader();

                reader.Read();

                OPessoa.Id = Int32.Parse(reader[0].ToString());
                OPessoa.Nome = reader[1].ToString();
                OPessoa.Cpf_Cnpj = reader[2].ToString();

                if (reader.IsDBNull(3))
                  OPessoa.TipoPessoa = 'F';
                else
                  OPessoa.TipoPessoa = char.Parse(reader[3].ToString());

                if (reader.IsDBNull(4))
                  OPessoa.DataNascimento = HelperDB.MinValue();
                else
                  OPessoa.DataNascimento = DateTime.Parse(reader[4].ToString());                    
                
                reader.Close();
            }
            finally
            {
                conexao.Close();
            }
            return OPessoa;            
        }

        public List<Pessoa> Select()
        {
            var lsPessoas = new List<Pessoa>();

            try
            {

                var SQL = "select ID, NOME, CPF_CNPJ, TIPOPESSOA, DATANASCIMENTO from PESSOA";
                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                comandoSQL.CommandType = CommandType.Text;
                conexao.Open();

                IDataReader reader = comandoSQL.ExecuteReader();

                while (reader.Read())
                {
                    var OPessoa = new Pessoa();

                    OPessoa.Id       = Int32.Parse(reader[0].ToString());
                    OPessoa.Nome     = reader[1].ToString();
                    OPessoa.Cpf_Cnpj = reader[2].ToString();

                    if (reader.IsDBNull(3))
                        OPessoa.TipoPessoa = 'F';
                    else
                        OPessoa.TipoPessoa = char.Parse(reader[3].ToString());

                    if (reader.IsDBNull(4))
                        OPessoa.DataNascimento = HelperDB.MinValue();
                    else
                        OPessoa.DataNascimento = DateTime.Parse(reader[4].ToString());

                    lsPessoas.Add(OPessoa);
                }
                reader.Close();
            }
            finally
            {
                conexao.Close();
            }
            return lsPessoas;

        }

        public void Update(Pessoa pessoa)
        {
            try
            {
                var SQL = "update PESSOA set NOME = @NOME, CPF_CNPJ = @CPF_CNPJ" +
                          " ,TIPOPESSOA = @TIPOPESSOA, DATANASCIMENTO = @DATANASCIMENTO where ID = @ID";

                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                HelperDB.AddParameter(comandoSQL, "@NOME", pessoa.Nome);
                HelperDB.AddParameter(comandoSQL, "@CPF_CNPJ", pessoa.Cpf_Cnpj);
                HelperDB.AddParameter(comandoSQL, "@TIPOPESSOA", pessoa.TipoPessoa);
                HelperDB.AddParameter(comandoSQL, "@ID", pessoa.Id);
                HelperDB.AddParameter(comandoSQL, "@DATANASCIMENTO", pessoa.DataNascimento);
                comandoSQL.CommandType = CommandType.Text;
                conexao.Open();
                comandoSQL.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataSet GetDataSet()
        {
            var dataSet = new DataSet();
            var pessoa = new Pessoa();
            var tabela = HelperDB.GetColumnsTable(pessoa);

            foreach (var p in Select())
                HelperDB.GetObjectRowTable(tabela, p);

            dataSet.Tables.Add(tabela);
            return dataSet;
        }
    }
}
