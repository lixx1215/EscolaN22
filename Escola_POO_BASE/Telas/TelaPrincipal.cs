﻿using Escola_POO_BASE.Classes;
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
    /*TODO 3- Desenhar uma tela para alterar a senha.
     * Esta tela deverá contar um campo para colocar a senha atual
     * a nova senha e confirmar a nova senha.
     * Também deverá conter um botão para confirmar e outro para cancelar.
     */

    public partial class TelaPrincipal : Form
    {
        private Usuario _userLogado;

        public TelaPrincipal(Usuario usuarioLogado, List<Usuario>usuarios)
        {
            InitializeComponent();
            _userLogado = usuarioLogado;
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            /*TODO 1- Identificar quem está logado, se é o aluno ou professor.
             * Se for o aluno, mostrar o perfil "Aluno" no ToolStrip. 
             * O mesmo deve acontecer caso seja o professor.
             */

            //If ternário.
            //Caso o obj _userLogado for do tipo Aluno, então armazenará na
            //propriedade Text a palavra "Aluno", senão, "Professor".
            TslPerfilUserLogado.Text = _userLogado is Aluno ? "Aluno" : "Professor";


            LblBoasVindas.Text = $"Bem-Vindo(a), {_userLogado.Nome}!";
            TslNomeUserLogado.Text = _userLogado.Nome;
            TslEmailUserLogado.Text = _userLogado.Email;


            //TODO 2- Descobrir como mostrar a data e hora completa no ToolStrip.            

            TslDataHora.Text = DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString();
            TmrRelogio.Interval = 1000;
            TmrRelogio.Enabled = true;

        }

        private void TsiAlterarSenha_Click(object sender, EventArgs e)
        {
            TelaAlterarSenha tlAlterarSenha = new TelaAlterarSenha(_userLogado);
            tlAlterarSenha.ShowDialog();
        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastraAluno telaCadastraAluno = new TelaCadastraAluno();
            telaCadastraAluno.ShowDialog();
        }

        private void TslDataHora_Click(object sender, EventArgs e)
        {

        }

        private void TmrRelogio_Tick(object sender, EventArgs e)
        {
            TslDataHora.Text = DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString();
            TmrRelogio.Interval = 1000;
            TmrRelogio.Enabled = true;
        }
    }
}
