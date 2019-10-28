using System.Data;
using System.Data.SqlClient;

namespace Caelum.Fn23.Blog.Infra
{
    /// <summary>
    /// Responsável por criar e abrir uma conexão a partir de uma string de conexão.
    /// </summary>
    public class ConnectionFactory
    {
        public static IDbConnection CriaConexaoAberta(string connectionString)
        {
            var cnx = new SqlConnection(connectionString);
            cnx.Open();
            return cnx;
        }
    }
}
