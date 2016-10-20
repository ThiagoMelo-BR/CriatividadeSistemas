using System;
using System.Collections.Generic;
using Sistema.Entidades.Globais;
using Sistema.Interface.Persistencia;
using Sistema.Banco.Conexao;
using Sistema.Helper;
using System.Data;

namespace Sistema.Persistencia.Entidades
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private ConexaoDB _conection;
        private IDbConnection conexao;
        public UsuarioDAO()
        {
            _conection = FactoryConexao.Fabricar(BancoDeDados.PostgreSQL);
            conexao = _conection.RetornarConexao();
        }
        public void Delete(Usuario usuario)
        {
            try
            {
                var SQL = "delete from USUARIO where ID = @ID";
                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                HelperDB.AddParameter(comandoSQL, "@ID", usuario.Id);
                comandoSQL.CommandType = CommandType.Text;
                conexao.Open();
                comandoSQL.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Insert(Usuario usuario)
        {
            try
            {
                var SQL = "insert into USUARIO (LOGIN, SENHA, IDPESSOA) values (@LOGIN, @SENHA, @IDPESSOA)";

                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                HelperDB.AddParameter(comandoSQL, "@LOGIN", usuario.Login);
                HelperDB.AddParameter(comandoSQL, "@SENHA", usuario.Senha);
                HelperDB.AddParameter(comandoSQL, "@IDPESSOA", usuario.IdPessoa);                
                comandoSQL.CommandType = CommandType.Text;
                conexao.Open();
                comandoSQL.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
        }
        public List<Usuario> Select()
        {
            var lsUsuarios = new List<Usuario>();

            try
            {
                var SQL = "select ID, LOGIN, SENHA, IDPESSOA from USUARIO";
                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                comandoSQL.CommandType = CommandType.Text;
                conexao.Open();

                IDataReader reader = comandoSQL.ExecuteReader();

                while (reader.Read())
                {
                    var OUsuario = new Usuario();

                    OUsuario.Id         = Int32.Parse(reader[0].ToString());
                    OUsuario.Login      = reader[1].ToString();
                    OUsuario.Senha      = reader[2].ToString();
                    OUsuario.IdPessoa   = Int32.Parse(reader[3].ToString());

                    lsUsuarios.Add(OUsuario);
                }
                reader.Close();
            }
            finally
            {
                conexao.Close();
            }
            return lsUsuarios;
        }
        public Usuario Select(int Id)
        {
            var OUsuario = new Usuario();
            try
            {
                var SQL = "select ID, LOGIN, SENHA, IDPESSOA from USUARIO where ID = @ID";
                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                comandoSQL.CommandType = CommandType.Text;
                HelperDB.AddParameter(comandoSQL, "@ID", Id);
                conexao.Open();

                IDataReader reader = comandoSQL.ExecuteReader();

                reader.Read();

                OUsuario.Id         = Int32.Parse(reader[0].ToString());
                OUsuario.Login      = reader[1].ToString();
                OUsuario.Senha      = reader[2].ToString();
                OUsuario.IdPessoa   = Int32.Parse(reader[3].ToString());
                reader.Close();
            }
            finally
            {
                conexao.Close();
            }
            return OUsuario;
        }
        public void Update(Usuario usuario)
        {
            try
            {
                var SQL = "update USUARIO set LOGIN = @LOGIN, SENHA = @SENHA, IDPESSOA = @IDPESSOA where ID = @ID";

                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                HelperDB.AddParameter(comandoSQL, "@LOGIN", usuario.Login);
                HelperDB.AddParameter(comandoSQL, "@SENHA", usuario.Senha);
                HelperDB.AddParameter(comandoSQL, "@IDPESSOA", usuario.IdPessoa);
                
                comandoSQL.CommandType = CommandType.Text;
                conexao.Open();
                comandoSQL.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool ValidarUsuario(Usuario usuario)
        {
            bool result = false;
            try
            {
                var SQL = "select count(1) RESULT from USUARIO where LOGIN = @LOGIN and SENHA = @SENHA";
                IDbCommand comandoSQL = conexao.CreateCommand();
                comandoSQL.CommandText = SQL;
                comandoSQL.CommandType = CommandType.Text;
                HelperDB.AddParameter(comandoSQL, "@LOGIN", usuario.Login);
                HelperDB.AddParameter(comandoSQL, "@SENHA", usuario.Senha);
                conexao.Open();

                IDataReader reader = comandoSQL.ExecuteReader();

                reader.Read();                
                result = Int32.Parse(reader[0].ToString()) > 0;

                reader.Close();
            }
            finally
            {
                conexao.Close();
            }
            return result;
        }
    }
}
