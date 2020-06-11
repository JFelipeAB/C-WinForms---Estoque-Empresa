using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Estoque_Empresa
{
    public partial class TelaMenu : Form
    {
        public DataGridView gridLista;

        public List<Estoque> lista = new List<Estoque>();

        public TelaMenu()
        {
            InitializeComponent();
            LerTexto();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            gridLista.Rows.Clear();
            CbAlterar.Items.Clear();
            int pos = 0;
            bool ExisteItem = false;
            foreach (Estoque a in lista)
            {
                if (a.Nome.ToUpper().IndexOf(txtBusca.Text.ToString().Trim().ToUpper()) != -1) //busca qualuqer parte do Nome
                {
                    gridLista.Rows.Add();
                    gridLista.Rows[pos].Cells[0].Value = a.Nome;
                    gridLista.Rows[pos].Cells[1].Value = a.Disponivel;
                    gridLista.Rows[pos].Cells[2].Value = a.Manutencao;
                    gridLista.Rows[pos].Cells[3].Value = a.Local;
                    gridLista.Rows[pos].Cells[4].Value = a.Data;
                    gridLista.Rows[pos].Cells[5].Value = a.Fornecedor;
                    pos++;
                    CbAlterar.Items.Add(a.Nome);
                    ExisteItem = true;
                }
            }
            if (!ExisteItem)
            {
                MessageBox.Show("Nenhum item Encontrado", "`Busca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AtualizaGrid();
            }
            txtBusca.Clear();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            LerTexto();
            LimpaCampos();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            Estoque itemAlterado = new Estoque();
            itemAlterado.Nome = CbAlterar.Text.Trim();
            itemAlterado.Disponivel = Nud1.Text.Trim();
            itemAlterado.Manutencao = Nud2.Text.Trim();
            itemAlterado.Local = txtLocalA.Text.Trim();
            itemAlterado.Fornecedor = txtFornecedor.Text.Trim();
            itemAlterado.Data = DateTime.Now.ToShortDateString();
            Estoque itemAnterior = ExcluiItem(itemAlterado); // O Item retornado pelo metodo serve para atribuir o lacal do item automaticamenta, mais explicação a seguir

            if (itemAnterior == null) //Se o item a ser excluido não for encontrado, ele retorna nulo
            {
                return;
            }

            lista.Add(itemAlterado);
            SalvaLista();
            int qtdAntes = Convert.ToInt32(itemAnterior.Disponivel);
            int qtdDepois = Convert.ToInt32(itemAlterado.Disponivel);
            int qtdMaAntes = Convert.ToInt32(itemAnterior.Manutencao);
            int qtdMaDepois = Convert.ToInt32(itemAlterado.Manutencao);
            if (qtdDepois < qtdAntes)
            {
                itemAlterado.Disponivel = (qtdAntes - qtdDepois).ToString();
                itemAlterado.Manutencao = "0";
                ConfirmaDestino(itemAlterado);
            }
            if (qtdMaDepois < qtdMaAntes)
            {
                itemAlterado.Manutencao = (qtdMaAntes - qtdMaDepois).ToString();
                itemAlterado.Disponivel = "0";
                ConfirmaDestino(itemAlterado);
            }
            else
            {
                MessageBox.Show("Ação concluida com sucesso ", "Ação concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            itemAlterado.Disponivel = qtdDepois.ToString();
            itemAlterado.Manutencao = qtdMaDepois.ToString();
            LimpaCampos();

        }

        private void BtnExclui_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Certeza que deseja exclui o Item?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                Estoque excluir = new Estoque();
                excluir.Nome = CbAlterar.Text.Trim();
                excluir = ExcluiItem(excluir); // O metodo tem retorno para outras funções
                if (excluir != null)
                {
                    LimpaCampos();
                    ConfirmaDestino(excluir);
                    MessageBox.Show("Ação concluida com sucesso ", "Ação concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Estoque cadastra = new Estoque();
            cadastra.Nome = CbAlterar.Text.Trim();
            cadastra.Disponivel = Nud1.Text.Trim();
            cadastra.Manutencao = Nud2.Text.Trim();
            cadastra.Local = txtLocalA.Text.Trim();
            cadastra.Fornecedor = txtFornecedor.Text.Trim();
            cadastra.Data = DateTime.Now.ToShortDateString();
            lista.Add(cadastra);
            SalvaLista();
            LimpaCampos();
            MessageBox.Show("Cadastrado com sucesso", "Ação concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LerTexto()
        {
            lista.Clear();
            using (StreamReader sr = new StreamReader("estoque.txt"))
            {
                string linha = string.Empty;
                int contador = 0;

                while ((linha = sr.ReadLine()) != null)
                {
                    string[] split = new string[6];
                    Estoque a = new Estoque();
                    split = linha.Split('|');
                    a.Nome = split[0];
                    a.Disponivel = split[1];
                    a.Manutencao = split[2];
                    a.Local = split[3];
                    a.Data = split[4];
                    a.Fornecedor = split[5];

                    lista.Add(a);
                    contador++;
                }
            }
            AtualizaGrid();
        }

        public void AtualizaGrid()
        {
            int pos = 0;

            gridLista = dgvLista;// Atribui o elemento da tela
            this.dgvLista.DefaultCellStyle.Font = new Font("Tahoma", 11);
            gridLista.Rows.Clear();
            gridLista.Columns.Clear();
            gridLista.Columns.Add("Item", "Item"); //nome das colunas
            gridLista.Columns.Add("Disponivel", "Disponivel");
            gridLista.Columns.Add("Manutenção", "Manutenção");
            gridLista.Columns.Add("Local", "Local");
            gridLista.Columns.Add("Data", "Data");
            gridLista.Columns.Add("Observação", "Observação");

            gridLista.Columns[0].Width = 200; //tamanho das colunas
            gridLista.Columns[1].Width = 90;
            gridLista.Columns[2].Width = 90;
            gridLista.Columns[3].Width = 200;
            gridLista.Columns[4].Width = 90;

            foreach (Estoque a in lista)
            {
                gridLista.Rows.Add();
                gridLista.Rows[pos].Cells[0].Value = a.Nome;
                gridLista.Rows[pos].Cells[1].Value = a.Disponivel;
                gridLista.Rows[pos].Cells[2].Value = a.Manutencao;
                gridLista.Rows[pos].Cells[3].Value = a.Local;
                gridLista.Rows[pos].Cells[4].Value = a.Data;
                gridLista.Rows[pos].Cells[5].Value = a.Fornecedor;
                pos++;
            }
        }

        public Estoque ExcluiItem(Estoque a)
        {
            Estoque Removido = a;
            bool ExisteItem = false;
            foreach (Estoque b in lista)
            {
                if (a.Nome.ToUpper() == b.Nome.ToUpper())
                {
                    lista.Remove(b);
                    ExisteItem = true;
                    Removido = b;
                    break;
                }
            }
            if (!ExisteItem)
            {
                MessageBox.Show("item Não Encontrado", "`Busca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AtualizaGrid();
                return null;
            }
            else
            {
                SalvaLista();
            }
            return Removido;
        }

        public void SalvaLista()
        {
            List<string> ListaTexo = new List<string>();
            foreach (Estoque b in lista)
            {
                ListaTexo.Add(b.Nome + '|' + b.Disponivel + '|' + b.Manutencao + '|' + b.Local + '|' + b.Data + '|' + b.Fornecedor);
            }
            System.IO.File.WriteAllLines(@"estoque.txt", ListaTexo);
            AtualizaGrid();
        }

        public void LimpaCampos()
        {
            CbAlterar.Text = "";
            txtBusca.Clear();
            txtLocalA.Clear();
            txtFornecedor.Clear();
            Nud1.Text = "0";
            Nud2.Text = "0";
            CbAlterar.Items.Clear();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLista.CurrentRow.Selected = true;
            CbAlterar.Text = dgvLista.CurrentRow.Cells[0].Value.ToString();
            Nud1.Text = dgvLista.CurrentRow.Cells[1].Value.ToString();
            Nud2.Text = dgvLista.CurrentRow.Cells[2].Value.ToString();
            txtLocalA.Text = dgvLista.CurrentRow.Cells[3].Value.ToString();
            txtFornecedor.Text = dgvLista.CurrentRow.Cells[5].Value.ToString();
        }

        public void ConfirmaDestino(Estoque i)
        {
            TelaConfirmacao form = new TelaConfirmacao(i);
            form.ShowDialog();
        }
    }
}

