using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_POO_BASE.Classes
{
    internal class Conexao
    {
        //CONEXÃO REMOTA
        #region Variáveis

        //String de Conexão                                         Informações CHUMBADAS - HardCore                    
        private static string _strConexao = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EscolaN22;Integrated Security=True";

        //Variáveis de uso (podem ou não serem usadas ao decorrer do projeto)
        public SqlConnection conexao = new SqlConnection(_strConexao);
        public SqlCommand comando; //Armaezena a query
        public SqlDataAdapter da; //Adaptador para alguns componentes
        public SqlDataReader dr; //Rece os select's
        public DataSet ds; // Trabalha com multiplas tabelas

        #endregion

        #region Construtores
        public Conexao(string query)
        {
            comando = new SqlCommand(query, conexao); //Comando montado
            da = new SqlDataAdapter(query, conexao); //Caso necessário, esta pronto
            ds = new DataSet(); //Se necessário
        }

        #endregion

        #region Métodos
        //Um método para abrir a conexão com o banco
        public void abrirConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
            conexao.Open();
        }

        //E um outro método para fechar a conexão com o banco
        public void FecharConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        #endregion
    }
}
