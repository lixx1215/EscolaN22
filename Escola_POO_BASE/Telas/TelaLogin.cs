using Escola_POO_BASE.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola_POO_BASE.Telas
{
    public partial class TelaLogin : Form
    {
        //Declarar objetos na classe o torna acessível
        //por todos os métodos da classe.
        private List<Usuario> _usuarios;

        public TelaLogin()
        {
            InitializeComponent();
            _usuarios = Usuario.GerarUsuarios();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            {
                Usuario userLogado = Usuario.RealizarLogin(TxtEmail.Text, TxtSenha.Text);

              if (userLogado.Senha == Crypto.Sha256("123"))
                {
                    TelaAlterarSenha tlAlterarSenha = new TelaAlterarSenha(userLogado);
                    tlAlterarSenha.ShowDialog();
                    TxtSenha.Clear(); //Limpar
                    TxtSenha.Focus(); //Deixar já selecionado.
                }
                else
                {
                    //Declaração da TELA! -- Instanciação executando um Construtor
                    TelaPrincipal tlPrincipal = new TelaPrincipal(userLogado, _usuarios);
                    this.Hide();
                    tlPrincipal.ShowDialog();
                    this.Show();
                    TxtSenha.Clear();
                }
            }
        }




    }
}
