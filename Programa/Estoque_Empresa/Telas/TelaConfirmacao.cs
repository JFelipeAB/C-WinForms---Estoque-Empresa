using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Crud;

namespace Telas
{
    public partial class TelaConfirmacao : Form
    {
        public Registro r;
        public TelaConfirmacao(Estoque item)
        {
            InitializeComponent();
            txtFornecedor.ReadOnly = true;
            txtFornecedor.Text = item.Observacao;
            txtLocal.ReadOnly = true;
            txtLocal.Text = item.Local;
            txtNome.ReadOnly = true;
            txtNome.Text = item.Nome;
            nudDisponivel.ReadOnly = true;
            nudDisponivel.Text = item.Disponivel;
            nudManutenção.ReadOnly = true;
            nudManutenção.Text = item.Manutencao;
            r = new Registro();
            r.Nome = item.Nome;
            r.Disponivel = item.Disponivel;
            r.Manutencao = item.Manutencao;
            r.Observacao = item.Observacao;
            r.Data = DateTime.Now.ToShortDateString();
        }

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDestino.Text == "")
            {
                MessageBox.Show("Preencha o campo destino ", "Campo invalido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                r.Destino = txtDestino.Text;
                CRUD.Inserir(r);
                MessageBox.Show("Registro salvo com sucesso ", "Ação concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
