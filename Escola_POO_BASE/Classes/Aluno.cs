using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_POO_BASE.Classes
{
    public class Aluno : Usuario
    {
        
        #region Propriedades
        public DateTime DtMatricula { get; set; }
        #endregion

        #region Construtores
        public Aluno()
        {
        }

        public Aluno(int id, string nome, DateTime dtNascimento, DateTime dtMatricula, string email, string senha, bool ativo) : base(id, nome, dtNascimento, email, senha, ativo)
        {
            DtMatricula = dtMatricula;
        }
        #endregion

        #region Método
        public void Cadastrar(List<Usuario> usuarios)

        {

            string query = ($"insert into Aluno VALUES ('{Nome}', '{DtNascimento}', '{DtMatricula}', '{Email}', '{Crypto.Sha256(Senha)}', {Ativo})");

            Conexao cn = new Conexao(query);



            try

            {

                cn.abrirConexao();

                cn.comando.ExecuteNonQuery();



                usuarios.Add(this);

            }

            catch (Exception)

            {



                throw;

            }

        }
        #endregion
    }
}
