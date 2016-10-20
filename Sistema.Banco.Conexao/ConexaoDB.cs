using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Sistema.Banco.Conexao
{
    public enum BancoDeDados { PostgreSQL = 0, SQLServer = 1, Oracle = 2 }    

    public abstract class ConexaoDB
    {
        public abstract IDbConnection RetornarConexao();

    }

    public class PostgreSQL : ConexaoDB
    {
        private static IDbConnection conexao;

        public static string getConnectionStringFromConfing()
        {
            return ConfigurationManager.ConnectionStrings["STRINGCONECTIONPOSTGRES"].ConnectionString;
        }

        public override IDbConnection RetornarConexao()
        {

            if (conexao == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("Npgsql");

                conexao = factory.CreateConnection();
                conexao.ConnectionString = getConnectionStringFromConfing();
            }

            return conexao;
        }
    }

    public class SQLServer : ConexaoDB
    {
        private static IDbConnection conexao;

        public static string getConnectionStringFromConfing()
        {
            return ConfigurationManager.ConnectionStrings["STRINGCONECTIONSQLSERVER"].ConnectionString;
        }

        public override IDbConnection RetornarConexao()
        {

            if (conexao == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

                conexao = factory.CreateConnection();
                conexao.ConnectionString = getConnectionStringFromConfing();
            }

            return conexao;
        }
    }

    public class FactoryConexao
    {
        public static ConexaoDB Fabricar(BancoDeDados tipoBD)
        {
            switch (tipoBD)
            {
                case BancoDeDados.PostgreSQL:
                    return new PostgreSQL();
                case BancoDeDados.SQLServer:
                    return new SQLServer();
                default:
                    return null;
            }

        }
    }
}
