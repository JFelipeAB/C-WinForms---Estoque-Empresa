﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using Entidades;


namespace Estoque_Empresa
{
    public partial class TelaConfirmacao : Form
    {
        public Estoque item;
        public TelaConfirmacao(Estoque i)
        {
            InitializeComponent();
            item = i;
            txtFornecedor.ReadOnly = true;
            txtFornecedor.Text = item.Fornecedor;
            txtLocal.ReadOnly = true;
            txtLocal.Text = item.Local;
            txtNome.ReadOnly = true;
            txtNome.Text = item.Nome;
            nudDisponivel.ReadOnly = true;
            nudDisponivel.Text = item.Disponivel;
            nudManutenção.ReadOnly = true;
            nudManutenção.Text = item.Manutencao;
        }
               

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtDestino == null)
            {
                MessageBox.Show("Preencha o campo destino ", "Campo invalido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string texto = "";
                texto = "\n" + item.Nome + '|' + item.Disponivel + '|' + item.Manutencao + '|' + item.Data + '|' + item.Fornecedor + '|' + txtDestino.Text;
                System.IO.File.AppendAllText(@"registros.txt", texto);
                this.Close();
            }
        }
    }
}